using System;
using Functional.Fluent.Extensions;
using Functional.Fluent.Helpers;
using Functional.Fluent.MonadicTypes;
using Functional.Fluent.Pattern;
using NUnit.Framework;
using static Functional.Fluent.Helpers.Funcs;

namespace FluentTests
{
    [TestFixture]
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

        [Test]
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

        [Test]
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

        [Test]
        public void TestUseOfFuncStateWithSimplePatternMatchingUsingRCompose()
        {
            var result = F((FuncState<int, int> v) => "multiply".ToM().Match()
                .With("add", _ => v.Invoke(x => x + 2))
                .With("multiply", _ => v.Invoke(x => x * 3))
                .Do()).RCompose((int v) => Funcs.Get<int>().With(v))(5);

            Assert.AreEqual(15, result);
        }

        [Test]
        public void TestUseOfFuncStateWithSimplePatternMatchingUsingRComposeNoLambda()
        {
            var result = F((FuncState<int, int> v) => "multiply".ToM().Match()
                .With("add", v.Invoke(x => x + 2))
                .With("multiply", v.Invoke(x => x * 3))
                .Do()).RCompose((int v) => Funcs.Get<int>().With(v))(5);

            Assert.AreEqual(15, result);
        }

        [Test]
        public void TestUseOfFuncStateWithSimplePatternMatchingUsingCompose()
        {
            var result = F((int v) => Funcs.Get<int>().With(v))
                .Compose(v => "multiply".ToM().Match()
               .With("add", _ => v.Invoke(F((int x) => x + 2)))
               .With("multiply", _ => v.Invoke(F((int x) => x * 3)))
               .Do())(5);
            Assert.AreEqual(15, result);
        }

        [Test]
        public void TestUseOfFuncStateWithSimplePatternMatchingUsingComposeNoLambda()
        {
            var result = F((int v) => Funcs.Get<int>().With(v))
                .Compose(v => "multiply".ToM().Match()
               .With("add", v.Invoke(F((int x) => x + 2)))
               .With("multiply", v.Invoke(F((int x) => x * 3)))
               .Do())(5);
            Assert.AreEqual(15, result);
        }

        [Test]
        public void TestUseOfFuncStateWithSimplePatternMatchingUsingCall()
        {
            var result = F((Func<Func<int, int>, int> v) => "multiply".ToM().Match()
                .With("add", _ => v(x => x + 2))
                .With("multiply", _ => v(x => x * 3))
                .Do())(F((int v) => Funcs.Get<int>().With(v).Func)(5));

            Assert.AreEqual(15, result);
        }

        [Test]
        public void TestUseOfFuncStateWithSimplePatternMatchingUsingCallNoLambda()
        {
            var result = F((Func<Func<int, int>, int> v) => "multiply".ToM().Match()
                .With("add", v(x => x + 2))
                .With("multiply", v(x => x * 3))
                .Do())(F((int v) => Funcs.Get<int>().With(v).Func)(5));

            Assert.AreEqual(15, result);
        }

        [Test]
        public void TestUseOfFuncStateWithSimplePatternMatchingUsingMatchConstructor()
        {
            var result = Funcs.Get<int>().With(5).With(v =>
                new Matcher<string, int>()
                {
                    { "add", _ => v.Invoke(x => x + 2) },
                    { "multiply", _ => v.Invoke(x => x * 3) }
                }).Value.Match("multiply");

            Assert.AreEqual(15, result);
        }

        [Test]
        public void TestUseOfFuncStateWithSimplePatternMatchingUsingMatchConstructorAndFluent()
        {
            var result = Funcs.Get<int>().With(5).With(v =>
                new Matcher<string, int>()
                    .With("add", _ => v.Invoke(x => x + 2))
                    .With("multiply", _ => v.Invoke(x => x * 3)))
                    .Value.Match("multiply");

            Assert.AreEqual(15, result);
        }

        [Test]
        public void TestUseOfFuncStateWithSimplePatternMatchingUsingMatchConstructorAndFluentNoLambda()
        {
            var result = Funcs.Get<int>().With(5).With(v =>
                new Matcher<string, int>()
                    .With("add", v.Invoke(x => x + 2))
                    .With("multiply", v.Invoke(x => x * 3)))
                    .Value.Match("multiply");

            Assert.AreEqual(15, result);
        }

        [Test]
        public void TestUseOfFuncStateWithSimplePatternMatchingUsingMathExtension()
        {
            var result = Funcs.Get<int>().With(5).Match("multiply".ToM(), (m, v) => m
                    .With("add", _ => v(x => x + 2))
                    .With("multiply", _ => v(x => x * 3))).Do();

            Assert.AreEqual(15, result);
        }

        [Test]
        public void TestUseOfFuncStateWithSimplePatternMatchingUsingMathExtensionNoLambda()
        {
            var result = Funcs.Get<int>().With(5).Match("multiply".ToM(), (m, v) => m
                    .With("add", v(x => x + 2))
                    .With("multiply", v(x => x * 3))).Do();

            Assert.AreEqual(15, result);
        }

        [Test]
        public void TestUseOfFuncStateWithSimpleTypePatternMatchingUsingMathExtension()
        {
            var result = Funcs.Get<int>().With(5).TypeMatch(((object)"the long string").ToM(), (m, v) => m
                    .With(Case.Is<string>(), _ => v(x => x * 3))
                    .With(Case.Is<string>(), _ => v(x => x + 2))
                    .Else(_ => v(x => x))).Do();

            Assert.AreEqual(15, result);
        }

        [Test]
        public void TestUseOfFuncStateWithSimpleTypePatternMatchingUsingMathExtensionNoLambda()
        {
            var result = Funcs.Get<int>().With(5).TypeMatch(((object)"the long string").ToM(), (m, v) => m
                    .With(Case.Is<string>(), v(x => x * 3))
                    .With(Case.Is<string>(), v(x => x + 2))
                    .Else(v(x => x))).Do();

            Assert.AreEqual(15, result);
        }
    }
}