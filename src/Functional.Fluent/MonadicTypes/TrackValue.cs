using System;
using System.Collections.Generic;

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

        public bool HasChanges { get; protected set; }

        public TrackValue(T value) : this(value, value, new DefaultValueTracker<T>(), false) { }

        public TrackValue(T value, ValueTrackerTypes valueTrackerType) : this(value, value, CreateValueTracker(valueTrackerType), false) { }

        private static IValueTracker<T> CreateValueTracker(ValueTrackerTypes valueTrackerType)
        {
            switch (valueTrackerType)
            {
                case ValueTrackerTypes.Default:
                    return new DefaultValueTracker<T>();
                case ValueTrackerTypes.Equality:
                    return new EqualityValueTracker<T>();
                case ValueTrackerTypes.DeepEquality:
                    return new DeepEqualityValueTracker<T>();
                case ValueTrackerTypes.Interceptor:
                default:
                    throw new NotSupportedException();
            }
        }

        internal TrackValue(T originalValue, T modifiedValue, IValueTracker<T> valueTracker, bool trackChanges) : base(modifiedValue)
        {
            ValueTracker = valueTracker;
            HasChanges = trackChanges && ValueTracker.HasChanges(originalValue, modifiedValue);
        }
    }

    internal interface IValueTracker<in T>
    {
        bool HasChanges(T originalValue, T modifiedValue);
    }

    internal class DefaultValueTracker<T> : IValueTracker<T>
    {
        public bool HasChanges(T originalValue, T modifiedValue) => true;
    }

    internal class EqualityValueTracker<T> : IValueTracker<T>
    {
        public bool HasChanges(T originalValue, T modifiedValue) => !EqualityComparer<T>.Default.Equals(originalValue, modifiedValue);
    }

    internal class DeepEqualityValueTracker<T> : IValueTracker<T>
    {
        public bool HasChanges(T originalValue, T modifiedValue)
        {
            throw new NotSupportedException();
        }
    }
}