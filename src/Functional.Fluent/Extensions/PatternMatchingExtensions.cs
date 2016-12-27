using System.Collections.Generic;
using Functional.Fluent.MonadicTypes;
using Functional.Fluent.Pattern;

namespace Functional.Fluent.Extensions
{
    public static class PatternMatchingExtensions
    {

        // value matcher

        public static MatcherContext<TV> Match<TV>(this TV v) => new MatcherContext<TV>(v);

        public static MatcherContext<TV> Match<TV>(this MonadicValue<TV> v) => new MatcherContext<TV>(v);

        public static MatcherContext<TV> Match<TV>(this Maybe<TV> v) => new MatcherContext<TV>(v);
        

        // list matcher

        public static ListMatcherContext<TV> Match<TV>(this IEnumerable<TV> v) => new ListMatcherContext<TV>(new MonadicValue<IEnumerable<TV>>(v));

        public static ListMatcherContext<TV> Match<TV>(this MonadicValue<IEnumerable<TV>> v) => new ListMatcherContext<TV>(v);

        public static ListMatcherContext<TV> Match<TV>(this MonadicValue<List<TV>> v) => new ListMatcherContext<TV>(v.With(x => x as IEnumerable<TV>));

        public static ListMatcherContext<TV> Match<TV>(this MonadicValue<TV[]> v) => new ListMatcherContext<TV>(v.With(x => x as IEnumerable<TV>));

        public static ListMatcherContext<TV> Match<TV>(this Maybe<IEnumerable<TV>> v) => new ListMatcherContext<TV>(v);

        public static ListMatcherContext<TV> Match<TV>(this Maybe<List<TV>> v) => new ListMatcherContext<TV>(v.With(x => x as IEnumerable<TV>));

        public static ListMatcherContext<TV> Match<TV>(this Maybe<TV[]> v) => new ListMatcherContext<TV>(v.With(x => x as IEnumerable<TV>));
        

        //type matcher


        public static TypeMatcherContext<TV> TypeMatch<TV>(this TV v) => new TypeMatcherContext<TV>(v);

        public static TypeMatcherContext<TV> TypeMatch<TV>(this MonadicValue<TV> v) => new TypeMatcherContext<TV>(v);

        public static MonadicValue<TU> Match<TV, TU>(this MonadicValue<TV> v, Matcher<TV, TU> matcher) => matcher.Match(v.Value).ToM();

        public static MonadicValue<TU> Match<TV, TU>(this MonadicValue<TV> v, TypeMatcher<TU> matcher) => matcher.Match(v.Value).ToM();

        public static TypeMatcherContext<TV> TypeMatch<TV>(this Maybe<TV> v) => new TypeMatcherContext<TV>(v);

        public static MonadicValue<TU> Match<TV, TU>(this Maybe<TV> v, Matcher<TV, TU> matcher) => matcher.Match(v.Value).ToM();

        public static MonadicValue<TU> Match<TV, TU>(this Maybe<TV> v, TypeMatcher<TU> matcher) => matcher.Match(v.Value).ToM();
    }
}