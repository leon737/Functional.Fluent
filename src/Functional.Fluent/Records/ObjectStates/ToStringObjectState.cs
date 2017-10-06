using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Functional.Fluent.Extensions;
using Functional.Fluent.Helpers;
using Functional.Fluent.Records.Attributes;
using Functional.Fluent.Records.ObjectWalkers;
using static System.Linq.Expressions.Expression;

namespace Functional.Fluent.Records.ObjectStates
{
    internal class ToStringObjectState : OneParameterObjectStateBase
    {
        private static readonly IEnumerable<MethodInfo> StringConcatMethods = typeof(string).GetMethods().Where(x => x.Name == nameof(string.Concat));
        private static readonly Func<MethodInfo, int, bool> Predicate = (x, n) => x.GetParameters().Length == n;
        private static readonly MethodInfo StringConcat2StringsMethod = StringConcatMethods.First(Predicate.RPartial(2));
        private static readonly Type StringBuilderType = typeof(StringBuilder);
        private static readonly Type StringType = typeof(string);

        private const string Tab = "\t";
        private const string NewLine = "\r\n";
        private const string AppendLine = "AppendLine";

        public ToStringObjectState(Type type) : base(Constant(string.Empty), Parameter(type)) { }

        private ToStringObjectState(Expression expression, ParameterExpression target) : base(expression, target) { }

        public override IObjectState UpdateImpl(IObjectDataMember objectDataMember)
        {
            var tabExpression = Constant(Tab);
            var callExpression = MakeIndentExpression(Call(StringConcat2StringsMethod, tabExpression, 
                Call(objectDataMember.GetValueExpression(_Target), GetToStringMethodInfo(objectDataMember))));
            Expression memberNameExpression = Constant(objectDataMember.MemberName + " :");
            var endOfLineExpression = Constant(NewLine);
            var typeExpression = objectDataMember.Walker.CanExpand(objectDataMember.MemberType) && Nullable.GetUnderlyingType(objectDataMember.MemberType) == null
                ? Call(StringConcat2StringsMethod, Constant($"{Tab}<{objectDataMember.MemberType.Name}>"), endOfLineExpression)
                : null;

            if (typeExpression != null)
                memberNameExpression = Call(StringConcat2StringsMethod, memberNameExpression, typeExpression);

            if (Nullable.GetUnderlyingType(objectDataMember.MemberType) != null || !objectDataMember.MemberType.IsValueType)
            {
                callExpression = Condition(NotEqual(objectDataMember.GetValueExpression(_Target),
                    Constant(null, objectDataMember.MemberType)), callExpression, Constant($"{Tab}(null){NewLine}"));
            }
            var lineExpression = Call(StringConcat2StringsMethod, memberNameExpression, callExpression);
            var concatLinesExpression = Call(StringConcat2StringsMethod, _Expression, lineExpression);
            return new ToStringObjectState(concatLinesExpression, _Target);
        }

        private MethodInfo GetToStringMethodInfo(IObjectDataMember objectDataMember) =>
            typeof(object).GetMethods().First(x => x.Name == nameof(ToString) && !x.GetParameters().Any());

        private Expression MakeIndentExpression(Expression expression)
        {
            var tabExpression = Constant(Tab);
            var splitter = Call(expression,
                StringType.GetMethod(nameof(string.Split), new[] { typeof(string[]), typeof(StringSplitOptions) }),
                    Constant(new[] {NewLine}),
                    Constant(StringSplitOptions.None)

                );
            var accumulator = Variable(StringBuilderType);
            var accumulatorInit = Assign(accumulator, New(StringBuilderType));
            var loopVar = Parameter(StringType);
            var skipVar = Variable(typeof(bool));
            var loopBody = Block(Call(accumulator, StringBuilderType.GetMethod(AppendLine, new[] { StringType }),
                Condition(IsTrue(skipVar), Call(StringConcat2StringsMethod, tabExpression, loopVar), loopVar)),
                Assign(skipVar, Constant(true)));
            var loop = ExpressionBuilder.ForEach(splitter, loopVar, loopBody);
            var toStringCall = Call(accumulator, StringBuilderType.GetMethod(nameof(ToString), Type.EmptyTypes));
            var target = Label(StringType);
            var block = Block(new [] {accumulator, skipVar},  accumulatorInit, loop, Expression.Return(target, toStringCall), Label(target, Constant(string.Empty)));
            return block;
        }

        public override Features Feature => Features.ToString;
    }
}