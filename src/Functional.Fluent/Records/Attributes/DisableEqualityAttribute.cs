using System;

namespace Functional.Fluent.Records.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property)]
    public class DisableEqualityAttribute : EnableAttributeBase
    {
        public DisableEqualityAttribute() : base(Features.Equality, false) { }
    }
}