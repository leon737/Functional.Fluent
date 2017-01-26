using System.Linq;
using Functional.Fluent.Extensions;
using Functional.Fluent.MonadicTypes;
using NUnit.Framework;

namespace FluentTests
{
    [TestFixture]
    public class AdvancedMaybeTests
    {

        class TestFooClass
        {
            public string sValue { get; set; }
        }


        [Test]
        public void TestLifMethod()
        {
            var list = new[]
            {
                1, 2, 3, 4, 5
            };

            var maybes = list.Select(v => v.ToMaybe());
            var lifted = maybes.ToMaybe().Lift();
            Assert.IsInstanceOf<Maybe<int>>(lifted.ElementAt(0));
        }

        [Test]
        public void TestMonadMultiplication()
        {
            var o = new object();
            var m = o.ToMaybe();
            var m2 = m.ToMaybe();
            Assert.IsInstanceOf<Maybe<object>>(m2);
        }

        [Test]
        public void TestLinqSyntax()
        {
            var o = new TestFooClass() { sValue = "test"};
            var m = o.ToMaybe();
            var r = from v in m
                from x in v.sValue.ToMaybe()
                select x.Length;
            Assert.IsTrue(r.HasValue, "all objects are resolved");
            Assert.AreEqual(4, r.Value, "length is 4");

            o.sValue = null;
            m = o.ToMaybe();
            r = from v in m
                    from x in v.sValue.ToMaybe()
                    select x.Length;
            Assert.AreEqual(Maybe<int>.Nothing, r, "field is null");

            o = null;
            m = o.ToMaybe();
            r = from v in m
                from x in v.sValue.ToMaybe()
                select x.Length;
            Assert.AreEqual(Maybe<int>.Nothing, r, "root object is null");
        }

        [Test]
        public void TestLinqSyntax2()
        {
            var o = new TestFooClass() { sValue = "test" };
            var m = o.ToMaybe();
            var r = from v in m
                    from x in v.sValue
                    select x.Length;
            Assert.IsTrue(r.HasValue, "all objects are resolved");
            Assert.AreEqual(4, r.Value, "length is 4");

            o.sValue = null;
            m = o.ToMaybe();
            r = from v in m
                from x in v.sValue
                select x.Length;
            Assert.AreEqual(Maybe<int>.Nothing, r, "field is null");

            o = null;
            m = o.ToMaybe();
            r = from v in m
                from x in v.sValue
                select x.Length;
            Assert.AreEqual(Maybe<int>.Nothing, r, "root object is null");
        }

        [Test]
        public void TestIteratingOverMaybeCollection()
        {
            var i = Enumerable.Range(1, 10);
            var m = i.ToMaybe();
            foreach (var e in m)
            {
                Assert.IsTrue(e > 0);
            }
        }

        [Test]
        public void TestIteratingOverMaybeCollectionWithFilter()
        {
            var i = Enumerable.Range(1, 10);
            var m = i.ToMaybe();
            foreach (var e in m.Where(x => x % 2 == 0))
            {
                Assert.IsTrue(e % 2 == 0);
            }
        }

    }
}
