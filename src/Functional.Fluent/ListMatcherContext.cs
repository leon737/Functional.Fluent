using System;
using System.Collections.Generic;

namespace Functional.Fluent
{
    public class ListMatcherContext<TV> : MatcherContext<IEnumerable<TV>>
    {
        public ListMatcherContext(Maybe<IEnumerable<TV>> contextValue) : base(contextValue) { }

        public ListMatcher<TV, TU> With<TU>(Func<TV, IEnumerable<TV>, TU> func)
        {
            return new ListMatcher<TV, TU>(contextValue) { { func } };
        }

        public ListMatcher<TV, TU> With<TU>(Predicate<TV> predicate, Func<TV, IEnumerable<TV>, TU> func)
        {
            return new ListMatcher<TV, TU>(contextValue) { { predicate, func } };
        }
    }
}
