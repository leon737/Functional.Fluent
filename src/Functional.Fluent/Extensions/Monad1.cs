


using System;

namespace Functional.Fluent.Extensions
{
	public static class FuncExtensions
    {

	    
	public static Func<T1, Func<T2, T3>> Curry<T1, T2, T3>(this Func<T1, T2, T3> z) => a => b => z(a, b);
    
	public static Func<T2, Func<T1, T3>> Rcurry<T1, T2, T3>(this Func<T1, T2, T3> z) => b => a => z(a, b);

	public static Func<T2, T3> Partial<T1, T2, T3>(this Func<T1, T2, T3> z, T1 p) => (a) => z(p, a);

	public static Func<T1, T3> RPartial<T1, T2, T3>(this Func<T1, T2, T3> z, T2 p) => (a) => z(a, p);
	
	    
	public static Func<T1, Func<T2, Func<T3, T4>>> Curry<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> z) => a => b => c => z(a, b, c);
    
	public static Func<T3, Func<T2, Func<T1, T4>>> Rcurry<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> z) => c => b => a => z(a, b, c);

	public static Func<T2, T3, T4> Partial<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> z, T1 p) => (a , b) => z(p, a, b);

	public static Func<T1, T2, T4> RPartial<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> z, T3 p) => (a , b) => z(a, b, p);
	
	    
	public static Func<T1, Func<T2, Func<T3, Func<T4, T5>>>> Curry<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> z) => a => b => c => d => z(a, b, c, d);
    
	public static Func<T4, Func<T3, Func<T2, Func<T1, T5>>>> Rcurry<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> z) => d => c => b => a => z(a, b, c, d);

	public static Func<T2, T3, T4, T5> Partial<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> z, T1 p) => (a , b , c) => z(p, a, b, c);

	public static Func<T1, T2, T3, T5> RPartial<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> z, T4 p) => (a , b , c) => z(a, b, c, p);
	
	    
	public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, T6>>>>> Curry<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> z) => a => b => c => d => e => z(a, b, c, d, e);
    
	public static Func<T5, Func<T4, Func<T3, Func<T2, Func<T1, T6>>>>> Rcurry<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> z) => e => d => c => b => a => z(a, b, c, d, e);

	public static Func<T2, T3, T4, T5, T6> Partial<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> z, T1 p) => (a , b , c , d) => z(p, a, b, c, d);

	public static Func<T1, T2, T3, T4, T6> RPartial<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> z, T5 p) => (a , b , c , d) => z(a, b, c, d, p);
	
	    
	public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, T7>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> z) => a => b => c => d => e => f => z(a, b, c, d, e, f);
    
	public static Func<T6, Func<T5, Func<T4, Func<T3, Func<T2, Func<T1, T7>>>>>> Rcurry<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> z) => f => e => d => c => b => a => z(a, b, c, d, e, f);

	public static Func<T2, T3, T4, T5, T6, T7> Partial<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> z, T1 p) => (a , b , c , d , e) => z(p, a, b, c, d, e);

	public static Func<T1, T2, T3, T4, T5, T7> RPartial<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> z, T6 p) => (a , b , c , d , e) => z(a, b, c, d, e, p);
	
	    
	public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, T8>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> z) => a => b => c => d => e => f => g => z(a, b, c, d, e, f, g);
    
	public static Func<T7, Func<T6, Func<T5, Func<T4, Func<T3, Func<T2, Func<T1, T8>>>>>>> Rcurry<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> z) => g => f => e => d => c => b => a => z(a, b, c, d, e, f, g);

	public static Func<T2, T3, T4, T5, T6, T7, T8> Partial<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> z, T1 p) => (a , b , c , d , e , f) => z(p, a, b, c, d, e, f);

	public static Func<T1, T2, T3, T4, T5, T6, T8> RPartial<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> z, T7 p) => (a , b , c , d , e , f) => z(a, b, c, d, e, f, p);
	
	    
	public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, T9>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> z) => a => b => c => d => e => f => g => h => z(a, b, c, d, e, f, g, h);
    
	public static Func<T8, Func<T7, Func<T6, Func<T5, Func<T4, Func<T3, Func<T2, Func<T1, T9>>>>>>>> Rcurry<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> z) => h => g => f => e => d => c => b => a => z(a, b, c, d, e, f, g, h);

	public static Func<T2, T3, T4, T5, T6, T7, T8, T9> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> z, T1 p) => (a , b , c , d , e , f , g) => z(p, a, b, c, d, e, f, g);

	public static Func<T1, T2, T3, T4, T5, T6, T7, T9> RPartial<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> z, T8 p) => (a , b , c , d , e , f , g) => z(a, b, c, d, e, f, g, p);
	
	    
	public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, T10>>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> z) => a => b => c => d => e => f => g => h => i => z(a, b, c, d, e, f, g, h, i);
    
	public static Func<T9, Func<T8, Func<T7, Func<T6, Func<T5, Func<T4, Func<T3, Func<T2, Func<T1, T10>>>>>>>>> Rcurry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> z) => i => h => g => f => e => d => c => b => a => z(a, b, c, d, e, f, g, h, i);

	public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> z, T1 p) => (a , b , c , d , e , f , g , h) => z(p, a, b, c, d, e, f, g, h);

	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T10> RPartial<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> z, T9 p) => (a , b , c , d , e , f , g , h) => z(a, b, c, d, e, f, g, h, p);
	
	    
	public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, T11>>>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> z) => a => b => c => d => e => f => g => h => i => j => z(a, b, c, d, e, f, g, h, i, j);
    
	public static Func<T10, Func<T9, Func<T8, Func<T7, Func<T6, Func<T5, Func<T4, Func<T3, Func<T2, Func<T1, T11>>>>>>>>>> Rcurry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> z) => j => i => h => g => f => e => d => c => b => a => z(a, b, c, d, e, f, g, h, i, j);

	public static Func<T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> Partial<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> z, T1 p) => (a , b , c , d , e , f , g , h , i) => z(p, a, b, c, d, e, f, g, h, i);

	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T11> RPartial<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> z, T10 p) => (a , b , c , d , e , f , g , h , i) => z(a, b, c, d, e, f, g, h, i, p);
	
	
	}
}