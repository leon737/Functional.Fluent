namespace Functional.Fluent.AutoValues
{
    public interface IAutoValueGenerator<out T>
    {
        T GetNextValue();
    }
}