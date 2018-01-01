using System;
using Functional.Fluent.Records;

namespace FluentTests.Records
{
    public class SimpleType : Record<SimpleType>
    {
        public int IntField;

        public string StringField;

        public bool BoolField;

        public double DoubleField;

        public TimeSpan TimeSpanField;

        public DateTime DateTimeField;

        public int? IntNullableField;

        public bool? BoolNullableField;
        
        public double? DoubleNullableField;

        public TimeSpan? TimeSpanNullableField;

        public DateTime? DateTimeNullableField;

        public int IntProperty { get; set; }

        public string StringProperty { get; set; }

        public bool BoolProperty { get; set; }

        public double DoubleProperty { get; set; }

        public TimeSpan TimeSpanProperty { get; set; }

        public DateTime DateTimeProperty { get; set; }

        public int? IntNullableProperty { get; set; }

        public bool? BoolNullableProperty { get; set; }

        public double? DoubleNullableProperty { get; set; }

        public TimeSpan? TimeSpanNullableProperty { get; set; }

        public DateTime? DateTimeNullableProperty { get; set; }
    }
}