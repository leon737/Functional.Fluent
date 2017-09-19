using System;
using System.Linq.Expressions;

namespace Functional.Fluent.Records.ObjectWalkers
{
    internal interface IObjectDataMember
    {
        string MemberName { get; }

        Expression GetValueExpression(Expression target);

        Type MemberType { get; }

        IObjectWalker Walker { get; }
    }
}