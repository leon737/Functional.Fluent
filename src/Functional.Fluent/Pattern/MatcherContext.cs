using System;
using System.Collections.Generic;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Pattern
{
    public class MatcherContext<TV>
    {
        protected MonadicValue<TV> contextValue;

        public MatcherContext(MonadicValue<TV> contextValue)
        {
            this.contextValue = contextValue;
        }

        public Matcher<TV, TU> With<TU>(Predicate<TV> predicate, Func<TV, TU> func) =>
            new Matcher<TV, TU>(contextValue) { { predicate, func } };

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

        public PartiaMatcher<TV, TU, T1> Partial<TU, T1>(Func<T1, TV, bool> func) =>
            new PartiaMatcher<TV, TU, T1>(contextValue, func);

        public PartiaMatcher<TV, TU, T1> Partial<TU, T1>(Func<T1, TV, bool> func, T1 value, Func<TV, TU> result) =>
            new PartiaMatcher<TV, TU, T1>(contextValue, func).With(value, result);

        public PartiaMatcher<TV, TU, T1> Partial<TU, T1>(Func<T1, TV, bool> func, T1 value, TU result) =>
            new PartiaMatcher<TV, TU, T1>(contextValue, func).With(value, result);

        public PartiaMatcher<TV, TU, T1, T2> Partial<TU, T1, T2>(Func<T1, T2, TV, bool> func) =>
            new PartiaMatcher<TV, TU, T1, T2>(contextValue, func);

        public PartiaMatcher<TV, TU, T1, T2> Partial<TU, T1, T2>(Func<T1, T2, TV, bool> func, T1 value, T2 value2, Func<TV, TU> result) =>
            new PartiaMatcher<TV, TU, T1, T2>(contextValue, func).With(value, value2, result);

        public PartiaMatcher<TV, TU, T1, T2> Partial<TU, T1, T2>(Func<T1, T2, TV, bool> func, T1 value, T2 value2, TU result) =>
            new PartiaMatcher<TV, TU, T1, T2>(contextValue, func).With(value, value2, result);

        public PartiaMatcher<TV, TU, T1, T2, T3> Partial<TU, T1, T2, T3>(Func<T1, T2, T3, TV, bool> func) =>
            new PartiaMatcher<TV, TU, T1, T2, T3>(contextValue, func);

        public PartiaMatcher<TV, TU, T1, T2, T3> Partial<TU, T1, T2, T3>(Func<T1, T2, T3, TV, bool> func, T1 value, T2 value2, T3 value3, Func<TV, TU> result) =>
            new PartiaMatcher<TV, TU, T1, T2, T3>(contextValue, func).With(value, value2, value3, result);

        public PartiaMatcher<TV, TU, T1, T2, T3> Partial<TU, T1, T2, T3>(Func<T1, T2, T3, TV, bool> func, T1 value, T2 value2, T3 value3, TU result) =>
            new PartiaMatcher<TV, TU, T1, T2, T3>(contextValue, func).With(value, value2, value3, result);
    }
}
