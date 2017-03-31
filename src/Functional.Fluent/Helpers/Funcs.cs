using System;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Helpers
{
    public static partial class Funcs
    {
        public static FuncState<T> Get<T>() => new FuncState<T>();

        public delegate bool OutParamsDelegateNoInputParameters<R>(out R result);

        public static Func<Result<R>> MakeResult<R>(OutParamsDelegateNoInputParameters<R> d) => () =>
        {
            R result;
            return d(out result) ? Result.Success(result) : Result.Fail<R>();
        };

    }
}
