using System;

namespace Functional.Fluent
{
    public partial class FuncState<T> : MonadicValue<T>
    {
        public T Invoke(Func<T> func) => func();

        public T Invoke(Action action)  { action(); return default(T);}

        public virtual T New<V>() where V : T => NewCore<V>();

        protected T NewCore<V>(params object[] parameters) where V : T => (T)Activator.CreateInstance(typeof(V), parameters);

        public virtual Func<Func<T>, T> ToFunc() => (Func<T> func) => Invoke(func);

        public virtual Func<Func<T>, T> Func => ToFunc();

        public virtual Matcher<TV, TU> Match<TV, TU>(MonadicValue<TV> value, Func<MatcherContext<TV>, Func<Func<T>, T>, Matcher<TV, TU>> f) =>
            f(value.Match(), Func);

        public virtual MaybeTypeMatcher<TV, T> TypeMatch<TV>(MonadicValue<TV> value, Func<TypeMatcherContext<TV>, Func<Func<T>, T>, MaybeTypeMatcher<TV, T>> f) =>
            f(value.TypeMatch(), Func);
    }
}