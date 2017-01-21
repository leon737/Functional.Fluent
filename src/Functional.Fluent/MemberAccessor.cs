using System;
using System.Linq.Expressions;
using System.Reflection;
using Functional.Fluent.Extensions;
using Functional.Fluent.Helpers;
using Functional.Fluent.Pattern;

namespace Functional.Fluent
{
    public class MemberAccessor<T, V>
    {
        private readonly Expression<Func<T, V>> _memberExpression;

        public MemberAccessor(Expression<Func<T, V>> memberExpression)
        {
            _memberExpression = memberExpression;
        }

        public V GetValue(T obj)
        {
            return MemberInfo.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => GetValue(v, obj))
                .With(Case.Is<FieldInfo>(), v => GetValue(v, obj))
                .ElseThrow<InvalidOperationException>()
                .Do();
        }

        public void SetValue(T obj, V value)
        {
           MemberInfo.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(v, obj, value))
                .With(Case.Is<FieldInfo>(), v => SetValue(v, obj, value))
                .ElseThrow<InvalidOperationException>()
                .Do();
        }

        private MemberInfo MemberInfo => _memberExpression.Body.TypeMatch()
                .With(Case.Is<MemberExpression>(), v => v.Member)
                .ElseThrow<InvalidOperationException>()
                .Do();

        private V GetValue(PropertyInfo pi, T obj) => (V)pi.GetValue(obj);

        private V GetValue(FieldInfo pi, T obj) => (V) pi.GetValue(obj);

        private IResult SetValue(PropertyInfo pi, T obj, V value)
        {
            pi.SetValue(obj, value);
            return Result.Success();
        }

        private IResult SetValue(FieldInfo pi, T obj, V value)
        {
            pi.SetValue(obj, value);
            return Result.Success();
        }
    }
}