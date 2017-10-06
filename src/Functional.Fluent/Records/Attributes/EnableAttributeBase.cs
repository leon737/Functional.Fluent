using System;

namespace Functional.Fluent.Records.Attributes
{
    public abstract class EnableAttributeBase : Attribute
    {
        internal Features Feature { get; }

        internal bool Enable { get; }

        internal EnableAttributeBase(Features feature, bool enable)
        {
            Feature = feature;
            Enable = enable;
        }
    }
}