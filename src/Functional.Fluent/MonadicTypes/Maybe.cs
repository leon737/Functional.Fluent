namespace Functional.Fluent.MonadicTypes
{
    public class Maybe<T> : MonadicValue<T>, IMaybe<T>
    {
        public static readonly Maybe<T> Nothing = new Maybe<T>();
        public bool HasValue { get; protected set; }

        protected Maybe()
        {
            HasValue = false;
        }

        public Maybe(T value)
        {
            WrappedValue = value;
            HasValue = value != null;
        }

        public static implicit operator Maybe<T>(T v) => new Maybe<T>(v);

        public override bool Equals(object obj)
        {
            if ((object)this == obj)
                return true;

            var other = obj as Maybe<T>;
            if (other == null) return false;

            if (HasValue != other.HasValue) return false;

            if (!HasValue) return true;

            if (Value == null && other.Value == null) return true;
            
            return Value != null && Value.Equals(other.Value);
        }
        
        public override int GetHashCode()
        {
            if (!HasValue || Value == null) return 0;
            return Value.GetHashCode();
        }
    }
}