


using System;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Helpers
{
	
	public static partial class Result
    {

	    
	internal static AggregateResult<T1, T2> Success<T1, T2>(Tuple<Result<T1>, Result<T2>> value) => new AggregateResult<T1, T2>(true, value);

	internal static AggregateResult<T1, T2> Fail<T1, T2>(Tuple<Result<T1>, Result<T2>> value) => new AggregateResult<T1, T2>(false, value);
	

	    
	internal static AggregateResult<T1, T2, T3> Success<T1, T2, T3>(Tuple<Result<T1>, Result<T2>, Result<T3>> value) => new AggregateResult<T1, T2, T3>(true, value);

	internal static AggregateResult<T1, T2, T3> Fail<T1, T2, T3>(Tuple<Result<T1>, Result<T2>, Result<T3>> value) => new AggregateResult<T1, T2, T3>(false, value);
	

	    
	internal static AggregateResult<T1, T2, T3, T4> Success<T1, T2, T3, T4>(Tuple<Result<T1>, Result<T2>, Result<T3>, Result<T4>> value) => new AggregateResult<T1, T2, T3, T4>(true, value);

	internal static AggregateResult<T1, T2, T3, T4> Fail<T1, T2, T3, T4>(Tuple<Result<T1>, Result<T2>, Result<T3>, Result<T4>> value) => new AggregateResult<T1, T2, T3, T4>(false, value);
	

	    
	internal static AggregateResult<T1, T2, T3, T4, T5> Success<T1, T2, T3, T4, T5>(Tuple<Result<T1>, Result<T2>, Result<T3>, Result<T4>, Result<T5>> value) => new AggregateResult<T1, T2, T3, T4, T5>(true, value);

	internal static AggregateResult<T1, T2, T3, T4, T5> Fail<T1, T2, T3, T4, T5>(Tuple<Result<T1>, Result<T2>, Result<T3>, Result<T4>, Result<T5>> value) => new AggregateResult<T1, T2, T3, T4, T5>(false, value);
	

	    
	internal static AggregateResult<T1, T2, T3, T4, T5, T6> Success<T1, T2, T3, T4, T5, T6>(Tuple<Result<T1>, Result<T2>, Result<T3>, Result<T4>, Result<T5>, Result<T6>> value) => new AggregateResult<T1, T2, T3, T4, T5, T6>(true, value);

	internal static AggregateResult<T1, T2, T3, T4, T5, T6> Fail<T1, T2, T3, T4, T5, T6>(Tuple<Result<T1>, Result<T2>, Result<T3>, Result<T4>, Result<T5>, Result<T6>> value) => new AggregateResult<T1, T2, T3, T4, T5, T6>(false, value);
	

	    
	internal static AggregateResult<T1, T2, T3, T4, T5, T6, T7> Success<T1, T2, T3, T4, T5, T6, T7>(Tuple<Result<T1>, Result<T2>, Result<T3>, Result<T4>, Result<T5>, Result<T6>, Result<T7>> value) => new AggregateResult<T1, T2, T3, T4, T5, T6, T7>(true, value);

	internal static AggregateResult<T1, T2, T3, T4, T5, T6, T7> Fail<T1, T2, T3, T4, T5, T6, T7>(Tuple<Result<T1>, Result<T2>, Result<T3>, Result<T4>, Result<T5>, Result<T6>, Result<T7>> value) => new AggregateResult<T1, T2, T3, T4, T5, T6, T7>(false, value);
	

	
	}

	
	
}