using System;
using System.Linq.Expressions;
using System.Reflection;
using Functional.Fluent.Records.Attributes;
using Functional.Fluent.Records.ObjectWalkers;

namespace Functional.Fluent.Records.ObjectStates
{
    // see https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
    internal class GetHashCodeObjectState : OneParameterObjectStateBase
    {
        public GetHashCodeObjectState(Type type) : base(Expression.Constant(17), Expression.Parameter(type)) { }

        private GetHashCodeObjectState(Expression expression, ParameterExpression target) : base(expression, target) { }

        public override IObjectState UpdateImpl(IObjectDataMember objectDataMember)
        {
            Expression callExpression = Expression.Call(objectDataMember.GetValueExpression(_Target), GetHashCodeMethodInfo(objectDataMember));
            if (Nullable.GetUnderlyingType(objectDataMember.MemberType) != null || !objectDataMember.MemberType.IsValueType)
            {
                callExpression = Expression.Condition(Expression.NotEqual(objectDataMember.GetValueExpression(_Target),
                    Expression.Constant(null, objectDataMember.MemberType)), callExpression, Expression.Constant(0));
            }
            var multExpression = Expression.Multiply(_Expression, Expression.Constant(23));
            var addExpression = Expression.Add(multExpression, callExpression);
            return new GetHashCodeObjectState(addExpression, _Target);
        }

        private MethodInfo GetHashCodeMethodInfo(IObjectDataMember objectDataMember) => 
            typeof(object).GetMethod(nameof(GetHashCode));

        public override Features Feature => Features.GetHashCode;
    }
}