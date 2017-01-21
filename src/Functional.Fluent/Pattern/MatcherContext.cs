using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Pattern
{
    public partial class MatcherContext<TV>
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

        public MatcherMemberAccessor<TV, TC, TM> Member<TC, TM>(Predicate<TV> predicate,
                Expression<Func<TC, TM>> expression) =>
            new MatcherMemberAccessor<TV, TC, TM>(contextValue)
            {
                {predicate, _ => new MemberAccessor<TC, TM>(expression)}
            };

        public Matcher<TV, TU> WithThrow<TU, TE>(Predicate<TV> predicate) where TE : Exception, new() =>
            With<TU>(predicate, _ =>
            {
                throw new TE();
            });

        public Matcher<TV, TU> WithThrow<TU, TE>(Predicate<TV> predicate, TE exception) where TE : Exception =>
            With<TU>(predicate, _ =>
            {
                throw exception;
            });

        public Matcher<TV, TU> With<TU>(TV value, Func<TV, TU> func) =>
            new Matcher<TV, TU>(contextValue) { { value, func } };

        public Matcher<TV, TU> With<TU>(TV value, TU resultValue) =>
            With(value, _ => resultValue);

        public MatcherMemberAccessor<TV, TC, TM> Member<TC, TM>(TV value, Expression<Func<TC, TM>> expression) =>
            new MatcherMemberAccessor<TV, TC, TM>(contextValue) { { value, _ => new MemberAccessor<TC, TM>(expression) } };

        public Matcher<TV, TU> WithThrow<TU, TE>(TV value) where TE : Exception, new() =>
            With<TU>(value, _ =>
            {
                throw new TE();
            });

        public Matcher<TV, TU> WithThrow<TU, TE>(TV value, TE exception) where TE : Exception =>
            With<TU>(value, _ =>
            {
                throw exception;
            });
        
        public Matcher<TV, TU> With<TU>(IEnumerable<TV> values, Func<TV, TU> func) =>
            new Matcher<TV, TU>(contextValue) { { values, func } };

        public Matcher<TV, TU> With<TU>(IEnumerable<TV> values, TU resultValue) =>
            With(values, _ => resultValue);

        public MatcherMemberAccessor<TV, TC, TM> Member<TC, TM>(IEnumerable<TV> values, Expression<Func<TC, TM>> expression) =>
           new MatcherMemberAccessor<TV, TC, TM>(contextValue) { { values, _ => new MemberAccessor<TC, TM>(expression) } };

        public Matcher<TV, TU> WithThrow<TU, TE>(IEnumerable<TV> values) where TE : Exception, new() =>
            With<TU>(values, _ =>
            {
                throw new TE();
            });

        public Matcher<TV, TU> WithThrow<TU, TE>(IEnumerable<TV> values, TE exception) where TE : Exception =>
            With<TU>(values, _ =>
            {
                throw exception;
            });

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
