using System;
using System.Collections.Generic;

namespace Functional.Fluent.MonadicTypes
{
    public class MaybeEnumerableApplicator<T, V> : MaybeEnumerable<V>
    {
        protected readonly Func<T, V> applicator;
        protected readonly Func<V> failure;
        protected readonly MaybeEnumerable<T> list;
    
        internal MaybeEnumerableApplicator(MaybeEnumerable<T> list, Func<T, V> applicator)
        {
            this.list = list;
            HasValue = true;
            this.applicator = applicator;
        }

        internal MaybeEnumerableApplicator(MaybeEnumerable<T> list, Func<T, V> applicator, Func<V> failure )
        {
            this.list = list;
            HasValue = true;
            this.applicator = applicator;
            this.failure = failure;
        }

        public override IEnumerable<Maybe<V>> Value
        {
            get
            {
                if (HasValue)
                    foreach (var e in list)
                        if (e.HasValue)
                            yield return new Maybe<V>(applicator(e.Value));
                        else 
                            if (failure != null)
                                yield return new Maybe<V>(failure());
            }
        }

        public override IEnumerator<Maybe<V>> GetEnumerator()
        {
            return Value.GetEnumerator();
        }
    }
}