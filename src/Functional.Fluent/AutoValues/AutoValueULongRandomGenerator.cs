using System;

namespace Functional.Fluent.AutoValues
{
    public class AutoValueULongRandomGenerator : AutoValueNumericRandomGenerator<ulong>
    {
        public AutoValueULongRandomGenerator() : this(ulong.MinValue, ulong.MaxValue) { }

        public AutoValueULongRandomGenerator(ulong minValue, ulong maxValue) : base(minValue, maxValue) { }

        public override ulong GetNextValue() => ULongRandom(MinValue, MaxValue);

        private ulong ULongRandom(ulong min, ulong max)
        {
            byte[] buf = new byte[8];
            Random.NextBytes(buf);
            long ulongRand = BitConverter.ToInt64(buf, 0);
            return (ulong)(Math.Abs(ulongRand % ((double)max - (double)min)) + (double)min);
        }
    }
}