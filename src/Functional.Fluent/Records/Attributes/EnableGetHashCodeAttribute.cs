using System;

namespace Functional.Fluent.Records.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property)]
    public class EnableGetHashCodeAttribute : EnableAttributeBase
    {
        public EnableGetHashCodeAttribute() : base(Features.GetHashCode, true) { }
    }
}