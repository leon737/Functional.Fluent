using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Functional.Fluent.Helpers;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Pattern
{
    public partial class MatcherMemberAccessor<TV, TC, TM> : Matcher<TV, MemberAccessor<TC, TM>>
    {
        public MatcherMemberAccessor()
        {
        }

        public MatcherMemberAccessor(MonadicValue<TV> contextValue) : base(contextValue)
        {
        }

        public MatcherMemberAccessor<TV, TC, TM> Member(Predicate<TV> predicate, Expression<Func<TC, TM>> expression)
        {
            Add(predicate, _ => new MemberAccessor<TC, TM>(expression));
            return this;
        }

        public MatcherMemberAccessor<TV, TC, TM> Member(TV value, Expression<Func<TC, TM>> expression)
        {
            Add(value, _ => new MemberAccessor<TC, TM>(expression));
            return this;
        }

        public MatcherMemberAccessor<TV, TC, TM> Member(IEnumerable<TV> values, Expression<Func<TC, TM>> expression)
        {
            Add(values, _ => new MemberAccessor<TC, TM>(expression));
            return this;
        }

        public ObjectMemberAccessor<TC, TM> Do(TC obj) => ObjectMemberAccessor.Create(obj, Do());
    }
}