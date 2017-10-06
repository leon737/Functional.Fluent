using Functional.Fluent.Records;
using Functional.Fluent.Records.Attributes;

namespace FluentTests.Records
{
    [DisableEquality]
    public class AttributedSimpleType : Record<AttributedSimpleType>
    {
        [EnableEquality]
        public string StringField;

        public bool BoolField;
    }
}