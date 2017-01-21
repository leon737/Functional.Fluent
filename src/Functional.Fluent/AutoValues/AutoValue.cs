using System;
using Functional.Fluent.Extensions;
using Functional.Fluent.MonadicTypes;
using Functional.Fluent.Pattern;

namespace Functional.Fluent.AutoValues
{

    //TODO: primitive types support: int, uint, long, ulong, decimal, float, double, string, bool, DateTime, TimeSpan

    public static class AutoValue
    {
        public static AutoValue<T> Random<T>() =>
            default(T).TypeMatch()
                .With(Case.Is<int>(), _ => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueIntegerRandomGenerator()))
                .With(Case.Is<uint>(), _ => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueUIntegerRandomGenerator()))
                .With(Case.Is<long>(), _ => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueLongRandomGenerator()))
                .With(Case.Is<ulong>(), _ => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueULongRandomGenerator()))
                .Do();

        public static AutoValue<T> Random<T>(T minValue, T maxValue) =>
            Tuple.Create(minValue, maxValue).TypeMatch()
                .With(Case.Is<Tuple<int, int>>(), v => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueIntegerRandomGenerator(v.Item1, v.Item2)))
                .With(Case.Is<Tuple<uint, uint>>(), v => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueUIntegerRandomGenerator(v.Item1, v.Item2)))
                .With(Case.Is<Tuple<long, long>>(), v => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueLongRandomGenerator(v.Item1, v.Item2)))
                .With(Case.Is<Tuple<ulong, ulong>>(), v => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueULongRandomGenerator(v.Item1, v.Item2)))
                .Do();

        public static AutoValue<T> Seq<T>() =>
            default(T).TypeMatch()
                .With(Case.Is<int>(), _ => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueIntegerSequenceGenerator()))
                .Do();

        public static AutoValue<T> Seq<T>(T initial, T min, T max, T step, bool loop) =>
            Tuple.Create(initial, min, max, step, loop).TypeMatch()
                .With(Case.Is<Tuple<int, int, int, int, bool>>(), v => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueIntegerSequenceGenerator(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5)))
                .Do();
    }

    public class AutoValue<T> : MonadicValue<T>
    {

        private readonly IAutoValueGenerator<T> _generator;

        internal AutoValue(IAutoValueGenerator<T> generator )
        {
            _generator = generator;
        }

        public override T Value => _generator.GetNextValue();
    }
}
