


using System;
using System.Collections;
using System.Collections.Generic;

namespace Functional.Fluent.MonadicTypes
{
	

	
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