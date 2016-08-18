using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Functional.Fluent;

namespace FluentTests
{
    [TestClass]
    public class MonadicValueTests
    {
        [TestMethod]
        public void TestMapFunction()
        {
            var m = 5.ToM();
            var n = m.Map(x => x * 2.0);
            Assert.AreEqual(10.0, n.Value);
            Assert.AreEqual(typeof(double), n.WrappedType);
        }

        [TestMethod]
        public void TestMapFunctions()
        {
            var m = 5.ToM();
            var n = m.Map(x => x * 2, x => x + 2);
            Assert.AreEqual(12, n.Value);
            Assert.AreEqual(typeof(int), n.WrappedType);
        }
    }
}
