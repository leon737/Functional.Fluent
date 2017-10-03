using System;

namespace Functional.Fluent.Extensions
{
    public static partial class TupleExtensions
    {
        public static Tuple<T1, T2> Tie<T1, T2>(this Tuple<T1, T2> tuple, out T1 p1, out T2 p2)
        {
            p1 = tuple.Item1;
            p2 = tuple.Item2;
            return tuple;
        }
    }
}