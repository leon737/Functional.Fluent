using System;

namespace Functional.Fluent
{
    public class FuncState<T>
    {
        public T Invoke(Func<T> func) => func();

        public virtual T New<V>() where V : T => NewCore<V>();

        protected T NewCore<V>(params object[] parameters) where V : T => (T)Activator.CreateInstance(typeof(V), parameters);
    }

    public class FuncState<T1, T> : FuncState<T>
    {
        protected T1 P1;

        public FuncState(T1 p1)
        {
            P1 = p1;
        }

        public T Invoke(Func<T1, T> func) => func(P1);

        public override T New<V>() => NewCore<V>(P1);
    }

    public class FuncState<T1, T2, T> : FuncState<T1, T>
    {
        protected T2 P2;

        public FuncState(T1 p1, T2 p2) : base(p1)
        {
            P2 = p2;
        }

        public T Invoke(Func<T1, T2, T> func) => func(P1, P2);

        public override T New<V>()=> NewCore<V>(P1, P2);
    }

    public class FuncState<T1, T2, T3, T> : FuncState<T1, T2, T>
    {
        protected T3 P3;

        public FuncState(T1 p1, T2 p2, T3 p3) : base(p1, p2)
        {
            P3 = p3;
        }

        public T Invoke(Func<T1, T2, T3, T> func) => func(P1, P2, P3);

        public override T New<V>() => NewCore<V>(P1, P2, P3);
    }

    public class FuncState<T1, T2, T3, T4, T> : FuncState<T1, T2, T3, T>
    {
        protected T4 P4;

        public FuncState(T1 p1, T2 p2, T3 p3, T4 p4) : base(p1, p2, p3)
        {
            P4 = p4;
        }

        public T Invoke(Func<T1, T2, T3, T4, T> func) => func(P1, P2, P3, P4);

        public override T New<V>() => NewCore<V>(P1, P2, P3, P4);
    }

    public class FuncState<T1, T2, T3, T4, T5, T> : FuncState<T1, T2, T3, T4, T>
    {
        protected T5 P5;

        public FuncState(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5) : base(p1, p2, p3, p4)
        {
            P5 = p5;
        }

        public T Invoke(Func<T1, T2, T3, T4, T5, T> func) => func(P1, P2, P3, P4, P5);

        public override T New<V>() => NewCore<V>(P1, P2, P3, P4, P5);
    }
}