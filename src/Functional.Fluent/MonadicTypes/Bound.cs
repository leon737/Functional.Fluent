using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Fluent.MonadicTypes
{
    internal enum BoundTypeBehaviour
    {
        Exception,
        ExplicitCheck
    }


    public class BoundType<T> //: IBoundType<T>
    {
        private readonly IList<IConstraint<T>> _constraints = new List<IConstraint<T>>();
        private readonly Func<IEnumerable<IConstraint<T>>, Func<IConstraint<T>, bool>, bool> _func;

        public BoundType()
        {
            _func = Enumerable.Any;
        }

        public BoundType(bool requireAllContraints)
        {
            _func = requireAllContraints ? (Func<IEnumerable<IConstraint<T>>, Func<IConstraint<T>, bool>, bool>)Enumerable.All : Enumerable.Any;
        }

        public BoundType<T> Add(IConstraint<T> constraint)
        {
            _constraints.Add(constraint);
            return this;
        }

        public bool Check(T value) => _func(_constraints, v => v.IsValid(value));

        public IBound<T> Create(T value)
        {
            return new Bound<T>(value, this);
        }

        public BoundType<T> OnException()
        {
            Behaviour = BoundTypeBehaviour.Exception;
            return this;
        }

        public BoundType<T> OnExplicitCheck()
        {
            Behaviour = BoundTypeBehaviour.ExplicitCheck;
            return this;
        }

        internal BoundTypeBehaviour Behaviour { get; private set; } = BoundTypeBehaviour.Exception;
    }

    public interface IBound<T>
    {
        T Value { get; }

        IBound<T> Set(T value);

        bool IsValid { get; }
    }


    public class Bound<T> : MonadicValue<T>, IBound<T>
    {
        private readonly BoundType<T> _boundType;

        public bool IsValid { get; }


        public Bound(T value, BoundType<T> boundType)
        {
            _boundType = boundType;
            IsValid = SetValue(value);
        }

        private bool SetValue(T value)
        {
            if (CheckValue(value))
            {
                WrappedValue = value;
                return true;
            }
            if (_boundType.Behaviour == BoundTypeBehaviour.Exception)
                throw new ArgumentOutOfRangeException(nameof(value));
            return false;
        }

        private bool CheckValue(T value)
        {
            return _boundType.Check(value);
        }

        public new T Value => WrappedValue;

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

    public class NotEqualsConstraint<T> : IConstraint<T>
        where T : IEquatable<T>
    {
        private readonly T _value;

        public NotEqualsConstraint(T value)
        {
            _value = value;
        }

        public bool IsValid(T value)
        {
            return !_value.Equals(value);
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

    public class LessConstraint<T> : IConstraint<T>
        where T : IComparable<T>
    {
        private readonly T _value;

        public LessConstraint(T value)
        {
            _value = value;
        }

        public bool IsValid(T value)
        {
            return _value.CompareTo(value) > 0;
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

    public class GreaterConstraint<T> : IConstraint<T>
       where T : IComparable<T>
    {
        private readonly T _value;

        public GreaterConstraint(T value)
        {
            _value = value;
        }

        public bool IsValid(T value)
        {
            return _value.CompareTo(value) < 0;
        }
    }

    public class RangeConstraint<T> : IConstraint<T>
      where T : IComparable<T>
    {
        private readonly T _min;
        private readonly T _max;
        private readonly bool _includeMin;
        private readonly bool _includeMax;


        public RangeConstraint(T min, T max, bool includeMin = true, bool includeMax = true)
        {
            _min = min;
            _max = max;
            _includeMin = includeMin;
            _includeMax = includeMax;
        }

        public bool IsValid(T value)
        {
            return (_includeMin ? _min.CompareTo(value) <= 0 : _min.CompareTo(value) < 0)
                && (_includeMax ? _max.CompareTo(value) >= 0 : _max.CompareTo(value) > 0);
        }
    }
}