


using System;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Helpers
{

	public static partial class Funcs
    {
	public delegate bool OutParamsDelegate0<in T1, R>(T1 p1, out R result);
			
	public static Func<T1, Result<R>> MakeResult<T1, R>(OutParamsDelegate0<T1, R> d) => (p1) =>
        {
            R result;
            return d(p1, out result) ? Result.Success(result) : Result.Fail<R>();
        };

	public delegate bool OutParamsDelegate1<in T1, in T2, R>(T1 p1, T2 p2, out R result);
			
	public static Func<T1, T2, Result<R>> MakeResult<T1, T2, R>(OutParamsDelegate1<T1, T2, R> d) => (p1, p2) =>
        {
            R result;
            return d(p1, p2, out result) ? Result.Success(result) : Result.Fail<R>();
        };

	public delegate bool OutParamsDelegate2<in T1, in T2, in T3, R>(T1 p1, T2 p2, T3 p3, out R result);
			
	public static Func<T1, T2, T3, Result<R>> MakeResult<T1, T2, T3, R>(OutParamsDelegate2<T1, T2, T3, R> d) => (p1, p2, p3) =>
        {
            R result;
            return d(p1, p2, p3, out result) ? Result.Success(result) : Result.Fail<R>();
        };

	public delegate bool OutParamsDelegate3<in T1, in T2, in T3, in T4, R>(T1 p1, T2 p2, T3 p3, T4 p4, out R result);
			
	public static Func<T1, T2, T3, T4, Result<R>> MakeResult<T1, T2, T3, T4, R>(OutParamsDelegate3<T1, T2, T3, T4, R> d) => (p1, p2, p3, p4) =>
        {
            R result;
            return d(p1, p2, p3, p4, out result) ? Result.Success(result) : Result.Fail<R>();
        };

	public delegate bool OutParamsDelegate4<in T1, in T2, in T3, in T4, in T5, R>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, out R result);
			
	public static Func<T1, T2, T3, T4, T5, Result<R>> MakeResult<T1, T2, T3, T4, T5, R>(OutParamsDelegate4<T1, T2, T3, T4, T5, R> d) => (p1, p2, p3, p4, p5) =>
        {
            R result;
            return d(p1, p2, p3, p4, p5, out result) ? Result.Success(result) : Result.Fail<R>();
        };

	public delegate bool OutParamsDelegate5<in T1, in T2, in T3, in T4, in T5, in T6, R>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, out R result);
			
	public static Func<T1, T2, T3, T4, T5, T6, Result<R>> MakeResult<T1, T2, T3, T4, T5, T6, R>(OutParamsDelegate5<T1, T2, T3, T4, T5, T6, R> d) => (p1, p2, p3, p4, p5, p6) =>
        {
            R result;
            return d(p1, p2, p3, p4, p5, p6, out result) ? Result.Success(result) : Result.Fail<R>();
        };

	public delegate bool OutParamsDelegate6<in T1, in T2, in T3, in T4, in T5, in T6, in T7, R>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, out R result);
			
	public static Func<T1, T2, T3, T4, T5, T6, T7, Result<R>> MakeResult<T1, T2, T3, T4, T5, T6, T7, R>(OutParamsDelegate6<T1, T2, T3, T4, T5, T6, T7, R> d) => (p1, p2, p3, p4, p5, p6, p7) =>
        {
            R result;
            return d(p1, p2, p3, p4, p5, p6, p7, out result) ? Result.Success(result) : Result.Fail<R>();
        };

	public delegate bool OutParamsDelegate7<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, R>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, out R result);
			
	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, Result<R>> MakeResult<T1, T2, T3, T4, T5, T6, T7, T8, R>(OutParamsDelegate7<T1, T2, T3, T4, T5, T6, T7, T8, R> d) => (p1, p2, p3, p4, p5, p6, p7, p8) =>
        {
            R result;
            return d(p1, p2, p3, p4, p5, p6, p7, p8, out result) ? Result.Success(result) : Result.Fail<R>();
        };

	public delegate bool OutParamsDelegate8<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, R>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, out R result);
			
	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Result<R>> MakeResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, R>(OutParamsDelegate8<T1, T2, T3, T4, T5, T6, T7, T8, T9, R> d) => (p1, p2, p3, p4, p5, p6, p7, p8, p9) =>
        {
            R result;
            return d(p1, p2, p3, p4, p5, p6, p7, p8, p9, out result) ? Result.Success(result) : Result.Fail<R>();
        };

	public delegate bool OutParamsDelegate9<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, R>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, out R result);
			
	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Result<R>> MakeResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R>(OutParamsDelegate9<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, R> d) => (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) =>
        {
            R result;
            return d(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, out result) ? Result.Success(result) : Result.Fail<R>();
        };

	public delegate bool OutParamsDelegate10<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, R>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, out R result);
			
	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Result<R>> MakeResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R>(OutParamsDelegate10<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, R> d) => (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) =>
        {
            R result;
            return d(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, out result) ? Result.Success(result) : Result.Fail<R>();
        };

	public delegate bool OutParamsDelegate11<in T1, in T2, in T3, in T4, in T5, in T6, in T7, in T8, in T9, in T10, in T11, in T12, R>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10, T11 p11, T12 p12, out R result);
			
	public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Result<R>> MakeResult<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R>(OutParamsDelegate11<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, R> d) => (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) =>
        {
            R result;
            return d(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, out result) ? Result.Success(result) : Result.Fail<R>();
        };

	}
}