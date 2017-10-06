using System;

namespace Functional.Fluent.Records.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property)]
    public class DisableMergeAttribute : EnableAttributeBase
    {
        public DisableMergeAttribute() : base(Features.Merge, false) { }
    }
}