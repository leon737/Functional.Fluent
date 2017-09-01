using System;
using NUnit.Framework;

namespace FluentTests.Records
{
    [TestFixture]
    public class GetHashCodeFuncTests
    {
        [Test]
        public void Test_GetHashCode()
        {
            var record = new SimpleType {StringField = "Hello"};

            var result = record.GetHashCode();

            Console.WriteLine(result);
        }
    }
}