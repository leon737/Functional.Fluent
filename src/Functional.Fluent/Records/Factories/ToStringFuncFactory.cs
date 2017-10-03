using Functional.Fluent.Records.ObjectVisitors;

namespace Functional.Fluent.Records.Factories
{
    internal class ToStringFuncFactory : BasicFuncFactoryBase
    {
        public override IObjectVisitor CreateVisitor() => new ToStringVisitor();
    }
}