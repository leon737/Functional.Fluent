using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Functional.Fluent.Records.Attributes;
using Functional.Fluent.Records.ObjectWalkers;

namespace Functional.Fluent.Records.ObjectStates
{
    internal class MergeObjectState : ObjectStateBase
    {
        private readonly ParameterExpression _target;

        private readonly IList<Expression> _expressions;

        private readonly ParameterExpression _left;

        private readonly ParameterExpression _right;

        private readonly Type _type;

        public MergeObjectState(Type type)
        {
            _expressions = new List<Expression>();

            _target = Expression.Variable(type);
            var ne = Expression.New(type);
            var assign = Expression.Assign(_target, ne);

            _expressions.Add(assign);

            _left = Expression.Parameter(type);
            _right = Expression.Parameter(type);

            _type = type;
        }

        private MergeObjectState(IList<Expression> expressions, ParameterExpression target, ParameterExpression left, ParameterExpression right, Type type)
        {
            _expressions = expressions;
            _target = target;
            _left = left;
            _right = right;
            _type = type;
        }

        public override IObjectState UpdateImpl(IObjectDataMember objectDataMember)
        {
            var targetMember = objectDataMember.GetValueExpression(_target);
            var leftMember = objectDataMember.GetValueExpression(_left);
            var rightMember = objectDataMember.GetValueExpression(_right);

            var test = Expression.NotEqual(Expression.Default(objectDataMember.MemberType), leftMember);
            var assign = Expression.Assign(targetMember, Expression.Condition(test, leftMember, rightMember));

            _expressions.Add(assign);

            return new MergeObjectState(_expressions, _target, _left, _right, _type);
        }

        public override LambdaExpression Return()
        {
            var target = Expression.Label(_type);
            var label = Expression.Label(target, Expression.Constant(null, _type));
            var result = Expression.Return(target, _target);

            _expressions.Add(result);
            _expressions.Add(label);

            var block = Expression.Block(new[] { _target }, _expressions);

            return Expression.Lambda(block, true, _left, _right);
        }

        public override Features Feature => Features.Merge;
    }
}