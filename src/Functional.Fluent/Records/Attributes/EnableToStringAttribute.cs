using System;

namespace Functional.Fluent.Records.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property)]
    public class EnableToStringAttribute : EnableAttributeBase
    {
        public EnableToStringAttribute() : base(Features.ToString, true) { }
    }
}