namespace Functional.Fluent.MonadicTypes
{
    public interface IMaybe<out T>
    {
        bool HasValue { get; }

        T Value { get; }
    }
}