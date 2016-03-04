using System;
using System.Linq.Expressions;

namespace Functional.Fluent
{
    public class TypeMatcherContext<TV>
    {

        private Maybe<TV> contextValue;

        public TypeMatcherContext(Maybe<TV> contextValue)
        {
            this.contextValue = contextValue;
        }
        public MaybeTypeMatcher<TV, TU> With<TU, TZ>(Expression<Func<object, TZ>> predicate, Expression<Func<TZ, TU>> func)
        {
            return new MaybeTypeMatcher<TV, TU> (contextValue) { { predicate, func } };
        }
    }
}
