using System;
using System.Collections.Generic;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Pattern
{
    public partial class ListMatcherContext<TV> : MatcherContext<IEnumerable<TV>>
    {
        public ListMatcherContext(MonadicValue<IEnumerable<TV>> contextValue) : base(contextValue) { }

        public ListMatcher<TV, TU> With<TU>(Func<TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { func } };

        public ListMatcher<TV, TU> With<TU>(TU returnValue) =>
            new ListMatcher<TV, TU>(contextValue) { { (_, __) => returnValue } };

        public ListMatcher<TV, TU> With<TU>(Predicate<TV> predicate, Func<TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { predicate, func } };

        public ListMatcher<TV, TU> With<TU>(Predicate<TV> predicate, TU returnValue) =>
            new ListMatcher<TV, TU>(contextValue) { { predicate, (_, __) => returnValue } };
    }
}
