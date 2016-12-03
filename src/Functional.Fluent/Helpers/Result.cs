using System;
using System.Linq;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Helpers
{
    public static partial class Result
    {
        
        public static Result<T> Success<T>(T value) => new Result<T>(true, value);

        public static Result<Unit> Success() => new Result<Unit>(true, new Unit());

        internal static AggregateCollectionResult Combine<T1, T2, T3, T4, T5, T6, T7, T8>(AggregateResult<T1, T2, T3, T4, T5, T6, T7> result, Result<T8> other) => 
            new AggregateCollectionResult(result.IsSucceed && other.IsSucceed, new IResult[]
            {
                result.Value.Item1,
                result.Value.Item2,
                result.Value.Item3,
                result.Value.Item4,
                result.Value.Item5,
                result.Value.Item6,
                result.Value.Item7,
                other
            });

        internal static AggregateCollectionResult CombineByOr<T1, T2, T3, T4, T5, T6, T7, T8>(AggregateResult<T1, T2, T3, T4, T5, T6, T7> result, Result<T8> other) =>
            new AggregateCollectionResult(result.IsSucceed || other.IsSucceed, new IResult[]
            {
                result.Value.Item1,
                result.Value.Item2,
                result.Value.Item3,
                result.Value.Item4,
                result.Value.Item5,
                result.Value.Item6,
                result.Value.Item7,
                other
            });

        internal static AggregateCollectionResult Combine<T>(AggregateCollectionResult result, Result<T> other) =>
           new AggregateCollectionResult(result.IsSucceed && other.IsSucceed, result.Value.Concat(new IResult[] { other }));

        internal static AggregateCollectionResult CombineByOr<T>(AggregateCollectionResult result, Result<T> other ) =>
           new AggregateCollectionResult(result.IsSucceed || other.IsSucceed, result.Value.Concat(new IResult[] { other }));

        public static Result<T> Success<T>(MonadicValue<T> value) => new Result<T>(true, value.Value);

        public static Result<T> Fail<T>() => new Result<T>(false, default(T));
        
        public static Result<T> SuccessIfNotNull<T>(T value) => new Result<T>(value != null, value);

        public static Result<T> Eval<T>(Func<T> f, params Type[] safeExceptions)
        {
            try
            {
                return Success(f());
            }
            catch (Exception e) when (safeExceptions.Any(x => x == e.GetType()))
            {
                return Fail<T>();
            }
        }

        public static IResult Combine(params IResult[] results) => new Result<Unit>(results.All(x => x.IsSucceed));

        public static ResultBuilderForSucceeded<T> For<T>(T value) => new ResultBuilderForSucceeded<T>(value);

        public static ResultBuilderForFailed<T> For<T>() => new ResultBuilderForFailed<T>();
    }

    
}
