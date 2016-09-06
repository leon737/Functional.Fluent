using System;

namespace Functional.Fluent.AutoValues
{
    public class AutoValueUIntegerRandomGenerator : AutoValueNumericRandomGenerator<uint>
    {
        public AutoValueUIntegerRandomGenerator() : this(uint.MinValue, uint.MaxValue) { }

        public AutoValueUIntegerRandomGenerator(uint minValue, uint maxValue) : base(minValue, maxValue) { }

        public override uint GetNextValue() => UIntegerRandom(MinValue, MaxValue);

        private uint UIntegerRandom(uint min, uint max)
        {
            byte[] buf = new byte[4];
            Random.NextBytes(buf);
            uint uintRand = BitConverter.ToUInt32(buf, 0);
            return (uint)(Math.Abs(uintRand % (max - min)) + min);
        }
    }
}