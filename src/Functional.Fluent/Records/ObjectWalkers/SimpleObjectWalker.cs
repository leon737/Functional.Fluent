using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Functional.Fluent.Records.ObjectWalkers
{
    internal class SimpleObjectWalker : IObjectWalker
    {
        public bool CanExpand(Type type)
        {
            if (type.IsPrimitive) return false;

            if (type == typeof(string)) return false;

            return true;
        }

        public IEnumerable<ObjectDataMember> GetDataMembers(Type type)
        {
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.FlattenHierarchy;
            var result = new List<ObjectDataMember>();
            result.AddRange(type.GetFields(flags).Select(v => new ObjectDataMember(v, this)));
            result.AddRange(type.GetProperties(flags).Select(v => new ObjectDataMember(v, this)));

            return result;
        }
    }
}