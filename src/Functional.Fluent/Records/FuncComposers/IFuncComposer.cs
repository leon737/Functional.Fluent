using System;
using System.Linq.Expressions;

namespace Functional.Fluent.Records.FuncComposers
{
    internal interface IFuncComposer<TFunc>
    {
        Expression<TFunc> Compose();
    }
}