using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Functional.Fluent
{
    public class TypeMatcher<TU> : IEnumerable<TU>
    {
        private readonly List<Tuple<Expression, Expression>> list = new List<Tuple<Expression, Expression>>();

        public void Add<TZ>(Expression<Func<object, TZ>> predicate, Expression<Func<TZ, TU>> func)
        {
            list.Add(Tuple.Create((Expression)predicate, (Expression)func));
        }

        public TU Match(object value)
        {
            foreach (var item in list)
            {
                var predicate = item.Item1 as LambdaExpression;
                var type = predicate.ReturnType;
                if (type.IsInstanceOfType(value))
                {
                    var expression = item.Item2 as LambdaExpression;
                    var func = expression.Compile();
                    return (TU) func.DynamicInvoke(value);
                }
            }

            return default(TU);
        }


        public static implicit operator Func<object, TU>(TypeMatcher<TU> matcher)
        {
            return matcher.Match;
        }

        public Func<object, TU> ToFunc()
        {
            return Match;
        }

        public IEnumerator<TU> GetEnumerator()
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class MaybeTypeMatcher<TV, TU> : TypeMatcher<TU>
    {
        private Maybe<TV> contextValue;

        public MaybeTypeMatcher(Maybe<TV> contextValue )
        {
            this.contextValue = contextValue;
        }

        public MaybeTypeMatcher<TV, TU> With<TZ>(Expression<Func<object, TZ>> predicate, Expression<Func<TZ, TU>> func)
        {
            Add(predicate, func);
            return this;
        }

        public MaybeTypeMatcher<TV, TU> Else(Expression<Func<object, TU>> func)
        {
            Add(Case.Is<object>(), func);
            return this;
        }

        public TU Do()
        {
            return Match(contextValue.Value);
        }
    }

    public class Case
    {
        public static Expression<Func<object, T>> Is<T>()
            where T : class
        {
            return v => v as T;
        }
    }
}
