using System;
using System.Linq;
using Functional.Fluent.Extensions;
using Functional.Fluent.Helpers;
using Functional.Fluent.MonadicTypes;
using NUnit.Framework;

namespace FluentTests
{
    [TestFixture]
    public class ResultTests
    {
        [Test]
        public void TestEvalWithNullReferenceException()
        {
            Func<string> someFunc = () => { throw new NullReferenceException(); };
            var result = Result.Eval(someFunc, typeof(NullReferenceException));
            Assert.IsTrue(result.IsFailed);
        }

        [Test]
        public void TestValueIsProtectedForFailedResult()
        {
            Func<Result<string>> someFunc = () => Result.Fail<string>();
            var result = someFunc();
            Assert.Throws<ApplicationException>(() =>
            {
                var resultValue = result.Value; 
            });
        }

        [Test]
        public void TestTwoResultsAreSucceeded()
        {
            var resultA = Result.Success("result A");
            var resultB = Result.Success("result B");
            var result = resultA.And(resultB).Success(v => Result.Success("ok"));
            Assert.AreEqual("ok", result.Value);
        }

        [Test]
        public void TestTwoResultsOneSucceededOneFailed()
        {
            bool flag = false;
            var resultA = Result.Success("result A");
            var resultB = Result.Fail<string>();
            var result = resultA.And(resultB).Success(v => Result.Success("ok"));
            Assert.IsTrue(result.IsFailed);
            var resultFailure = resultA.And(resultB).Fail(() =>
            {
                flag = true;
                return Result.Success();
            });
            Assert.IsTrue(flag);
        }

        [Test]
        public void TestTwoResultsOneSucceededOneFailedByOr()
        {
            bool flag = false;
            var resultA = Result.Success("result A");
            var resultB = Result.Fail<string>();
            var result = resultA.Or(resultB).Success(v => Result.Success("ok"));
            Assert.IsTrue(result.IsSucceed);
            var resultFailure = resultA.Or(resultB).Success(v =>
            {
                flag = true;
                return Result.Success();
            });
            Assert.IsTrue(flag);
        }

        [Test]
        public void TestCombineResults()
        {
            var intResult = Result.Success(1);
            var stringResult = Result.Success("hello");
            var datetimeResult = Result.Success(new DateTime(2010, 1, 1));

            var aggregateResult = intResult.And(stringResult).And(datetimeResult);

            // use of implicit cast from Result<T> to T
            Assert.AreEqual(1, (int)aggregateResult.Value.Item1);
            Assert.AreEqual("hello", (string)aggregateResult.Value.Item2);
            Assert.AreEqual(new DateTime(2010, 1, 1), (DateTime)aggregateResult.Value.Item3);

            // use of distinct AgregateValue property 
            Assert.AreEqual(1, aggregateResult.AggregateValue.Item1);
            Assert.AreEqual("hello", aggregateResult.AggregateValue.Item2);
            Assert.AreEqual(new DateTime(2010, 1, 1), aggregateResult.AggregateValue.Item3);

            var result1 = aggregateResult.ElementAt(0) as Result<int>;
            var result2 = aggregateResult.ElementAt(1) as Result<string>;
            var result3 = aggregateResult.ElementAt(2) as Result<DateTime>;

            Assert.AreEqual(1, result1.Value);
            Assert.AreEqual("hello", result2.Value);
            Assert.AreEqual(new DateTime(2010, 1, 1), result3.Value);
        }

        [Test]
        public void TestCombineResultsToCollectionAggregateResult()
        {
            var intResult = Result.Success(1);
            var stringResult = Result.Success("hello");
            var datetimeResult = Result.Success(new DateTime(2010, 1, 1));
            var intResult2 = Result.Success(1);
            var stringResult2 = Result.Success("hello");
            var datetimeResult2 = Result.Success(new DateTime(2010, 1, 1));
            var intResult3 = Result.Success(1);
            var stringResult3 = Result.Success("hello");
            var datetimeResult3 = Result.Success(new DateTime(2010, 1, 1));

            var aggregateResult = intResult.And(stringResult).And(datetimeResult)
                .And(intResult2).And(stringResult2).And(datetimeResult2)
                .And(intResult3).And(stringResult3).And(datetimeResult3);

            Assert.AreEqual(9, aggregateResult.Count());

            var result1 = aggregateResult.ElementAt(0) as Result<int>;
            var result2 = aggregateResult.ElementAt(1) as Result<string>;
            var result3 = aggregateResult.ElementAt(2) as Result<DateTime>;
            var result4 = aggregateResult.ElementAt(0) as Result<int>;
            var result5 = aggregateResult.ElementAt(1) as Result<string>;
            var result6 = aggregateResult.ElementAt(2) as Result<DateTime>;
            var result7 = aggregateResult.ElementAt(0) as Result<int>;
            var result8 = aggregateResult.ElementAt(1) as Result<string>;
            var result9 = aggregateResult.ElementAt(2) as Result<DateTime>;

            Assert.AreEqual(1, result1.Value);
            Assert.AreEqual("hello", result2.Value);
            Assert.AreEqual(new DateTime(2010, 1, 1), result3.Value);

            Assert.AreEqual(1, result4.Value);
            Assert.AreEqual("hello", result5.Value);
            Assert.AreEqual(new DateTime(2010, 1, 1), result6.Value);

            Assert.AreEqual(1, result7.Value);
            Assert.AreEqual("hello", result8.Value);
            Assert.AreEqual(new DateTime(2010, 1, 1), result9.Value);

        }

        [Test]
        public void TestResultBuilder()
        {
            var result = Result.For(5).And<string>();
            Assert.IsTrue(result.IsSucceed);
            Assert.IsFalse(result.IsFailed);
            Assert.AreEqual(5, result.SuccessValue);

            result = Result.For<int>().And("error");
            Assert.IsTrue(result.IsFailed);
            Assert.IsFalse(result.IsSucceed);
            Assert.AreEqual("error", result.ErrorValue);
        }

        [Test]
        public void TestTwist_PositivePositive()
        {
            var source = Result.Success(5.ToMaybe());
            var result = source.Twist().Twist();
            Assert.True(result.IsSucceed, "source.IsSucceed");
            Assert.True(result.Value.HasValue, "source.Value.HasValue");
            Assert.AreEqual(source.Value.Value, result.Value.Value);
        }

        [Test]
        public void TestTwist_PositiveNegative()
        {
            var source = Result.Success(Maybe<int>.Nothing);
            var result = source.Twist().Twist();
            Assert.True(result.IsSucceed, "source.IsSucceed");
            Assert.False(result.Value.HasValue, "source.Value.HasValue");
        }

        [Test]
        public void TestTwist_Negative()
        {
            var source = Result.Fail<Maybe<int>>();
            var result = source.Twist().Twist();
            Assert.True(result.IsFailed, "source.IsFailed");
        }
    }
}
