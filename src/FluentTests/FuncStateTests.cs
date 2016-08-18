using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Functional.Fluent;
using static Functional.Fluent.FuncExtensions;

namespace FluentTests
{
    [TestClass]
    public class FuncStateTests
    {

        interface IMyInterface
        {
            int Foo(int a);
        }

        class A : IMyInterface
        {
            public int Foo(int a)
            {
                return a * 2;
            }
        }

        class B : IMyInterface
        {
            public int Foo(int a)
            {
                return a * 3;
            }
        }

        class Processor
        {

            public int Process(IMyInterface v) => Funcs.Get<int>().With(5).With(z =>
                new TypeMatcher<int>
                    {
                    { Case.Is<A>(), x => z.Invoke(((Func<A, int, int>)ProcessA).Curry()(x)) },
                    { Case.Is<B>(), x => z.Invoke(((Func<B, int, int>)ProcessB).Curry()(x)) }
                    }).Value.Match(v);

            int ProcessA(A v, int i)
            {
                Console.WriteLine("A");
                Console.WriteLine(v.Foo(i));
                return i * 10;
            }

            int ProcessB(B v, int i)
            {
                Console.WriteLine("B");
                Console.WriteLine(v.Foo(i));
                return i * 20;
            }
        }

        [TestMethod]
        public void TestUseOfFuncStateWithTypePatternMatching()
        {
            IMyInterface v = new A();

            var processor = new Processor();
            var result = processor.Process(v);

            Assert.AreEqual(50, result);

            v = new B();
            result = processor.Process(v);

            Assert.AreEqual(100, result);
        }

        [TestMethod]
        public void TestUseOfFuncStateWithSimplePatternMatching()
        {
            var add2 = F((int x) => x + 2);
            var mult3 = F((int x) => x * 3);
            var f = Funcs.Get<int>().With(5);

            var result = "multiply".ToM().Match()
                .With("add", _ => f.Invoke(add2))
                .With("multiply", _ => f.Invoke(mult3))
                .Do();

            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void TestUseOfFuncStateWithSimplePatternMatchingUsingCompose()
        {
            var result = F((FuncState<int, int> s) => "multiply".ToM().Match()
                .With("add", _ => s.Invoke(F((int x) => x + 2)))
                .With("multiply", _ => s.Invoke(F((int x) => x * 3)))
                .Do()).Compose(F((int v) => Funcs.Get<int>().With(v)))(5);

            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void TestUseOfFuncStateWithSimplePatternMatchingUsingMatchConstructor()
        {
            var result = Funcs.Get<int>().With(5).With(z =>
                new Matcher<string, int>()
                {
                    { "add", _ => z.Invoke(F((int x) => x + 2)) },
                    { "multiply", _ => z.Invoke(F((int x) => x * 3)) }
                }).Value.Match("multiply");

            Assert.AreEqual(15, result);
        }

        [TestMethod]
        public void TestUseOfFuncStateWithSimplePatternMatchingUsingMatchConstructorAndFluent()
        {
            var result = Funcs.Get<int>().With(5).With(z =>
                new Matcher<string, int>()
                    .With("add", _ => z.Invoke(F((int x) => x + 2)))
                    .With("multiply", _ => z.Invoke(F((int x) => x * 3))))
                    .Value.Match("multiply");

            Assert.AreEqual(15, result);
        }
    }
}
