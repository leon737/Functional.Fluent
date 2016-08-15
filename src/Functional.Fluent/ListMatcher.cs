using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Fluent
{
    public class ListMatcher<TV, TU> : Matcher<IEnumerable<TV>, TU>
    {
        public ListMatcher() : base() { }

        public ListMatcher(MonadicValue<IEnumerable<TV>> contextValue) : base(contextValue) {  }

        public void Add(Func<TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(x => x != null && x.Any(), v => func(v.First(), v.Skip(1))));
        }

        public void Add(Predicate<TV> predicate, Func<TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(x => x != null && x.Any() && predicate(x.First()), 
                v => func(v.First(), v.Skip(1))));
        }

        public ListMatcher<TV, TU> With(Func<TV, IEnumerable<TV>, TU> func)
        {
            Add(func);
            return this;
        }

        public ListMatcher<TV, TU> With(Predicate<TV> predicate, Func<TV, IEnumerable<TV>, TU> func)
        {
            Add(predicate, func);
            return this;
        }

        public ListMatcher<TV, TU> Empty(Func<TU> func)
        {
            Add(x => true, _ => func());
            return this;
        }
    }
}
