


using System;

namespace Functional.Fluent.MonadicTypes
{

	    
	
	public class FuncState<T1, T2> : FuncState< T2>
    {
        protected T1 P1;

        public FuncState(T1 p1)         {
            P1 = p1;
        }

        public T2 Invoke(Func<T1, T2> func) => func(P1);

        public T2 Invoke(Action<T1> action) { action(P1); return default(T2); }

        public override T2 New<V>() => NewCore<V>(P1);

		public new Func<Func<T1, T2>, T2> ToFunc() => (Func<T1, T2> func) => Invoke(func);

		public new Func<Func<T1, T2>, T2> Func => ToFunc();
    }


	    
	
	public class FuncState<T1, T2, T3> : FuncState<T1 , T3>
    {
        protected T2 P2;

        public FuncState(T1 p1, T2 p2)  : base(p1)

		        {
            P2 = p2;
        }

        public T3 Invoke(Func<T1, T2, T3> func) => func(P1, P2);

        public T3 Invoke(Action<T1, T2> action) { action(P1, P2); return default(T3); }

        public override T3 New<V>() => NewCore<V>(P1, P2);

		public new Func<Func<T1, T2, T3>, T3> ToFunc() => (Func<T1, T2, T3> func) => Invoke(func);

		public new Func<Func<T1, T2, T3>, T3> Func => ToFunc();
    }


	    
	
	public class FuncState<T1, T2, T3, T4> : FuncState<T1, T2 , T4>
    {
        protected T3 P3;

        public FuncState(T1 p1, T2 p2, T3 p3)  : base(p1, p2)

		        {
            P3 = p3;
        }

        public T4 Invoke(Func<T1, T2, T3, T4> func) => func(P1, P2, P3);

        public T4 Invoke(Action<T1, T2, T3> action) { action(P1, P2, P3); return default(T4); }

        public override T4 New<V>() => NewCore<V>(P1, P2, P3);

		public new Func<Func<T1, T2, T3, T4>, T4> ToFunc() => (Func<T1, T2, T3, T4> func) => Invoke(func);

		public new Func<Func<T1, T2, T3, T4>, T4> Func => ToFunc();
    }


	    
	
	public class FuncState<T1, T2, T3, T4, T5> : FuncState<T1, T2, T3 , T5>
    {
        protected T4 P4;

        public FuncState(T1 p1, T2 p2, T3 p3, T4 p4)  : base(p1, p2, p3)

		        {
            P4 = p4;
        }

        public T5 Invoke(Func<T1, T2, T3, T4, T5> func) => func(P1, P2, P3, P4);

        public T5 Invoke(Action<T1, T2, T3, T4> action) { action(P1, P2, P3, P4); return default(T5); }

        public override T5 New<V>() => NewCore<V>(P1, P2, P3, P4);

		public new Func<Func<T1, T2, T3, T4, T5>, T5> ToFunc() => (Func<T1, T2, T3, T4, T5> func) => Invoke(func);

		public new Func<Func<T1, T2, T3, T4, T5>, T5> Func => ToFunc();
    }


	    
	
	public class FuncState<T1, T2, T3, T4, T5, T6> : FuncState<T1, T2, T3, T4 , T6>
    {
        protected T5 P5;

        public FuncState(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5)  : base(p1, p2, p3, p4)

		        {
            P5 = p5;
        }

        public T6 Invoke(Func<T1, T2, T3, T4, T5, T6> func) => func(P1, P2, P3, P4, P5);

        public T6 Invoke(Action<T1, T2, T3, T4, T5> action) { action(P1, P2, P3, P4, P5); return default(T6); }

        public override T6 New<V>() => NewCore<V>(P1, P2, P3, P4, P5);

		public new Func<Func<T1, T2, T3, T4, T5, T6>, T6> ToFunc() => (Func<T1, T2, T3, T4, T5, T6> func) => Invoke(func);

		public new Func<Func<T1, T2, T3, T4, T5, T6>, T6> Func => ToFunc();
    }


	    
	
	public class FuncState<T1, T2, T3, T4, T5, T6, T7> : FuncState<T1, T2, T3, T4, T5 , T7>
    {
        protected T6 P6;

        public FuncState(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6)  : base(p1, p2, p3, p4, p5)

		        {
            P6 = p6;
        }

        public T7 Invoke(Func<T1, T2, T3, T4, T5, T6, T7> func) => func(P1, P2, P3, P4, P5, P6);

        public T7 Invoke(Action<T1, T2, T3, T4, T5, T6> action) { action(P1, P2, P3, P4, P5, P6); return default(T7); }

        public override T7 New<V>() => NewCore<V>(P1, P2, P3, P4, P5, P6);

		public new Func<Func<T1, T2, T3, T4, T5, T6, T7>, T7> ToFunc() => (Func<T1, T2, T3, T4, T5, T6, T7> func) => Invoke(func);

		public new Func<Func<T1, T2, T3, T4, T5, T6, T7>, T7> Func => ToFunc();
    }


	    
	
	public class FuncState<T1, T2, T3, T4, T5, T6, T7, T8> : FuncState<T1, T2, T3, T4, T5, T6 , T8>
    {
        protected T7 P7;

        public FuncState(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7)  : base(p1, p2, p3, p4, p5, p6)

