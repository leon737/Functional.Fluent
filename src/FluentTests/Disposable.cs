using System;

namespace FluentTests
{
    public static class Disposable
    {
        public static V Using<T, V>(Func<T> fabric, Func<T, V> func) where T : IDisposable
        {
            using (var v = fabric())
                return func(v);
        }
    }
}
