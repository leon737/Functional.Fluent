using System;

namespace Functional.Fluent.Records.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field | AttributeTargets.Property)]
    public class DisableTostringAttribute : EnableAttributeBase
    {
        public DisableTostringAttribute() : base(Features.ToString, false) { }
    }
}