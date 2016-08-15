using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Fluent
{
    public static class MonadicValueExtensions
    {

        public static MonadicValue<TResult> With<TInput, TResult>(this MonadicValue<TInput> o, Func<TInput, TResult> evaluator)
            => new MonadicValue<TResult>(evaluator(o.Value));
        
        public static MonadicValue<TInput> Do<TInput>(this MonadicValue<TInput> o, Action<TInput> action)
        {
            action(o.Value);
            return o;
        }
        
        public static MonadicValue<TInput> Do<TInput>(this MonadicValue<TInput> o, params Action<TInput>[] actions)
        {
            foreach (var action in actions)
                action(o.Value);
            return o;
        }    

        public static MonadicValue<TInput> ApplyIf<TInput>(this MonadicValue<TInput> o, Func<TInput, bool> evaluator, Func<TInput, TInput> action)
            => evaluator(o.Value) ? new Maybe<TInput>(action(o.Value)) : o;

        public static MonadicValue<TInput> ApplyUnless<TInput>(this MonadicValue<TInput> o, Func<TInput, bool> evaluator, Func<TInput, TInput> action)
            => evaluator(o.Value) ? o : new Maybe<TInput>(action(o.Value));

        public static IEnumerable<MonadicValue<T>> Lift<T>(this MonadicValue<IEnumerable<T>> v) => v.Value.Select(z => z.ToM());

        public static IEnumerable<MonadicValue<T>> Lift<T>(this MonadicValue<IEnumerable<MonadicValue<T>>> v) => v.Value;

        public static MonadicValue<T> ToM<T>(this MonadicValue<T> value) => value;

        public static MonadicValue<T> ToM<T>(this T value) => new MonadicValue<T>(value);

        public static MonadicValue<TU> Map<TV, TU>(this MonadicValue<TV> v, Func<MonadicValue<TV>, TU> mapFunc) => mapFunc(v).ToM();

        /// matcher

        public static MatcherContext<TV> Match<TV>(this MonadicValue<TV> v) => new MatcherContext<TV>(v);

        public static ListMatcherContext<TV> Match<TV>(this MonadicValue<IEnumerable<TV>> v) => new ListMatcherContext<TV>(v);

        public static ListMatcherContext<TV> Match<TV>(this MonadicValue<List<TV>> v) => new ListMatcherContext<TV>(v.With(x => x as IEnumerable<TV>));

        public static ListMatcherContext<TV> Match<TV>(this MonadicValue<TV[]> v) => new ListMatcherContext<TV>(v.With(x => x as IEnumerable<TV>));

        public static TypeMatcherContext<TV> TypeMatch<TV>(this MonadicValue<TV> v) => new TypeMatcherContext<TV>(v);

        public static MonadicValue<TU> Match<TV, TU>(this MonadicValue<TV> v, Matcher<TV, TU> matcher) => matcher.Match(v.Value).ToM();

        public static MonadicValue<TU> Match<TV, TU>(this MonadicValue<TV> v, TypeMatcher<TU> matcher) => matcher.Match(v.Value).ToM();

        // funcs composition and partial application

        public static Func<T2> Partial<T1, T2>(this Func<T1, T2> z, T1 p) => () => z(p);

        public static Func<T2> RPartial<T1, T2>(this Func<T1, T2> z, T1 p) => () => z(p);

        public static Func<T, V> Compose<T, U, V>(this Func<U, V> f, Func<T, U> g) => x => f(g(x));
    }
}
