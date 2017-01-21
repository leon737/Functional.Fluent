using System;
using System.Linq.Expressions;

namespace Functional.Fluent.Pattern
{
    public class Case
    {
        public static Expression<Func<object, T>> Is<T>() => _ => default(T);
    }
}