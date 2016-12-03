using System;
using System.Linq.Expressions;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Pattern
{
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

        public MaybeTypeMatcher<TV, TU> With<TZ>(Expression<Func<object, TZ>> predicate, TU returnValue)
        {
            Add(predicate, _ => returnValue);
            return this;
        }

        public MaybeTypeMatcher<TV, TU> With<TZ>(Expression<Func<object, TZ>> predicate, Expression<Func<TZ, bool>> whenPredicate, Expression<Func<TZ, TU>> func)
        {
            Add(predicate, whenPredicate, func);
            return this;
        }

        public MaybeTypeMatcher<TV, TU> With<TZ>(Expression<Func<object, TZ>> predicate, Expression<Func<TZ, bool>> whenPredicate, TU returnValue)
        {
            Add(predicate, whenPredicate, _ => returnValue);
            return this;
        }

        public MaybeTypeMatcher<TV, TU> Else(Expression<Func<TV, TU>> func)
        {
            elseExpression = func;
            return this;
        }

        public MaybeTypeMatcher<TV, TU> Else(TU returnValue)
        {
            elseExpression = (Expression< Func<TV,TU>>)(_ => returnValue);
            return this;
        }

        public TU Do() => Match(contextValue.Value);
    }
}