namespace Functional.Fluent
{
    public interface IResult
    {
        bool IsSucceed { get; }

        bool IsFailed { get; }
    }
}