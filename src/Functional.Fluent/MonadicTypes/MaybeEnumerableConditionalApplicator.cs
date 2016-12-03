using System;
using System.Collections.Generic;

namespace Functional.Fluent.MonadicTypes
{
    public class MaybeEnumerableConditionalApplicator<T> : MaybeEnumerableApplicator<T, T>
    {
        private readonly Func<T, bool> evaluator;
        private readonly bool inverseCondition;


        internal MaybeEnumerableConditionalApplicator(MaybeEnumerable<T> list, Func<T, bool> evaluator, Func<T, T> applicator, bool inverseCondition = false)
            : base(list, applicator)
        {
            this.evaluator = evaluator;
            this.inverseCondition = inverseCondition;
        }

        public override IEnumerable<Maybe<T>> Value
        {
            get
            {
                if (HasValue)
                    foreach (var e in list)
                        if (e.HasValue)
                            yield return evaluator(e.Value) ^ inverseCondition ? new Maybe<T>(applicator(e.Value)) : e;
            }
        }

        public override IEnumerator<Maybe<T>> GetEnumerator()
        {
            return Value.GetEnumerator();
        }
    }
}