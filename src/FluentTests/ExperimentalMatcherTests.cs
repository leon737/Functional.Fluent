using Functional.Fluent.Pattern;
using NUnit.Framework;

namespace FluentTests
{

    [TestFixture]
    public class ExperimentalMatcherTests
    {

        [Test]
        public void TestMakeExpressions()
        {
            var matcher = new ExperimentalMatcher<string, int>()
                .With("Hello", 1)
                .With("Good", "Bye", 2);

            Assert.AreEqual(1, matcher.Match("Hello"));
            Assert.AreEqual(2, matcher.Match("Good"));
            Assert.AreEqual(2, matcher.Match("Bye"));
        }

        [Test]
        public void TestMakeExpressionsCompile()
        {
            var matcher = new ExperimentalMatcher<string, int>()
                .With("Hello", 1)
                .With("Good", "Bye", 2);

            var func = matcher.Compile();

            Assert.AreEqual(1, func("Hello"));
            Assert.AreEqual(2, func("Good"));
            Assert.AreEqual(2, func("Bye"));
        }


        [Test]
        public void TestMakeExpressionsCompileLambdas()
        {
            var matcher = new ExperimentalMatcher<string, int>()
                .With(x => x == "Hello", v => v.Length * 2)
                .With(x => x == "Good" || x == "Bye", v => v.Length);

            var func = matcher.Compile();

            Assert.AreEqual(10, func("Hello"));
            Assert.AreEqual(4, func("Good"));
            Assert.AreEqual(3, func("Bye"));
        }

        [Test]
        public void TestMakeExpressionsElseCompile()
        {
            var matcher = new ExperimentalMatcher<string, int>()
                .With("Hello", 1)
                .With("Good", "Bye", 2)
                .Null(3)
                .Else(4);

            var func = matcher.Compile();

            Assert.AreEqual(1, func("Hello"));
            Assert.AreEqual(2, func("Good"));
            Assert.AreEqual(2, func("Bye"));
            Assert.AreEqual(3, func(null));
            Assert.AreEqual(4, func("Hi"));
        }

        [Test]
        public void TestMakeExpressionsCompile2()
        {
            var matcher = new ExperimentalMatcher<int, string>()
                .With(1, "Hello")
                .With(2, "Goodbye");

            var func = matcher.Compile();

            Assert.AreEqual("Hello", func(1));
            Assert.AreEqual("Goodbye", func(2));
        }

        [Test]
        public void TestMakeExpressionsCompile3()
        {
            var matcher = new ExperimentalMatcher<int, string>()
                .With(1, "Hello")
                .With(2, (string)null)
                .With(3, _ => null);

            var func = matcher.Compile();

            Assert.AreEqual("Hello", func(1));
            Assert.IsNull(func(2));
            Assert.IsNull(func(3));
        }
    }
}