using System;
using Functional.Fluent.Extensions;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Pattern
{
    public partial class PartiaMatcher<TV, TU, T1> : Matcher<TV, TU>
    {
        private readonly Func<T1, TV, bool> _func;

        public PartiaMatcher(MonadicValue<TV> contextValue, Func<T1, TV, bool> func) : base(contextValue)
        {
            _func = func;
        }

        public PartiaMatcher<TV, TU, T1> With(T1 value, Func<TV, TU> func)
        {
            Add(new Predicate<TV>(_func.Partial(value)), func);
            return this;
        }

        public PartiaMatcher<TV, TU, T1> With(T1 value, TU resultValue)
        {
            Add(new Predicate<TV>(_func.Partial(value)), _ => resultValue);
            return this;
        }
    }

    public class PartiaMatcher<TV, TU, T1, T2> : Matcher<TV, TU>
    {
        private readonly Func<T1, T2, TV, bool> _func;

        public PartiaMatcher(TV contextValue, Func<T1, T2, TV, bool> func) : base(contextValue)
        {
            _func = func;
        }

        public PartiaMatcher<TV, TU, T1, T2> With(T1 value, T2 value2, Func<TV, TU> func)
        {
            Add(new Predicate<TV>(_func.Partial(value).Partial(value2)), func);
            return this;
        }

        public PartiaMatcher<TV, TU, T1, T2> With(T1 value, T2 value2, TU resultValue)
        {
            Add(new Predicate<TV>(_func.Partial(value).Partial(value2)), _ => resultValue);
            return this;
        }
    }

    public class PartiaMatcher<TV, TU, T1, T2, T3> : Matcher<TV, TU>
    {
        private readonly Func<T1, T2, T3, TV, bool> _func;

        public PartiaMatcher(TV contextValue, Func<T1, T2, T3, TV, bool> func) : base(contextValue)
        {
            _func = func;
        }

        public PartiaMatcher<TV, TU, T1, T2, T3> With(T1 value, T2 value2, T3 value3, Func<TV, TU> func)
        {
            Add(new Predicate<TV>(_func.Partial(value).Partial(value2).Partial(value3)), func);
            return this;
        }

        public PartiaMatcher<TV, TU, T1, T2, T3> With(T1 value, T2 value2, T3 value3, TU resultValue)
        {
            Add(new Predicate<TV>(_func.Partial(value).Partial(value2).Partial(value3)), _ => resultValue);
            return this;
        }
    }
}