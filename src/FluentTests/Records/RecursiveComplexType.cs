using System;
using Functional.Fluent.Records;

namespace FluentTests.Records
{
    public class RecursiveComplexType : Record<RecursiveComplexType>
    {
        public RecursiveComplexType Child { get; set; }

        public ComplexType Data { get; set; }

    }
}