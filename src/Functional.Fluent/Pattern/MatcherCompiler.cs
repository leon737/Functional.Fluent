using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Functional.Fluent.Helpers;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Pattern
{
    public class MatcherCompiler<TV, TU>
    {
        private readonly List<Tuple<Expression<Func<TV, bool>>, Expression<Func<TV, TU>>>> _list;

        public MatcherCompiler(List<Tuple<Expression<Func<TV, bool>>, Expression<Func<TV, TU>>>> list)
        {
            _list = list;
            _list.Reverse();
        }

        public Func<TV, TU> Compile()
        {
            var rootParameter = Expression.Parameter(typeof(TV));
            var parameters = new List<ParameterExpression>();
            var label = Expression.Label(typeof(TU));

            Expression condition = null;
            var defaultValue = Expression.Constant(default(TU), typeof(TU));

            foreach (var item in _list)
            {
                var predicate = item.Item1;
                var result = item.Item2;
                var constantExpression = IsConstantResult(result.Body);
                if (constantExpression.IsFailed)
                    parameters.Add(result.Parameters.First());

              
                var cp = predicate.Body as ConstantExpression;
                if (cp != null && cp.Type == typeof(bool) && (bool) cp.Value)
                {
                    condition = Expression.Return(label, result.Body);
                }
                else
                {
                    parameters.Add(predicate.Parameters.First());
                    condition = Expression.IfThenElse(predicate.Body, 
                        Expression.Return(label, constantExpression.IsSucceed
                        ? Expression.Constant(constantExpression.Value.Value, typeof(TU)) : result.Body),
                        condition ?? Expression.Return(label, defaultValue));
                }
            }

            var block = Expression.Block(parameters, MakeAssign(parameters, rootParameter).Concat(new []
            {
                condition,
                Expression.Label(label, defaultValue)
            }));
            
            return Expression.Lambda<Func<TV, TU>>(block, rootParameter).Compile();
        }

        private Result<ConstantExpression> IsConstantResult(Expression result) => 
            Result.SuccessIfNotNull(result as ConstantExpression);

        private IEnumerable<Expression> MakeAssign(IEnumerable<ParameterExpression> parameters, ParameterExpression rootParameter)
        {
            foreach (var parameter in parameters)
                yield return Expression.Assign(parameter, rootParameter);
        }
    }
}