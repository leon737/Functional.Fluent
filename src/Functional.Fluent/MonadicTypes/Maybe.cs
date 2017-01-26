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
            if ((object)other == null) return false;

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

        public static bool operator ==(Maybe<T> lhv, Maybe<T> rhv)
        {
            if((object)lhv == (object)rhv)
                return true;

            if ((object)lhv == null || (object)rhv == null)
                return false;

            if (lhv.HasValue != rhv.HasValue) return false;

            if (!lhv.HasValue) return true;

            if (lhv.Value == null && rhv.Value == null) return true;

            return lhv.Value != null && lhv.Value.Equals(rhv.Value);
        }

        public static bool operator !=(Maybe<T> lhv, Maybe<T> rhv)
        {
            if ((object)lhv == (object)rhv)
                return false;

            if ((object)lhv == null || (object)rhv == null)
                return true;

            if (lhv.HasValue != rhv.HasValue) return true;

            if (!lhv.HasValue) return false;

            if (lhv.Value == null && rhv.Value == null) return false;

            return lhv.Value == null || !lhv.Value.Equals(rhv.Value);
        }
    }
}