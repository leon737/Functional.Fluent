using System;
using System.Linq.Expressions;

namespace Functional.Fluent
{
    public class TypeMatcherContext<TV>
    {

        private MonadicValue<TV> contextValue;

        public TypeMatcherContext(MonadicValue<TV> contextValue)
        {
            this.contextValue = contextValue;
        }

        public MaybeTypeMatcher<TV, TU> With<TU, TZ>(Expression<Func<object, TZ>> predicate, Expression<Func<TZ, TU>> func)
        {
            return new MaybeTypeMatcher<TV, TU> (contextValue) { { predicate, func } };
        }

        public MaybeTypeMatcher<TV, TU> With<TU, TZ>(Expression<Func<object, TZ>> predicate, Expression<Func<TZ, bool>> whenPredicate, Expression<Func<TZ, TU>> func)
        {
            return new MaybeTypeMatcher<TV, TU>(contextValue) { { predicate, whenPredicate, func } };
        }
    }
}
