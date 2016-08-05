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

        public static FuncState<T> Get<T1, T>(T1 p1) => new FuncState<T1, T>(p1);

        public static FuncState<T> Get<T1, T2, T>(T1 p1, T2 p2) => new FuncState<T1, T2, T>(p1, p2);

        public static FuncState<T> Get<T1, T2, T3, T>(T1 p1, T2 p2, T3 p3) => new FuncState<T1, T2, T3, T>(p1, p2, p3);

        public static FuncState<T> Get<T1, T2, T3, T4, T>(T1 p1, T2 p2, T3 p3, T4 p4) => new FuncState<T1, T2, T3, T4, T>(p1, p2, p3, p4);

        public static FuncState<T> Get<T1, T2, T3, T4, T5, T>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5) => new FuncState<T1, T2, T3, T4, T5, T>(p1, p2, p3, p4, p5);
    }
}
