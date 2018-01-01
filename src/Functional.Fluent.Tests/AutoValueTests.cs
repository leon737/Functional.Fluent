using Functional.Fluent.AutoValues;
using NUnit.Framework;

namespace FluentTests
{
    [TestFixture]
    public class AutoValueTests
    {

        [Test]
        public void TestGetRandomInteger()
        {
            var value = AutoValue.Random<int>();
            for (int i = 0; i < 1000; ++i)
            {
                var result = value.Value;
            }
        }

        [Test]
        public void TestGetRandomIntegerInRange([Random(0, 100, 10)]int min, [Random(101, 200, 10)]int max)
        {
            var value = AutoValue.Random<int>(min, max);
            for (int i = 0; i < 1000; ++i)
            {
                var result = value.Value;
                Assert.That(() => result >= min && result < max, $"{result} should be between {min} and {max}");
            }
        }

        [Test]
        public void TestGetRandomUInteger()
        {
            var value = AutoValue.Random<uint>();
            for (int i = 0; i < 1000; ++i)
            {
                var result = value.Value;
            }
        }

        [Test]
        public void TestGetRandomLong()
        {
            var value = AutoValue.Random<long>();
            for (int i = 0; i < 1000; ++i)
            {
                var result = value.Value;
            }
        }

        [Test]
        public void TestGetRandomULong()
        {
            var value = AutoValue.Random<ulong>();
            for (int i = 0; i < 1000; ++i)
            {
                var result = value.Value;
            }
        }

        [TestCase(0, -10, 10, 1, false, 1)]
        [TestCase(10, -10, 10, 1, true, -10)]
        [TestCase(0, -10, 10, -1, false, -1)]
        [TestCase(-10, -10, 10, -1, true, 10)]
        [TestCase(int.MaxValue, int.MinValue, int.MaxValue, 1, true, int.MinValue)]
        [TestCase(int.MinValue, int.MinValue, int.MaxValue, -1, true, int.MaxValue)]
        public void TestGetSeqInteger(int initial, int from, int to, int step, bool loop, int expected)
        {
            var value = AutoValue.Seq(initial, from, to, step, loop);
            var result1 = value.Value;
            var result2 = value.Value;
            Assert.AreEqual(initial, result1);
            Assert.AreEqual(expected, result2);
        }

    }
}
