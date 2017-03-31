using System;
using Functional.Fluent.Extensions;
using Functional.Fluent.Helpers;
using Functional.Fluent.MonadicTypes;
using NUnit.Framework;

namespace FluentTests
{
    [TestFixture]
    public class MonadicValueTests
    {
        [Test]
        public void TestMapFunction()
        {
            var m = 5.ToM();
            var n = m.Map(x => x * 2.0);
            Assert.AreEqual(10.0, n.Value);
            Assert.AreEqual(typeof(double), n.WrappedType);
        }

        [Test]
        public void TestMapFunctions()
        {
            var m = 5.ToM();
            var n = m.Map(x => x * 2, x => x + 2);
            Assert.AreEqual(12, n.Value);
            Assert.AreEqual(typeof(int), n.WrappedType);
        }

        [Test]
        public void TestUnwrapAll()
        {
            var wrappedValue = new TrackValue<int>(10).ToMaybe().ToM();
            var result = wrappedValue.UnwrapAll<int>();
            Assert.AreEqual(10, result);
        }

        [Test]
        public void TestUnwrapAllInvalidCast()
        {
            var wrappedValue = "hello";
            Assert.Throws<InvalidCastException>(() => wrappedValue.UnwrapAll<int>());
        }
    }
}
