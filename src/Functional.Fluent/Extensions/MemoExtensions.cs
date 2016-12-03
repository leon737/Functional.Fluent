using System;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Extensions
{
    public static class MemoExtensions
    {

        public static MemoBuilder<T> ToMemo<T>(this T value) => new MemoBuilder<T>(value);

        public static Memo<T, V> With<T, V>(this MemoBuilder<T> value, Func<T, V> func) => new Memo<T, V>(value, func);

        public static Memo<T, R> With<T, V, R>(this Memo<T, V> value, Func<T, V, R> func) => value.ApplyFunc(func);
    }
}