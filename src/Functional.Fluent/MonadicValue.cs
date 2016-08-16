namespace Functional.Fluent
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

    }
}