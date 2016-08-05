using System;
using Functional.Fluent;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentTests
{
    [TestClass]
    public class FuncsConstructorTests
    {

        public interface ISomeInterface
        {
            int Foo();
        }

        public class ClassA : ISomeInterface
        {
            private readonly int _v;

            public ClassA(int v)
            {
                _v = v;
            }

            public int Foo() => _v * 2;
        }

        public class ClassB : ISomeInterface
        {
            private readonly int _v;

            public ClassB(int v)
            {
                _v = v;
            }

            public int Foo() => _v * 3;
        }

        [TestMethod]
        public void TestSimpleConstructors()
        {
            var func = Funcs.Get<int, ISomeInterface>(5);

            var resultA = func.New<ClassA>().Foo();

            var resultB = func.New<ClassB>().Foo();

            Assert.AreEqual(10, resultA);

            Assert.AreEqual(15, resultB);

        }

        [TestMethod]
        public void TestSimpleConstructorsUsingMatching()
        {
            var f = Funcs.Get<int, ISomeInterface>(5).ToMaybe().With(v =>
                    new Matcher<string, ISomeInterface>
                    {
                        {nameof(ClassA), x => v.New<ClassA>()},
                        {nameof(ClassB), x => v.New<ClassB>()},
                    }).Value;

            Assert.AreEqual(10, f.Match(nameof(ClassA)).Foo());
            Assert.AreEqual(15, f.Match(nameof(ClassB)).Foo());
        }
    }
}
