using Functional.Fluent.Extensions;
using Functional.Fluent.MonadicTypes;
using NUnit.Framework;

namespace FluentTests
{

    [TestFixture]
    public class MaybeValueTests
    {

        struct TestStruct
        {
            public MaybeValue<int> IntValue { get; set; }

            public MaybeValue<string> StringValue { get; set; }
        }

        [Test]
        public void TestInitStruct()
        {
            var data = new TestStruct();

            Assert.NotNull(data.IntValue);
            Assert.False(data.IntValue.HasValue);

            Assert.NotNull(data.StringValue);
            Assert.False(data.StringValue.HasValue);
        }

        [Test]
        public void TestAssign()
        {
            var data = new TestStruct {IntValue = new MaybeValue<int>(5)};
            
            Assert.NotNull(data.IntValue);
            Assert.True(data.IntValue.HasValue);
            Assert.AreEqual(5, data.IntValue.Value);

            data.IntValue = new MaybeValue<int>(15);
            Assert.AreEqual(15, data.IntValue.Value);
        }

        [Test]
        public void TestMaybe()
        {
            var data = new TestStruct { IntValue = new MaybeValue<int>(5) };

            data.IntValue = data.IntValue.As().With(x => x*2);
            data.StringValue = data.StringValue.As().With(x => x.ToUpper());

            Assert.True(data.IntValue.HasValue);
            Assert.AreEqual(10, data.IntValue.Value);

            Assert.False(data.StringValue.HasValue);

        }

    }
}