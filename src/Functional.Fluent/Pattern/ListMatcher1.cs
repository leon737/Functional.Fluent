


using System;
using System.Collections.Generic;
using System.Linq;

namespace Functional.Fluent.Pattern
{
	public partial class ListMatcher<TV, TU> : Matcher<IEnumerable<TV>, TU>
    {


			
		public void Add(Func<TV,TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(x => x != null && x.Any(), 
                v => func(v.ElementAt(0), v.ElementAt(1), v.Skip(2)))); 
        }
				

		public void Add( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Func<TV, TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(
                x => x != null && x.Any() &&   predicate0 (x.ElementAt(0))&&  predicate1 (x.ElementAt(1)),
                v => func(v.ElementAt(0), v.ElementAt(1), v.Skip(2))));
        }

		public ListMatcher<TV, TU> With(Func<TV,TV, IEnumerable<TV>, TU> func)
        {
            Add(func);
            return this;
        }

		public ListMatcher<TV, TU> With( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Func<TV, TV, IEnumerable<TV>, TU> func)
        {
            Add(predicate0 ,predicate1 , func);
            return this;
        }


		public ListMatcher<TV, TU> With( Predicate<TV> predicate0,  Predicate<TV> predicate1, TU returnValue)
        {
            Add(predicate0,predicate1, (p1, p2, p3) => returnValue);
            return this;
        }
		

			
		public void Add(Func<TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(x => x != null && x.Any(), 
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.Skip(3)))); 
        }
				

		public void Add( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Func<TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(
                x => x != null && x.Any() &&   predicate0 (x.ElementAt(0))&&  predicate1 (x.ElementAt(1))&&  predicate2 (x.ElementAt(2)),
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.Skip(3))));
        }

		public ListMatcher<TV, TU> With(Func<TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            Add(func);
            return this;
        }

		public ListMatcher<TV, TU> With( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Func<TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            Add(predicate0 ,predicate1 ,predicate2 , func);
            return this;
        }


		public ListMatcher<TV, TU> With( Predicate<TV> predicate0,  Predicate<TV> predicate1,  Predicate<TV> predicate2, TU returnValue)
        {
            Add(predicate0,predicate1,predicate2, (p1, p2, p3, p4) => returnValue);
            return this;
        }
		

			
		public void Add(Func<TV,TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(x => x != null && x.Any(), 
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.ElementAt(3), v.Skip(4)))); 
        }
				

		public void Add( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Func<TV, TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(
                x => x != null && x.Any() &&   predicate0 (x.ElementAt(0))&&  predicate1 (x.ElementAt(1))&&  predicate2 (x.ElementAt(2))&&  predicate3 (x.ElementAt(3)),
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.ElementAt(3), v.Skip(4))));
        }

		public ListMatcher<TV, TU> With(Func<TV,TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            Add(func);
            return this;
        }

		public ListMatcher<TV, TU> With( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Func<TV, TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            Add(predicate0 ,predicate1 ,predicate2 ,predicate3 , func);
            return this;
        }


		public ListMatcher<TV, TU> With( Predicate<TV> predicate0,  Predicate<TV> predicate1,  Predicate<TV> predicate2,  Predicate<TV> predicate3, TU returnValue)
        {
            Add(predicate0,predicate1,predicate2,predicate3, (p1, p2, p3, p4, p5) => returnValue);
            return this;
        }
		

			
		public void Add(Func<TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(x => x != null && x.Any(), 
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.ElementAt(3), v.ElementAt(4), v.Skip(5)))); 
        }
				

		public void Add( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Func<TV, TV, TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(
                x => x != null && x.Any() &&   predicate0 (x.ElementAt(0))&&  predicate1 (x.ElementAt(1))&&  predicate2 (x.ElementAt(2))&&  predicate3 (x.ElementAt(3))&&  predicate4 (x.ElementAt(4)),
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.ElementAt(3), v.ElementAt(4), v.Skip(5))));
        }

		public ListMatcher<TV, TU> With(Func<TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            Add(func);
            return this;
        }

		public ListMatcher<TV, TU> With( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Func<TV, TV, TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            Add(predicate0 ,predicate1 ,predicate2 ,predicate3 ,predicate4 , func);
            return this;
        }


		public ListMatcher<TV, TU> With( Predicate<TV> predicate0,  Predicate<TV> predicate1,  Predicate<TV> predicate2,  Predicate<TV> predicate3,  Predicate<TV> predicate4, TU returnValue)
        {
            Add(predicate0,predicate1,predicate2,predicate3,predicate4, (p1, p2, p3, p4, p5, p6) => returnValue);
            return this;
        }
		

			
		public void Add(Func<TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(x => x != null && x.Any(), 
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.ElementAt(3), v.ElementAt(4), v.ElementAt(5), v.Skip(6)))); 
        }
				

		public void Add( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Func<TV, TV, TV, TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(
                x => x != null && x.Any() &&   predicate0 (x.ElementAt(0))&&  predicate1 (x.ElementAt(1))&&  predicate2 (x.ElementAt(2))&&  predicate3 (x.ElementAt(3))&&  predicate4 (x.ElementAt(4))&&  predicate5 (x.ElementAt(5)),
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.ElementAt(3), v.ElementAt(4), v.ElementAt(5), v.Skip(6))));
        }

		public ListMatcher<TV, TU> With(Func<TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            Add(func);
            return this;
        }

		public ListMatcher<TV, TU> With( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Func<TV, TV, TV, TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            Add(predicate0 ,predicate1 ,predicate2 ,predicate3 ,predicate4 ,predicate5 , func);
            return this;
        }


		public ListMatcher<TV, TU> With( Predicate<TV> predicate0,  Predicate<TV> predicate1,  Predicate<TV> predicate2,  Predicate<TV> predicate3,  Predicate<TV> predicate4,  Predicate<TV> predicate5, TU returnValue)
        {
            Add(predicate0,predicate1,predicate2,predicate3,predicate4,predicate5, (p1, p2, p3, p4, p5, p6, p7) => returnValue);
            return this;
        }
		

			
		public void Add(Func<TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(x => x != null && x.Any(), 
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.ElementAt(3), v.ElementAt(4), v.ElementAt(5), v.ElementAt(6), v.Skip(7)))); 
        }
				

		public void Add( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Func<TV, TV, TV, TV, TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(
                x => x != null && x.Any() &&   predicate0 (x.ElementAt(0))&&  predicate1 (x.ElementAt(1))&&  predicate2 (x.ElementAt(2))&&  predicate3 (x.ElementAt(3))&&  predicate4 (x.ElementAt(4))&&  predicate5 (x.ElementAt(5))&&  predicate6 (x.ElementAt(6)),
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.ElementAt(3), v.ElementAt(4), v.ElementAt(5), v.ElementAt(6), v.Skip(7))));
        }

		public ListMatcher<TV, TU> With(Func<TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            Add(func);
            return this;
        }

		public ListMatcher<TV, TU> With( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Func<TV, TV, TV, TV, TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            Add(predicate0 ,predicate1 ,predicate2 ,predicate3 ,predicate4 ,predicate5 ,predicate6 , func);
            return this;
        }


		public ListMatcher<TV, TU> With( Predicate<TV> predicate0,  Predicate<TV> predicate1,  Predicate<TV> predicate2,  Predicate<TV> predicate3,  Predicate<TV> predicate4,  Predicate<TV> predicate5,  Predicate<TV> predicate6, TU returnValue)
        {
            Add(predicate0,predicate1,predicate2,predicate3,predicate4,predicate5,predicate6, (p1, p2, p3, p4, p5, p6, p7, p8) => returnValue);
            return this;
        }
		

			
		public void Add(Func<TV,TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(x => x != null && x.Any(), 
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.ElementAt(3), v.ElementAt(4), v.ElementAt(5), v.ElementAt(6), v.ElementAt(7), v.Skip(8)))); 
        }
				

		public void Add( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Predicate<TV> predicate7  , Func<TV, TV, TV, TV, TV, TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(
                x => x != null && x.Any() &&   predicate0 (x.ElementAt(0))&&  predicate1 (x.ElementAt(1))&&  predicate2 (x.ElementAt(2))&&  predicate3 (x.ElementAt(3))&&  predicate4 (x.ElementAt(4))&&  predicate5 (x.ElementAt(5))&&  predicate6 (x.ElementAt(6))&&  predicate7 (x.ElementAt(7)),
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.ElementAt(3), v.ElementAt(4), v.ElementAt(5), v.ElementAt(6), v.ElementAt(7), v.Skip(8))));
        }

		public ListMatcher<TV, TU> With(Func<TV,TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            Add(func);
            return this;
        }

		public ListMatcher<TV, TU> With( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Predicate<TV> predicate7  , Func<TV, TV, TV, TV, TV, TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            Add(predicate0 ,predicate1 ,predicate2 ,predicate3 ,predicate4 ,predicate5 ,predicate6 ,predicate7 , func);
            return this;
        }


		public ListMatcher<TV, TU> With( Predicate<TV> predicate0,  Predicate<TV> predicate1,  Predicate<TV> predicate2,  Predicate<TV> predicate3,  Predicate<TV> predicate4,  Predicate<TV> predicate5,  Predicate<TV> predicate6,  Predicate<TV> predicate7, TU returnValue)
        {
            Add(predicate0,predicate1,predicate2,predicate3,predicate4,predicate5,predicate6,predicate7, (p1, p2, p3, p4, p5, p6, p7, p8, p9) => returnValue);
            return this;
        }
		

			
		public void Add(Func<TV,TV,TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(x => x != null && x.Any(), 
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.ElementAt(3), v.ElementAt(4), v.ElementAt(5), v.ElementAt(6), v.ElementAt(7), v.ElementAt(8), v.Skip(9)))); 
        }
				

		public void Add( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Predicate<TV> predicate7  , Predicate<TV> predicate8  , Func<TV, TV, TV, TV, TV, TV, TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(
                x => x != null && x.Any() &&   predicate0 (x.ElementAt(0))&&  predicate1 (x.ElementAt(1))&&  predicate2 (x.ElementAt(2))&&  predicate3 (x.ElementAt(3))&&  predicate4 (x.ElementAt(4))&&  predicate5 (x.ElementAt(5))&&  predicate6 (x.ElementAt(6))&&  predicate7 (x.ElementAt(7))&&  predicate8 (x.ElementAt(8)),
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.ElementAt(3), v.ElementAt(4), v.ElementAt(5), v.ElementAt(6), v.ElementAt(7), v.ElementAt(8), v.Skip(9))));
        }

		public ListMatcher<TV, TU> With(Func<TV,TV,TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            Add(func);
            return this;
        }

		public ListMatcher<TV, TU> With( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Predicate<TV> predicate7  , Predicate<TV> predicate8  , Func<TV, TV, TV, TV, TV, TV, TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            Add(predicate0 ,predicate1 ,predicate2 ,predicate3 ,predicate4 ,predicate5 ,predicate6 ,predicate7 ,predicate8 , func);
            return this;
        }


		public ListMatcher<TV, TU> With( Predicate<TV> predicate0,  Predicate<TV> predicate1,  Predicate<TV> predicate2,  Predicate<TV> predicate3,  Predicate<TV> predicate4,  Predicate<TV> predicate5,  Predicate<TV> predicate6,  Predicate<TV> predicate7,  Predicate<TV> predicate8, TU returnValue)
        {
            Add(predicate0,predicate1,predicate2,predicate3,predicate4,predicate5,predicate6,predicate7,predicate8, (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) => returnValue);
            return this;
        }
		

			
		public void Add(Func<TV,TV,TV,TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(x => x != null && x.Any(), 
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.ElementAt(3), v.ElementAt(4), v.ElementAt(5), v.ElementAt(6), v.ElementAt(7), v.ElementAt(8), v.ElementAt(9), v.Skip(10)))); 
        }
				

		public void Add( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Predicate<TV> predicate7  , Predicate<TV> predicate8  , Predicate<TV> predicate9  , Func<TV, TV, TV, TV, TV, TV, TV, TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(
                x => x != null && x.Any() &&   predicate0 (x.ElementAt(0))&&  predicate1 (x.ElementAt(1))&&  predicate2 (x.ElementAt(2))&&  predicate3 (x.ElementAt(3))&&  predicate4 (x.ElementAt(4))&&  predicate5 (x.ElementAt(5))&&  predicate6 (x.ElementAt(6))&&  predicate7 (x.ElementAt(7))&&  predicate8 (x.ElementAt(8))&&  predicate9 (x.ElementAt(9)),
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.ElementAt(3), v.ElementAt(4), v.ElementAt(5), v.ElementAt(6), v.ElementAt(7), v.ElementAt(8), v.ElementAt(9), v.Skip(10))));
        }

		public ListMatcher<TV, TU> With(Func<TV,TV,TV,TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            Add(func);
            return this;
        }

		public ListMatcher<TV, TU> With( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Predicate<TV> predicate7  , Predicate<TV> predicate8  , Predicate<TV> predicate9  , Func<TV, TV, TV, TV, TV, TV, TV, TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            Add(predicate0 ,predicate1 ,predicate2 ,predicate3 ,predicate4 ,predicate5 ,predicate6 ,predicate7 ,predicate8 ,predicate9 , func);
            return this;
        }


		public ListMatcher<TV, TU> With( Predicate<TV> predicate0,  Predicate<TV> predicate1,  Predicate<TV> predicate2,  Predicate<TV> predicate3,  Predicate<TV> predicate4,  Predicate<TV> predicate5,  Predicate<TV> predicate6,  Predicate<TV> predicate7,  Predicate<TV> predicate8,  Predicate<TV> predicate9, TU returnValue)
        {
            Add(predicate0,predicate1,predicate2,predicate3,predicate4,predicate5,predicate6,predicate7,predicate8,predicate9, (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) => returnValue);
            return this;
        }
		

			
		public void Add(Func<TV,TV,TV,TV,TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(x => x != null && x.Any(), 
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.ElementAt(3), v.ElementAt(4), v.ElementAt(5), v.ElementAt(6), v.ElementAt(7), v.ElementAt(8), v.ElementAt(9), v.ElementAt(10), v.Skip(11)))); 
        }
				

		public void Add( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Predicate<TV> predicate7  , Predicate<TV> predicate8  , Predicate<TV> predicate9  , Predicate<TV> predicate10  , Func<TV, TV, TV, TV, TV, TV, TV, TV, TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            list.Add(new Tuple<Predicate<IEnumerable<TV>>, Func<IEnumerable<TV>, TU>>(
                x => x != null && x.Any() &&   predicate0 (x.ElementAt(0))&&  predicate1 (x.ElementAt(1))&&  predicate2 (x.ElementAt(2))&&  predicate3 (x.ElementAt(3))&&  predicate4 (x.ElementAt(4))&&  predicate5 (x.ElementAt(5))&&  predicate6 (x.ElementAt(6))&&  predicate7 (x.ElementAt(7))&&  predicate8 (x.ElementAt(8))&&  predicate9 (x.ElementAt(9))&&  predicate10 (x.ElementAt(10)),
                v => func(v.ElementAt(0), v.ElementAt(1), v.ElementAt(2), v.ElementAt(3), v.ElementAt(4), v.ElementAt(5), v.ElementAt(6), v.ElementAt(7), v.ElementAt(8), v.ElementAt(9), v.ElementAt(10), v.Skip(11))));
        }

		public ListMatcher<TV, TU> With(Func<TV,TV,TV,TV,TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func)
        {
            Add(func);
            return this;
        }

		public ListMatcher<TV, TU> With( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Predicate<TV> predicate7  , Predicate<TV> predicate8  , Predicate<TV> predicate9  , Predicate<TV> predicate10  , Func<TV, TV, TV, TV, TV, TV, TV, TV, TV, TV, TV, IEnumerable<TV>, TU> func)
        {
            Add(predicate0 ,predicate1 ,predicate2 ,predicate3 ,predicate4 ,predicate5 ,predicate6 ,predicate7 ,predicate8 ,predicate9 ,predicate10 , func);
            return this;
        }


		public ListMatcher<TV, TU> With( Predicate<TV> predicate0,  Predicate<TV> predicate1,  Predicate<TV> predicate2,  Predicate<TV> predicate3,  Predicate<TV> predicate4,  Predicate<TV> predicate5,  Predicate<TV> predicate6,  Predicate<TV> predicate7,  Predicate<TV> predicate8,  Predicate<TV> predicate9,  Predicate<TV> predicate10, TU returnValue)
        {
            Add(predicate0,predicate1,predicate2,predicate3,predicate4,predicate5,predicate6,predicate7,predicate8,predicate9,predicate10, (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) => returnValue);
            return this;
        }
		

	
	}

	public partial class  ListMatcherContext<TV> : MatcherContext<IEnumerable<TV>>
    {

			
		public ListMatcher<TV, TU> With<TU>(Func<TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { func } };

		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Func<TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { predicate0 ,predicate1 , func } };


		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , TU returnValue) =>
            new ListMatcher<TV, TU>(contextValue) { { predicate0,predicate1, (p1, p2, p3) => returnValue } };

			
		public ListMatcher<TV, TU> With<TU>(Func<TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { func } };

		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Func<TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { predicate0 ,predicate1 ,predicate2 , func } };


		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , TU returnValue) =>
            new ListMatcher<TV, TU>(contextValue) { { predicate0,predicate1,predicate2, (p1, p2, p3, p4) => returnValue } };

			
		public ListMatcher<TV, TU> With<TU>(Func<TV,TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { func } };

		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Func<TV,TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { predicate0 ,predicate1 ,predicate2 ,predicate3 , func } };


		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , TU returnValue) =>
            new ListMatcher<TV, TU>(contextValue) { { predicate0,predicate1,predicate2,predicate3, (p1, p2, p3, p4, p5) => returnValue } };

			
		public ListMatcher<TV, TU> With<TU>(Func<TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { func } };

		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Func<TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { predicate0 ,predicate1 ,predicate2 ,predicate3 ,predicate4 , func } };


		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , TU returnValue) =>
            new ListMatcher<TV, TU>(contextValue) { { predicate0,predicate1,predicate2,predicate3,predicate4, (p1, p2, p3, p4, p5, p6) => returnValue } };

			
		public ListMatcher<TV, TU> With<TU>(Func<TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { func } };

		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Func<TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { predicate0 ,predicate1 ,predicate2 ,predicate3 ,predicate4 ,predicate5 , func } };


		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , TU returnValue) =>
            new ListMatcher<TV, TU>(contextValue) { { predicate0,predicate1,predicate2,predicate3,predicate4,predicate5, (p1, p2, p3, p4, p5, p6, p7) => returnValue } };

			
		public ListMatcher<TV, TU> With<TU>(Func<TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { func } };

		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Func<TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { predicate0 ,predicate1 ,predicate2 ,predicate3 ,predicate4 ,predicate5 ,predicate6 , func } };


		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , TU returnValue) =>
            new ListMatcher<TV, TU>(contextValue) { { predicate0,predicate1,predicate2,predicate3,predicate4,predicate5,predicate6, (p1, p2, p3, p4, p5, p6, p7, p8) => returnValue } };

			
		public ListMatcher<TV, TU> With<TU>(Func<TV,TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { func } };

		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Predicate<TV> predicate7  , Func<TV,TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { predicate0 ,predicate1 ,predicate2 ,predicate3 ,predicate4 ,predicate5 ,predicate6 ,predicate7 , func } };


		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Predicate<TV> predicate7  , TU returnValue) =>
            new ListMatcher<TV, TU>(contextValue) { { predicate0,predicate1,predicate2,predicate3,predicate4,predicate5,predicate6,predicate7, (p1, p2, p3, p4, p5, p6, p7, p8, p9) => returnValue } };

			
		public ListMatcher<TV, TU> With<TU>(Func<TV,TV,TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { func } };

		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Predicate<TV> predicate7  , Predicate<TV> predicate8  , Func<TV,TV,TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { predicate0 ,predicate1 ,predicate2 ,predicate3 ,predicate4 ,predicate5 ,predicate6 ,predicate7 ,predicate8 , func } };


		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Predicate<TV> predicate7  , Predicate<TV> predicate8  , TU returnValue) =>
            new ListMatcher<TV, TU>(contextValue) { { predicate0,predicate1,predicate2,predicate3,predicate4,predicate5,predicate6,predicate7,predicate8, (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10) => returnValue } };

			
		public ListMatcher<TV, TU> With<TU>(Func<TV,TV,TV,TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { func } };

		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Predicate<TV> predicate7  , Predicate<TV> predicate8  , Predicate<TV> predicate9  , Func<TV,TV,TV,TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { predicate0 ,predicate1 ,predicate2 ,predicate3 ,predicate4 ,predicate5 ,predicate6 ,predicate7 ,predicate8 ,predicate9 , func } };


		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Predicate<TV> predicate7  , Predicate<TV> predicate8  , Predicate<TV> predicate9  , TU returnValue) =>
            new ListMatcher<TV, TU>(contextValue) { { predicate0,predicate1,predicate2,predicate3,predicate4,predicate5,predicate6,predicate7,predicate8,predicate9, (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11) => returnValue } };

			
		public ListMatcher<TV, TU> With<TU>(Func<TV,TV,TV,TV,TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { func } };

		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Predicate<TV> predicate7  , Predicate<TV> predicate8  , Predicate<TV> predicate9  , Predicate<TV> predicate10  , Func<TV,TV,TV,TV,TV,TV,TV,TV,TV,TV,TV, IEnumerable<TV>, TU> func) => 
            new ListMatcher<TV, TU>(contextValue) { { predicate0 ,predicate1 ,predicate2 ,predicate3 ,predicate4 ,predicate5 ,predicate6 ,predicate7 ,predicate8 ,predicate9 ,predicate10 , func } };


		public ListMatcher<TV, TU> With<TU>( Predicate<TV> predicate0  , Predicate<TV> predicate1  , Predicate<TV> predicate2  , Predicate<TV> predicate3  , Predicate<TV> predicate4  , Predicate<TV> predicate5  , Predicate<TV> predicate6  , Predicate<TV> predicate7  , Predicate<TV> predicate8  , Predicate<TV> predicate9  , Predicate<TV> predicate10  , TU returnValue) =>
            new ListMatcher<TV, TU>(contextValue) { { predicate0,predicate1,predicate2,predicate3,predicate4,predicate5,predicate6,predicate7,predicate8,predicate9,predicate10, (p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12) => returnValue } };

	
	}
}