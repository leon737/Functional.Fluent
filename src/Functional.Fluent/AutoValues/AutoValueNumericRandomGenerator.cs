using System;

namespace Functional.Fluent.AutoValues
{
    public abstract class AutoValueNumericRandomGenerator<T> : IAutoValueGenerator<T>
    {
        protected Random Random;
        protected T MinValue;
        protected T MaxValue;
        

        protected AutoValueNumericRandomGenerator(T minValue, T maxValue) 
        {
            Random = new Random();
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public abstract T GetNextValue();
    }
}