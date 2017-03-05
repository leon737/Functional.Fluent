using System;
using System.Collections.Generic;

namespace Functional.Fluent.MonadicTypes
{
    public class BoundType<T>: IBoundType<T>
    {
        private readonly IList<IConstraint<T>> _constraints = new List<IConstraint<T>>();

        public IBoundType<T> Add(IConstraint<T> constraint)
        {
            _constraints.Add(constraint);
            return this;
        }

        public bool Check(T value)
        {
            foreach (var constraint in _constraints)
            {
                if (!constraint.IsValid(value)) return false;
            }
            return true;
        }

        public IBound<T> Create(T value)
        {
            return new Bound<T>(value, this);
        }
    }

    public interface IBoundType<T>
    {
        IBoundType<T> Add(IConstraint<T> constraint);

        bool Check(T value);

        IBound<T> Create(T value);

    }

    public interface IBound<T>
    {
        T Value { get; }
        IBound<T> Set(T value);
    }


    public class Bound<T> : MonadicValue<T>, IBound<T>
    {
        private readonly IBoundType<T> _boundType;

        public Bound(T value, IBoundType<T> boundType)
        {
            _boundType = boundType;
            SetValue(value);
        }

        private void SetValue(T value)
        {
            if (CheckValue(value))
                WrappedValue = value;
            else
                throw new ArgumentOutOfRangeException(nameof(value));
        }

        private bool CheckValue(T value)
        {
            return _boundType.Check(value);
        }

        public new T Value
        {
            get { return WrappedValue; }
        }

        public IBound<T> Set(T value)
        {
           return new Bound<T>(value, _boundType);
        }
    }

    
    public interface IConstraint<in T>
    {
        bool IsValid(T value);
    }

    public class EqualsConstraint<T> : IConstraint<T>
        where T : IEquatable<T>
    {
        private readonly T _value;

        public EqualsConstraint(T value)
        {
            _value = value;
        }
        
        public bool IsValid(T value)
        {
            return _value.Equals(value);
        }
    }

    public class LessOrEqualsConstraint<T> : IConstraint<T>
        where T : IComparable<T>
    {
        private readonly T _value;

        public LessOrEqualsConstraint(T value)
        {
            _value = value;
        }

        public bool IsValid(T value)
        {
            return _value.CompareTo(value) >= 0;
        }
    }

    public class GreaterOrEqualsConstraint<T> : IConstraint<T>
       where T : IComparable<T>
    {
        private readonly T _value;

        public GreaterOrEqualsConstraint(T value)
        {
            _value = value;
        }

        public bool IsValid(T value)
        {
            return _value.CompareTo(value) <= 0;
        }
    }

    public class RangeConstraint<T> : IConstraint<T>
      where T : IComparable<T>
    {
        private readonly T _min;
        private readonly T _max;

        public RangeConstraint(T min, T max)
        {
            _min = min;
            _max = max;
        }

        public bool IsValid(T value)
        {
            return _min.CompareTo(value) <= 0 && _max.CompareTo(value) >= 0;
        }
    }
}