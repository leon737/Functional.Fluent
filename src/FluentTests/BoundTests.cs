using System;
using Functional.Fluent.MonadicTypes;
using NUnit.Framework;

namespace FluentTests
{

    [TestFixture]
    public class BoundTests
    {
        public void TestBoundExactValues()
        {
            var boundType = new BoundType<int>().Add(new EqualsConstraint<int>(5)).Add(new EqualsConstraint<int>(10));

            var bound = new Bound<int>(5, boundType);

            Assert.AreEqual(5, bound.Value);

            Assert.Throws<ArgumentOutOfRangeException>(() => new Bound<int>(7, boundType));

        }

        [Test]
        public void TestBoundRangeValues()
        {
            var bound = new BoundType<int>().Add(new RangeConstraint<int>(5, 10)).Create(5);
            Assert.AreEqual(5, bound.Value);

            for (int i = 6; i < 11; i++)
            {
                bound = bound.Set(i);
                Assert.AreEqual(i, bound.Value);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => bound.Set(4));
            Assert.Throws<ArgumentOutOfRangeException>(() => bound.Set(11));

        }
    }
}