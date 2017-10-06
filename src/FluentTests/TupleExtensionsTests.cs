using System;
using Functional.Fluent.Extensions;
using NUnit.Framework;

namespace FluentTests
{

    [TestFixture]
    public class TupleExtensionsTests
    {

        private class SampleClass
        {
            public string StringProperty { get; set; }

            public int IntProperty { get; set; }

            public DateTime? DateTimeNullableProperty { get; set; }
        }

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

        [Test]
        public void DecomposeTupleIntoProperties()
        {
            DateTime? date = DateTime.Today;
            var tuple = Tuple.Create(10, "hello", date);

            var result = new SampleClass();
            tuple.Tie(result, v => v.IntProperty, v => v.StringProperty, v=>v.DateTimeNullableProperty);

            Assert.AreEqual(10, result.IntProperty);
            Assert.AreEqual("hello", result.StringProperty);
            Assert.AreEqual(date, result.DateTimeNullableProperty);
        }

        [Test]
        public void DecomposeTupleIntoPropertiesOfDifferentObjects()
        {
            DateTime? date = DateTime.Today;
            var tuple = Tuple.Create(10, "hello", date);

            var result1 = new SampleClass();
            var result2 = new SampleClass();
            tuple.Tie(result1, v => v.IntProperty, result2, v => v.StringProperty, result2, v => v.DateTimeNullableProperty);

            Assert.AreEqual(10, result1.IntProperty);
            Assert.AreEqual("hello", result2.StringProperty);
            Assert.AreEqual(date, result2.DateTimeNullableProperty);
        }
    }
}