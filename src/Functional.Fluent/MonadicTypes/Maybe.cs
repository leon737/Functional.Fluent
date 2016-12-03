namespace Functional.Fluent.MonadicTypes
{
    public class Maybe<T> : MonadicValue<T>
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

    }    
}