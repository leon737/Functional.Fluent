using System;
using System.Collections.Generic;
using System.Linq;
using Functional.Fluent.MonadicTypes;
using Functional.Fluent.Pattern;

namespace Functional.Fluent.Extensions
{
    public static partial class MonadicValueExtensions
    {

        public static MonadicValue<TResult> Bind<TInput, TResult>(this MonadicValue<TInput> o, Func<TInput, MonadicValue<TResult>> f) => f(o.Value);

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

        public static MonadicValue<TInput> Map<TInput>(this MonadicValue<TInput> o, params Func<TInput, TInput>[] funcs)
        {
            var result = o;
            foreach (var func in funcs)
                result = func(result);
            return result;
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

       // funcs composition and partial application

        public static Func<T2> Partial<T1, T2>(this Func<T1, T2> z, T1 p) => () => z(p);

        public static Func<T2> RPartial<T1, T2>(this Func<T1, T2> z, T1 p) => () => z(p);

        public static Func<T, V> RCompose<T, U, V>(this Func<U, V> f, Func<T, U> g) => x => f(g(x));

        public static Func<T, V> Compose<T, U, V>(this Func<T, U> f, Func<U, V> g) => x => g(f(x));

        public static T UnwrapAll<T>(this object value)
        {
            while (true)
            {
                var type = value.GetType();

                if (type == typeof(T))
                    return (T) value;

                if (!type.IsGenericType || typeof(MonadicValue<>).IsAssignableFrom(type)) throw new InvalidCastException();

                value = type.GetProperty(nameof(MonadicValue<object>.Value)).GetValue(value);
            }
        }
    }
}
