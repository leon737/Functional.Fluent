using Functional.Fluent.Helpers;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Extensions
{
    public static class BoolExtensions
    {

        public static Result<bool> ToBool(this string value)
        {
            bool result;
            return bool.TryParse(value, out result)
                ? Result.Success(result)
                : Result.Fail<bool>();
        }
    }
}