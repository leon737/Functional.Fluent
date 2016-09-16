using System;
using System.Collections;
using System.Collections.Generic;

namespace Functional.Fluent
{
    public static class ResultExtensions
    {
        public static Result<TU> Success<TV, TU>(this Result<TV> result, Func<TV, Result<TU>> f) =>
            result.IsSucceed ? f(result.Value) : Result.Fail<TU>();

        public static Result<TV> Success<TV>(this IResult result, Func<Result<TV>> f) =>
            result.IsSucceed ? f() : Result.Fail<TV>();

        public static Result<TV> Fail<TV>(this Result<TV> result, Func<Result<TV>> f) =>
            result.IsFailed ? f() : result;

        public static IResult Fail(this IResult result, Func<IResult> f) =>
           result.IsFailed ? f() : result;

        public static Result<TU> Always<TV, TU>(this Result<TV> result, Func<Result<TV>, Result<TU>> f) => f(result);

        public static Result<TV> Always<TV>(this IResult result, Func<IResult, Result<TV>> f) => f(result);

        public static AggregateResult<TV, TU> And<TV, TU>(this Result<TV> result, Result<TU> other) =>
            result.IsSucceed && other.IsSucceed ? Result.Success(Tuple.Create(result, other))
            : new AggregateResult<TV, TU>(false);

        public static AggregateResult<TV, TU> Or<TV, TU>(this Result<TV> result, Result<TU> other) =>
            result.IsSucceed || other.IsSucceed ? Result.Success(Tuple.Create(result, other))
            : new AggregateResult<TV, TU>(false);

        public static AggregateCollectionResult And<T1, T2, T3, T4, T5, T6, T7, T8>(this AggregateResult<T1, T2, T3, T4, T5, T6, T7> result, Result<T8> other) => Result.Combine(result, other);

        public static AggregateCollectionResult Or<T1, T2, T3, T4, T5, T6, T7, T8>(this AggregateResult<T1, T2, T3, T4, T5, T6, T7> result, Result<T8> other) => Result.Combine(result, other);

        public static AggregateCollectionResult And<T>(this AggregateCollectionResult result, Result<T> other) => Result.Combine(result, other);

        public static AggregateCollectionResult Or<T>(this AggregateCollectionResult result, Result<T> other) => Result.Combine(result, other);

    }
}
