using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Extensions
{
    public static class StringExtensions
    {

        public static Maybe<string> ToMaybeNonEmpty(this string value) =>
            !string.IsNullOrEmpty(value) ? value.ToMaybe() : Maybe<string>.Nothing;

        public static Maybe<string> ToMaybeNonWhitespace(this string value) =>
            !string.IsNullOrWhiteSpace(value) ? value.ToMaybe() : Maybe<string>.Nothing;
    }
}