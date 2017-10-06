using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Functional.Fluent.Extensions;
using Functional.Fluent.MonadicTypes;
using Functional.Fluent.Pattern;

namespace Functional.Fluent.Records.ObjectWalkers
{
    internal class ObjectDataMember : IObjectDataMember
    {
        private readonly MemberInfo _memberInfo;

        public ObjectDataMember(PropertyInfo propertyInfo, IObjectWalker walker)
        {
            _memberInfo = propertyInfo;
            Walker = walker;
        }

        public ObjectDataMember(FieldInfo fieldInfo, IObjectWalker walker)
        {
            _memberInfo = fieldInfo;
            Walker = walker;
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

        public Type DeclaringType => _memberInfo.DeclaringType;

        public IObjectWalker Walker { get; }
        public Maybe<IEnumerable<T>> GetCustomAttributes<T>() where T:Attribute => _memberInfo.GetCustomAttributes((typeof(T))).ToMaybeNonEmpty().With(v => v.Select(x => (T)x));
    }
}