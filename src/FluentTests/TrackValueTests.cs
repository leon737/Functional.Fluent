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
    }
}