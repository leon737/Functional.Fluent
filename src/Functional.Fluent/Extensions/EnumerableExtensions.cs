using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Functional.Fluent.Extensions
{

    public static partial class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            var exceptions = new List<Exception>();
            try
            {
                foreach (var item in source)
                {
                    action(item);
                }
            }
            catch (Exception ex)
            {
                exceptions.Add(ex);
            }
            if (exceptions.Any())
                throw new AggregateException(exceptions);
        }

        public static IEnumerable<T> Apply<T>(this IEnumerable<T> collection, Action<T> applicator)
        {
            if (applicator == null)
                throw new ArgumentNullException(nameof(applicator));
            foreach (var item in collection)
            {
                applicator(item);
                yield return item;
            }
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> collection, PredicateCombination combination, 
            params Predicate<T>[] predicates)
        {
            if (collection == null) yield break;
            foreach (var item in collection)
                if (combination == PredicateCombination.OrEse && predicates.Any(p => p(item)) 
                    || (combination == PredicateCombination.AndAlso && predicates.All(p => p(item))))
                    yield return item;
        }

        public static IReadOnlyList<T> AsReadOnlyList<T>(this IEnumerable<T> collection)
        {
            if (collection == null) return null;
            var list = collection as IReadOnlyList<T>;
            return list ?? collection.ToList();
        }

        public static IEnumerable<T> DistinctBy<T, V>(this IEnumerable<T> collection, Expression<Func<T, V>> selector) =>
            collection.Distinct(new PropertyEqualityComparer<T, V>(selector));

        public static IEnumerable<T> IntersectBy<T, V>(this IEnumerable<T> collection, IEnumerable<T> other,
                Expression<Func<T, V>> selector) =>
            collection.Intersect(other, new PropertyEqualityComparer<T, V>(selector));

        public static IEnumerable<T> UnionBy<T, V>(this IEnumerable<T> collection, IEnumerable<T> other,
                Expression<Func<T, V>> selector) =>
            collection.Union(other, new PropertyEqualityComparer<T, V>(selector));

        public static IEnumerable<T> ExceptBy<T, V>(this IEnumerable<T> collection, IEnumerable<T> other,
                Expression<Func<T, V>> selector) =>
            collection.Except(other, new PropertyEqualityComparer<T, V>(selector));


        public static IEnumerable<Tuple<T1, T2>> CrossJoin<T1, T2>(this IEnumerable<T1> collection, IEnumerable<T2> otherCollection) => collection.SelectMany(v1 => otherCollection.Select(v2 => Tuple.Create(v1, v2)));

        public static IEnumerable<Tuple<T1, T2, T3>> CrossJoin<T1, T2, T3>(this IEnumerable<Tuple<T1, T2>> collection, IEnumerable<T3> otherCollection) =>
            collection.SelectMany(v1 => otherCollection.Select(v2 => Tuple.Create(v1.Item1, v1.Item2, v2)));

        public enum PredicateCombination
        {
            AndAlso,
            OrEse
        }
    }
}