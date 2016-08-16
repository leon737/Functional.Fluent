using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Functional.Fluent
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
                        var expression = item.Item3 as LambdaExpression;
                        var func = expression.Compile();
                        return (TU)func.DynamicInvoke(value);
                    }
                }
            }

            if (elseExpression != null)
            {
                var expression = elseExpression as LambdaExpression;
                var func = expression.Compile();
                return (TU)func.DynamicInvoke(value);
            }

            return default(TU);
        }


        public static implicit operator Func<object, TU>(TypeMatcher<TU> matcher) => matcher.Match;

        public Func<object, TU> ToFunc() => Match;

        public IEnumerator<TU> GetEnumerator()
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class MaybeTypeMatcher<TV, TU> : TypeMatcher<TU>
    {
        private readonly MonadicValue<TV> contextValue;

        public MaybeTypeMatcher(MonadicValue<TV> contextValue )
        {
            this.contextValue = contextValue;
        }

        public MaybeTypeMatcher<TV, TU> With<TZ>(Expression<Func<object, TZ>> predicate, Expression<Func<TZ, TU>> func)
        {
            Add(predicate, func);
            return this;
        }

        public MaybeTypeMatcher<TV, TU> With<TZ>(Expression<Func<object, TZ>> predicate, Expression<Func<TZ, bool>> whenPredicate, Expression<Func<TZ, TU>> func)
        {
            Add(predicate, whenPredicate, func);
            return this;
        }

        public MaybeTypeMatcher<TV, TU> Else(Expression<Func<TV, TU>> func)
        {
            elseExpression = func;
            return this;
        }

        public TU Do() => Match(contextValue.Value);
    }

    public class Case
    {
        public static Expression<Func<object, T>> Is<T>() where T : class => v => v as T;
    }
}
