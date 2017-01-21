using System;
using System.Linq.Expressions;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Pattern
{
    public class TypeMatcherContext<TV>
    {
        private readonly MonadicValue<TV> contextValue;

        public TypeMatcherContext(MonadicValue<TV> contextValue)
        {
            this.contextValue = contextValue;
        }

        public MaybeTypeMatcher<TV, TU> With<TU, TZ>(Expression<Func<object, TZ>> predicate, 
            Expression<Func<TZ, TU>> func) => new MaybeTypeMatcher<TV, TU>(contextValue) { { predicate, func } };

        public MaybeTypeMatcher<TV, TU> With<TU, TZ>(Expression<Func<object, TZ>> predicate,
           TU returnValue) => new MaybeTypeMatcher<TV, TU>(contextValue) { { predicate, _ => returnValue } };

        public MaybeTypeMatcher<TV, TU> With<TU, TZ>(Expression<Func<object, TZ>> predicate, 
            Expression<Func<TZ, bool>> whenPredicate, Expression<Func<TZ, TU>> func) =>
            new MaybeTypeMatcher<TV, TU>(contextValue) { { predicate, whenPredicate, func } };

        public MaybeTypeMatcher<TV, TU> With<TU, TZ>(Expression<Func<object, TZ>> predicate,
           Expression<Func<TZ, bool>> whenPredicate, TU returnValue) =>
           new MaybeTypeMatcher<TV, TU>(contextValue) { { predicate, whenPredicate, _ => returnValue } };

        public MaybeTypeMatcher<TV, TU> WithThrow<TU, TZ, TE>(Expression<Func<object, TZ>> predicate) where TE : Exception, new()
            => new MaybeTypeMatcher<TV, TU>(contextValue) { { predicate, new TE() } };

        public MaybeTypeMatcher<TV, TU> WithThrow<TU, TZ, TE>(Expression<Func<object, TZ>> predicate, TE exception)
                where TE : Exception, new()
            => new MaybeTypeMatcher<TV, TU>(contextValue) { { predicate, exception } };

    }
}
