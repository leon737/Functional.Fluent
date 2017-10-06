using System;

namespace Functional.Fluent.Records.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property)]
    public class EnableEqualityAttribute : EnableAttributeBase
    {
        public EnableEqualityAttribute() : base(Features.Equality, true) { }
    }
}