using System;
using Functional.Fluent.Records.ObjectStates;

namespace Functional.Fluent.Records.ObjectVisitors
{
    internal class ToStringVisitor : VisitorBase
    {
        public override IObjectState InitializeState(Type type) => new ToStringObjectState(type);
    }
}