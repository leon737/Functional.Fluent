


using System;

namespace Functional.Fluent
{
	public static class MonadExtensions
    {

	    
	public static Func<T1, Func<T2, Func<T3, T4>>> Curry<T1, T2, T3, T4>(this Func<T1, T2, T3, T4> z)
    {
        return a => b => c => z(a, b, c);
    }

	    
	public static Func<T1, Func<T2, Func<T3, Func<T4, T5>>>> Curry<T1, T2, T3, T4, T5>(this Func<T1, T2, T3, T4, T5> z)
    {
        return a => b => c => d => z(a, b, c, d);
    }

	    
	public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, T6>>>>> Curry<T1, T2, T3, T4, T5, T6>(this Func<T1, T2, T3, T4, T5, T6> z)
    {
        return a => b => c => d => e => z(a, b, c, d, e);
    }

	    
	public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, T7>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7>(this Func<T1, T2, T3, T4, T5, T6, T7> z)
    {
        return a => b => c => d => e => f => z(a, b, c, d, e, f);
    }

	    
	public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, T8>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8>(this Func<T1, T2, T3, T4, T5, T6, T7, T8> z)
    {
        return a => b => c => d => e => f => g => z(a, b, c, d, e, f, g);
    }

	    
	public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, T9>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> z)
    {
        return a => b => c => d => e => f => g => h => z(a, b, c, d, e, f, g, h);
    }

	    
	public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, T10>>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> z)
    {
        return a => b => c => d => e => f => g => h => i => z(a, b, c, d, e, f, g, h, i);
    }

	    
	public static Func<T1, Func<T2, Func<T3, Func<T4, Func<T5, Func<T6, Func<T7, Func<T8, Func<T9, Func<T10, T11>>>>>>>>>> Curry<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> z)
    {
        return a => b => c => d => e => f => g => h => i => j => z(a, b, c, d, e, f, g, h, i, j);
    }

	
	public static Func<T1> ToFunc<T1>(Func<T1> f)
    {
        return f;
    }

	
	public static Func<T1, T2> ToFunc<T1, T2>(Func<T1, T2> f)
    {
        return f;
    }

	
	public static Func<T1, T2, T3> ToFunc<T1, T2, T3>(Func<T1, T2, T3> f)
    {
        return f;
    }

	
	public static Func<T1, T2, T3, T4> ToFunc<T1, T2, T3, T4>(Func<T1, T2, T3, T4> f)
    {
        return f;
    }

	
	public static Func<T1, T2, T3, T4, T5> ToFunc<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5> f)
    {
        return f;
    }

	
	public static Func<T1, T2, T3, T4, T5, T6> ToFunc<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6> f)
    {
        return f;
    }

	
	public static Func<T1, T2, T3, T4, T5, T6, T7> ToFunc<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, T7> f)
    {
        return f;
    }

	
	public static Func<T1, T2, T3, T4, T5, T6, T7, T8> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2, T3, T4, T5, T6, T7, T8> f)
    {
        return f;
    }

	
	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> f)
    {
        return f;
    }

	
	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> f)
    {
        return f;
    }

	
	}
}