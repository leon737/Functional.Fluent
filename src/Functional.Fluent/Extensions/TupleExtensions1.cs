


using System;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Extensions
{
	public static partial class TupleExtensions
    {

	    

	public static Tuple<T1, T2, T3> Tie<T1, T2, T3>(this Tuple<T1, T2, T3> tuple, out T1 p1, out T2 p2, out T3 p3) 
	{
				p1 = tuple.Item1;
				p2 = tuple.Item2;
				p3 = tuple.Item3;
				
		return tuple;
	}

	    

	public static Tuple<T1, T2, T3, T4> Tie<T1, T2, T3, T4>(this Tuple<T1, T2, T3, T4> tuple, out T1 p1, out T2 p2, out T3 p3, out T4 p4) 
	{
				p1 = tuple.Item1;
				p2 = tuple.Item2;
				p3 = tuple.Item3;
				p4 = tuple.Item4;
				
		return tuple;
	}

	    

	public static Tuple<T1, T2, T3, T4, T5> Tie<T1, T2, T3, T4, T5>(this Tuple<T1, T2, T3, T4, T5> tuple, out T1 p1, out T2 p2, out T3 p3, out T4 p4, out T5 p5) 
	{
				p1 = tuple.Item1;
				p2 = tuple.Item2;
				p3 = tuple.Item3;
				p4 = tuple.Item4;
				p5 = tuple.Item5;
				
		return tuple;
	}

	    

	public static Tuple<T1, T2, T3, T4, T5, T6> Tie<T1, T2, T3, T4, T5, T6>(this Tuple<T1, T2, T3, T4, T5, T6> tuple, out T1 p1, out T2 p2, out T3 p3, out T4 p4, out T5 p5, out T6 p6) 
	{
				p1 = tuple.Item1;
				p2 = tuple.Item2;
				p3 = tuple.Item3;
				p4 = tuple.Item4;
				p5 = tuple.Item5;
				p6 = tuple.Item6;
				
		return tuple;
	}

	    

	public static Tuple<T1, T2, T3, T4, T5, T6, T7> Tie<T1, T2, T3, T4, T5, T6, T7>(this Tuple<T1, T2, T3, T4, T5, T6, T7> tuple, out T1 p1, out T2 p2, out T3 p3, out T4 p4, out T5 p5, out T6 p6, out T7 p7) 
	{
				p1 = tuple.Item1;
				p2 = tuple.Item2;
				p3 = tuple.Item3;
				p4 = tuple.Item4;
				p5 = tuple.Item5;
				p6 = tuple.Item6;
				p7 = tuple.Item7;
				
		return tuple;
	}

	
	}
}