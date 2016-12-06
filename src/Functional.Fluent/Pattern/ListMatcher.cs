using System;
using System.Collections.Generic;
using System.Linq;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Pattern
{
    public partial class ListMatcher<TV, TU> : Matcher<IEnumerable<TV>, TU>
    {
        public ListMatcher() : base() { }

        public ListMatcher(MonadicValue<IEnumerable<TV>> contextValue) : base(contextValue) {  }

        public void Add(Func<TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(x => x != null && x.Any(), 
                v => func(v.First(), v.Skip(1))));
        }
        
        public void Add(Predicate<TV> predicate, Func<TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(
                x => x != null && x.Any() && predicate(x.First()), 
                v => func(v.First(), v.Skip(1))));
        }

        public ListMatcher<TV, TU> With(Func<TV, IEnumerable<TV>, TU> func)
        {
            Add(func);
            return this;
        }

        public ListMatcher<TV, TU> With(TU returnValue)
        {
            Add((_, __) => returnValue);
            return this;
        }

        public ListMatcher<TV, TU> With(Predicate<TV> predicate, Func<TV, IEnumerable<TV>, TU> func)
        {
            Add(predicate, func);
            return this;
        }

        public ListMatcher<TV, TU> With(Predicate<TV> predicate, TU returnValue)
        {
            Add(predicate, (_, __) => returnValue);
            return this;
        }

        public ListMatcher<TV, TU> Empty(Func<TU> func)
        {
            Add(x => true, _ => func(), false);
            return this;
        }

        public ListMatcher<TV, TU> Empty(TU returnValue)
        {
            Add(x => true, _ => returnValue, false);
            return this;
        }
    }
}
