using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace FluentTests.Records
{
    [TestFixture]
    public class ToStringFuncTests
    {
        [Test]
        public void Test_SimpleType_ToString()
        {
            var record = new SimpleType {StringField = "Hello"};

            var result = record.ToString();

            Console.WriteLine(result);
        }

        [Test]
        public void Test_ComplexType_ToString()
        {
            var record = new ComplexType
            {
                SubField = new SimpleType {StringField = "Hello"},
                SubProperty = new SimpleType {StringField = "Bye"}
            };

            var result = record.ToString();

            Console.WriteLine(result);
        }

        [Test]
        public void Test_RecursiveComplexType_ToString()
        {
            var record = new RecursiveComplexType
            {
                Child = new RecursiveComplexType
                {
                    Data = new ComplexType
                    {
                        SubProperty = new SimpleType { StringProperty = "Hello"}
                    }
                }
            };

            var result = record.ToString();

            Console.WriteLine(result);
        }

        [Test]
        public void Test_SimpleTypeWithCollection_ToString()
        {
            var record = new SimpleTypeWithCollection()
            {
               IntCollection = Enumerable.Range(1, 10).ToList()
            };

            //typeof(ICollection<int>).GetMethod("GetHashCode", System.Reflection.BindingFlags.FlattenHierarchy);

            var result = record.ToString();

            Console.WriteLine(result);
        }
    }
}