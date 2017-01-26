namespace Functional.Fluent.MonadicTypes
{
    public struct MaybeValue<T>
    {
        public static MaybeValue<T> Nothing => new MaybeValue<T>();

        public bool HasValue { get; }

        public T Value { get; }
        
        public MaybeValue(T value)
        {
            Value = value;
            HasValue = value != null;
        }

        public static implicit operator MaybeValue<T> (Maybe<T> value)
        {
            if (value == null)
                return MaybeValue<T>.Nothing;

            return value.HasValue ? new MaybeValue<T>(value.Value) : MaybeValue<T>.Nothing;
        }

        public Maybe<T> As() => !HasValue ? Maybe<T>.Nothing : new Maybe<T>(Value);
    }
}