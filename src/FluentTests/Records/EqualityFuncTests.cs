using System;
using NUnit.Framework;

namespace FluentTests.Records
{
    [TestFixture]
    public class EqualityFuncTests
    {
        [Test]
        public void TestEqual()
        {
            var recordA = new SimpleType {StringField = "Hello"};

            var recordB = new SimpleType { StringField = "Hello" };

            var result = recordA.Equals(recordB);

            Assert.True(result);
        }

        [Test]
        public void TestNotEqual()
        {
            var recordA = new SimpleType { StringField = "Hello", BoolField = true};

            var recordB = new SimpleType { StringField = "Hello" };

            var result = recordA.Equals(recordB);

            Assert.False(result);
        }

        [Test]
        public void TestEqualWithAttribute()
        {
            var recordA = new AttributedSimpleType { StringField = "Hello" };

            var recordB = new AttributedSimpleType { StringField = "Hello", BoolField = true};

            var result = recordA.Equals(recordB);

            Assert.True(result);
        }

        [Test]
        public void TestNotEqualWithAttribute()
        {
            var recordA = new AttributedSimpleType { StringField = "Hello", BoolField = true };

            var recordB = new AttributedSimpleType { StringField = "Bye" };

            var result = recordA.Equals(recordB);

            Assert.False(result);
        }
    }
}