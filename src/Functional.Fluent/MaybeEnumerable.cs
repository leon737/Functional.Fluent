using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Fluent
{
    public class MaybeEnumerable<T> : Maybe<IEnumerable<Maybe<T>>>, IEnumerable<Maybe<T>>
    {

        public readonly static MaybeEnumerable<T> Empty = new MaybeEnumerable<T>();

        internal MaybeEnumerable()
        {
            HasValue = false;
        }

        public MaybeEnumerable(IEnumerable<Maybe<T>> value)
        {
            Value = value;
            HasValue = value != null;
        }

        public MaybeEnumerable(IEnumerable<T> value)
        {
            Value = value.Select(v => new Maybe<T>(v));
            HasValue = value != null;
        }

        public MaybeEnumerable(T value)
        {
            Value = new[] { new Maybe<T>(value) };
            HasValue = value != null;
        }

        public virtual IEnumerator<Maybe<T>> GetEnumerator()
        {
            if (HasValue)
                foreach (var e in Value)
                    yield return e;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal MaybeEnumerableApplicator<T, T> ToApplicator()
        {
            return new MaybeEnumerableApplicator<T, T>(this, v => v);
        }

    }
}