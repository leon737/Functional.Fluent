using System;
using Functional.Fluent.MonadicTypes;
using NUnit.Framework;

namespace FluentTests
{

    [TestFixture]
    public class BoundTests
    {

        [Test]
        public void TestBoundExactValues()
        {
            var boundType = new BoundType<int>().Add(new EqualsConstraint<int>(5)).Add(new EqualsConstraint<int>(10));

            var bound = new Bound<int>(5, boundType);

            Assert.AreEqual(5, bound.Value);

            Assert.Throws<ArgumentOutOfRangeException>(() => new Bound<int>(7, boundType));
        }

        [Test]
        public void TestBoundExactValuesAllContraints()
        {
            var boundType = new BoundType<int>(true).Add(new EqualsConstraint<int>(5)).Add(new EqualsConstraint<int>(10));

            Assert.Throws<ArgumentOutOfRangeException>(() => new Bound<int>(5, boundType));
        }

        [Test]
        public void TestBoundExactValuesAllContraints2()
        {
            var boundType = new BoundType<int>(true).Add(new NotEqualsConstraint<int>(5)).Add(new NotEqualsConstraint<int>(10));

            var bound = new Bound<int>(7, boundType);
            
            Assert.AreEqual(7, bound.Value);
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

        [Test]
        public void TestBoundExactValuesExplicitCheck()
        {
            var boundType = new BoundType<int>().Add(new EqualsConstraint<int>(5)).Add(new EqualsConstraint<int>(10)).OnExplicitCheck();

            var bound = new Bound<int>(5, boundType);

            Assert.AreEqual(5, bound.Value);
            Assert.True(bound.IsValid);

            bound = new Bound<int>(7, boundType);
            Assert.False(bound.IsValid, "bound.IsValid");
        }

        [Test]
        public void TestBoundRangeValuesExplicitCheck()
        {
            var bound = new BoundType<int>().Add(new RangeConstraint<int>(5, 10)).OnExplicitCheck().Create(5);
            Assert.AreEqual(5, bound.Value);

            for (int i = 6; i < 11; i++)
            {
                bound = bound.Set(i);
                Assert.AreEqual(i, bound.Value);
            }

            bound = bound.Set(4);
            Assert.False(bound.IsValid, "bound.IsValid");
            Assert.AreNotEqual(10, bound.Value);

            bound = bound.Set(11);
            Assert.False(bound.IsValid, "bound.IsValid");
            Assert.AreNotEqual(10, bound.Value);
        }
    }
}