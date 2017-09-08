using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace Functional.Fluent.Pattern
{
    public class TypeMatcher<TU> : IEnumerable<TU>
    {
        private readonly List<Tuple<Expression, Expression, Expression>> list = new List<Tuple<Expression, Expression, Expression>>();

        protected Expression elseExpression = null;

        public void Add<TZ>(Expression<Func<object, TZ>> predicate, Expression<Func<TZ, TU>> func)
        {
            list.Add(Tuple.Create((Expression)predicate, (Expression)null, (Expression)func));
        }

        public void Add<TZ>(Expression<Func<object, TZ>> predicate, Expression<Func<TZ, bool>> whenPredicate, Expression<Func<TZ, TU>> func)
        {
            list.Add(Tuple.Create((Expression)predicate, (Expression)whenPredicate, (Expression)func));
        }

        public void Add<TZ, TE>(Expression<Func<object, TZ>> predicate, Expression<Func<TZ, bool>> whenPredicate, TE exception) where TE : Exception
        {
            list.Add(Tuple.Create((Expression)predicate, (Expression)whenPredicate, BuildThrowExpression(exception)));
        }

        public void Add<TZ, TE>(Expression<Func<object, TZ>> predicate, TE exception) where TE : Exception
        {
            list.Add(Tuple.Create((Expression)predicate, (Expression)null, BuildThrowExpression(exception)));
        }

        protected Expression BuildThrowExpression(Exception exception) => Expression.Throw(Expression.Constant(exception));


        public TU Match(object value)
        {
            foreach (var item in list)
            {
                var predicate = item.Item1 as LambdaExpression;
                var type = predicate.ReturnType;
                if (type.IsInstanceOfType(value))
                {
                    bool matched = false;
                    if (item.Item2 != null)
                    {
                        var whenPredicate = item.Item2 as LambdaExpression;
                        var func = whenPredicate.Compile();
                        matched = (bool)func.DynamicInvoke(value);
                    }
                    else matched = true;
                    if (matched)
                    {
                        return ExecuteExpression(item.Item3, value);
                    }
                }
            }

            if (elseExpression != null)
            {
                return ExecuteExpression(elseExpression, value);
            }

            return default(TU);
        }

        private TU ExecuteExpression(Expression expression, object value)
        {
            var lambdaExpression = expression as LambdaExpression;
            if (lambdaExpression != null)
            {
                var func = lambdaExpression.Compile();
                try
                {
                    return (TU) func.DynamicInvoke(value);
                }
                catch (TargetInvocationException ex)
                {
                    if (ex.InnerException != null)
                        throw ex.InnerException;
                    throw;
                }
            }
            var unaryExpression = expression as UnaryExpression;
            if (unaryExpression?.NodeType == ExpressionType.Throw)
            {
                throw (Exception)((ConstantExpression)unaryExpression.Operand).Value;
            }
            throw new InvalidOperationException();
        }


        public static implicit operator Func<object, TU>(TypeMatcher<TU> matcher) => matcher.Match;

        public Func<object, TU> ToFunc() => Match;

        public IEnumerator<TU> GetEnumerator()
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
