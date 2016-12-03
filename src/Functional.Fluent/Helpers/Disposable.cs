using System;
using System.Linq.Expressions;

namespace Functional.Fluent.Helpers
{
    public static class Disposable
    {
        public static V Using<T, V>(Func<T> fabric, Func<T, V> func) where T : IDisposable
        {
            using (var v = fabric())
                return func(v);
        }

        public static Expression<Func<V>> UsingExpression<T, V>(Expression<Func<T>> fabric, Expression<Func<T, V>> func) where T : IDisposable
        {
            return () => UsingInternal(fabric, func);
        }

        private static V UsingInternal<T, V>(Expression<Func<T>> fabric, Expression<Func<T, V>> func) where T : IDisposable
        {
            using (var v = fabric.Compile()())
                return func.Compile()(v);

        }
    }
}
