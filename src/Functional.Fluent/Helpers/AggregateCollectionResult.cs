using System.Collections;
using System.Collections.Generic;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Helpers
{
    public class AggregateCollectionResult : Result<IEnumerable<IResult>>, IEnumerable<IResult>
    {
        internal AggregateCollectionResult(bool isSucceed) : base(isSucceed)
        {
        }

        internal AggregateCollectionResult(bool isSucceed, IEnumerable<IResult> value) : base(isSucceed, value)
        {
        }

        public IEnumerator<IResult> GetEnumerator()
        {
            return Value.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}