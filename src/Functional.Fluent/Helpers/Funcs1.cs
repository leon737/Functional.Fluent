


using System;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Helpers
{
	public static partial class Funcs
    {


	    
	
	public static FuncState<T1, T2> Get<T1, T2>(T1 p1) => new FuncState<T1, T2>(p1);

	public static Func<T1, T2> F<T1, T2>(Func<T1, T2> f) => f;


	    
	
	public static FuncState<T1, T2, T3> Get<T1, T2, T3>(T1 p1, T2 p2) => new FuncState<T1, T2, T3>(p1, p2);

	public static Func<T1, T2, T3> F<T1, T2, T3>(Func<T1, T2, T3> f) => f;


	    
	
	public static FuncState<T1, T2, T3, T4> Get<T1, T2, T3, T4>(T1 p1, T2 p2, T3 p3) => new FuncState<T1, T2, T3, T4>(p1, p2, p3);

	public static Func<T1, T2, T3, T4> F<T1, T2, T3, T4>(Func<T1, T2, T3, T4> f) => f;


	    
	
	public static FuncState<T1, T2, T3, T4, T5> Get<T1, T2, T3, T4, T5>(T1 p1, T2 p2, T3 p3, T4 p4) => new FuncState<T1, T2, T3, T4, T5>(p1, p2, p3, p4);

	public static Func<T1, T2, T3, T4, T5> F<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5> f) => f;


	    
	
	public static FuncState<T1, T2, T3, T4, T5, T6> Get<T1, T2, T3, T4, T5, T6>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5) => new FuncState<T1, T2, T3, T4, T5, T6>(p1, p2, p3, p4, p5);

	public static Func<T1, T2, T3, T4, T5, T6> F<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6> f) => f;


	    
	
	public static FuncState<T1, T2, T3, T4, T5, T6, T7> Get<T1, T2, T3, T4, T5, T6, T7>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6) => new FuncState<T1, T2, T3, T4, T5, T6, T7>(p1, p2, p3, p4, p5, p6);

	public static Func<T1, T2, T3, T4, T5, T6, T7> F<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7> f) => f;


	    
	
	public static FuncState<T1, T2, T3, T4, T5, T6, T7, T8> Get<T1, T2, T3, T4, T5, T6, T7, T8>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7) => new FuncState<T1, T2, T3, T4, T5, T6, T7, T8>(p1, p2, p3, p4, p5, p6, p7);

	public static Func<T1, T2, T3, T4, T5, T6, T7, T8> F<T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2, T3, T4, T5, T6, T7, T8> f) => f;


	    
	
	public static FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9> Get<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8) => new FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9>(p1, p2, p3, p4, p5, p6, p7, p8);

	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> F<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> f) => f;


	    
	
	public static FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Get<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9) => new FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(p1, p2, p3, p4, p5, p6, p7, p8, p9);

	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> f) => f;


	    
	
	public static FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Get<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10) => new FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);

	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> F<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> f) => f;


		

	}
}