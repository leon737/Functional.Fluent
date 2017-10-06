using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Records.ObjectWalkers
{
    internal interface IObjectDataMember
    {
        string MemberName { get; }

        Expression GetValueExpression(Expression target);

        Type MemberType { get; }

        Type DeclaringType { get; }

        IObjectWalker Walker { get; }

        Maybe<IEnumerable<T>> GetCustomAttributes<T>() where T : Attribute;
    }
}