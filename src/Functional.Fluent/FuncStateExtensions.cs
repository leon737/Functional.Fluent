


using System;

namespace Functional.Fluent
{

	public static class FuncStateExtensions
    {

	
	public static MonadicValue<T> With<T1, T2, T>(this FuncState<T1, T2> s, Func<FuncState<T1, T2>, T> f) => new MonadicValue<T>(f(s));

	
	public static MonadicValue<T> With<T1, T2, T3, T>(this FuncState<T1, T2, T3> s, Func<FuncState<T1, T2, T3>, T> f) => new MonadicValue<T>(f(s));

	
	public static MonadicValue<T> With<T1, T2, T3, T4, T>(this FuncState<T1, T2, T3, T4> s, Func<FuncState<T1, T2, T3, T4>, T> f) => new MonadicValue<T>(f(s));

	
	public static MonadicValue<T> With<T1, T2, T3, T4, T5, T>(this FuncState<T1, T2, T3, T4, T5> s, Func<FuncState<T1, T2, T3, T4, T5>, T> f) => new MonadicValue<T>(f(s));

	
	public static MonadicValue<T> With<T1, T2, T3, T4, T5, T6, T>(this FuncState<T1, T2, T3, T4, T5, T6> s, Func<FuncState<T1, T2, T3, T4, T5, T6>, T> f) => new MonadicValue<T>(f(s));

	
	public static MonadicValue<T> With<T1, T2, T3, T4, T5, T6, T7, T>(this FuncState<T1, T2, T3, T4, T5, T6, T7> s, Func<FuncState<T1, T2, T3, T4, T5, T6, T7>, T> f) => new MonadicValue<T>(f(s));

	
	public static MonadicValue<T> With<T1, T2, T3, T4, T5, T6, T7, T8, T>(this FuncState<T1, T2, T3, T4, T5, T6, T7, T8> s, Func<FuncState<T1, T2, T3, T4, T5, T6, T7, T8>, T> f) => new MonadicValue<T>(f(s));

	
	public static MonadicValue<T> With<T1, T2, T3, T4, T5, T6, T7, T8, T9, T>(this FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9> s, Func<FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T> f) => new MonadicValue<T>(f(s));

	
	public static MonadicValue<T> With<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T>(this FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> s, Func<FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, T> f) => new MonadicValue<T>(f(s));

	
	public static MonadicValue<T> With<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T>(this FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> s, Func<FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, T> f) => new MonadicValue<T>(f(s));

	

	}

}