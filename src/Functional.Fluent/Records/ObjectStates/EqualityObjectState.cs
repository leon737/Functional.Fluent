using System;
using System.Linq.Expressions;
using Functional.Fluent.Records.Attributes;
using Functional.Fluent.Records.ObjectWalkers;

namespace Functional.Fluent.Records.ObjectStates
{
    internal class EqualityObjectState : ObjectStateBase
    {

        private readonly Expression _expression;

        private readonly ParameterExpression _left;

        private readonly ParameterExpression _right;

        public EqualityObjectState(Type type)
        {
            _expression = Expression.Constant(true);
            _left = Expression.Parameter(type);
            _right = Expression.Parameter(type);
        }

        private EqualityObjectState(Expression expression, ParameterExpression left, ParameterExpression right)
        {
            _expression = expression;
            _left = left;
            _right = right;
        }

        public override IObjectState UpdateImpl(IObjectDataMember objectDataMember)
        {
            var eqExpression = Expression.Equal(objectDataMember.GetValueExpression(_left), objectDataMember.GetValueExpression(_right));
            var result = Expression.AndAlso(_expression, eqExpression);
            return new EqualityObjectState(result, _left, _right);
        }

        public override LambdaExpression Return() => Expression.Lambda(_expression, true, _left, _right);

        public override Features Feature => Features.Equality;
    }
}