using System;
using Functional.Fluent.Helpers;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Extensions
{
    public static class GuidExtensions
    {

        public static Result<Guid> ToGuid(this string value)
        {
            Guid result;
            return Guid.TryParse(value, out result)
                ? Result.Success(result)
                : Result.Fail<Guid>();
        }

        public static Result<Guid> ToGuid(this string value, string format)
        {
            Guid result;
            return Guid.TryParseExact(value, format, out result)
                ? Result.Success(result)
                : Result.Fail<Guid>();
        }
    }
}