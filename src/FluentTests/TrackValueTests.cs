using System;
using Functional.Fluent.Extensions;
using Functional.Fluent.MonadicTypes;
using NUnit.Framework;

namespace FluentTests
{
    [TestFixture]
    public class TrackValueTests
    {
        [Test]
        public void TestWithoutChanges()
        {
            var value = new TrackValue<int>(10);

            Assert.False(value.HasChanges, "value.HasChanges");
        }

        [Test]
        public void TestApplyChanges()
        {
            var value = new TrackValue<int>(10);

            value = value.With(v => v*2);

            Assert.True(value.HasChanges, "value.HasChanges");
            Assert.AreEqual(20, value.Value);
        }

        [Test]
        public void TestWithoutChanges_UseDefault()
        {
            var dt = DateTime.Now;
            var value = new TrackValue<DateTime>(dt);

            value = value.With(v => v);

            Assert.True(value.HasChanges, "value.HasChanges");
            Assert.AreEqual(dt, value.Value);
        }

        [Test]
        public void TestWithoutChanges_UseEquitable()
        {
            var dt = DateTime.Now;
            var value = new TrackValue<DateTime>(dt, ValueTrackerTypes.Equality);

            value = value.With(v => v);

            Assert.False(value.HasChanges, "value.HasChanges");
            Assert.AreEqual(dt, value.Value);
        }

        [Test]
        public void TestApplyChanges_UseEquitable()
        {
            var dt = DateTime.Now;
            var value = new TrackValue<DateTime>(dt, ValueTrackerTypes.Equality);

            value = value.With(v => v.AddDays(1));

            Assert.True(value.HasChanges, "value.HasChanges");
            Assert.AreEqual(dt.AddDays(1), value.Value);
        }

        private class SampleClass
        {
            public int IntValue { get; set; }

            public SampleClass UpdateIntValue(int i)
            {
                IntValue = i;
                return this;
            }

            public override bool Equals(object obj)
            {
                var other = obj as SampleClass;
                return IntValue == other?.IntValue;
            }

            public override int GetHashCode() => IntValue;
        }


        [Test]
        public void TestWithoutChanges_CustomRefType_UseDefault()
        {
            var customValue = new SampleClass {IntValue = 10};
            var value = new TrackValue<SampleClass>(customValue);

            value = value.With(v => v);

            Assert.True(value.HasChanges, "value.HasChanges");
            Assert.AreEqual(customValue, value.Value);
            Assert.AreEqual(customValue.IntValue, value.Value.IntValue);
        }

        [Test]
        public void TestWithoutChanges_CustomRefType_UseEquitable()
        {
            var customValue = new SampleClass { IntValue = 10 };
            var value = new TrackValue<SampleClass>(customValue, ValueTrackerTypes.Equality);

            value = value.With(v => new SampleClass { IntValue = v.IntValue});

            Assert.False(value.HasChanges, "value.HasChanges");
            Assert.AreNotSame(customValue, value.Value);
            Assert.AreEqual(customValue.IntValue, value.Value.IntValue);
        }

        [Test]
        public void TestApplyChanges_CustomRefType_UseEquitable()
        {
            var customValue = new SampleClass { IntValue = 10 };
            var value = new TrackValue<SampleClass>(customValue, ValueTrackerTypes.Equality);

            value = value.With(v => v.UpdateIntValue(v.IntValue * 2));

            Assert.True(value.HasChanges, "value.HasChanges");
            Assert.AreSame(customValue, value.Value);
            Assert.AreEqual(20, value.Value.IntValue);
        }
    }
}