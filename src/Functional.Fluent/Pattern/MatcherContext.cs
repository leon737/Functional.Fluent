using System;
using System.Collections.Generic;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Pattern
{
    public class MatcherContext<TV>
    {
        protected MonadicValue<TV> contextValue;

        public MatcherContext(MonadicValue<TV> contextValue )
        {
            this.contextValue = contextValue;
        }

        public Matcher<TV, TU> With<TU>(Predicate<TV> predicate, Func<TV, TU> func) => 
            new Matcher<TV, TU>(contextValue) {{predicate, func}};

        public Matcher<TV, TU> With<TU>(Predicate<TV> predicate, TU resultValue) => 
            With(predicate, _ => resultValue);

        public Matcher<TV, TU> With<TU>(TV value, Func<TV, TU> func) => 
            new Matcher<TV, TU>(contextValue) { { value, func } };

        public Matcher<TV, TU> With<TU>(TV value, TU resultValue) =>
            With(value, _ => resultValue);

        public Matcher<TV, TU> With<TU>(TV value, TV value2, Func<TV, TU> func) => 
            new Matcher<TV, TU>(contextValue) { { new[] { value, value2 }, func } };

        public Matcher<TV, TU> With<TU>(TV value, TV value2, TU resultValue) =>
            With(value, value2, _ => resultValue);

        public Matcher<TV, TU> With<TU>(TV value, TV value2, TV value3, Func<TV, TU> func) => 
            new Matcher<TV, TU>(contextValue) { { new[] { value, value2, value3 }, func } };

        public Matcher<TV, TU> With<TU>(TV value, TV value2, TV value3, TU resultValue) =>
            With(value, value2, value3, _ => resultValue);

        public Matcher<TV, TU> With<TU>(TV value, TV value2, TV value3, TV value4, Func<TV, TU> func) => 
            new Matcher<TV, TU>(contextValue) { { new[] { value, value2, value3, value4 }, func } };

        public Matcher<TV, TU> With<TU>(TV value, TV value2, TV value3, TV value4, TU resultValue) =>
            With(value, value2, value3, value4, _ => resultValue);

        public Matcher<TV, TU> With<TU>(TV value, TV value2, TV value3, TV value4, TV value5, Func<TV, TU> func) => 
            new Matcher<TV, TU>(contextValue) { { new[] { value, value2, value3, value4, value5 }, func } };

        public Matcher<TV, TU> With<TU>(TV value, TV value2, TV value3, TV value4, TV value5, TU resultValue) =>
            With(value, value2, value3, value4, value5, _ => resultValue);

        public Matcher<TV, TU> With<TU>(IEnumerable<TV> values, Func<TV, TU> func) => 
            new Matcher<TV, TU>(contextValue) { { values, func } };

        public Matcher<TV, TU> With<TU>(IEnumerable<TV> values, TU resultValue) =>
            With(values, _ => resultValue);
    }
}
