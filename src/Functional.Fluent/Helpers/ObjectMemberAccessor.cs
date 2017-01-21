using System;
using System.Linq.Expressions;

namespace Functional.Fluent.Helpers
{
    public static class ObjectMemberAccessor
    {
        public static ObjectMemberAccessor<T, V> Create<T, V>(T obj, MemberAccessor<T, V> accessor ) =>
            new ObjectMemberAccessor<T, V>(accessor, obj);

    }
}