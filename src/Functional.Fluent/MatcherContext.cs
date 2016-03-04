using System;
using System.Collections.Generic;

namespace Functional.Fluent
{
    public class MatcherContext<TV>
    {

        private Maybe<TV> contextValue;

        public MatcherContext(Maybe<TV> contextValue )
        {
            this.contextValue = contextValue;
        }

        public Matcher<TV, TU> With<TU>(Predicate<TV> predicate, Func<TV, TU> func)
        {
            return new Matcher<TV, TU>(contextValue) {{predicate, func}};
        }

        public Matcher<TV, TU> With<TU>(TV value, Func<TV, TU> func)
        {
            return new Matcher<TV, TU>(contextValue) { { value, func } };
        }

        public Matcher<TV, TU> With<TU>(IEnumerable<TV> values, Func<TV, TU> func)
        {
            return new Matcher<TV, TU>(contextValue) { { values, func } };
        }

    }
}
