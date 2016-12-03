namespace Functional.Fluent.MonadicTypes
{
    public class MemoBuilder<T> : MonadicValue<T>
    {
        public MemoBuilder(T value) : base(value) { }

    }
}