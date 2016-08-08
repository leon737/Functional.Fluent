using System;

namespace Functional.Fluent
{
    public class FuncState<T>
    {
        public T Invoke(Func<T> func) => func();

        public T Invoke(Action action)  { action(); return default(T);}

        public virtual T New<V>() where V : T => NewCore<V>();

        protected T NewCore<V>(params object[] parameters) where V : T => (T)Activator.CreateInstance(typeof(V), parameters);
    }
}