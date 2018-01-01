using System;
using Functional.Fluent.Records;

namespace FluentTests.Records
{
    public class ComplexType : Record<ComplexType>
    {
        public int ComplexTypeIntField;

        public SimpleType SubField;

        public int ComplexTypeIntProperty { get; set; }

        public SimpleType SubProperty { get; set; }
    }
}