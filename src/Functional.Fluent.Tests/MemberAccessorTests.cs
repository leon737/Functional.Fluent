using Functional.Fluent;
using Functional.Fluent.Extensions;
using NUnit.Framework;

namespace FluentTests
{
    [TestFixture]
    public class MemberAccessorTests
    {
        public class TestClass
        {
            public int IntValue1 { get; set; }

            public int IntValue2;

            public string StrValue { get; set; }
        }

        [Test]
        public void TestGetAccess()
        {
            var test = new TestClass
            {
                IntValue1 = 10,
                IntValue2 = 20
            };

            var accessor = new MemberAccessor<TestClass, int>(v => v.IntValue1);
            Assert.AreEqual(10, accessor.GetValue(test));

            accessor = new MemberAccessor<TestClass, int>(v => v.IntValue2);
            Assert.AreEqual(20, accessor.GetValue(test));
        }

        [Test]
        public void TestSetAccess()
        {
            var test = new TestClass();

            var accessor = new MemberAccessor<TestClass, int>(v => v.IntValue1);
            accessor.SetValue(test, 10);
            Assert.AreEqual(10, test.IntValue1);

            accessor = new MemberAccessor<TestClass, int>(v => v.IntValue2);
            accessor.SetValue(test, 20);
            Assert.AreEqual(20, test.IntValue2);
        }

        [TestCase(1, 10)]
        [TestCase(2, 20)]
        public void TestGetMatching(int key, int expected)
        {
            var test = new TestClass
            {
                IntValue1 = 10,
                IntValue2 = 20
            };
            var result = key.Match()
                .Member<TestClass, int>(1, v => v.IntValue1)
                .Member(2, v => v.IntValue2)
                .Do(test);
            Assert.AreEqual(expected, result.Value);
        }

        [TestCase(1, 10, 0)]
        [TestCase(2, 0, 20)]
        public void TestSetMatching(int key, int expected1, int expected2)
        {
            var test = new TestClass();
            key.Match()
                .Member<TestClass, int>(1, v => v.IntValue1)
                .Member(2, v => v.IntValue2)
                .Do(test).Apply(key * 10);
            Assert.AreEqual(expected1, test.IntValue1);
            Assert.AreEqual(expected2, test.IntValue2);
        }
    }
}