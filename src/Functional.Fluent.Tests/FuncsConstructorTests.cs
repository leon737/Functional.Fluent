using Functional.Fluent.Extensions;
using Functional.Fluent.Helpers;
using Functional.Fluent.Pattern;
using NUnit.Framework;

namespace FluentTests
{
    [TestFixture]
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

        [Test]
        public void TestSimpleConstructors()
        {
            var func = Funcs.Get<int, ISomeInterface>(5);

            var resultA = func.New<ClassA>().Foo();

            var resultB = func.New<ClassB>().Foo();

            Assert.AreEqual(10, resultA);

            Assert.AreEqual(15, resultB);

        }

        [Test]
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
