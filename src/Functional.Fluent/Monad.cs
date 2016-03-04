using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Fluent
{
    public static class Monad
    {

        public static Maybe<TResult> Select<T, TResult>(this Maybe<T> o, Func<T, TResult> evaluator)
        {
            return With(o, evaluator);
        }

        public static Maybe<TResult> SelectMany<T, T2, TResult>(this Maybe<T> a, Func<T, Maybe<T2>> func, Func<T, T2, TResult> select)
        {
            if (a == null || !a.HasValue) return Maybe<TResult>.Nothing;
            var f = func(a.Value);
            if (f == null || !f.HasValue) return Maybe<TResult>.Nothing;
            return select(a.Value, f.Value).ToMaybe();
        }

        public static Maybe<TResult> SelectMany<T, T2, TResult>(this Maybe<T> a, Func<T, T2> func, Func<T, T2, TResult> select)
        {
            if (a == null || !a.HasValue) return Maybe<TResult>.Nothing;
            var f = func(a.Value);
            if (f == null) return Maybe<TResult>.Nothing;
            return select(a.Value, f).ToMaybe();
        }


        public static Maybe<TResult> With<TInput, TResult>(this Maybe<TInput> o, Func<TInput, TResult> evaluator)
        {
            if (o == null || !o.HasValue) return Maybe<TResult>.Nothing;
            return new Maybe<TResult>(evaluator(o.Value));
        }

        public static Maybe<TResult> Return<TInput, TResult>(this Maybe<TInput> o,
            Func<TInput, TResult> evaluator, TResult failureValue)
        {
            if (o == null || !o.HasValue) return new Maybe<TResult>(failureValue);
            return new Maybe<TResult>(evaluator(o.Value));
        }

        public static Maybe<TResult> Return<TInput, TResult>(this Maybe<TInput> o,
            Func<TInput, TResult> evaluator, Func<TResult> failureValue)
        {
            if (o == null || !o.HasValue) return new Maybe<TResult>(failureValue());
            return new Maybe<TResult>(evaluator(o.Value));
        }

        public static Maybe<TInput> If<TInput>(this Maybe<TInput> o, Func<TInput, bool> evaluator)
        {
            if (o == null || !o.HasValue) return Maybe<TInput>.Nothing;
            return evaluator(o.Value) ? o : Maybe<TInput>.Nothing;
        }

        public static Maybe<TInput> Unless<TInput>(this Maybe<TInput> o, Func<TInput, bool> evaluator)
        {
            if (o == null || !o.HasValue) return Maybe<TInput>.Nothing;
            return evaluator(o.Value) ? Maybe<TInput>.Nothing : o;
        }

        public static Maybe<TInput> Do<TInput>(this Maybe<TInput> o, Action<TInput> action)
        {
            if (o == null || !o.HasValue) return Maybe<TInput>.Nothing;
            action(o.Value);
            return o;
        }

        public static Maybe<TInput> Do<TInput>(this Maybe<TInput> o, params Action<TInput>[] actions)
        {
            if (o == null || !o.HasValue) return Maybe<TInput>.Nothing;
            foreach (var action in actions)
                action(o.Value);
            return o;
        }

        public static Maybe<TInput> ApplyIf<TInput>(this Maybe<TInput> o, Func<TInput, bool> evaluator, Func<TInput, TInput> action)
        {
            if (o == null || !o.HasValue) return Maybe<TInput>.Nothing;
            return evaluator(o.Value) ? new Maybe<TInput>(action(o.Value)) : o;
        }

        public static Maybe<TInput> ApplyUnless<TInput>(this Maybe<TInput> o, Func<TInput, bool> evaluator, Func<TInput, TInput> action)
        {
            if (o == null || !o.HasValue) return Maybe<TInput>.Nothing;
            return evaluator(o.Value) ? o : new Maybe<TInput>(action(o.Value));
        }

        public static Maybe<TInput> IsNull<TInput>(this Maybe<TInput> o, Func<TInput> func)
        {
            if (o == null || !o.HasValue) return new Maybe<TInput>(func());
            return o;
        }

        public static Maybe<TOutput> SelectOne<TInput, TOutput>(this Maybe<TInput> o, params Func<Maybe<TInput>, Maybe<TOutput>>[] selectors)
        {
            foreach (var selector in selectors)
            {
                var result = selector(o);
                if (result.HasValue)
                    return result;
            }
            return Maybe<TOutput>.Nothing;
        }

        public static IEnumerable<Maybe<T>> Lift<T>(this Maybe<IEnumerable<T>> v)
        {
            return !v.HasValue ? Enumerable.Empty<Maybe<T>>() : v.Value.Select(z => z.ToMaybe());
        }

        public static IEnumerable<Maybe<T>> Lift<T>(this Maybe<IEnumerable<Maybe<T>>> v)
        {
            return !v.HasValue ? Enumerable.Empty<Maybe<T>>() : v.Value;
        }

        public static Func<T, V> Compose<T, U, V>(this Func<U, V> f, Func<T, U> g)
        {
            return x => f(g(x));
        }

        public static Func<T1, Func<T2, T3>> Curry<T1, T2, T3>(this Func<T1, T2, T3> f)
        {
            return a => b => f(a, b);
        }

        public static Func<T1, Func<T2, Func<T3, T4>>> Curry<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> f)
        {
            return a => b => c => f(a, b, c);
        }

        public static Func<T1, Func<T2, Func<T3, Func<T4, T5>>>> Curry<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> f)
        {
            return a => b => c => d => f(a, b, c, d);
        }

        public static Func<T1> ToFunc<T1>(Func<T1> f)
        {
            return f;
        }

        public static Func<T1, T2> ToFunc<T1, T2>(Func<T1, T2> f)
        {
            return f;
        }

        public static Func<T1, T2, T3> ToFunc<T1, T2, T3>(Func<T1, T2, T3> f)
        {
            return f;
        }

        public static Func<T1, T2, T3, T4> ToFunc<T1, T2, T3, T4>(Func<T1, T2, T3, T4> f)
        {
            return f;
        }

        public static Func<T1, T2, T3, T4, T5> ToFunc<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5> f)
        {
            return f;
        }

        public static Maybe<T> ToMaybe<T>(this Maybe<T> value)
        {
            return value;
        }

        public static Maybe<T> ToMaybe<T>(this T value)
        {
            return new Maybe<T>(value);
        }

        public static Maybe<IEnumerable<T>> ToMaybeNonEmpty<T>(this IEnumerable<T> value)
        {
            if (value == null || !value.Any()) return Maybe<IEnumerable<T>>.Nothing;
            return new Maybe<IEnumerable<T>>(value);
        }

        public static Maybe<TU> Map<TV, TU>(this Maybe<TV> v, Func<Maybe<TV>, TU> mapFunc)
        {
            return mapFunc(v).ToMaybe();
        }

        public static MatcherContext<TV> Match<TV>(this Maybe<TV> v)
        {
            return new MatcherContext<TV>(v);
        }

        public static TypeMatcherContext<TV> TypeMatch<TV>(this Maybe<TV> v)
        {
            return new TypeMatcherContext<TV>(v);
        }

        public static Maybe<TU> Match<TV, TU>(this Maybe<TV> v, Matcher<TV, TU> matcher)
        {
            if (v == null || !v.HasValue) return Maybe<TU>.Nothing;
            return matcher.Match(v.Value).ToMaybe();
        }

        public static Maybe<TU> Match<TV, TU>(this Maybe<TV> v, TypeMatcher<TU> matcher)
        {
            if (v == null || !v.HasValue) return Maybe<TU>.Nothing;
            return matcher.Match(v.Value).ToMaybe();
        }

    }
}
