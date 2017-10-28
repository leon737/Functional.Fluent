


using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Fluent.Extensions
{

	public static partial class EnumerableExtensions 
    {

	
	   public static IEnumerable<Tuple<T1, T2, T3, T4>> CrossJoin<T1, T2, T3, T4>(this IEnumerable<Tuple<T1, T2, T3>> collection, IEnumerable<T4> otherCollection) => 
            collection.SelectMany(v1 => otherCollection.Select(v2 => Tuple.Create( v1.Item1,  v1.Item2,  v1.Item3,  v2)));


	
	   public static IEnumerable<Tuple<T1, T2, T3, T4, T5>> CrossJoin<T1, T2, T3, T4, T5>(this IEnumerable<Tuple<T1, T2, T3, T4>> collection, IEnumerable<T5> otherCollection) => 
            collection.SelectMany(v1 => otherCollection.Select(v2 => Tuple.Create( v1.Item1,  v1.Item2,  v1.Item3,  v1.Item4,  v2)));


	
	   public static IEnumerable<Tuple<T1, T2, T3, T4, T5, T6>> CrossJoin<T1, T2, T3, T4, T5, T6>(this IEnumerable<Tuple<T1, T2, T3, T4, T5>> collection, IEnumerable<T6> otherCollection) => 
            collection.SelectMany(v1 => otherCollection.Select(v2 => Tuple.Create( v1.Item1,  v1.Item2,  v1.Item3,  v1.Item4,  v1.Item5,  v2)));


	
	   public static IEnumerable<Tuple<T1, T2, T3, T4, T5, T6, T7>> CrossJoin<T1, T2, T3, T4, T5, T6, T7>(this IEnumerable<Tuple<T1, T2, T3, T4, T5, T6>> collection, IEnumerable<T7> otherCollection) => 
            collection.SelectMany(v1 => otherCollection.Select(v2 => Tuple.Create( v1.Item1,  v1.Item2,  v1.Item3,  v1.Item4,  v1.Item5,  v1.Item6,  v2)));


	

	}

}