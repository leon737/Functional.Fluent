using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Functional.Fluent.Extensions;
using Functional.Fluent.Records.ObjectWalkers;
using System.Linq;

namespace Functional.Fluent.Records.ObjectStates
{
    internal class ToStringObjectState : OneParameterObjectStateBase
    {
        private static readonly IEnumerable<MethodInfo> StringConcatMethods =
            typeof(string).GetMethods().Where(x => x.Name == nameof(string.Concat));

        private static readonly Func<MethodInfo, int, bool> Predicate = (x, n) => x.GetParameters().Length == n;

        private static readonly MethodInfo StringConcat3StringsMethod = StringConcatMethods.First(Predicate.RPartial(3));

        private static readonly MethodInfo StringConcat2StringsMethod = StringConcatMethods.First(Predicate.RPartial(2));

        public ToStringObjectState(Type type) : base(Expression.Constant(string.Empty), Expression.Parameter(type)) { }

        private ToStringObjectState(Expression expression, ParameterExpression target) : base(expression, target) { }

        public override IObjectState Update(IObjectDataMember objectDataMember)
        {
            Expression callExpression = Expression.Call(objectDataMember.GetValueExpression(_Target),GeToStringMethodInfo(objectDataMember));
            var memberNameExpression = Expression.Constant(objectDataMember.MemberName + " : ");
            var endOfLineExpression = Expression.Constant("\r\n");
            if (Nullable.GetUnderlyingType(objectDataMember.MemberType) != null || !objectDataMember.MemberType.IsValueType)
            {
                callExpression = Expression.Condition(Expression.NotEqual(objectDataMember.GetValueExpression(_Target),
                    Expression.Constant(null, objectDataMember.MemberType)), callExpression, Expression.Constant("(null)"));
            }
            var lineExpression = Expression.Call(null, StringConcat3StringsMethod, memberNameExpression, callExpression,
                endOfLineExpression);
                

           var concatLinesExpression = Expression.Call(StringConcat2StringsMethod, _Expression, lineExpression);
            return new ToStringObjectState(concatLinesExpression, _Target);
        }

        private MethodInfo GeToStringMethodInfo(IObjectDataMember objectDataMember) =>
            objectDataMember.MemberType.GetMethods().First(x => x.Name == nameof(ToString) && !x.GetParameters().Any());
    }
}