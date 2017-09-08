using System.Text;
using System;
using System.Linq;
using System.Collections.Generic;
using Functional.Fluent.Extensions;
using Functional.Fluent.Pattern;
using NUnit.Framework;

namespace FluentTests
{
    [TestFixture]
    public class PatternMatchingTests
    {
        [Test]
        public void TestApplyIf()
        {
            var s = "fox";
            var r = s.ToM()
                .ApplyIf(x => x == "bird", x => x + " can fly")
                .ApplyIf(x => x == "fox", x => x + " can run");
            Assert.AreEqual("fox can run", r.Value);
        }

        [Test]
        public void TestApplyIfForValueTypes()
        {
            var i = 4;
            var r = i.ToM()
                .ApplyIf(x => x < 10, x => x * 2)
                .ApplyIf(x => x >= 10, x => x / 5);
            Assert.AreEqual(8, r.Value);
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public void TestNullMaybe()
        {
            string s = null;
            var r = s.ToMaybe();
            Assert.IsFalse(r.HasValue);
        }

        [Test]
        public void TestFluentSyntax()
        {
            var s = "fox".ToM();
            var r = new Matcher<string, string>
            {
                {x => x == "bird", x => x + " can fly"},
                {x => x == "fox", x => x + " can run"},
                {x => true, x => x + " can do something else"},
            }.ToFunc()(s);
            Assert.AreEqual("fox can run", r);
        }

        [Test]
        public void TestFluentSyntax2()
        {
            var s = "fox".ToM().Match(new Matcher<string, string>
            {
                {x => x == "bird", x => x + " can fly"},
                {x => x == "fox", x => x + " can run"},
                {x => true, x => x + " can do something else"},
            });
            Assert.AreEqual("fox can run", s.Value);
        }

        [Test]
        public void TestFluentSyntax3()
        {
            var s = "fox".ToM().Match()
                .With(x => x == "bird", x => x + " can fly")
                .With(x => x == "fox", x => x + " can run")
                .Else(x => x + " can do something else").Do();

            Assert.AreEqual("fox can run", s);
        }

        [Test]
        public void TestFluentSyntaxSimpleValues()
        {
            var s = "fox".Match()
                .With(x => x == "bird", x => x + " can fly")
                .With(x => x == "fox", x => x + " can run")
                .Else(x => x + " can do something else").Do();

            Assert.AreEqual("fox can run", s);
        }

        [Test]
        public void TestFluentSyntaxSimpleValues2()
        {
            var s = "fox".Match()
                .With("bird", x => x + " can fly")
                .With("fox", x => x + " can run")
                .Else(x => x + " can do something else").Do();

            Assert.AreEqual("fox can run", s);
        }

        [Test]
        public void TestFluentSyntaxMaybeValues()
        {
            var s = "fox".ToMaybe().Match()
                .With("bird", x => x + " can fly")
                .With("fox", x => x + " can run")
                .Else(x => x + " can do something else").Do();

            Assert.AreEqual("fox can run", s);
        }

        [Test]
        public void TestFluentSyntaxMValues()
        {
            var s = "fox".ToM().Match()
                .With("bird", x => x + " can fly")
                .With("fox", x => x + " can run")
                .Else(x => x + " can do something else").Do();

            Assert.AreEqual("fox can run", s);
        }


        [Test]
        public void TestWithThrowExceptionByParam()
        {
            var m = "fox".Match()
                .With(x => x == "bird", x => x + " can fly")
                .WithThrow(x => x == "fox", new ApplicationException("it's a fox"))
                .Else(x => x + " can do something else");

            Assert.Throws<ApplicationException>(() => m.Do());
        }

        [Test]
        public void TestElseThrowExceptionByCtor()
        {
            var m = "dog".Match()
                .With(x => x == "bird", x => x + " can fly")
                 .With(x => x == "fox", x => x + " can run")
                .ElseThrow(new ApplicationException("not a bird nor a fox"));

            Assert.Throws<ApplicationException>(() => m.Do());
        }

        [Test]
        public void TestElseThrowExceptionByParam()
        {
            var m = "dog".Match()
                .With(x => x == "bird", x => x + " can fly")
                 .With(x => x == "fox", x => x + " can run")
                .ElseThrow<ApplicationException>();

            Assert.Throws<ApplicationException>(() => m.Do());
        }

        [Test]
        public void TestWithThrowExceptionByCtor()
        {
            var m = "fox".Match()
                .With(x => x == "bird", x => x + " can fly")
                .WithThrow<ApplicationException>(x => x == "fox")
                .Else(x => x + " can do something else");

            Assert.Throws<ApplicationException>(() => m.Do());
        }


        [Test]
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

        [Test]
        public void TestTypeMatchingFluentSyntax()
        {
            var m = new TypeMatcher<string>
            {
                { Case.Is<string>(), s => s},
                { Case.Is<StringBuilder>(), s => s.ToString()}
            };

            var test1 = ((object)"string").ToM().Match(m);
            Assert.AreEqual("string", test1.Value);

            var test2 = ((object)new StringBuilder("StringBuilder")).ToM().Match(m);
            Assert.AreEqual("StringBuilder", test2.Value);
        }

        [Test]
        public void TestMaybeFluentSyntax()
        {
            var s = "fox".ToM().Match()
                .With(x => x == "bird", x => x + " can fly")
                .With(x => x == "fox", x => x + " can run")
                .Else(x => x + " can do something else")
                .Do();

            Assert.AreEqual("fox can run", s);
        }

        [Test]
        public void TestMaybeFluentSyntaxWithExact()
        {
            var s = "fox".ToM().Match()
                .With("bird", x => x + " can fly")
                .With("fox", x => x + " can run")
                .Else(x => x + " can do something else")
                .Do();

            Assert.AreEqual("fox can run", s);
        }

        [Test]
        public void TestTypeMatchingMaybeFluentSyntax()
        {
            var test1 = ((object)"string").TypeMatch()
                .With(Case.Is<string>(), s => s)
                .With(Case.Is<StringBuilder>(), s => s.ToString())
                .Else(_ => "that's an object").Do();

            Assert.AreEqual("string", test1);
        }

        [Test]
        public void TestTypeMatchingMaybeFluentSyntaxSimpleValues()
        {
            var test1 = ((object)"string").TypeMatch()
                .With(Case.Is<string>(), s => s)
                .With(Case.Is<StringBuilder>(), s => s.ToString())
                .Else(_ => "that's an object").Do();

            Assert.AreEqual("string", test1);
        }

        [Test]
        public void TestTypeMatchingWithThrowExceptions()
        {
            var matcher = ((object)"string").TypeMatch()
                .With(Case.Is<StringBuilder>(), s => s.ToString())
                .WithThrow(Case.Is<string>(), new ArgumentException())
                .Else(_ => "that's an object");

            Assert.Throws<ArgumentException>(() => matcher.Do());
        }

        [Test]
        public void TestTypeMatchingElseThrowExceptions()
        {
            var matcher = ((object)"string").TypeMatch()
                .With(Case.Is<StringBuilder>(), s => s.ToString())
                .With(Case.Is<int>(), s => s.ToString())
                .ElseThrow<ArgumentException>();

            Assert.Throws<ArgumentException>(() => matcher.Do());
        }

        [Test]
        public void TestTypeMatchingMaybeFluentSyntaxWithAdditionalPredicate()
        {
            var test1 = ((object)"the long string").TypeMatch()
                .With(Case.Is<string>(), s => s.Length > 10, s => s + "!")
                .With(Case.Is<string>(), s => s)
                .With(Case.Is<StringBuilder>(), s => s.ToString())
                .Else(_ => "that's an object").Do();

            Assert.AreEqual("the long string!", test1);
        }

        [Test]
        public void TestMatchList()
        {
            var list = new[] { "good morning", "good afternoon", "good evening" };
            var result = list.ToM().Match()
                .With((h, t) => Tuple.Create(h.ToUpper(), t))
                .Do();
            Assert.AreEqual("GOOD MORNING", result.Item1);
            Assert.AreEqual(2, result.Item2.Count());
        }

        [Test]
        public void TestMatchListSimpleValues()
        {
            IEnumerable<string> list = new[] { "good morning", "good afternoon", "good evening" };
            var result = list.Match()
                .With((h, t) => Tuple.Create(h.ToUpper(), t))
                .Do();
            Assert.AreEqual("GOOD MORNING", result.Item1);
            Assert.AreEqual(2, result.Item2.Count());
        }

        [Test]
        public void TestMatchEmptyList()
        {
            var list = new List<string>();
            var result = list.ToM().Match()
                .With((h, t) => h.ToUpper())
                .Empty(() => "List is empty")
                .Do();
            Assert.AreEqual("List is empty", result);
        }

        private int factorial(int n) => n.ToM().Match()
            .With(0, 1, _ => 1)
            .Else(v => v * factorial(v - 1))
            .Do();

        [Test]
        public void TestCalculateFactorial()
        {
            int result = 0.Match()
                .With(0, 1, _ => 1)
                .Else(v => v*factorial(v - 1))
                .ToFunc()(5);
            Assert.AreEqual(120, result);
        }

        [Test]
        public void TestCalculateFactorialSelfFunc()
        {
            int result = factorial(5);
            Assert.AreEqual(120, result);
        }

        private int sum(IEnumerable<int> value) => value.ToM().Match()
            .With((head, tail) => head + sum(tail))
            .Empty(() => 0)
            .Do();

        [Test]
        public void TestCalculateSumInList()
        {
            var list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result = sum(list);
            Assert.AreEqual(list.Sum(), result);
        }

        private int sum_even(IEnumerable<int> value) => value.ToM().Match()
           .With(v => v % 2 == 0, (head, tail) => head + sum_even(tail))
           .With((_, tail) => sum_even(tail))
           .Empty(() => 0)
           .Do();

        [Test]
        public void TestCalculateSumEvensInList()
        {
            var list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result = sum_even(list);
            Assert.AreEqual(list.Where(x => x % 2 == 0).Sum(), result);
        }

        [Test]
        public void TestCalculateSumEvensInListSelfFunc()
        {
            var list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result = ((IEnumerable<int>) list).Match()
                .With(v => v%2 == 0, (head, tail) => head + sum_even(tail))
                .With((_, tail) => sum_even(tail))
                .Empty(() => 0).ToFunc()(list);
            Assert.AreEqual(list.Where(x => x % 2 == 0).Sum(), result);
        }

        [Test]
        public void TestNullReferencePassedToMatcher()
        {
            string value = null;
            var result = value.ToM().Match()
                .With("one", 1)
                .With("two", 2)
                .Else(-1)
                .Do();
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void TestNullReferencePassedToMatcher2()
        {
            string value = null;
            var result = value.ToM().Match()
                .With("one", 1)
                .With("two", 2)
                .With(x => x == null, 3)
                .Else(-1)
                .Do();
            Assert.AreEqual(3, result);
        }

        [Test]
        public void TestNullReferencePassedToMatcher3()
        {
            string value = null;
            var result = value.ToM().Match()
                .With("one", 1)
                .With("two", 2)
                .Null(3)
                .Else(-1)
                .Do();
            Assert.AreEqual(3, result);
        }

        [Test]
        public void TestNullReferencePassedToTypeMatcher()
        {
            string value = null;
            var result = value.TypeMatch()
                .With(Case.Is<string>(), "string")
                .With(Case.Is<int>(), "integer")
                .Else("something else")
                .Do();
            Assert.AreEqual("something else", result);
        }

        [Test]
        public void TestNullReferencePassedToListMatcher()
        {
            int[] list = null;
            var result = list.ToM().Match()
                .With((h, t) => h * 2)
                .Empty(-1)
                .Do();
            Assert.AreEqual(-1, result);
        }

        private Tuple<int, int> sum_both(IEnumerable<int> list) => list.ToM().Match()
             .With((a, b, tail) => sum_both(tail).ToM().With(v => Tuple.Create(a + v.Item1, b + v.Item2)).Value)
             .Empty(Tuple.Create(0, 0))
             .Do();

        [Test]
        public void TestSumOddAndEven()
        {
            var list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result = sum_both(list);
            Assert.AreEqual(25, result.Item1);
            Assert.AreEqual(30, result.Item2);
        }

        [Test]
        public void TestSumOddAndEvenSelfFunv()
        {
            var list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var result = list.ToM().Match()
                .With((a, b, tail) => sum_both(tail).ToM().With(v => Tuple.Create(a + v.Item1, b + v.Item2)).Value)
                .Empty(Tuple.Create(0, 0)).ToFunc()(list);
            Assert.AreEqual(25, result.Item1);
            Assert.AreEqual(30, result.Item2);
        }

        [Test]
        public void TestPartials()
        {
            var value = "test";

            var result = value.ToM().Match()
                .Partial<string, int>((a, b) => b.Length == a)
                .With(4, "four")
                .With(5, "five")
                .Do();
            Assert.AreEqual("four", result);

            value.ToM().Match()
                .Partial((a, b) => b.Length == a, 4, "four")
                .With(5, "five")
                .Do();
            Assert.AreEqual("four", result);

            var result2 = value.ToM().Match()
                .Partial<int, string>((a, b) => b.StartsWith(a))
                .With("he", 1)
                .With("te", 2)
                .Do();
            Assert.AreEqual(2, result2);

            result2 = value.ToM().Match()
                .Partial((a, b) => b.StartsWith(a), "he", 1)
                .With("te", 2)
                .Do();
            Assert.AreEqual(2, result2);

            result2 = value.ToM().Match()
                 .Partial((a, b, c) => c.StartsWith(a) && c.Length == b, "he", 5, 1)
                 .With("te", 4, 2)
                 .Do();

            Assert.AreEqual(2, result2);
        }

        [Test]
        public void TestNullReferencePassedToMatcherWithLambda()
        {
            string value = null;
            var result = value.ToMaybe().Match()
                .With(v => v.Equals("one"), 1)
                .With(v => v.Equals("two"), 2)
                .Else(-1)
                .Do();
            Assert.AreEqual(-1, result);
        }


        [Test]
        public void TestPartialNullRef()
        {
            string value = null;

            var result = value.ToMaybe().Match()
                .Partial<string, int>((a, b) => b.Length == a)
                .With(4, "four")
                .With(5, "five")
                .Do();

            Assert.IsNull( result);
        }

        [Test]
        public void TestMatch_When_ExceptionThrownInAction_Then_ShouldThrowSameException()
        {
            var m = "bird".Match()
               .With(x => x == "fox", x => x + " can run")
               .With(x => x == "bird", x =>
               {
                   throw new ApplicationException("My customized exception");
               });

            Assert.That(() => m.Do(), Throws.TypeOf<ApplicationException>().With.Message.EqualTo("My customized exception"));
        }

        [Test]
        public void Test_TypeMatch_When_ExceptionThrownInAction_Then_ShouldThrowSameException()
        {
            var f = new Func<string, string>(_ =>
            {
                throw new ApplicationException("My customized exception");
            });

            var matcher = ((object) "string").TypeMatch()
                .With(Case.Is<StringBuilder>(), s => s.ToString())
                .With(Case.Is<string>(), s => f(s));

            Assert.That(() => matcher.Do(), Throws.TypeOf<ApplicationException>().With.Message.EqualTo("My customized exception"));
        }

    }
}
