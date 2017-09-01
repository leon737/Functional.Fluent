using Functional.Fluent.Records.ObjectVisitors;
using Functional.Fluent.Records.ObjectWalkers;

namespace Functional.Fluent.Records.Factories
{
    internal interface IFuncFactory
    {
        IObjectWalker CreateWalker();

        IObjectVisitor CreateVisitor();
    }
}