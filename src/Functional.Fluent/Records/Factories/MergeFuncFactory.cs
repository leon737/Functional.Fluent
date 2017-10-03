using Functional.Fluent.Records.ObjectVisitors;

namespace Functional.Fluent.Records.Factories
{
    internal class MergeFuncFactory : BasicFuncFactoryBase
    {
        public override IObjectVisitor CreateVisitor() => new MergeVisitor();
    }
}