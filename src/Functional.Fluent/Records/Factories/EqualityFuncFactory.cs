using Functional.Fluent.Records.ObjectVisitors;

namespace Functional.Fluent.Records.Factories
{
    internal class EqualityFuncFactory : BasicFuncFactoryBase
    {
        public override IObjectVisitor CreateVisitor() => new EqualityVisitor();
    }
}