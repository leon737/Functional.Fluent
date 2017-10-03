using System;
using Functional.Fluent.Extensions;
using NUnit.Framework;

namespace FluentTests
{

    [TestFixture]
    public class TupleExtensionsTests
    {
        [Test]
        public void DecomposeSimpleTuple()
        {
            var date = DateTime.Today;
            var tuple = Tuple.Create(10, "hello", date);

            int i;
            string s;
            DateTime d;

            var result = tuple.Tie(out i, out s, out d);

            Assert.AreSame(tuple, result);
            Assert.AreEqual(10, i);
            Assert.AreEqual("hello", s);
            Assert.AreEqual(date, d);
        }
    }
}