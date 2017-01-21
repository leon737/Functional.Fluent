using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Functional.Fluent.Extensions;
using Functional.Fluent.Pattern;

namespace Functional.Fluent
{
    public class PropertyEqualityComparer<T, V> : IEqualityComparer<T>
    {
        private readonly Func<IEnumerable<MemberInfo>, T, IEnumerable<object>> _func = (m, o) => m.Select(v => v is FieldInfo ? ((FieldInfo)v).GetValue(o) : ((PropertyInfo)v).GetValue(o));
        private readonly Func<T, IEnumerable<object>> _accessor;

        public PropertyEqualityComparer(Expression<Func<T, V>> selector)
        {
            _accessor = GetAccessor(selector);
        }

        public bool Equals(T x, T y) =>
           _accessor(x).Zip(_accessor(y), Tuple.Create).All(v => EqualsInternal(v.Item1, v.Item2));

        private bool EqualsInternal(object x, object y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            return x.Equals(y);
        }

        public int GetHashCode(T obj) => _accessor(obj).Aggregate(0, (a, v) => a ^ (v?.GetHashCode() ?? 0));

        private Func<T, IEnumerable<object>> GetAccessor(Expression<Func<T, V>> selector) =>
            selector.Body.TypeMatch()
           .With(Case.Is<MemberExpression>(), v => _func.Partial(new[] { v.Member }))
           .With(Case.Is<NewExpression>(), v => _func.Partial(v.Arguments.Select(z => ((MemberExpression)z).Member)))
           .Do();


    }
}