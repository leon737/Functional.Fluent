


using System;
using Functional.Fluent.MonadicTypes;
using Functional.Fluent.Pattern;

namespace Functional.Fluent.Extensions
{

	public static class FuncStateExtensions
    {

	
	public static MonadicValue<T> With<T1, T2, T>(this FuncState<T1, T2> s, Func<FuncState<T1, T2>, T> f) => new MonadicValue<T>(f(s));

	public static Matcher<TV, TU> Match<TV, TU, T1, T2>(this FuncState<T1, T2> s, 
		MonadicValue<TV> value, Func<MatcherContext<TV>, Func<Func<T1, T2>, T2>, Matcher<TV, TU>> f) =>  f(value.Match(), s.Func);

	public static MaybeTypeMatcher<TV, T2> TypeMatch<TV, T1, T2>(this FuncState<T1, T2> s, 
		MonadicValue<TV> value, Func<TypeMatcherContext<TV>, Func<Func<T1, T2>, T2>, MaybeTypeMatcher<TV, T2>> f) =>  f(value.TypeMatch(), s.Func);

	
	public static MonadicValue<T> With<T1, T2, T3, T>(this FuncState<T1, T2, T3> s, Func<FuncState<T1, T2, T3>, T> f) => new MonadicValue<T>(f(s));

	public static Matcher<TV, TU> Match<TV, TU, T1, T2, T3>(this FuncState<T1, T2, T3> s, 
		MonadicValue<TV> value, Func<MatcherContext<TV>, Func<Func<T1, T2, T3>, T3>, Matcher<TV, TU>> f) =>  f(value.Match(), s.Func);

	public static MaybeTypeMatcher<TV, T3> TypeMatch<TV, T1, T2, T3>(this FuncState<T1, T2, T3> s, 
		MonadicValue<TV> value, Func<TypeMatcherContext<TV>, Func<Func<T1, T2, T3>, T3>, MaybeTypeMatcher<TV, T3>> f) =>  f(value.TypeMatch(), s.Func);

	
	public static MonadicValue<T> With<T1, T2, T3, T4, T>(this FuncState<T1, T2, T3, T4> s, Func<FuncState<T1, T2, T3, T4>, T> f) => new MonadicValue<T>(f(s));

	public static Matcher<TV, TU> Match<TV, TU, T1, T2, T3, T4>(this FuncState<T1, T2, T3, T4> s, 
		MonadicValue<TV> value, Func<MatcherContext<TV>, Func<Func<T1, T2, T3, T4>, T4>, Matcher<TV, TU>> f) =>  f(value.Match(), s.Func);

	public static MaybeTypeMatcher<TV, T4> TypeMatch<TV, T1, T2, T3, T4>(this FuncState<T1, T2, T3, T4> s, 
		MonadicValue<TV> value, Func<TypeMatcherContext<TV>, Func<Func<T1, T2, T3, T4>, T4>, MaybeTypeMatcher<TV, T4>> f) =>  f(value.TypeMatch(), s.Func);

	
	public static MonadicValue<T> With<T1, T2, T3, T4, T5, T>(this FuncState<T1, T2, T3, T4, T5> s, Func<FuncState<T1, T2, T3, T4, T5>, T> f) => new MonadicValue<T>(f(s));

	public static Matcher<TV, TU> Match<TV, TU, T1, T2, T3, T4, T5>(this FuncState<T1, T2, T3, T4, T5> s, 
		MonadicValue<TV> value, Func<MatcherContext<TV>, Func<Func<T1, T2, T3, T4, T5>, T5>, Matcher<TV, TU>> f) =>  f(value.Match(), s.Func);

	public static MaybeTypeMatcher<TV, T5> TypeMatch<TV, T1, T2, T3, T4, T5>(this FuncState<T1, T2, T3, T4, T5> s, 
		MonadicValue<TV> value, Func<TypeMatcherContext<TV>, Func<Func<T1, T2, T3, T4, T5>, T5>, MaybeTypeMatcher<TV, T5>> f) =>  f(value.TypeMatch(), s.Func);

	
	public static MonadicValue<T> With<T1, T2, T3, T4, T5, T6, T>(this FuncState<T1, T2, T3, T4, T5, T6> s, Func<FuncState<T1, T2, T3, T4, T5, T6>, T> f) => new MonadicValue<T>(f(s));

	public static Matcher<TV, TU> Match<TV, TU, T1, T2, T3, T4, T5, T6>(this FuncState<T1, T2, T3, T4, T5, T6> s, 
		MonadicValue<TV> value, Func<MatcherContext<TV>, Func<Func<T1, T2, T3, T4, T5, T6>, T6>, Matcher<TV, TU>> f) =>  f(value.Match(), s.Func);

