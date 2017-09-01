using System;
using Functional.Fluent.Records.ObjectVisitors;
using Functional.Fluent.Records.ObjectWalkers;

namespace Functional.Fluent.Records.Factories
{
    internal class EqualityFuncFactory : IFuncFactory
    {
        public IObjectWalker CreateWalker() => new SimpleObjectWalker();

        public IObjectVisitor CreateVisitor() => new EqualityVisitor();
    }
}