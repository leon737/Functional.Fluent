namespace Functional.Fluent
{
    public class Maybe<T>
    {
        public readonly static Maybe<T> Nothing = new Maybe<T>();
        public virtual T Value { get; protected set; }
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

        public static implicit operator Maybe<T>(T v)
        {
            return new Maybe<T>(v);
        }

        public static implicit operator T(Maybe<T> v)
        {
            return v.Value;
        }
       
    }
}