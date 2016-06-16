using System;
using System.Linq;

namespace Functional.Fluent
{
    public class Result
    {
        public bool IsSucceed { get; }

        public bool IsFailed => !IsSucceed;

        protected Result(bool isSucceed)
        {
            IsSucceed = isSucceed;
        }

        public static Result<T> Success<T>(T Value) => new Result<T>(true, Value);

        public static Result<T> Fail<T>() => new Result<T>(false, default(T));

        public static Result<T> SuccessIfNotNull<T>(T Value) => new Result<T>(Value != null, Value);

        public static Result<T> Eval<T>(Func<T> f, params Type[] safeExceptions)
        {
            try
            {
                return Result.Success(f());
            }
            catch (Exception e) when (safeExceptions.Any(x => x == e.GetType()))
            {
                return Result.Fail<T>();
            }
        }

        public static Result Combine(params Result[] results) => new Result(results.All(x => x.IsSucceed));
        
    }

    public class Result<T> : Result
    {

        private T value;

        public T Value
        {
            get
            {
                if (IsSucceed)
                    return value;
                throw new ApplicationException("Cannot obtain value for not succeed result");
            }
        }

        internal Result(bool isSucceed, T value) : base(isSucceed)
        {
            this.value = value;
        }
    }
}
