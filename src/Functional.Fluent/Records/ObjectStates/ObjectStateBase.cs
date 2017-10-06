using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Functional.Fluent.Extensions;
using Functional.Fluent.MonadicTypes;
using Functional.Fluent.Records.Attributes;
using Functional.Fluent.Records.ObjectWalkers;

namespace Functional.Fluent.Records.ObjectStates
{
    internal abstract class ObjectStateBase : IObjectState
    {
        public IObjectState Update(IObjectDataMember objectDataMember)
        {
            if (!CanUpdate(objectDataMember)) return this;
            return UpdateImpl(objectDataMember);
        }

        public abstract IObjectState UpdateImpl(IObjectDataMember objectDataMember);

        public abstract LambdaExpression Return();

        public abstract Features Feature { get; }

        private bool CanUpdate(IObjectDataMember objectDataMember)
        {
            var typeEnable = GetEnable(objectDataMember.DeclaringType);
            var memberEnable = CheckEnable(objectDataMember.GetCustomAttributes<EnableAttributeBase>());

            if (!typeEnable.HasValue && !memberEnable.HasValue) return true;

            return memberEnable.HasValue ? memberEnable : typeEnable;
        }

        private Maybe<bool> GetEnable(Type type) =>
            CheckEnable(type.GetCustomAttributes(typeof(EnableAttributeBase), true).ToMaybeNonEmpty().With(v => v.Select(x => ((EnableAttributeBase) x))));

        private Maybe<bool> CheckEnable(Maybe<IEnumerable<EnableAttributeBase>> attributes)
            => attributes.With(v => v.SingleOrDefault(x => x.Feature == Feature)).With(v => v.Enable);
    }
}