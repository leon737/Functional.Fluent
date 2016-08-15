namespace Functional.Fluent
{
    public class MonadicValue<T>
    {
        public virtual T Value { get; protected set; }

        protected MonadicValue()
        {

        }
        
        public MonadicValue(T value)
        {
            Value = value;
        }

        public static implicit operator MonadicValue<T>(T v) => new MonadicValue<T>(v);

        public static implicit operator T(MonadicValue<T> v) => v.Value;

    }
}