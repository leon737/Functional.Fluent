using System;
using System.Globalization;
using Functional.Fluent.Helpers;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Extensions
{
    public static class DateTimeExtensions
    {

        public static Result<DateTime> ToDateTime(this string value)
        {
            DateTime result;
            return DateTime.TryParse(value, out result)
                ? Result.Success(result)
                : Result.Fail<DateTime>();
        }

        public static Result<DateTime> ToDateTime(this string value, DateTimeStyles dateTimeStyles, IFormatProvider formatProvider)
        {
            DateTime result;
            return DateTime.TryParse(value, formatProvider, dateTimeStyles, out result)
                ? Result.Success(result)
                : Result.Fail<DateTime>();
        }

        public static Result<DateTime> ToDateTime(this string value, string format, DateTimeStyles dateTimeStyles, IFormatProvider formatProvider)
        {
            DateTime result;
            return DateTime.TryParseExact(value, format, formatProvider, dateTimeStyles, out result)
                ? Result.Success(result)
                : Result.Fail<DateTime>();
        }
    }
}