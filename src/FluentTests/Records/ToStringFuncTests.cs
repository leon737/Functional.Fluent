using System;
using NUnit.Framework;

namespace FluentTests.Records
{
    [TestFixture]
    public class ToStringFuncTests
    {
        [Test]
        public void TestToString()
        {
            var record = new SimpleType {StringField = "Hello"};

            var result = record.ToString();

            Console.WriteLine(result);
        }
    }
}