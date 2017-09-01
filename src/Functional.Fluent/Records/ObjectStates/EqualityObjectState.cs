using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Functional.Fluent.Extensions;
using Functional.Fluent.Records.ObjectWalkers;
using System.Linq;

namespace Functional.Fluent.Records.ObjectStates
{
    internal class EqualityObjectState : IObjectState
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

        public IObjectState Update(IObjectDataMember objectDataMember)
        {
            var eqExpression = Expression.Equal(objectDataMember.GetValueExpression(_left), objectDataMember.GetValueExpression(_right));
            var result = Expression.AndAlso(_expression, eqExpression);
            return new EqualityObjectState(result, _left, _right);
        }

        public LambdaExpression Return() => Expression.Lambda(_expression, true, _left, _right);
    }
}