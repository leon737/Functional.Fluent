using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Fluent
{
    public static class MaybeMonadExtensions
    {

        public static Maybe<TResult> Select<T, TResult>(this Maybe<T> o, Func<T, TResult> evaluator) => With(o, evaluator);

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

        public static Maybe<TResult> With<TInput, TResult>(this Maybe<TInput> o, Func<TInput, TResult> evaluator) => 
            o == null || !o.HasValue ? Maybe<TResult>.Nothing : new Maybe<TResult>(evaluator(o.Value));

        public static MaybeEnumerable<TResult> With<TInput, TResult>(this MaybeEnumerable<TInput> o, Func<TInput, TResult> evaluator) => 
            o == null || !o.HasValue
            ? MaybeEnumerable<TResult>.Empty
            : new MaybeEnumerableApplicator<TInput, TResult>(o, evaluator);

        public static Maybe<TResult> Return<TInput, TResult>(this Maybe<TInput> o,
            Func<TInput, TResult> evaluator, TResult failureValue) => 
            o == null || !o.HasValue ? new Maybe<TResult>(failureValue) : new Maybe<TResult>(evaluator(o.Value));

        public static MaybeEnumerable<TResult> Return<TInput, TResult>(this MaybeEnumerable<TInput> o,
            Func<TInput, TResult> evaluator, TResult failureValue) => 
            o == null || !o.HasValue
                ? MaybeEnumerable<TResult>.Empty
                : new MaybeEnumerableApplicator<TInput, TResult>(o, evaluator, () => failureValue);

        public static Maybe<TResult> Return<TInput, TResult>(this Maybe<TInput> o,
            Func<TInput, TResult> evaluator, Func<TResult> failureValue) => 
            o == null || !o.HasValue
                ? new Maybe<TResult>(failureValue())
                : new Maybe<TResult>(evaluator(o.Value));

        public static MaybeEnumerable<TResult> Return<TInput, TResult>(this MaybeEnumerable<TInput> o,
            Func<TInput, TResult> evaluator, Func<TResult> failureValue) => 
            o == null || !o.HasValue
                ? MaybeEnumerable<TResult>.Empty
                : new MaybeEnumerableApplicator<TInput, TResult>(o, evaluator, failureValue);

        public static Maybe<TInput> If<TInput>(this Maybe<TInput> o, Func<TInput, bool> evaluator) => 
            o == null || !o.HasValue ? Maybe<TInput>.Nothing : (evaluator(o.Value) ? o : Maybe<TInput>.Nothing);

        public static Maybe<TInput> Unless<TInput>(this Maybe<TInput> o, Func<TInput, bool> evaluator) => 
            o == null || !o.HasValue ? Maybe<TInput>.Nothing : (evaluator(o.Value) ? Maybe<TInput>.Nothing : o);

        public static Maybe<TInput> Do<TInput>(this Maybe<TInput> o, Action<TInput> action)
        {
            if (o == null || !o.HasValue) return Maybe<TInput>.Nothing;
            action(o.Value);
            return o;
        }

        public static MaybeEnumerable<TInput> Do<TInput>(this MaybeEnumerable<TInput> o, Action<TInput> action)
        {
            if (o == null || !o.HasValue) return MaybeEnumerable<TInput>.Empty;
            foreach (var e in o.Where(e => e.HasValue))
                action(e.Value);
            return o;
        }

        public static Maybe<TInput> Do<TInput>(this Maybe<TInput> o, params Action<TInput>[] actions)
        {
            if (o == null || !o.HasValue) return Maybe<TInput>.Nothing;
            foreach (var action in actions)
                action(o.Value);
            return o;
        }

        public static MaybeEnumerable<TInput> Do<TInput>(this MaybeEnumerable<TInput> o, params Action<TInput>[] actions)
        {
            if (o == null || !o.HasValue) return MaybeEnumerable<TInput>.Empty;
            foreach (var action in actions)
                foreach (var e in o.Where(e => e.HasValue))
                    action(e.Value);
            return o;
        }

        public static Maybe<TInput> ApplyIf<TInput>(this Maybe<TInput> o, Func<TInput, bool> evaluator, Func<TInput, TInput> action) => 
            o == null || !o.HasValue
            ? Maybe<TInput>.Nothing
            : (evaluator(o.Value) ? new Maybe<TInput>(action(o.Value)) : o);

        public static MaybeEnumerable<TInput> ApplyIf<TInput>(this MaybeEnumerable<TInput> o, Func<TInput, bool> evaluator, Func<TInput, TInput> action) => 
            o == null || !o.HasValue
            ? MaybeEnumerable<TInput>.Empty
            : new MaybeEnumerableConditionalApplicator<TInput>(o, evaluator, action);

        public static Maybe<TInput> ApplyUnless<TInput>(this Maybe<TInput> o, Func<TInput, bool> evaluator, Func<TInput, TInput> action) => 
            o == null || !o.HasValue
            ? Maybe<TInput>.Nothing
            : (evaluator(o.Value) ? o : new Maybe<TInput>(action(o.Value)));

        public static MaybeEnumerable<TInput> ApplyUnless<TInput>(this MaybeEnumerable<TInput> o, Func<TInput, bool> evaluator, Func<TInput, TInput> action) 
            => o == null || !o.HasValue
            ? MaybeEnumerable<TInput>.Empty
            : new MaybeEnumerableConditionalApplicator<TInput>(o, evaluator, action, true);

        public static Maybe<TInput> IsNull<TInput>(this Maybe<TInput> o, Func<TInput> func) => 
            o == null || !o.HasValue ? new Maybe<TInput>(func()) : o;

        public static Maybe<TInput> IsNull<TInput>(this Maybe<TInput> o, TInput defaultValue) => 
            o == null || !o.HasValue ? new Maybe<TInput>(defaultValue) : o;

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

        public static IEnumerable<Maybe<T>> Lift<T>(this Maybe<IEnumerable<T>> v) => 
            !v.HasValue ? Enumerable.Empty<Maybe<T>>() : v.Value.Select(z => z.ToMaybe());

        public static IEnumerable<Maybe<T>> Lift<T>(this Maybe<IEnumerable<Maybe<T>>> v) => 
            !v.HasValue ? Enumerable.Empty<Maybe<T>>() : v.Value;

        public static Maybe<T> ToMaybe<T>(this Maybe<T> value) => value;

        public static Maybe<T> ToMaybe<T>(this MonadicValue<T> value) => new Maybe<T>(value.Value);

        public static Maybe<T> ToMaybe<T>(this Result<T> value) => 
            value.IsSucceed ? new Maybe<T>(value.Value) : Maybe<T>.Nothing;

        public static Maybe<T> ToMaybe<T>(this T value) => new Maybe<T>(value);

        public static MaybeEnumerable<T> ToMaybe<T>(this IEnumerable<T> value) => new MaybeEnumerable<T>(value);

        public static MaybeEnumerable<T> ToMaybe<T>(this IEnumerable<Maybe<T>> value) => new MaybeEnumerable<T>(value);

        public static Maybe<T> ToMaybe<T>(this T value, T defaultValue) => new Maybe<T>(value).IsNull(defaultValue);

        public static Maybe<T> ToMaybe<T>(this T value, Func<T> defaultValue) => new Maybe<T>(value).IsNull(defaultValue);

        public static Result<T> ToResult<T>(this Maybe<T> value)
            => value?.HasValue ?? false ? Result.Success(value.Value) : Result.Fail<T>();
        
        public static Maybe<IEnumerable<T>> ToMaybeNonEmpty<T>(this IEnumerable<T> value)
        {
            if (value == null || !value.Any()) return Maybe<IEnumerable<T>>.Nothing;
            return new Maybe<IEnumerable<T>>(value);
        }

        public static Maybe<TU> Map<TV, TU>(this Maybe<TV> v, Func<Maybe<TV>, TU> mapFunc)
        {
            return mapFunc(v).ToMaybe();
        }
        
        public static ListMatcherContext<TV> Match<TV>(this MaybeEnumerable<TV> v)
        {
            return new ListMatcherContext<TV>(v.Value.Select(x => x.Value).ToMaybeNonEmpty());
        }        
    }
}
