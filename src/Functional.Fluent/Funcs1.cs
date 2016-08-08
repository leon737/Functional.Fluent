


using System;

namespace Functional.Fluent
{
	public static partial class Funcs
    {

	public static Func<Void> ToVoid(this Action v) => () => { v(); return new Void(); };


	    
	
	public static FuncState<T1, T2> Get<T1, T2>(T1 p1) => new FuncState<T1, T2>(p1);


	    
	
	public static FuncState<T1, T2, T3> Get<T1, T2, T3>(T1 p1, T2 p2) => new FuncState<T1, T2, T3>(p1, p2);


	    
	
	public static FuncState<T1, T2, T3, T4> Get<T1, T2, T3, T4>(T1 p1, T2 p2, T3 p3) => new FuncState<T1, T2, T3, T4>(p1, p2, p3);


	    
	
	public static FuncState<T1, T2, T3, T4, T5> Get<T1, T2, T3, T4, T5>(T1 p1, T2 p2, T3 p3, T4 p4) => new FuncState<T1, T2, T3, T4, T5>(p1, p2, p3, p4);


	    
	
	public static FuncState<T1, T2, T3, T4, T5, T6> Get<T1, T2, T3, T4, T5, T6>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5) => new FuncState<T1, T2, T3, T4, T5, T6>(p1, p2, p3, p4, p5);


	    
	
	public static FuncState<T1, T2, T3, T4, T5, T6, T7> Get<T1, T2, T3, T4, T5, T6, T7>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6) => new FuncState<T1, T2, T3, T4, T5, T6, T7>(p1, p2, p3, p4, p5, p6);


	    
	
	public static FuncState<T1, T2, T3, T4, T5, T6, T7, T8> Get<T1, T2, T3, T4, T5, T6, T7, T8>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7) => new FuncState<T1, T2, T3, T4, T5, T6, T7, T8>(p1, p2, p3, p4, p5, p6, p7);


	    
	
	public static FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9> Get<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8) => new FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9>(p1, p2, p3, p4, p5, p6, p7, p8);


	    
	
	public static FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> Get<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9) => new FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(p1, p2, p3, p4, p5, p6, p7, p8, p9);


	    
	
	public static FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Get<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10) => new FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);


	
	    
	
	public static Func<T1, T2, Void> ToVoid<T1, T2>(this Action<T1, T2> v) => (p1, p2) => { v(p1, p2); return new Void(); };


	    
	
	public static Func<T1, T2, T3, Void> ToVoid<T1, T2, T3>(this Action<T1, T2, T3> v) => (p1, p2, p3) => { v(p1, p2, p3); return new Void(); };


	    
	
	public static Func<T1, T2, T3, T4, Void> ToVoid<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> v) => (p1, p2, p3, p4) => { v(p1, p2, p3, p4); return new Void(); };


	    
	
	public static Func<T1, T2, T3, T4, T5, Void> ToVoid<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> v) => (p1, p2, p3, p4, p5) => { v(p1, p2, p3, p4, p5); return new Void(); };


	    
	
	public static Func<T1, T2, T3, T4, T5, T6, Void> ToVoid<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> v) => (p1, p2, p3, p4, p5, p6) => { v(p1, p2, p3, p4, p5, p6); return new Void(); };


	    
	
	public static Func<T1, T2, T3, T4, T5, T6, T7, Void> ToVoid<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> v) => (p1, p2, p3, p4, p5, p6, p7) => { v(p1, p2, p3, p4, p5, p6, p7); return new Void(); };


	    
	
	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, Void> ToVoid<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> v) => (p1, p2, p3, p4, p5, p6, p7, p8) => { v(p1, p2, p3, p4, p5, p6, p7, p8); return new Void(); };


	    
	
	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Void> ToVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> v) => (p1, p2, p3, p4, p5, p6, p7, p8, p9) => { v(p1, p2, p3, p4, p5, p6, p7, p8, p9); return new Void(); };


	    
	
	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Void> ToVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> v) => (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) => { v(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10); return new Void(); };


	    
	
	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Void> ToVoid<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> v) => (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) => { v(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11); return new Void(); };


	
	}
}