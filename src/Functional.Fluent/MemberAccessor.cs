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
            var mi = MemberInfo;
            if (mi == null)
                throw new InvalidOperationException();
            return mi.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => GetValue(v, obj))
                .With(Case.Is<FieldInfo>(), v => GetValue(v, obj))
                .Else(_ => ThrowGetException())
                .Do();
        }

        public void SetValue(T obj, V value)
        {
            var mi = MemberInfo;
            if (mi == null)
                throw new InvalidOperationException();
            mi.TypeMatch()
                .With(Case.Is<PropertyInfo>(), v => SetValue(v, obj, value))
                .With(Case.Is<FieldInfo>(), v => SetValue(v, obj, value))
                .Else(_ => ThrowSetException())
                .Do();
        }

        private MemberInfo MemberInfo => _memberExpression.Body.TypeMatch()
                .With(Case.Is<MemberExpression>(), v => v.Member)
                .Do();

        private V ThrowGetException()
        {
            throw new InvalidOperationException();
        }

        private IResult ThrowSetException()
        {
            throw new InvalidOperationException();
        }

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