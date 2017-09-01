using System;
using Functional.Fluent.Records.ObjectStates;
using Functional.Fluent.Records.ObjectWalkers;

namespace Functional.Fluent.Records.ObjectVisitors
{
    internal class ToStringVisitor : IObjectVisitor
    {
        public IObjectState InitializeState(Type type) => new ToStringObjectState(type);

        public IObjectState Visit(IObjectState state, IObjectDataMember objectDataMember) => state.Update(objectDataMember);
    }
}