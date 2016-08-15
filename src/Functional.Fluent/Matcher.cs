using System;
using System.Collections;
using System.Collections.Generic;

namespace Functional.Fluent
{
    public class Matcher<TV, TU> : IEnumerable<TU>
    {
        protected readonly List<Tuple<Predicate<TV>, Func<TV, TU>>>  list = new List<Tuple<Predicate<TV>, Func<TV, TU>>>();

        protected MonadicValue<TV> contextValue;

        public Matcher()
        {
            contextValue = null;
        }

        public Matcher(MonadicValue<TV> contextValue )
        {
            this.contextValue = contextValue;
        }

        public void Add(Predicate<TV> predicate, Func<TV, TU> func)
        {
            list.Add(Tuple.Create(predicate, func));
        }

        public void Add(TV value, Func<TV, TU> func)
        {
            Predicate<TV> predicate = x => x.Equals(value);
            list.Add(Tuple.Create(predicate, func));
        }

        public void Add(IEnumerable<TV> values, Func<TV, TU> func)
        {
            foreach (var value in values)
            {
                TV local = value;
                Predicate<TV> predicate = x => x.Equals(local);
                list.Add(Tuple.Create(predicate, func));    
            }
        }

        public Matcher<TV, TU> With(Predicate<TV> predicate, Func<TV, TU> func)
        {
            Add(predicate, func);
            return this;
        }

        public Matcher<TV, TU> With(TV value, Func<TV, TU> func)
        {
            Add(value, func);
            return this;
        }

        public Matcher<TV, TU> With(TV value, TV value2, Func<TV, TU> func)
        {
            Add(new[] { value, value2 }, func);
            return this;
        }

        public Matcher<TV, TU> With(TV value, TV value2, TV value3, Func<TV, TU> func)
        {
            Add(new[] { value, value2, value3 }, func);
            return this;
        }

        public Matcher<TV, TU> With(TV value, TV value2, TV value3, TV value4, Func<TV, TU> func)
        {
            Add(new[] { value, value2, value3, value4 }, func);
            return this;
        }

        public Matcher<TV, TU> With(TV value, TV value2, TV value3, TV value4, TV value5, Func<TV, TU> func)
        {
            Add(new[] { value, value2, value3, value4, value5 }, func);
            return this;
        }

        public Matcher<TV, TU> With(IEnumerable<TV>values , Func<TV, TU> func)
        {
            Add(values, func);
            return this;
        }

        public Matcher<TV, TU> Else(Func<TV, TU> func)
        {
            Add(x => true, func);
            return this;
        }

        public TU Do()
        {
            return Match(contextValue.Value);
        }

        public virtual TU Match(TV value)
        {
            foreach (var item in list)
            {
                if (item.Item1(value))
                    return item.Item2(value);
            }
            return default (TU);
        }

        public static implicit operator Func<TV, TU>(Matcher<TV, TU> matcher)
        {
            return matcher.Match;
        }

        public Func<TV, TU> ToFunc ()
        {
            return Match;
        }

        public IEnumerator<TU> GetEnumerator()
        {
            throw new InvalidOperationException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
