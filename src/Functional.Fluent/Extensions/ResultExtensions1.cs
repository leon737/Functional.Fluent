


using System;
using Functional.Fluent.Helpers;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Extensions
{
	public static class ResultExtensions2
    {

	    
	public static AggregateResult<T1, T2, T3> And <T1, T2, T3> (this AggregateResult<T1, T2> result, Result<T3> other) =>
		result.IsSucceed && other.IsSucceed ? Result.Success(Tuple.Create(result.Value.Item1, result.Value.Item2, other))
            : Result.Fail(Tuple.Create(result.Value.Item1, result.Value.Item2, other));

		public static AggregateResult<T1, T2, T3> Or <T1, T2, T3> (this AggregateResult<T1, T2> result, Result<T3> other) =>
		result.IsSucceed || other.IsSucceed ? Result.Success(Tuple.Create(result.Value.Item1, result.Value.Item2, other))
            : Result.Fail(Tuple.Create(result.Value.Item1, result.Value.Item2, other));
	

	    
	public static AggregateResult<T1, T2, T3, T4> And <T1, T2, T3, T4> (this AggregateResult<T1, T2, T3> result, Result<T4> other) =>
		result.IsSucceed && other.IsSucceed ? Result.Success(Tuple.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3, other))
            : Result.Fail(Tuple.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3, other));

		public static AggregateResult<T1, T2, T3, T4> Or <T1, T2, T3, T4> (this AggregateResult<T1, T2, T3> result, Result<T4> other) =>
		result.IsSucceed || other.IsSucceed ? Result.Success(Tuple.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3, other))
            : Result.Fail(Tuple.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3, other));
	

	    
	public static AggregateResult<T1, T2, T3, T4, T5> And <T1, T2, T3, T4, T5> (this AggregateResult<T1, T2, T3, T4> result, Result<T5> other) =>
		result.IsSucceed && other.IsSucceed ? Result.Success(Tuple.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3, result.Value.Item4, other))
            : Result.Fail(Tuple.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3, result.Value.Item4, other));

		public static AggregateResult<T1, T2, T3, T4, T5> Or <T1, T2, T3, T4, T5> (this AggregateResult<T1, T2, T3, T4> result, Result<T5> other) =>
		result.IsSucceed || other.IsSucceed ? Result.Success(Tuple.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3, result.Value.Item4, other))
            : Result.Fail(Tuple.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3, result.Value.Item4, other));
	

	    
	public static AggregateResult<T1, T2, T3, T4, T5, T6> And <T1, T2, T3, T4, T5, T6> (this AggregateResult<T1, T2, T3, T4, T5> result, Result<T6> other) =>
		result.IsSucceed && other.IsSucceed ? Result.Success(Tuple.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3, result.Value.Item4, result.Value.Item5, other))
            : Result.Fail(Tuple.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3, result.Value.Item4, result.Value.Item5, other));

		public static AggregateResult<T1, T2, T3, T4, T5, T6> Or <T1, T2, T3, T4, T5, T6> (this AggregateResult<T1, T2, T3, T4, T5> result, Result<T6> other) =>
		result.IsSucceed || other.IsSucceed ? Result.Success(Tuple.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3, result.Value.Item4, result.Value.Item5, other))
            : Result.Fail(Tuple.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3, result.Value.Item4, result.Value.Item5, other));
	

	    
	public static AggregateResult<T1, T2, T3, T4, T5, T6, T7> And <T1, T2, T3, T4, T5, T6, T7> (this AggregateResult<T1, T2, T3, T4, T5, T6> result, Result<T7> other) =>
		result.IsSucceed && other.IsSucceed ? Result.Success(Tuple.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3, result.Value.Item4, result.Value.Item5, result.Value.Item6, other))
            : Result.Fail(Tuple.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3, result.Value.Item4, result.Value.Item5, result.Value.Item6, other));

		public static AggregateResult<T1, T2, T3, T4, T5, T6, T7> Or <T1, T2, T3, T4, T5, T6, T7> (this AggregateResult<T1, T2, T3, T4, T5, T6> result, Result<T7> other) =>
		result.IsSucceed || other.IsSucceed ? Result.Success(Tuple.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3, result.Value.Item4, result.Value.Item5, result.Value.Item6, other))
            : Result.Fail(Tuple.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3, result.Value.Item4, result.Value.Item5, result.Value.Item6, other));
	

	
	}	
}