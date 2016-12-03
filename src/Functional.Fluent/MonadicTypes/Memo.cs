using System;

namespace Functional.Fluent.MonadicTypes
{
    public class Memo<T, V> : MonadicValue<V>
    {

        protected T _memo;

        internal T MemoValue => _memo;

        private Memo(T memo, V value) : base(value)
        {
            _memo = memo;
        }

        internal Memo(MemoBuilder<T> builder, Func<T, V> func) : base(func(builder.Value))
        {
            _memo = builder.Value;
        }

        internal Memo<T, R> ApplyFunc<R>(Func<T, V, R> func) => new Memo<T, R>(_memo, func(_memo, Value));
    }
}