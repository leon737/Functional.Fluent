namespace Functional.Fluent.AutoValues
{
    public abstract class AutoValueNumericSequenceGenerator<T> : IAutoValueGenerator<T>
    {
        protected T Initial;
        protected T Min;
        protected T Max;
        protected T Step;
        protected bool Loop;


        protected AutoValueNumericSequenceGenerator(T initial, T min, T max, T step, bool loop)
        {
            Initial = initial;
            Min = min;
            Max = max;
            Step = step;
            Loop = loop;
        }

        public abstract T GetNextValue();
    }
}