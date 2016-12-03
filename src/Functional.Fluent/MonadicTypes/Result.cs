using System;
using Functional.Fluent.Extensions;
using Functional.Fluent.Helpers;

namespace Functional.Fluent.MonadicTypes
{
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


    public class Result<V, U> : MonadicValue<Either<U, V>>, IResult
    {
        public Result(Either<U, V> e)
        {
            WrappedValue = e;
        }

        public Result(V value)
        {
            WrappedValue = () => value;
        }

        public Result(U value)
        {
            WrappedValue = () => value;
        }

        public bool IsSucceed => !WrappedValue.HasLeft() && WrappedValue.HasRight();

        public bool IsFailed => !IsSucceed;

        public override Either<U, V> Value => WrappedValue;

        public V SuccessValue => WrappedValue.Right();

        public U ErrorValue => WrappedValue.Left();

    }
}