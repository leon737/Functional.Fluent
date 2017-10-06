using System;

namespace Functional.Fluent.Records.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property)]
    public class DisableGetHashCodeAttribute : EnableAttributeBase
    {
        public DisableGetHashCodeAttribute() : base(Features.GetHashCode, false) { }
    }
}