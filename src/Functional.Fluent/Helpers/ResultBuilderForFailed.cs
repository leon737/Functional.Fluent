using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Helpers
{
    public class ResultBuilderForFailed<T> : ResultBuilder<T>
    {

        internal ResultBuilderForFailed () : base(false) { }

        public Result<T, U> And<U>(U value) => new Result<T, U>(value);
    }
}