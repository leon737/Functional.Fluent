using System;

namespace Functional.Fluent.AutoValues
{

    //TODO: primitive types support: int, uint, long, ulong, decimal, float, double, string, bool, DateTime, TimeSpan

    public static class AutoValue
    {
        public static AutoValue<T> Random<T>() =>
            default(T).ToM().TypeMatch()
                .With(Case.Is<int>(), _ => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueIntegerRandomGenerator()))
                .With(Case.Is<uint>(), _ => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueUIntegerRandomGenerator()))
                .With(Case.Is<long>(), _ => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueLongRandomGenerator()))
                .With(Case.Is<ulong>(), _ => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueULongRandomGenerator()))
                .Do();

        public static AutoValue<T> Random<T>(T minValue, T maxValue) =>
            Tuple.Create(minValue, maxValue).ToM().TypeMatch()
                .With(Case.Is<Tuple<int, int>>(), v => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueIntegerRandomGenerator(v.Item1, v.Item2)))
                .With(Case.Is<Tuple<uint, uint>>(), v => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueUIntegerRandomGenerator(v.Item1, v.Item2)))
                .With(Case.Is<Tuple<long, long>>(), v => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueLongRandomGenerator(v.Item1, v.Item2)))
                .With(Case.Is<Tuple<ulong, ulong>>(), v => new AutoValue<T>((IAutoValueGenerator<T>)new AutoValueULongRandomGenerator(v.Item1, v.Item2)))
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
