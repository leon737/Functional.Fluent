using System;
using Functional.Fluent.Records.ObjectStates;

namespace Functional.Fluent.Records.ObjectVisitors
{
    internal class EqualityVisitor : VisitorBase
    {
        public override IObjectState InitializeState(Type type) => new EqualityObjectState(type);
    }
}