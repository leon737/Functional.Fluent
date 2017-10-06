using System.Linq.Expressions;
using Functional.Fluent.Records.ObjectWalkers;

namespace Functional.Fluent.Records.ObjectStates
{
    internal abstract class OneParameterObjectStateBase : ObjectStateBase
    {
        protected readonly Expression _Expression;
        protected readonly ParameterExpression _Target;

        protected OneParameterObjectStateBase()
        {
            
        }

        protected OneParameterObjectStateBase(Expression expression, ParameterExpression target)
        {
            _Expression = expression;
            _Target = target;
        }

        public ParameterExpression Target => _Target;

        public override LambdaExpression Return() => Expression.Lambda(_Expression, true, _Target);
    }
}