		        {
            P7 = p7;
        }

        public T8 Invoke(Func<T1, T2, T3, T4, T5, T6, T7, T8> func) => func(P1, P2, P3, P4, P5, P6, P7);

        public T8 Invoke(Action<T1, T2, T3, T4, T5, T6, T7> action) { action(P1, P2, P3, P4, P5, P6, P7); return default(T8); }

        public override T8 New<V>() => NewCore<V>(P1, P2, P3, P4, P5, P6, P7);

		public new Func<Func<T1, T2, T3, T4, T5, T6, T7, T8>, T8> ToFunc() => (Func<T1, T2, T3, T4, T5, T6, T7, T8> func) => Invoke(func);

		public new Func<Func<T1, T2, T3, T4, T5, T6, T7, T8>, T8> Func => ToFunc();
    }


	    
	
	public class FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9> : FuncState<T1, T2, T3, T4, T5, T6, T7 , T9>
    {
        protected T8 P8;

        public FuncState(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8)  : base(p1, p2, p3, p4, p5, p6, p7)

		        {
            P8 = p8;
        }

        public T9 Invoke(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func) => func(P1, P2, P3, P4, P5, P6, P7, P8);

        public T9 Invoke(Action<T1, T2, T3, T4, T5, T6, T7, T8> action) { action(P1, P2, P3, P4, P5, P6, P7, P8); return default(T9); }

        public override T9 New<V>() => NewCore<V>(P1, P2, P3, P4, P5, P6, P7, P8);

		public new Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T9> ToFunc() => (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9> func) => Invoke(func);

		public new Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9>, T9> Func => ToFunc();
    }


	    
	
	public class FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> : FuncState<T1, T2, T3, T4, T5, T6, T7, T8 , T10>
    {
        protected T9 P9;

        public FuncState(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9)  : base(p1, p2, p3, p4, p5, p6, p7, p8)

		        {
            P9 = p9;
        }

        public T10 Invoke(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> func) => func(P1, P2, P3, P4, P5, P6, P7, P8, P9);

        public T10 Invoke(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> action) { action(P1, P2, P3, P4, P5, P6, P7, P8, P9); return default(T10); }

        public override T10 New<V>() => NewCore<V>(P1, P2, P3, P4, P5, P6, P7, P8, P9);

		public new Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, T10> ToFunc() => (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> func) => Invoke(func);

		public new Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>, T10> Func => ToFunc();
    }


	    
	
	public class FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> : FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9 , T11>
    {
        protected T10 P10;

        public FuncState(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10)  : base(p1, p2, p3, p4, p5, p6, p7, p8, p9)

		        {
            P10 = p10;
        }

        public T11 Invoke(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> func) => func(P1, P2, P3, P4, P5, P6, P7, P8, P9, P10);

        public T11 Invoke(Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> action) { action(P1, P2, P3, P4, P5, P6, P7, P8, P9, P10); return default(T11); }

        public override T11 New<V>() => NewCore<V>(P1, P2, P3, P4, P5, P6, P7, P8, P9, P10);

		public new Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, T11> ToFunc() => (Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> func) => Invoke(func);

		public new Func<Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>, T11> Func => ToFunc();
    }


	
	public partial class FuncState<T>
    {

	
	public FuncState<T1, T> With<T1>(T1 p1) => new FuncState<T1, T>(p1);

	
	public FuncState<T1, T2, T> With<T1, T2>(T1 p1, T2 p2) => new FuncState<T1, T2, T>(p1, p2);

	
	public FuncState<T1, T2, T3, T> With<T1, T2, T3>(T1 p1, T2 p2, T3 p3) => new FuncState<T1, T2, T3, T>(p1, p2, p3);

	
	public FuncState<T1, T2, T3, T4, T> With<T1, T2, T3, T4>(T1 p1, T2 p2, T3 p3, T4 p4) => new FuncState<T1, T2, T3, T4, T>(p1, p2, p3, p4);

	
	public FuncState<T1, T2, T3, T4, T5, T> With<T1, T2, T3, T4, T5>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5) => new FuncState<T1, T2, T3, T4, T5, T>(p1, p2, p3, p4, p5);

	
	public FuncState<T1, T2, T3, T4, T5, T6, T> With<T1, T2, T3, T4, T5, T6>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6) => new FuncState<T1, T2, T3, T4, T5, T6, T>(p1, p2, p3, p4, p5, p6);

	
	public FuncState<T1, T2, T3, T4, T5, T6, T7, T> With<T1, T2, T3, T4, T5, T6, T7>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7) => new FuncState<T1, T2, T3, T4, T5, T6, T7, T>(p1, p2, p3, p4, p5, p6, p7);

	
	public FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T> With<T1, T2, T3, T4, T5, T6, T7, T8>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8) => new FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T>(p1, p2, p3, p4, p5, p6, p7, p8);

	
	public FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T> With<T1, T2, T3, T4, T5, T6, T7, T8, T9>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9) => new FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T>(p1, p2, p3, p4, p5, p6, p7, p8, p9);

	
	public FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T> With<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(T1 p1, T2 p2, T3 p3, T4 p4, T5 p5, T6 p6, T7 p7, T8 p8, T9 p9, T10 p10) => new FuncState<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T>(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10);

	

	}

}