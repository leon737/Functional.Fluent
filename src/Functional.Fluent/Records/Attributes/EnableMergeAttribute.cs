using System;

namespace Functional.Fluent.Records.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property)]
    public class EnableMergeAttribute : EnableAttributeBase
    {
        public EnableMergeAttribute() : base(Features.Merge, true) { }
    }
}