using System;

namespace Functional.Fluent.MonadicTypes
{

    public enum ValueTrackerTypes
    {
        Default,
        Equality,
        DeepEquality,
        Interceptor
    }


    public class TrackValue<T> : MonadicValue<T>
    {
        internal IValueTracker<T> ValueTracker;

        internal int ValueHashCode;

        public bool HasChanges { get; protected set; }

        public TrackValue(T value) : this(value, value, new DefaultValueTracker<T>(), 0, false) { }

        public TrackValue(T value, ValueTrackerTypes valueTrackerType) : this(value, value, CreateValueTracker(valueTrackerType), 0, false) { }

        private static IValueTracker<T> CreateValueTracker(ValueTrackerTypes valueTrackerType)
        {
            switch (valueTrackerType)
            {
                case ValueTrackerTypes.Default:
                    return new DefaultValueTracker<T>();
                case ValueTrackerTypes.Equality:
                    return new EqualityValueTracker<T>();
                case ValueTrackerTypes.DeepEquality:
                case ValueTrackerTypes.Interceptor:
                default:
                    throw new NotSupportedException();
            }
        }

        internal TrackValue(T originalValue, T modifiedValue, IValueTracker<T> valueTracker, int originalHashCode, bool trackChanges) : base(modifiedValue)
        {
            ValueHashCode = modifiedValue.GetHashCode();
            ValueTracker = valueTracker;
            HasChanges = trackChanges && ValueTracker.HasChanges(originalValue, modifiedValue, originalHashCode);
        }
    }

    internal interface IValueTracker<in T>
    {
        bool HasChanges(T originalValue, T modifiedValue, int originalHashCode);
    }

    internal class DefaultValueTracker<T> : IValueTracker<T>
    {
        public bool HasChanges(T originalValue, T modifiedValue, int originalHashCode) => true;
    }

    internal class EqualityValueTracker<T> : IValueTracker<T>
    {
        public bool HasChanges(T originalValue, T modifiedValue, int originalHashCode) => !originalValue.Equals(modifiedValue) || originalHashCode != modifiedValue.GetHashCode();
    }
}