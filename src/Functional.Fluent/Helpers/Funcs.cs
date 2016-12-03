namespace Functional.Fluent.Helpers
{
    public static partial class Funcs
    {
        public static MonadicTypes.FuncState<T> Get<T>() => new MonadicTypes.FuncState<T>();
    }
}
