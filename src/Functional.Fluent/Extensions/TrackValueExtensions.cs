using System;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Extensions
{
    public static class TrackValueExtensions
    {
        public static TrackValue<T> With<T>(this TrackValue<T> value, Func<T, T> func) => value == null 
            ? null 
            : new TrackValue<T>(value.Value, func(value), value.ValueTracker, true);
    }
}