using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.Fluent
{
    public static class Funcs
    {
        public static FuncState<T> Get<T>() => new FuncState<T>();

        public static FuncState<T1, T> Get<T1, T>(T1 p1) => new FuncState<T1, T>(p1);

        public static FuncState<T1, T2, T> Get<T1, T2, T>(T1 p1, T2 p2) => new FuncState<T1, T2, T>(p1, p2);

        public static FuncState<T1, T2, T3, T> Get<T1, T2, T3, T>(T1 p1, T2 p2, T3 p3) => new FuncState<T1, T2, T3, T>(p1, p2, p3);

        public static FuncState<T1, T2, T3, T4, T> Get<T1, T2, T3, T4, T>(T1 p1, T2 p2, T3 p3, T4 p4) => new FuncState<T1, T2, T3, T4, T>(p1, p2, p3, p4);

        public static FuncState<T1, T2, T3, T4, T5, T> Get<T1, T2, T3, T4, T5, T>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5) => new FuncState<T1, T2, T3, T4, T5, T>(p1, p2, p3, p4, p5);

        public static Func<Void> ToVoid(this Action v) => () => { v(); return new Void(); };

        public static Func<T1, Void> ToVoid<T1>(this Action<T1> v) => p1 => { v(p1); return new Void(); };

        public static Func<T1, T2, Void> ToVoid<T1, T2>(this Action<T1, T2> v) => (p1, p2) => { v(p1, p2); return new Void(); };

        public static Func<T1, T2, T3, Void> ToVoid<T1, T2, T3>(this Action<T1, T2, T3> v) => (p1, p2, p3) => { v(p1, p2, p3); return new Void(); };

        public static Func<T1, T2, T3, T4, Void> ToVoid<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> v) => (p1, p2, p3, p4) => { v(p1, p2, p3, p4); return new Void(); };

        public static Func<T1, T2, T3, T4, T5, Void> ToVoid<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> v) => (p1, p2, p3, p4, p5) => { v(p1, p2, p3, p4, p5); return new Void(); };
    }
}
