using System;
using NUnit.Framework;

namespace FluentTests.Records
{
    [TestFixture]
    public class MergeFuncTests
    {
        [Test]
        public void TestMerge()
        {
            var recordA = new SimpleType {StringField = "Hello"};

            var recordB = new SimpleType { StringField = "Bye", IntField = 10 };

            var result = recordA.Merge(recordB);

            Assert.AreEqual("Hello", result.StringField);
            Assert.AreEqual(10, result.IntField);
        }

    }
}