using System;

namespace Functional.Fluent
{
    public static class ResultExtensions
    {
        private static TU SequentialExecution<TV, TU>(Action<TV> f, TV args, TU value)
        {
            f(args);
            return value;
        }

        private static TV SequentialExecution<TV>(Action f, TV value)
        {
            f();
            return value;
        }

        public static Result<TU> Success<TV, TU>(this Result<TV> result, Func<TV, Result<TU>> f) =>
            result.IsSucceed ? f(result.Value) : Result.Fail <TU>();

        public static Result<TV> Success<TV>(this IResult result, Func<Result<TV>> f) =>
            result.IsSucceed ? f() : Result.Fail<TV>();

        public static Result<TV> Success<TV>(this Result<TV> result, Action<TV> f) =>
            result.IsSucceed ? SequentialExecution(f, result.Value, result) : Result.Fail<TV>();

        public static IResult Success<TV>(this IResult result, Action f) =>
            result.IsSucceed ? SequentialExecution(f, result) : Result.Fail<TV>();

        public static Result<TV> Fail<TV>(this Result<TV> result, Func<Result<TV>> f) =>
            result.IsFailed ? f() : result;

        public static IResult Fail(this IResult result, Func<IResult> f) =>
           result.IsFailed ? f() : result;

        public static Result<TV> Fail<TV>(this Result<TV> result, Action f) =>
            result.IsFailed ? SequentialExecution(f, result) : result;

        public static IResult Fail(this IResult result, Action f) =>
            result.IsFailed ? SequentialExecution(f, result) : result;

        public static Result<TU> Always<TV, TU>(this Result<TV> result, Func<Result<TV>, Result<TU>> f) => f(result);

        public static Result<TV> Always<TV>(this IResult result, Func<IResult, Result<TV>> f) => f(result);

        public static Result<TV> Always<TV>(this Result<TV> result, Action<Result<TV>> f) => SequentialExecution(f, result, result);

        public static IResult Always(this IResult result, Action f) => SequentialExecution(f, result);

        public static Result<Tuple<TV, TU>> And<TV, TU>(this Result<TV> result, Result<TU> other) =>
            result.IsSucceed && other.IsSucceed ? Result.Success(Tuple.Create(result.Value, other.Value))
            : Result.Fail<Tuple<TV, TU>>();

    }
}
