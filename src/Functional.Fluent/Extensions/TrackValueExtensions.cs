using System;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Extensions
{
    public static class TrackValueExtensions
    {
        public static TrackValue<V> With<T, V>(this TrackValue<T> value, Func<T, V> func) => value == null ? null : new TrackValue<V>(func(value), true);
    }
}