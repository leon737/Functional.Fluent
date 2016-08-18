using System;
using System.Linq;

namespace Functional.Fluent
{
    public static class Result
    {
        
        public static Result<T> Success<T>(T value) => new Result<T>(true, value);

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
    }

    public class Result<T> : MonadicValue<T>, IResult
    {

        internal Result(bool isSucceed)
        {
            IsSucceed = isSucceed;
        }

        internal Result(bool isSucceed, T value) : this(isSucceed)
        {
            WrappedValue = value;
        }

        public bool IsSucceed { get; }

        public bool IsFailed => !IsSucceed;

        public override T Value
        {
            get
            {
                if (IsSucceed)
                    return WrappedValue;
                throw new ApplicationException("Cannot obtain value for not succeed result");
            }
        }
    }
}
