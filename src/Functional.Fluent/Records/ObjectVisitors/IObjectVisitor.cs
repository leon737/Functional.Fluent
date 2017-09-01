using System;
using Functional.Fluent.Records.ObjectStates;
using Functional.Fluent.Records.ObjectWalkers;

namespace Functional.Fluent.Records.ObjectVisitors
{
    internal interface IObjectVisitor
    {
        IObjectState InitializeState(Type type);

        IObjectState Visit(IObjectState state, IObjectDataMember objectDataMember);
    }
}