using System;
using Functional.Fluent.Records.ObjectStates;
using Functional.Fluent.Records.ObjectWalkers;

namespace Functional.Fluent.Records.ObjectVisitors
{
    internal class EqualityVisitor : IObjectVisitor
    {
        public IObjectState InitializeState(Type type) => new EqualityObjectState(type);

        public IObjectState Visit(IObjectState state, IObjectDataMember objectDataMember) => state.Update(objectDataMember);
    }
}