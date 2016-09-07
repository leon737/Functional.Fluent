using System;

namespace Functional.Fluent.AutoValues
{
    public class AutoValueIntegerSequenceGenerator : AutoValueNumericSequenceGenerator<int>
    {
        public AutoValueIntegerSequenceGenerator() : this(0, int.MinValue, int.MaxValue, 1, true) { }

        public AutoValueIntegerSequenceGenerator(int initial, int min, int max, int step, bool loop) : base(initial, min, max, step, loop) { }

        public override int GetNextValue()
        {
            int result = Initial;
            if (Step > 0)
            {
                if (Initial + Step > Max || Max - Step < Initial)
                {
                    if (Loop)
                        Initial = Min;
                    else
                        throw new ArgumentOutOfRangeException();
                }
                else
                {
                    Initial += Step;
                }
            }

            if (Step < 0)
            {
                if (Initial + Step < Min || Min - Step > Initial)
                {
                    if (Loop)
                        Initial = Max;
                    else
                        throw new ArgumentOutOfRangeException();
                }
                else
                    Initial += Step;
            }
            return result;
        }
    }
}