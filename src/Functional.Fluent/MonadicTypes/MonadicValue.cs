using System;

namespace Functional.Fluent.MonadicTypes
{
    public class MonadicValue<T> 
    {
        protected T WrappedValue;

        public virtual T Value => WrappedValue;

        protected MonadicValue() { }
        
        public MonadicValue(T value)
        {
            WrappedValue = value;
        }

        public static implicit operator MonadicValue<T>(T v) => new MonadicValue<T>(v);

        public static implicit operator T(MonadicValue<T> v) => v.Value;

        public virtual Type WrappedType => typeof(T);

        public override bool Equals(object obj)
        {
            if ((object)this == obj)
                return true;

            var other = obj as Maybe<T>;
            if (other == null) return false;
            
            if (Value == null && other.Value == null) return true;

            return Value != null && Value.Equals(other.Value);
        }

        public override int GetHashCode() => Value == null ? 0 : Value.GetHashCode();
    }
}