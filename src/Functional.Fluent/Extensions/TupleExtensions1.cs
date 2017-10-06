


using System;
using Functional.Fluent.MonadicTypes;
using System.Linq.Expressions;
using System.Reflection;
using Functional.Fluent.Pattern;

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

	public static Tuple<T1, T2, T3> Tie<T1, T2, T3, TTarget>(this Tuple<T1, T2, T3> tuple, TTarget target,  Expression<Func<TTarget, T1>> member1 ,   Expression<Func<TTarget, T2>> member2 ,   Expression<Func<TTarget, T3>> member3  ) 
	{
		            (member1.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item1))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item1))
                .Do();
		            (member2.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item2))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item2))
                .Do();
		            (member3.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item3))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item3))
                .Do();
				
		return tuple;
	}

	public static Tuple<T1, T2, T3> Tie<T1, T2, T3,  TTarget1 ,     TTarget2 ,     TTarget3    >(this Tuple<T1, T2, T3> tuple,  TTarget1 target1, Expression<Func<TTarget1, T1>> member1 ,   TTarget2 target2, Expression<Func<TTarget2, T2>> member2 ,   TTarget3 target3, Expression<Func<TTarget3, T3>> member3  ) 
	{
		            (member1.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target1, v, tuple.Item1))
                .With(Case.Is<FieldInfo>(), v => SetValue(target1, v, tuple.Item1))
                .Do();
		            (member2.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target2, v, tuple.Item2))
                .With(Case.Is<FieldInfo>(), v => SetValue(target2, v, tuple.Item2))
                .Do();
		            (member3.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target3, v, tuple.Item3))
                .With(Case.Is<FieldInfo>(), v => SetValue(target3, v, tuple.Item3))
                .Do();
				
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

	public static Tuple<T1, T2, T3, T4> Tie<T1, T2, T3, T4, TTarget>(this Tuple<T1, T2, T3, T4> tuple, TTarget target,  Expression<Func<TTarget, T1>> member1 ,   Expression<Func<TTarget, T2>> member2 ,   Expression<Func<TTarget, T3>> member3 ,   Expression<Func<TTarget, T4>> member4  ) 
	{
		            (member1.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item1))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item1))
                .Do();
		            (member2.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item2))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item2))
                .Do();
		            (member3.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item3))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item3))
                .Do();
		            (member4.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item4))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item4))
                .Do();
				
		return tuple;
	}

	public static Tuple<T1, T2, T3, T4> Tie<T1, T2, T3, T4,  TTarget1 ,     TTarget2 ,     TTarget3 ,     TTarget4    >(this Tuple<T1, T2, T3, T4> tuple,  TTarget1 target1, Expression<Func<TTarget1, T1>> member1 ,   TTarget2 target2, Expression<Func<TTarget2, T2>> member2 ,   TTarget3 target3, Expression<Func<TTarget3, T3>> member3 ,   TTarget4 target4, Expression<Func<TTarget4, T4>> member4  ) 
	{
		            (member1.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target1, v, tuple.Item1))
                .With(Case.Is<FieldInfo>(), v => SetValue(target1, v, tuple.Item1))
                .Do();
		            (member2.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target2, v, tuple.Item2))
                .With(Case.Is<FieldInfo>(), v => SetValue(target2, v, tuple.Item2))
                .Do();
		            (member3.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target3, v, tuple.Item3))
                .With(Case.Is<FieldInfo>(), v => SetValue(target3, v, tuple.Item3))
                .Do();
		            (member4.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target4, v, tuple.Item4))
                .With(Case.Is<FieldInfo>(), v => SetValue(target4, v, tuple.Item4))
                .Do();
				
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

	public static Tuple<T1, T2, T3, T4, T5> Tie<T1, T2, T3, T4, T5, TTarget>(this Tuple<T1, T2, T3, T4, T5> tuple, TTarget target,  Expression<Func<TTarget, T1>> member1 ,   Expression<Func<TTarget, T2>> member2 ,   Expression<Func<TTarget, T3>> member3 ,   Expression<Func<TTarget, T4>> member4 ,   Expression<Func<TTarget, T5>> member5  ) 
	{
		            (member1.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item1))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item1))
                .Do();
		            (member2.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item2))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item2))
                .Do();
		            (member3.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item3))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item3))
                .Do();
		            (member4.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item4))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item4))
                .Do();
		            (member5.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item5))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item5))
                .Do();
				
		return tuple;
	}

	public static Tuple<T1, T2, T3, T4, T5> Tie<T1, T2, T3, T4, T5,  TTarget1 ,     TTarget2 ,     TTarget3 ,     TTarget4 ,     TTarget5    >(this Tuple<T1, T2, T3, T4, T5> tuple,  TTarget1 target1, Expression<Func<TTarget1, T1>> member1 ,   TTarget2 target2, Expression<Func<TTarget2, T2>> member2 ,   TTarget3 target3, Expression<Func<TTarget3, T3>> member3 ,   TTarget4 target4, Expression<Func<TTarget4, T4>> member4 ,   TTarget5 target5, Expression<Func<TTarget5, T5>> member5  ) 
	{
		            (member1.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target1, v, tuple.Item1))
                .With(Case.Is<FieldInfo>(), v => SetValue(target1, v, tuple.Item1))
                .Do();
		            (member2.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target2, v, tuple.Item2))
                .With(Case.Is<FieldInfo>(), v => SetValue(target2, v, tuple.Item2))
                .Do();
		            (member3.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target3, v, tuple.Item3))
                .With(Case.Is<FieldInfo>(), v => SetValue(target3, v, tuple.Item3))
                .Do();
		            (member4.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target4, v, tuple.Item4))
                .With(Case.Is<FieldInfo>(), v => SetValue(target4, v, tuple.Item4))
                .Do();
		            (member5.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target5, v, tuple.Item5))
                .With(Case.Is<FieldInfo>(), v => SetValue(target5, v, tuple.Item5))
                .Do();
				
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

	public static Tuple<T1, T2, T3, T4, T5, T6> Tie<T1, T2, T3, T4, T5, T6, TTarget>(this Tuple<T1, T2, T3, T4, T5, T6> tuple, TTarget target,  Expression<Func<TTarget, T1>> member1 ,   Expression<Func<TTarget, T2>> member2 ,   Expression<Func<TTarget, T3>> member3 ,   Expression<Func<TTarget, T4>> member4 ,   Expression<Func<TTarget, T5>> member5 ,   Expression<Func<TTarget, T6>> member6  ) 
	{
		            (member1.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item1))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item1))
                .Do();
		            (member2.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item2))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item2))
                .Do();
		            (member3.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item3))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item3))
                .Do();
		            (member4.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item4))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item4))
                .Do();
		            (member5.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item5))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item5))
                .Do();
		            (member6.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item6))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item6))
                .Do();
				
		return tuple;
	}

	public static Tuple<T1, T2, T3, T4, T5, T6> Tie<T1, T2, T3, T4, T5, T6,  TTarget1 ,     TTarget2 ,     TTarget3 ,     TTarget4 ,     TTarget5 ,     TTarget6    >(this Tuple<T1, T2, T3, T4, T5, T6> tuple,  TTarget1 target1, Expression<Func<TTarget1, T1>> member1 ,   TTarget2 target2, Expression<Func<TTarget2, T2>> member2 ,   TTarget3 target3, Expression<Func<TTarget3, T3>> member3 ,   TTarget4 target4, Expression<Func<TTarget4, T4>> member4 ,   TTarget5 target5, Expression<Func<TTarget5, T5>> member5 ,   TTarget6 target6, Expression<Func<TTarget6, T6>> member6  ) 
	{
		            (member1.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target1, v, tuple.Item1))
                .With(Case.Is<FieldInfo>(), v => SetValue(target1, v, tuple.Item1))
                .Do();
		            (member2.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target2, v, tuple.Item2))
                .With(Case.Is<FieldInfo>(), v => SetValue(target2, v, tuple.Item2))
                .Do();
		            (member3.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target3, v, tuple.Item3))
                .With(Case.Is<FieldInfo>(), v => SetValue(target3, v, tuple.Item3))
                .Do();
		            (member4.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target4, v, tuple.Item4))
                .With(Case.Is<FieldInfo>(), v => SetValue(target4, v, tuple.Item4))
                .Do();
		            (member5.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target5, v, tuple.Item5))
                .With(Case.Is<FieldInfo>(), v => SetValue(target5, v, tuple.Item5))
                .Do();
		            (member6.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target6, v, tuple.Item6))
                .With(Case.Is<FieldInfo>(), v => SetValue(target6, v, tuple.Item6))
                .Do();
				
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

	public static Tuple<T1, T2, T3, T4, T5, T6, T7> Tie<T1, T2, T3, T4, T5, T6, T7, TTarget>(this Tuple<T1, T2, T3, T4, T5, T6, T7> tuple, TTarget target,  Expression<Func<TTarget, T1>> member1 ,   Expression<Func<TTarget, T2>> member2 ,   Expression<Func<TTarget, T3>> member3 ,   Expression<Func<TTarget, T4>> member4 ,   Expression<Func<TTarget, T5>> member5 ,   Expression<Func<TTarget, T6>> member6 ,   Expression<Func<TTarget, T7>> member7  ) 
	{
		            (member1.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item1))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item1))
                .Do();
		            (member2.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item2))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item2))
                .Do();
		            (member3.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item3))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item3))
                .Do();
		            (member4.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item4))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item4))
                .Do();
		            (member5.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item5))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item5))
                .Do();
		            (member6.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item6))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item6))
                .Do();
		            (member7.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item7))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item7))
                .Do();
				
		return tuple;
	}

	public static Tuple<T1, T2, T3, T4, T5, T6, T7> Tie<T1, T2, T3, T4, T5, T6, T7,  TTarget1 ,     TTarget2 ,     TTarget3 ,     TTarget4 ,     TTarget5 ,     TTarget6 ,     TTarget7    >(this Tuple<T1, T2, T3, T4, T5, T6, T7> tuple,  TTarget1 target1, Expression<Func<TTarget1, T1>> member1 ,   TTarget2 target2, Expression<Func<TTarget2, T2>> member2 ,   TTarget3 target3, Expression<Func<TTarget3, T3>> member3 ,   TTarget4 target4, Expression<Func<TTarget4, T4>> member4 ,   TTarget5 target5, Expression<Func<TTarget5, T5>> member5 ,   TTarget6 target6, Expression<Func<TTarget6, T6>> member6 ,   TTarget7 target7, Expression<Func<TTarget7, T7>> member7  ) 
	{
		            (member1.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target1, v, tuple.Item1))
                .With(Case.Is<FieldInfo>(), v => SetValue(target1, v, tuple.Item1))
                .Do();
		            (member2.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target2, v, tuple.Item2))
                .With(Case.Is<FieldInfo>(), v => SetValue(target2, v, tuple.Item2))
                .Do();
		            (member3.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target3, v, tuple.Item3))
                .With(Case.Is<FieldInfo>(), v => SetValue(target3, v, tuple.Item3))
                .Do();
		            (member4.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target4, v, tuple.Item4))
                .With(Case.Is<FieldInfo>(), v => SetValue(target4, v, tuple.Item4))
                .Do();
		            (member5.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target5, v, tuple.Item5))
                .With(Case.Is<FieldInfo>(), v => SetValue(target5, v, tuple.Item5))
                .Do();
		            (member6.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target6, v, tuple.Item6))
                .With(Case.Is<FieldInfo>(), v => SetValue(target6, v, tuple.Item6))
                .Do();
		            (member7.Body as MemberExpression).Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target7, v, tuple.Item7))
                .With(Case.Is<FieldInfo>(), v => SetValue(target7, v, tuple.Item7))
                .Do();
				
		return tuple;
	}

	
	}
}