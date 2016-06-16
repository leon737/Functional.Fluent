using System;
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
            var resultFailure = resultA.And(resultB).Fail(() => flag = true);
            Assert.IsTrue(flag);
        }
    }
}
