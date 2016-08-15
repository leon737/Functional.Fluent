namespace Functional.Fluent
{
    public class Maybe<T> : MonadicValue<T>
    {
        public readonly static Maybe<T> Nothing = new Maybe<T>();
        public bool HasValue { get; protected set; }

        protected Maybe()
        {
            HasValue = false;
        }

        public Maybe(T value)
        {
            Value = value;
            HasValue = value != null;
        }

        public static implicit operator Maybe<T>(T v) => new Maybe<T>(v);

        public static implicit operator T(Maybe<T> v) => v.Value;       
    }    
}