using System;
using System.Collections.Generic;

namespace Functional.Fluent.Records.ObjectWalkers
{
    internal interface IObjectWalker
    {
        bool CanExpand(Type type);

        IEnumerable<ObjectDataMember> GetDataMembers(Type type);
    }
}