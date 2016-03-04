using System.Text;
using Functional.Fluent;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentTests
{
    [TestClass]
    public class PatternMatchingTests
    {
        [TestMethod]
        public void TestApplyIf()
        {
            var s = "fox";
            var r = s.ToMaybe()
                .ApplyIf(x => x == "bird", x => x + " can fly")
                .ApplyIf(x => x == "fox", x => x + " can run");
            Assert.AreEqual("fox can run", r.Value);
        }

        [TestMethod]
        public void TestApplyIfForValueTypes()
        {
            var i = 4;
            var r = i.ToMaybe()
                .ApplyIf(x => x < 10, x => x * 2)
                .ApplyIf(x => x >= 10, x => x / 5);
            Assert.AreEqual(8, r.Value);
        }

        [TestMethod]
        public void TestMatchingForIntValues()
        {
            var i = 4;
            var m = new Matcher<int, string>
            {
                {x => x % 2 == 0, x => x.ToString() + " is even"},
                {x => true, x => x.ToString() + " is odd"}  
            };

            var r = m.Match(i);
            Assert.AreEqual("4 is even", r);
        }

        [TestMethod]
        public void TestMatchingForIntExactValues()
        {
            var i = 4;
            var m = new Matcher<int, string>
            {
                {5, x => x.ToString() + " is five"},
                {4, x => x.ToString() + " is four"},
                {3, x => x.ToString() + " is three"},
                {x => true, x => x.ToString() + " is something other"}  
            };

            var r = m.Match(i);
            Assert.AreEqual("4 is four", r);
        }

        [TestMethod]
        public void TestMatchingForIntExactValueCollections()
        {
            var i = 4;
            var m = new Matcher<int, string>
            {
                {new[] {2, 4, 6}, x => x.ToString() + " is two or four or six"},
                {new[] {3, 5, 7}, x => x.ToString() + " is three or five or seven"},
                {x => true, x => x.ToString() + " is something other"}  
            };

            var r = m.Match(i);
            Assert.AreEqual("4 is two or four or six", r);
        }

        [TestMethod]
        public void TestNullMaybe()
        {
            string s = null;
            var r = s.ToMaybe();
            Assert.IsFalse(r.HasValue);
        }

        [TestMethod]
        public void TestFluentSyntax()
        {
            var s = "fox".ToMaybe();
            var r = new Matcher<string, string>
            {
                {x => x == "bird", x => x + " can fly"},
                {x => x == "fox", x => x + " can run"},
                {x => true, x => x + " can do something else"},
            }.ToFunc()(s);
            Assert.AreEqual("fox can run", r);
        }

        [TestMethod]
        public void TestFluentSyntax2()
        {
            var s = "fox".ToMaybe().Match(new Matcher<string, string>
            {
                {x => x == "bird", x => x + " can fly"},
                {x => x == "fox", x => x + " can run"},
                {x => true, x => x + " can do something else"},
            });
            Assert.AreEqual("fox can run", s.Value);
        }


        [TestMethod]
        public void TestTypeMatching()
        {
            var m = new TypeMatcher<string>
            {
                { Case.Is<string>(), s => s},
                { Case.Is<StringBuilder>(), s => s.ToString()}
            };

            string test1 = "string";
            Assert.AreEqual("string", m.Match(test1));

            StringBuilder test2 = new StringBuilder("StringBuilder");
            Assert.AreEqual("StringBuilder", m.Match(test2));
        }

        [TestMethod]
        public void TestTypeMatchingFluentSyntax()
        {
            var m = new TypeMatcher<string>
            {
                { Case.Is<string>(), s => s},
                { Case.Is<StringBuilder>(), s => s.ToString()}
            };

            var test1 = ((object)"string").ToMaybe().Match(m);
            Assert.AreEqual("string", test1.Value);

            var test2 = ((object)new StringBuilder("StringBuilder")).ToMaybe().Match(m);
            Assert.AreEqual("StringBuilder", test2.Value);
        }

        [TestMethod]
        public void TestMaybeFluentSyntax()
        {
            var s = "fox".ToMaybe().Match()
                .With(x => x == "bird", x => x + " can fly")
                .With(x => x == "fox", x => x + " can run")
                .Else(x => x + " can do something else")
                .Do();

            Assert.AreEqual("fox can run", s);
        }

        [TestMethod]
        public void TestMaybeFluentSyntaxWithExact()
        {
            var s = "fox".ToMaybe().Match()
                .With("bird", x => x + " can fly")
                .With("fox", x => x + " can run")
                .Else(x => x + " can do something else")
                .Do();

            Assert.AreEqual("fox can run", s);
        }

        [TestMethod]
        public void TestTypeMatchingMaybeFluentSyntax()
        {
            var test1 = ((object) "string").ToMaybe().TypeMatch()
                .With(Case.Is<string>(), s => s)
                .With(Case.Is<StringBuilder>(), s => s.ToString())
                .Else(_ => "that's an object").Do();

            Assert.AreEqual("string", test1);
        }
    }
}
