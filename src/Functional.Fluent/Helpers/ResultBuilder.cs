namespace Functional.Fluent.Helpers
{
    public abstract class ResultBuilder<T>
    {
        protected T _value;

        protected bool _success;

        protected ResultBuilder(bool success)
        {
            _success = success;
        }

        protected ResultBuilder(T value) : this(true)
        {
            _value = value;
        }

    }
}