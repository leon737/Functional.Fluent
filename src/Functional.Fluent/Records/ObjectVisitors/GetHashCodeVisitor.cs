using System;
using Functional.Fluent.Records.ObjectStates;

namespace Functional.Fluent.Records.ObjectVisitors
{
    internal class GetHashCodeVisitor : VisitorBase
    {
        public override IObjectState InitializeState(Type type) => new GetHashCodeObjectState(type);
    }
}