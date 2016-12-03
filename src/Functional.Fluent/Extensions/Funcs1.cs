


using System;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Extensions
{
	public static class FuncsExt
    {

	public static Func<Unit> ToUnit(this Action v) => () => { v(); return new Unit(); };


	    
	
	public static Func<T1, T2, Unit> ToUnit<T1, T2>(this Action<T1, T2> v) => (p1, p2) => { v(p1, p2); return new Unit(); };


	    
	
	public static Func<T1, T2, T3, Unit> ToUnit<T1, T2, T3>(this Action<T1, T2, T3> v) => (p1, p2, p3) => { v(p1, p2, p3); return new Unit(); };


	    
	
	public static Func<T1, T2, T3, T4, Unit> ToUnit<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> v) => (p1, p2, p3, p4) => { v(p1, p2, p3, p4); return new Unit(); };


	    
	
	public static Func<T1, T2, T3, T4, T5, Unit> ToUnit<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> v) => (p1, p2, p3, p4, p5) => { v(p1, p2, p3, p4, p5); return new Unit(); };


	    
	
	public static Func<T1, T2, T3, T4, T5, T6, Unit> ToUnit<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> v) => (p1, p2, p3, p4, p5, p6) => { v(p1, p2, p3, p4, p5, p6); return new Unit(); };


	    
	
	public static Func<T1, T2, T3, T4, T5, T6, T7, Unit> ToUnit<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> v) => (p1, p2, p3, p4, p5, p6, p7) => { v(p1, p2, p3, p4, p5, p6, p7); return new Unit(); };


	    
	
	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, Unit> ToUnit<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> v) => (p1, p2, p3, p4, p5, p6, p7, p8) => { v(p1, p2, p3, p4, p5, p6, p7, p8); return new Unit(); };


	    
	
	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Unit> ToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> v) => (p1, p2, p3, p4, p5, p6, p7, p8, p9) => { v(p1, p2, p3, p4, p5, p6, p7, p8, p9); return new Unit(); };


	    
	
	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Unit> ToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> v) => (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) => { v(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10); return new Unit(); };


	    
	
	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Unit> ToUnit<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> v) => (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) => { v(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11); return new Unit(); };


	
	}
}