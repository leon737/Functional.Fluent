using System;
using System.Globalization;
using Functional.Fluent.AutoValues;
using Functional.Fluent.Helpers;
using NUnit.Framework;

namespace FluentTests
{
    [TestFixture]
    public class OutParamsHelperTests
    {
        [Test]
        public void Test1InParam()
        {
            var value = AutoValue.Random<int>();
            for (int i = 0; i < 100; ++i)
            {
                int v = value;
                var validStringValue = v.ToString();
                var invalidStringValue = "//" + validStringValue;

                var func = Funcs.MakeResult<string, int>(int.TryParse);

                var success = func(validStringValue);
                var fail = func(invalidStringValue);

                Assert.IsTrue(success.IsSucceed, "success.IsSucceed");
                Assert.IsTrue(fail.IsFailed, "fail.IsFailed");

                Assert.AreEqual(v, success.Value);
            }
        }

        [Test]
        public void Test2InParams()
        {
            var value = AutoValue.Random(0, 1000);
            for (int i = 0; i < 100; ++i)
            {
                int v = value;
                var stringValue = $"({v})";

                var func = Funcs.MakeResult<string, NumberStyles, IFormatProvider, int>(int.TryParse);

                var success = func(stringValue, NumberStyles.AllowParentheses, CultureInfo.InvariantCulture);
                var fail = func(stringValue, 0, CultureInfo.InvariantCulture);

                Assert.IsTrue(success.IsSucceed, "success.IsSucceed");
                Assert.IsTrue(fail.IsFailed, "fail.IsFailed");

                Assert.AreEqual(-v, success.Value);
            }
        }
    }
}