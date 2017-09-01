using System.Linq.Expressions;
using Functional.Fluent.Records.ObjectWalkers;

namespace Functional.Fluent.Records.ObjectStates
{
    internal interface IObjectState
    {
        IObjectState Update(IObjectDataMember objectDataMember);

        ParameterExpression Target { get; }

        Expression Return();
    }
}