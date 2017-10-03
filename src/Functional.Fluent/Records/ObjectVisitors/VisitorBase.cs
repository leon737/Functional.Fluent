using System;
using Functional.Fluent.Records.ObjectStates;
using Functional.Fluent.Records.ObjectWalkers;

namespace Functional.Fluent.Records.ObjectVisitors
{
    internal abstract class VisitorBase : IObjectVisitor
    {
        public abstract IObjectState InitializeState(Type type);

        public IObjectState Visit(IObjectState state, IObjectDataMember objectDataMember) => state.Update(objectDataMember);
    }
}