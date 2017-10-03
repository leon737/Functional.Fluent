using Functional.Fluent.Records.ObjectVisitors;
using Functional.Fluent.Records.ObjectWalkers;

namespace Functional.Fluent.Records.Factories
{
    internal abstract class BasicFuncFactoryBase : IFuncFactory
    {
        public IObjectWalker CreateWalker() => new SimpleObjectWalker();

        public abstract IObjectVisitor CreateVisitor();
    }
}