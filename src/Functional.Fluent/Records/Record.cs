using System;

namespace Functional.Fluent.Records
{
    public abstract class Record<T>
    {
        protected readonly Func<Record<T>, int> _GetHashCodeFunc;

        protected readonly Func<Record<T>, Record<T>, bool> _EqualityFunc;

        protected readonly Func<Record<T>, string> _ToStringFunc;

        protected readonly Func<Record<T>, Record<T>, T> _MergeFunc;

        protected Record()
        {
            _GetHashCodeFunc = RecordHelper<T>.ComposeGetHashCodeFunc();
            _EqualityFunc = RecordHelper<T>.ComposeEqualityFunc();
            _ToStringFunc = RecordHelper<T>.ComposeToStringFunc();
            _MergeFunc = RecordHelper<T>.ComposeMergeFunc();
        }

        public override int GetHashCode() => _GetHashCodeFunc(this);

        public override bool Equals(object obj)
        {
            var other = obj as Record<T>;
            return other != null && _EqualityFunc(this, other);
        }

        public override string ToString() => _ToStringFunc(this);

        public T Merge(Record<T> other) => _MergeFunc(this, other);
    }
}