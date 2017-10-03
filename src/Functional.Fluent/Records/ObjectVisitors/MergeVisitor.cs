using System;
using Functional.Fluent.Records.ObjectStates;

namespace Functional.Fluent.Records.ObjectVisitors
{
    internal class MergeVisitor : VisitorBase
    {
        public override IObjectState InitializeState(Type type) => new MergeObjectState(type);
    }
}