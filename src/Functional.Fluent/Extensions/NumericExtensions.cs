using System;
using System.Globalization;
using Functional.Fluent.Helpers;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Extensions
{
    public static class NumericExtensions
    {
        public static Result<int> ToInt(this string value)
        {
            int result;
            return int.TryParse(value, out result)
                ? Result.Success(result)
                : Result.Fail<int>();
        }

        public static Result<int> ToInt(this string value, NumberStyles numberStyles, IFormatProvider formatProvider)
        {
            int result;
            return int.TryParse(value, numberStyles, formatProvider, out result)
                ? Result.Success(result)
                : Result.Fail<int>();
        }

        public static Result<uint> ToUInt(this string value)
        {
            uint result;
            return uint.TryParse(value, out result)
                ? Result.Success(result)
                : Result.Fail<uint>();
        }

        public static Result<uint> ToUInt(this string value, NumberStyles numberStyles, IFormatProvider formatProvider)
        {
            uint result;
            return uint.TryParse(value, numberStyles, formatProvider, out result)
                ? Result.Success(result)
                : Result.Fail<uint>();
        }

        public static Result<long> ToLong(this string value)
        {
            long result;
            return long.TryParse(value, out result)
                ? Result.Success(result)
                : Result.Fail<long>();
        }

        public static Result<long> ToLong(this string value, NumberStyles numberStyles, IFormatProvider formatProvider)
        {
            long result;
            return long.TryParse(value, numberStyles, formatProvider, out result)
                ? Result.Success(result)
                : Result.Fail<long>();
        }

        public static Result<ulong> ToULong(this string value)
        {
            ulong result;
            return ulong.TryParse(value, out result)
                ? Result.Success(result)
                : Result.Fail<ulong>();
        }

        public static Result<ulong> ToULong(this string value, NumberStyles numberStyles, IFormatProvider formatProvider)
        {
            ulong result;
            return ulong.TryParse(value, numberStyles, formatProvider, out result)
                ? Result.Success(result)
                : Result.Fail<ulong>();
        }

        public static Result<short> ToShort(this string value)
        {
            short result;
            return short.TryParse(value, out result)
                ? Result.Success(result)
                : Result.Fail<short>();
        }

        public static Result<short> ToShort(this string value, NumberStyles numberStyles, IFormatProvider formatProvider)
        {
            short result;
            return short.TryParse(value, numberStyles, formatProvider, out result)
                ? Result.Success(result)
                : Result.Fail<short>();
        }

        public static Result<ushort> ToUShort(this string value)
        {
            ushort result;
            return ushort.TryParse(value, out result)
                ? Result.Success(result)
                : Result.Fail<ushort>();
        }

        public static Result<ushort> ToUShort(this string value, NumberStyles numberStyles, IFormatProvider formatProvider)
        {
            ushort result;
            return ushort.TryParse(value, numberStyles, formatProvider, out result)
                ? Result.Success(result)
                : Result.Fail<ushort>();
        }
    }
}