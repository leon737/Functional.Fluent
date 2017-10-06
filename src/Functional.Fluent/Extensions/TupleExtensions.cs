using System;
using System.Linq.Expressions;
using System.Reflection;
using Functional.Fluent.Pattern;

namespace Functional.Fluent.Extensions
{
    public static partial class TupleExtensions
    {
        private static bool SetValue(object target, PropertyInfo propertyInfo, object value)
        {
            propertyInfo.SetValue(target, value);
            return true;
        }

        private static bool SetValue(object target, FieldInfo propertyInfo, object value)
        {
            propertyInfo.SetValue(target, value);
            return true;
        }


        public static Tuple<T1, T2> Tie<T1, T2>(this Tuple<T1, T2> tuple, out T1 p1, out T2 p2)
        {
            p1 = tuple.Item1;
            p2 = tuple.Item2;
            return tuple;
        }

        public static Tuple<T1, T2> Tie<T1, T2, TTarget>(this Tuple<T1, T2> tuple, TTarget target, Expression<Func<TTarget, T1>> member1, Expression<Func<TTarget, T2>> member2)
        {
            var member1Expression = member1.Body as MemberExpression;
            member1Expression.Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item1))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item1))
                .Do();

            var member2Expression = member2.Body as MemberExpression;
            member2Expression.Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target, v, tuple.Item2))
                .With(Case.Is<FieldInfo>(), v => SetValue(target, v, tuple.Item2))
                .Do();

            return tuple;
        }

        public static Tuple<T1, T2> Tie<T1, T2, TTarget1, TTarget2>(this Tuple<T1, T2> tuple, TTarget1 target1, Expression<Func<TTarget1, T1>> member1, TTarget2 target2, Expression<Func<TTarget2, T2>> member2)
        {
            var member1Expression = member1.Body as MemberExpression;
            member1Expression.Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target1, v, tuple.Item1))
                .With(Case.Is<FieldInfo>(), v => SetValue(target1, v, tuple.Item1))
                .Do();

            var member2Expression = member2.Body as MemberExpression;
            member2Expression.Member.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(target2, v, tuple.Item2))
                .With(Case.Is<FieldInfo>(), v => SetValue(target2, v, tuple.Item2))
                .Do();

            return tuple;
        }
    }
}