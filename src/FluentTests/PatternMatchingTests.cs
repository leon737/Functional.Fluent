using System.Text;
using Functional.Fluent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

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

        [TestMethod]
        public void TestTypeMatchingMaybeFluentSyntaxWithAdditionalPredicate()
        {
            var test1 = ((object)"the long string").ToMaybe().TypeMatch()
                .With(Case.Is<string>(), s => s.Length > 10, s => s + "!")
                .With(Case.Is<string>(), s => s)
                .With(Case.Is<StringBuilder>(), s => s.ToString())
                .Else(_ => "that's an object").Do();

            Assert.AreEqual("the long string!", test1);
        }

        [TestMethod]
        public void TestMatchList()
        {
            var list = new [] { "good morning", "good afternoon", "good evening" };
            var result = list.ToMaybe().Match()
                .With((h, t) => Tuple.Create(h.ToUpper(), t))
                .Do();
            Assert.AreEqual("GOOD MORNING", result.Item1);
            Assert.AreEqual(2, result.Item2.Count());
        }

        [TestMethod]
        public void TestMatchEmptyList()
        {
            var list = new List<string>();
            var result = list.ToMaybe().Match()
                .With((h, t) => h.ToUpper())
                .Empty(() => "List is empty")
                .Do();
            Assert.AreEqual("List is empty", result);
        }

        private int factorial(int n) => n.ToMaybe().Match()
            .With(0, 1, _ => 1)
            .Else(v => v* factorial(v - 1))
            .Do();

        [TestMethod]
        public void TestCalculateFactorial()
        {
            int result = factorial(5);
            Assert.AreEqual(120, result);
        }

        private int sum(IEnumerable<int> value) => value.ToMaybe().Match()
            .With((head, tail) => head + sum(tail))
            .Empty(() => 0)
            .Do();

        [TestMethod]
        public void TestCalculateSumInList()
        {
            var list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result = sum(list);
            Assert.AreEqual(list.Sum(), result);          
        }

        private int sum_even(IEnumerable<int> value) => value.ToMaybe().Match()
           .With(v => v % 2 == 0, (head, tail) => head + sum_even(tail))
           .With((_, tail) => sum_even(tail))
           .Empty(() => 0)
           .Do();

        [TestMethod]
        public void TestCalculateSumEvensInList()
        {
            var list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result = sum_even(list);
            Assert.AreEqual(list.Where(x => x % 2 == 0).Sum(), result);
        }

    }
}
