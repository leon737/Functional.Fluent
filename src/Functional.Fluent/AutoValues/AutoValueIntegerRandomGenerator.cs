namespace Functional.Fluent.AutoValues
{
    public class AutoValueIntegerRandomGenerator : AutoValueNumericRandomGenerator<int>
    {
        public AutoValueIntegerRandomGenerator() : this(int.MinValue, int.MaxValue) { }

        public AutoValueIntegerRandomGenerator(int minValue, int maxValue) : base(minValue, maxValue) { }

        public override int GetNextValue() => Random.Next(MinValue, MaxValue);
    }
}