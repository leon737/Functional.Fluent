using System;
using System.Linq.Expressions;
using System.Reflection;
using Functional.Fluent.Extensions;
using Functional.Fluent.Pattern;

namespace Functional.Fluent.Records.ObjectWalkers
{
    internal class ObjectDataMember : IObjectDataMember
    {
        private readonly MemberInfo _memberInfo;

        public ObjectDataMember(PropertyInfo propertyInfo)
        {
            _memberInfo = propertyInfo;
        }

        public ObjectDataMember(FieldInfo fieldInfo)
        {
            _memberInfo = fieldInfo;
        }

        public string MemberName => _memberInfo.Name;

        public virtual Expression GetValueExpression(Expression target) => 
            _memberInfo.TypeMatch()
            .With(Case.Is<FieldInfo>(), v => Expression.Field(target, v))
            .With(Case.Is<PropertyInfo>(), v => Expression.Property(target, v))
            .ElseThrow<NotSupportedException>()
            .Do();

        public Type MemberType =>
            _memberInfo.TypeMatch()
            .With(Case.Is<FieldInfo>(), v => v.FieldType)
            .With(Case.Is<PropertyInfo>(), v => v.PropertyType)
            .Do();
    }
}