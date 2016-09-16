using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Functional.Fluent;

namespace FluentTests
{
    [TestClass]
    public class ResultTests
    {
        [TestMethod]
        public void TestEvalWithNullReferenceException()
        {
            Func<string> someFunc = () => { throw new NullReferenceException(); };
            var result = Result.Eval(someFunc, typeof(NullReferenceException));
            Assert.IsTrue(result.IsFailed);
        }

        [TestMethod, ExpectedException(typeof(ApplicationException))]
        public void TestValueIsProtectedForFailedResult()
        {
            Func<Result<string>> someFunc = () => Result.Fail<string>();
            var result = someFunc();
            var value = result.Value;
        }

        [TestMethod]
        public void TestTwoResultsAreSucceeded()
        {
            var resultA = Result.Success("result A");
            var resultB = Result.Success("result B");
            var result = resultA.And(resultB).Success(v => Result.Success("ok"));
            Assert.AreEqual("ok", result.Value);
        }

        [TestMethod]
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

        [TestMethod]
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

        [TestMethod]
        public void TestCombineResults()
        {
            var intResult = Result.Success(1);
            var stringResult = Result.Success("hello");
            var datetimeResult = Result.Success(new DateTime(2010, 1, 1));

            var aggregateResult = intResult.And(stringResult).And(datetimeResult);

            // use of implicit cast from Result<T> to T
            Assert.AreEqual(1, aggregateResult.Value.Item1);
            Assert.AreEqual("hello", aggregateResult.Value.Item2);
            Assert.AreEqual(new DateTime(2010, 1, 1), aggregateResult.Value.Item3);

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

        [TestMethod]
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
    }
}
