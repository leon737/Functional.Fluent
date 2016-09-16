


using System;
using System.Collections;
using System.Collections.Generic;

namespace Functional.Fluent
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

	
	public class AggregateResult<T1, T2> : Result<Tuple<Result<T1>, Result<T2>>>, IEnumerable<IResult>
	{

		public AggregateResult(bool isSucceed) : base(isSucceed)
	    {
	    }

	    public AggregateResult(bool isSucceed, Tuple<Result<T1>, Result<T2>> value) : base(isSucceed, value)
	    {
	    }

	    public IEnumerator<IResult> GetEnumerator()
	    {
							yield return Value.Item1;
							yield return Value.Item2;
				    }

	    IEnumerator IEnumerable.GetEnumerator()
	    {
	        return GetEnumerator();
	    }

		public Tuple<T1, T2> AggregateValue
        {
            get
            {
                if (IsSucceed)
                    return Tuple.Create(WrappedValue.Item1.Value  , WrappedValue.Item2.Value );
                throw new ApplicationException("Cannot obtain value for not succeed result");
            }
        }
	
	}
	
	public class AggregateResult<T1, T2, T3> : Result<Tuple<Result<T1>, Result<T2>, Result<T3>>>, IEnumerable<IResult>
	{

		public AggregateResult(bool isSucceed) : base(isSucceed)
	    {
	    }

	    public AggregateResult(bool isSucceed, Tuple<Result<T1>, Result<T2>, Result<T3>> value) : base(isSucceed, value)
	    {
	    }

	    public IEnumerator<IResult> GetEnumerator()
	    {
							yield return Value.Item1;
							yield return Value.Item2;
							yield return Value.Item3;
				    }

	    IEnumerator IEnumerable.GetEnumerator()
	    {
	        return GetEnumerator();
	    }

		public Tuple<T1, T2, T3> AggregateValue
        {
            get
            {
                if (IsSucceed)
                    return Tuple.Create(WrappedValue.Item1.Value  , WrappedValue.Item2.Value  , WrappedValue.Item3.Value );
                throw new ApplicationException("Cannot obtain value for not succeed result");
            }
        }
	
	}
	
	public class AggregateResult<T1, T2, T3, T4> : Result<Tuple<Result<T1>, Result<T2>, Result<T3>, Result<T4>>>, IEnumerable<IResult>
	{

		public AggregateResult(bool isSucceed) : base(isSucceed)
	    {
	    }

	    public AggregateResult(bool isSucceed, Tuple<Result<T1>, Result<T2>, Result<T3>, Result<T4>> value) : base(isSucceed, value)
	    {
	    }

	    public IEnumerator<IResult> GetEnumerator()
	    {
							yield return Value.Item1;
							yield return Value.Item2;
							yield return Value.Item3;
							yield return Value.Item4;
				    }

	    IEnumerator IEnumerable.GetEnumerator()
	    {
	        return GetEnumerator();
	    }

		public Tuple<T1, T2, T3, T4> AggregateValue
        {
            get
            {
                if (IsSucceed)
                    return Tuple.Create(WrappedValue.Item1.Value  , WrappedValue.Item2.Value  , WrappedValue.Item3.Value  , WrappedValue.Item4.Value );
                throw new ApplicationException("Cannot obtain value for not succeed result");
            }
        }
	
	}
	
	public class AggregateResult<T1, T2, T3, T4, T5> : Result<Tuple<Result<T1>, Result<T2>, Result<T3>, Result<T4>, Result<T5>>>, IEnumerable<IResult>
	{

		public AggregateResult(bool isSucceed) : base(isSucceed)
	    {
	    }

	    public AggregateResult(bool isSucceed, Tuple<Result<T1>, Result<T2>, Result<T3>, Result<T4>, Result<T5>> value) : base(isSucceed, value)
	    {
	    }

	    public IEnumerator<IResult> GetEnumerator()
	    {
							yield return Value.Item1;
							yield return Value.Item2;
							yield return Value.Item3;
							yield return Value.Item4;
							yield return Value.Item5;
				    }

	    IEnumerator IEnumerable.GetEnumerator()
	    {
	        return GetEnumerator();
	    }

		public Tuple<T1, T2, T3, T4, T5> AggregateValue
        {
            get
            {
                if (IsSucceed)
                    return Tuple.Create(WrappedValue.Item1.Value  , WrappedValue.Item2.Value  , WrappedValue.Item3.Value  , WrappedValue.Item4.Value  , WrappedValue.Item5.Value );
                throw new ApplicationException("Cannot obtain value for not succeed result");
            }
        }
	
	}
	
	public class AggregateResult<T1, T2, T3, T4, T5, T6> : Result<Tuple<Result<T1>, Result<T2>, Result<T3>, Result<T4>, Result<T5>, Result<T6>>>, IEnumerable<IResult>
	{

		public AggregateResult(bool isSucceed) : base(isSucceed)
	    {
	    }

	    public AggregateResult(bool isSucceed, Tuple<Result<T1>, Result<T2>, Result<T3>, Result<T4>, Result<T5>, Result<T6>> value) : base(isSucceed, value)
	    {
	    }

	    public IEnumerator<IResult> GetEnumerator()
	    {
							yield return Value.Item1;
							yield return Value.Item2;
							yield return Value.Item3;
							yield return Value.Item4;
							yield return Value.Item5;
							yield return Value.Item6;
				    }

	    IEnumerator IEnumerable.GetEnumerator()
	    {
	        return GetEnumerator();
	    }

		public Tuple<T1, T2, T3, T4, T5, T6> AggregateValue
        {
            get
            {
                if (IsSucceed)
                    return Tuple.Create(WrappedValue.Item1.Value  , WrappedValue.Item2.Value  , WrappedValue.Item3.Value  , WrappedValue.Item4.Value  , WrappedValue.Item5.Value  , WrappedValue.Item6.Value );
                throw new ApplicationException("Cannot obtain value for not succeed result");
            }
        }
	
	}
	
	public class AggregateResult<T1, T2, T3, T4, T5, T6, T7> : Result<Tuple<Result<T1>, Result<T2>, Result<T3>, Result<T4>, Result<T5>, Result<T6>, Result<T7>>>, IEnumerable<IResult>
	{

		public AggregateResult(bool isSucceed) : base(isSucceed)
	    {
	    }

	    public AggregateResult(bool isSucceed, Tuple<Result<T1>, Result<T2>, Result<T3>, Result<T4>, Result<T5>, Result<T6>, Result<T7>> value) : base(isSucceed, value)
	    {
	    }

	    public IEnumerator<IResult> GetEnumerator()
	    {
							yield return Value.Item1;
							yield return Value.Item2;
							yield return Value.Item3;
							yield return Value.Item4;
							yield return Value.Item5;
							yield return Value.Item6;
							yield return Value.Item7;
				    }

	    IEnumerator IEnumerable.GetEnumerator()
	    {
	        return GetEnumerator();
	    }

		public Tuple<T1, T2, T3, T4, T5, T6, T7> AggregateValue
        {
            get
            {
                if (IsSucceed)
                    return Tuple.Create(WrappedValue.Item1.Value  , WrappedValue.Item2.Value  , WrappedValue.Item3.Value  , WrappedValue.Item4.Value  , WrappedValue.Item5.Value  , WrappedValue.Item6.Value  , WrappedValue.Item7.Value );
                throw new ApplicationException("Cannot obtain value for not succeed result");
            }
        }
	
	}
	}