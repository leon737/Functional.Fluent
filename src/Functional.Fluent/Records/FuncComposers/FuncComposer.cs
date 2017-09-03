using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Functional.Fluent.Records.Factories;
using Functional.Fluent.Records.ObjectStates;
using Functional.Fluent.Records.ObjectVisitors;
using Functional.Fluent.Records.ObjectWalkers;

namespace Functional.Fluent.Records.FuncComposers
{
    internal class FuncComposer<TType, TFunc> : IFuncComposer<TFunc>
    {
        private readonly IObjectWalker _walker;
        private readonly IObjectVisitor _visitor;

        public FuncComposer(IFuncFactory factory)
        {
            _walker = factory.CreateWalker();
            _visitor = factory.CreateVisitor();
        }

        public Expression<TFunc> Compose()
        {
            var state = _visitor.InitializeState(typeof(TType));
            state = ProcessType(state, typeof(TType));
            var expression = state.Return();
            var parameters = new List<ParameterExpression>();
            var casts = new List<Expression>();
            for (var i = 0; i < expression.Parameters.Count; ++i)
            {
                var p = Expression.Parameter(typeof(Record<TType>));
                parameters.Add(p);
                var cast = Expression.Convert(p, typeof(TType));
                casts.Add(cast);
            }
            var call = Expression.Invoke(expression, casts.ToArray());
            var lambda = Expression.Lambda<TFunc>(call, true, parameters.ToArray());
            return lambda;
        }

        private IObjectState ProcessType(IObjectState state, Type type)
        {
            var members = _walker.GetDataMembers(type);
            foreach (var member in members)
            {
                state = ProcessMember(state, member);
            }
            return state;
        }

        private IObjectState ProcessMember(IObjectState state, IObjectDataMember member)
        {
            return typeof(Enumerable).IsAssignableFrom(member.MemberType)
                ? ProcessCollection(state, member)
                : _visitor.Visit(state, member);
        }

        private IObjectState ProcessCollection(IObjectState state, IObjectDataMember member)
        {
            throw new NotSupportedException();
        }
    }
}