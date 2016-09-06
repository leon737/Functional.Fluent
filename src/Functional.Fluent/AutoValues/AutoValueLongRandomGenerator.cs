using System;

namespace Functional.Fluent.AutoValues
{
    public class AutoValueLongRandomGenerator : AutoValueNumericRandomGenerator<long>
    {
        public AutoValueLongRandomGenerator() : this(long.MinValue, long.MaxValue) { }

        public AutoValueLongRandomGenerator(long minValue, long maxValue) : base(minValue, maxValue) { }

        public override long GetNextValue() => LongRandom(MinValue, MaxValue);

        private long LongRandom(long min, long max)
        {
            byte[] buf = new byte[8];
            Random.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);
            return (Math.Abs(longRand % (max - min)) + min);
        }
    }
}