using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Helpers
{
    public class ResultBuilderForSucceeded<T> : ResultBuilder<T>
    {

        internal ResultBuilderForSucceeded(T value) : base(value) { }

        public Result<T, U> And<U>() => new Result<T, U>(_value);
    }
}