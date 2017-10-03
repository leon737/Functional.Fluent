using Functional.Fluent.Records.ObjectVisitors;

namespace Functional.Fluent.Records.Factories
{
    internal class GetHashCodeFuncFactory : BasicFuncFactoryBase
    {
        public override IObjectVisitor CreateVisitor() => new GetHashCodeVisitor();
    }
}