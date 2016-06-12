using System;
using System.Collections.Generic;

namespace Functional.Fluent
{
    public class MatcherContext<TV>
    {
        protected Maybe<TV> contextValue;

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

        public Matcher<TV, TU> With<TU>(TV value, TV value2, Func<TV, TU> func)
        {
            return new Matcher<TV, TU>(contextValue) { { new[] { value, value2 }, func } };
        }

        public Matcher<TV, TU> With<TU>(TV value, TV value2, TV value3, Func<TV, TU> func)
        {
            return new Matcher<TV, TU>(contextValue) { { new[] { value, value2, value3 }, func } };
        }

        public Matcher<TV, TU> With<TU>(TV value, TV value2, TV value3, TV value4, Func<TV, TU> func)
        {
            return new Matcher<TV, TU>(contextValue) { { new[] { value, value2, value3, value4 }, func } };
        }

        public Matcher<TV, TU> With<TU>(TV value, TV value2, TV value3, TV value4, TV value5, Func<TV, TU> func)
        {
            return new Matcher<TV, TU>(contextValue) { { new[] { value, value2, value3, value4, value5 }, func } };
        }

        public Matcher<TV, TU> With<TU>(IEnumerable<TV> values, Func<TV, TU> func)
        {
            return new Matcher<TV, TU>(contextValue) { { values, func } };
        }
    }
}