	public static MaybeTypeMatcher<TV, T6> TypeMatch<TV, T1, T2, T3, T4, T5, T6>(this FuncState<T1, T2, T3, T4, T5, T6> s, 
		MonadicValue<TV> value, Func<TypeMatcherContext<TV>, Func<Func<T1, T2, T3, T4, T5, T6>, T6>, MaybeTypeMatcher<TV, T6>> f) =>  f(value.TypeMatch(), s.Func);

	
	public static MonadicValue<T> With<T1, T2, T3, T4, T5, T6, T7, T>(this FuncState<T1, T2, T3, T4, T5, T6, T7> s, Func<FuncState<T1, T2, T3, T4, T5, T6, T7>, T> f) => new MonadicValue<T>(f(s));

	public static Matcher<TV, TU> Match<TV, TU, T1, T2, T3, T4, T5, T6, T7>(this FuncState<T1, T2, T3, T4, T5, T6, T7> s, 
		MonadicValue<TV> value, Func<MatcherContext<TV>, Func<Func<T1, T2, T3, T4, T5, T6, T7>, T7>, Matcher<TV, TU>> f) =>  f(value.Match(), s.Func);

	public static MaybeTypeMatcher<TV, T7> TypeMatch<TV, T1, T2, T3, T4, T5, T6, T7>(this FuncState<T1, T2, T3, T4, T5, T6, T7> s, 
		MonadicValue<TV> value, Func<TypeMatcherContext<TV>, Func<Func<T1, T2, T3, T4, T5, T6, T7>, T7>, MaybeTypeMatcher<TV, T7>> f) =>  f(value.TypeMatch(), s.Func);

	
	public static MonadicValue<T> With<T1, T2, T3, T4, T5, T6, T7, T8, T>(this FuncState<T1, T2, T3, T4, T5, T6, T7, T8> s, Func<FuncState<T1, T2, T3, T4, T5, T6, T7, T8>, T> f) => new MonadicValue<T>(f(s));

	public static Matcher<TV, TU> Match<TV, TU, T1, T2, T3, T4, T5, T6, T7, T8>(this FuncState<T1, T2, T3, T4, T5, T6, T7, T8> s, 
		MonadicValue<TV> value, Func<MatcherContext<TV>, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8>, T8>, Matcher<TV, TU>> f) =>  f(value.Match(), s.Func);

	public static MaybeTypeMatcher<TV, T8> TypeMatch<TV, T1, T2, T3, T4, T5, T6, T7, T8>(this FuncState<T1, T2, T3, T4, T5, T6, T7, T8> s, 
		MonadicValue<TV> value, Func<TypeMatcherContext<TV>, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8>, T8>, MaybeTypeMatcher<TV, T8>> f) =>  f(value.TypeMatch(), s.Func);

	
	public static MonadicValue<T> With<T1, T2, T3, T4, T5, T6, T7, T8, T9, T>(this FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9> s, Func<FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T> f) => new MonadicValue<T>(f(s));

	public static Matcher<TV, TU> Match<TV, TU, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9> s, 
		MonadicValue<TV> value, Func<MatcherContext<TV>, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T9>, Matcher<TV, TU>> f) =>  f(value.Match(), s.Func);

	public static MaybeTypeMatcher<TV, T9> TypeMatch<TV, T1, T2, T3, T4, T5, T6, T7, T8, T9>(this FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9> s, 
		MonadicValue<TV> value, Func<TypeMatcherContext<TV>, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T9>, MaybeTypeMatcher<TV, T9>> f) =>  f(value.TypeMatch(), s.Func);

	
	public static MonadicValue<T> With<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T>(this FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> s, Func<FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, T> f) => new MonadicValue<T>(f(s));

	public static Matcher<TV, TU> Match<TV, TU, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> s, 
		MonadicValue<TV> value, Func<MatcherContext<TV>, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, T10>, Matcher<TV, TU>> f) =>  f(value.Match(), s.Func);

	public static MaybeTypeMatcher<TV, T10> TypeMatch<TV, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> s, 
		MonadicValue<TV> value, Func<TypeMatcherContext<TV>, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, T10>, MaybeTypeMatcher<TV, T10>> f) =>  f(value.TypeMatch(), s.Func);

	
	public static MonadicValue<T> With<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T>(this FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> s, Func<FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, T> f) => new MonadicValue<T>(f(s));

	public static Matcher<TV, TU> Match<TV, TU, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> s, 
		MonadicValue<TV> value, Func<MatcherContext<TV>, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, T11>, Matcher<TV, TU>> f) =>  f(value.Match(), s.Func);

	public static MaybeTypeMatcher<TV, T11> TypeMatch<TV, T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> s, 
		MonadicValue<TV> value, Func<TypeMatcherContext<TV>, Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, T11>, MaybeTypeMatcher<TV, T11>> f) =>  f(value.TypeMatch(), s.Func);

	

	}

}