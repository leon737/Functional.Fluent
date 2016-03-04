namespace Functional.Fluent
{
    public class Maybe<T>
    {
        public readonly static Maybe<T> Nothing = new Maybe<T>();
        public T Value { get; private set; }
        public bool HasValue { get; private set; }
        Maybe()
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