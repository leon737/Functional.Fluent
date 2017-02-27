using System;
using Functional.Fluent.Helpers;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Extensions
{
    public static class ResultExtensions
    {
        public static Result<TU> Success<TV, TU>(this Result<TV> result, Func<TV, Result<TU>> f) =>
            result.IsSucceed ? f(result.Value) : Result.Fail<TU>();

        public static Result<TV> Success<TV>(this IResult result, Func<Result<TV>> f) =>
            result.IsSucceed ? f() : Result.Fail<TV>();

        public static Result<TR, TU> Success<TV, TU, TR>(this Result<TV, TU> result, Func<TV, Result<TR, TU>> f) =>
            result.IsSucceed ? f(result.SuccessValue) : new Result<TR, TU>(result.ErrorValue);

        public static Result<TV> Fail<TV>(this Result<TV> result, Func<Result<TV>> f) =>
            result.IsFailed ? f() : result;

        public static Result<TV, TR> Fail<TV, TU, TR>(this Result<TV, TU> result, Func<TU, Result<TV, TR>> f) =>
            result.IsFailed ? f(result.ErrorValue) : new Result<TV, TR>(result.SuccessValue);

        public static IResult Fail(this IResult result, Func<IResult> f) =>
           result.IsFailed ? f() : result;

        public static Result<TU> Always<TV, TU>(this Result<TV> result, Func<Result<TV>, Result<TU>> f) => f(result);

        public static Result<TV> Always<TV>(this IResult result, Func<IResult, Result<TV>> f) => f(result);

        public static AggregateResult<TV, TU> And<TV, TU>(this Result<TV> result, Result<TU> other) =>
            result.IsSucceed && other.IsSucceed ? Result.Success(Tuple.Create(result, other))
            : new AggregateResult<TV, TU>(false);

        public static Result<TX, TY> And<TA, TB, TC, TD, TX, TY>(this Result<TA, TB> result, Result<TC, TD> other,
                Func<TA, TC, TX> success, Func<TB, TD, TY> error) =>
            result.IsSucceed && other.IsSucceed
                ? new Result<TX, TY>(success(result.SuccessValue, other.SuccessValue))
                : new Result<TX, TY>(error(result.ErrorValue, other.ErrorValue));

        public static AggregateResult<TV, TU> Or<TV, TU>(this Result<TV> result, Result<TU> other) =>
            result.IsSucceed || other.IsSucceed ? Result.Success(Tuple.Create(result, other))
            : new AggregateResult<TV, TU>(false);

        public static Result<TX, TY> Or<TA, TB, TC, TD, TX, TY>(this Result<TA, TB> result, Result<TC, TD> other,
                Func<TA, TC, TX> success, Func<TB, TD, TY> error) =>
            result.IsSucceed || other.IsSucceed
                ? new Result<TX, TY>(success(result.SuccessValue, other.SuccessValue))
                : new Result<TX, TY>(error(result.ErrorValue, other.ErrorValue));

        public static AggregateCollectionResult And<T1, T2, T3, T4, T5, T6, T7, T8>(this AggregateResult<T1, T2, T3, T4, T5, T6, T7> result, Result<T8> other) => Result.Combine(result, other);

        public static AggregateCollectionResult Or<T1, T2, T3, T4, T5, T6, T7, T8>(this AggregateResult<T1, T2, T3, T4, T5, T6, T7> result, Result<T8> other) => Result.Combine(result, other);

        public static AggregateCollectionResult And<T>(this AggregateCollectionResult result, Result<T> other) => Result.Combine(result, other);

        public static AggregateCollectionResult Or<T>(this AggregateCollectionResult result, Result<T> other) => Result.Combine(result, other);

        public static Result<V> SuccessValue<T, V>(this Result<T> result, Func<T, V> func) => result.Success(v => Result.Success(func(v)));

        public static Result<V> SuccessValue<T, V>(this Result<T> result, V value)=> result.Success(_ => Result.Success(value));

        public static Result<T> FailValue<T>(this Result<T> result, Func<T> func) => result.Fail(() => Result.Success(func()));

        public static Result<T> FailValue<T>(this Result<T> result, T value) => result.Fail(() => Result.Success(value));

        public static Result<T> FailThrow<T>(this Result<T> result) where T:Exception, new() => result.Fail(() => { throw new T();});

        public static Result<T> FailThrow<T>(this Result<T> result, T exception) where T : Exception => result.Fail(() => { throw exception; });

        public static Result<Unit> ToResult(this bool value) => value ? Result.Success() : Result.Fail<Unit>();

        public static Maybe<Result<T>> Twist<T>(this Result<Maybe<T>> value) => 
            value.IsSucceed
            ? (value.Value.HasValue
                ? new Maybe<Result<T>>(Result.Success(value.Value.Value))
                : Maybe<Result<T>>.Nothing)
            : new Maybe<Result<T>>(Result.Fail<T>());
    }
}
