using System.Linq;
using Functional.Fluent.Extensions;
using Functional.Fluent.Helpers;
using Functional.Fluent.MonadicTypes;
using NUnit.Framework;

namespace FluentTests
{
    [TestFixture]
    public class BasicMaybeTests
    {

        class MyClass
        {
            public string StringField;
            public string StringField2;
            public int IntField;
        }


        [Test]
        public void TestWith()
        {
            var result = new MyClass {StringField = "hello"}.ToMaybe().With(x => x.StringField).With(x => x.Length).Value;
            Assert.AreEqual(5, result);
            result = new MyClass().ToMaybe().With(x => x.StringField).With(x => x.Length).Value;
            Assert.AreEqual(0, result);
        }

        [Test]
        public void TestReturn()
        {
            var result = new MyClass { StringField = "hello" }.ToMaybe().With(x => x.StringField).Return(x => x.Length, -1).Value;
            Assert.AreEqual(5, result);
            result = new MyClass().ToMaybe().With(x => x.StringField).Return(x => x.Length, -1).Value;
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void TestReturnWithLambda()
        {
            var result = new MyClass { StringField = "hello" }.ToMaybe().With(x => x.StringField).Return(x => x.Length, () => -1).Value;
            Assert.AreEqual(5, result);
            result = new MyClass().ToMaybe().With(x => x.StringField).Return(x => x.Length, -1).Value;
            Assert.AreEqual(-1, result);
        }

        [Test]
        public void TestIf()
        {
            var result = new MyClass {StringField = "hello", IntField = 10}.ToMaybe().
                If(x => x.IntField > 5).Return(x => x.StringField, "").Value;
            Assert.AreEqual("hello", result);
            result = new MyClass { StringField = "hello", IntField = 5 }.ToMaybe().
                If(x => x.IntField > 5).Return(x => x.StringField, "").Value;
            Assert.AreEqual("", result);
        }

        [Test]
        public void TestUnless()
        {
            var result = new MyClass { StringField = "hello", IntField = 10 }.ToMaybe().
                Unless(x => x.IntField <= 5).Return(x => x.StringField, "").Value;
            Assert.AreEqual("hello", result);
            result = new MyClass { StringField = "hello", IntField = 5 }.ToMaybe().
                If(x => x.IntField > 5).Return(x => x.StringField, "").Value;
            Assert.AreEqual("", result);
        }

        [Test]
        public void TestDo()
        {
            int result = 0;
            new MyClass {StringField = "hello"}.ToMaybe().
                With(x => x.StringField)
                .Do(x => result = x.Length);
            Assert.AreEqual(5, result);

            result = 0;
            new MyClass().ToMaybe().
               With(x => x.StringField)
               .Do(x => result = x.Length);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void TestDoMultipleActions()
        {
            int result = 0;
            string s = "";
            new MyClass { StringField = "hello" }.ToMaybe().
                With(x => x.StringField)
                .Do(x => result = x.Length, x => s = new string(x.Reverse().ToArray()));
            Assert.AreEqual(5, result);
            Assert.AreEqual("olleh", s);

            result = 0;
            s = "";
            new MyClass().ToMaybe().
               With(x => x.StringField)
                .Do(x => result = x.Length, x => s = new string(x.Reverse().ToArray()));
            Assert.AreEqual(0, result);
            Assert.AreEqual("", s);
        }

        [Test]
        public void TestApplyIf()
        {
            var result = new MyClass {StringField = "hello"}.ToMaybe().
                With(x => x.StringField)
                .ApplyIf(x => x.Length > 5, x => new string(x.Reverse().ToArray()))
                .Default("");
            Assert.AreEqual("hello", result.Value);

            result = new MyClass { StringField = "hello!" }.ToMaybe().
                With(x => x.StringField)
                .ApplyIf(x => x.Length > 5, x => new string(x.Reverse().ToArray()))
                .Default("");
            Assert.AreEqual("!olleh", result.Value);

            result = new MyClass().ToMaybe().
                With(x => x.StringField)
                .ApplyIf(x => x.Length > 5, x => new string(x.Reverse().ToArray()))
                .Default("");
            Assert.AreEqual("", result.Value);
        }

        [Test]
        public void TestApplyUnless()
        {
            var result = new MyClass { StringField = "hello" }.ToMaybe().
                With(x => x.StringField)
                .ApplyUnless(x => x.Length > 5, x => new string(x.Reverse().ToArray()))
                .Default("");
            Assert.AreEqual("olleh", result.Value);

            result = new MyClass { StringField = "hello!" }.ToMaybe().
                With(x => x.StringField)
                .ApplyUnless(x => x.Length > 5, x => new string(x.Reverse().ToArray()))
                .Default("");
            Assert.AreEqual("hello!", result.Value);

            result = new MyClass().ToMaybe().
                With(x => x.StringField)
                .ApplyUnless(x => x.Length > 5, x => new string(x.Reverse().ToArray()))
                .Default("");
            Assert.AreEqual("", result.Value);
        }

        [Test]
        public void TestIsNull()
        {
            var result = new MyClass { StringField = "hello" }.ToMaybe().
                With(x => x.StringField)
                .Default("default");
            Assert.AreEqual("hello", result.Value);

            result = new MyClass().ToMaybe().
                With(x => x.StringField)
                .Default("default");
            Assert.AreEqual("default", result.Value);
        }

        [Test]
        public void TestIsNullWithLambda()
        {
            var result = new MyClass { StringField = "hello" }.ToMaybe().
                With(x => x.StringField)
                .Default(() => "default");
            Assert.AreEqual("hello", result.Value);

            result = new MyClass().ToMaybe().
                With(x => x.StringField)
                .Default(() => "default");
            Assert.AreEqual("default", result.Value);
        }

        [Test]
        public void TestSelectOne()
        {
            var result = new MyClass {StringField = "hello", StringField2 = "world"}.ToMaybe()
                .SelectOne(x => x.With(z => z.StringField), x => x.With(z => z.StringField2))
                .Default("default");
            Assert.AreEqual("hello", result.Value);

            result = new MyClass { StringField = "hello" }.ToMaybe()
                .SelectOne(x => x.With(z => z.StringField), x => x.With(z => z.StringField2))
                .Default("default");
            Assert.AreEqual("hello", result.Value);

            result = new MyClass { StringField2 = "world" }.ToMaybe()
                .SelectOne(x => x.With(z => z.StringField), x => x.With(z => z.StringField2))
                .Default("default");
            Assert.AreEqual("world", result.Value);

            result = new MyClass().ToMaybe()
                .SelectOne(x => x.With(z => z.StringField), x => x.With(z => z.StringField2))
                .Default("default");
            Assert.AreEqual("default", result.Value);
        }

        [Test]
        public void TestRefToMaybe()
        {
            string value = "hello";
            string nothing = null;

            var maybeValue = value.ToMaybe();
            var maybeNothing = nothing.ToMaybe();

            Assert.IsTrue(maybeValue.HasValue, "maybeValue.HasValue");
            Assert.IsFalse(maybeNothing.HasValue, "maybeNothing.HasValue");
        }

        [Test]
        public void TestValToMaybe()
        {
            int? value = 1;
            int? nothing = null;

            var maybeValue = value.ToMaybe();
            var maybeNothing = nothing.ToMaybe();

            Assert.IsTrue(maybeValue.HasValue, "maybeValue.HasValue");
            Assert.IsFalse(maybeNothing.HasValue, "maybeNothing.HasValue");

            var nullableIntWithValue = maybeValue.ToNullable();
            var nullableIntWithoutValue = maybeNothing.ToNullable();
            Assert.NotNull(nullableIntWithValue);
            Assert.Null(nullableIntWithoutValue);

        }

        [Test]
        public void TestWithIfNothing()
        {
            var data = Maybe<int>.Nothing;
            var result = data.WithIf(x => x > 5, x => x * 2, x => x / 2);
            Assert.False(result.HasValue);
        }

        [Test]
        public void TestWithIfTrue()
        {
            var data = 10.ToMaybe();
            var result = data.WithIf(x => x > 5, x => (x * 2).ToString(), x => (x / 2).ToString());
            Assert.True(result.HasValue);
            Assert.AreEqual("20", result.Value);
        }

        [Test]
        public void TestWithIfFalse()
        {
            var data = 4.ToMaybe();
            var result = data.WithIf(x => x > 5, x => (x * 2).ToString(), x => (x / 2).ToString());
            Assert.True(result.HasValue);
            Assert.AreEqual("2", result.Value);
        }

        [Test]
        public void TestWithUnlessNothing()
        {
            var data = Maybe<int>.Nothing;
            var result = data.WithUnless(x => x > 5, x => x * 2, x => x / 2);
            Assert.False(result.HasValue);
        }

        [Test]
        public void TestWithUnlessTrue()
        {
            var data = 10.ToMaybe();
            var result = data.WithUnless(x => x > 5, x => (x * 2).ToString(), x => (x / 2).ToString());
            Assert.True(result.HasValue);
            Assert.AreEqual("5", result.Value);
        }

        [Test]
        public void TestWithUnlessFalse()
        {
            var data = 4.ToMaybe();
            var result = data.WithUnless(x => x > 5, x => (x * 2).ToString(), x => (x / 2).ToString());
            Assert.True(result.HasValue);
            Assert.AreEqual("8", result.Value);
        }

        [Test]
        public void TestEquals()
        {

            var left = Maybe<int>.Nothing;
            var right = Maybe<int>.Nothing;
            Assert.True(left.Equals(right));

            left = 5.ToMaybe();
            Assert.False(left.Equals(right));

            right = 5.ToMaybe();
            Assert.True(left.Equals(right));
        }


        [Test]
        public void TestEqualsOperator()
        {
            Maybe<int> left = null;
            Maybe<int> right = null;
            Assert.True(left == right);

            left = Maybe<int>.Nothing;
            right = Maybe<int>.Nothing;
            Assert.True(left == right);

            left = 5.ToMaybe();
            Assert.False(left == right);

            right = 5.ToMaybe();
            Assert.True(left == right);
        }

        [Test]
        public void TestNotEqualsOperator()
        {
            Maybe<int> left = null;
            Maybe<int> right = null;
            Assert.False(left != right);

            left = Maybe<int>.Nothing;
            right = Maybe<int>.Nothing;
            Assert.False(left != right);

            left = 5.ToMaybe();
            Assert.True(left != right);

            right = 5.ToMaybe();
            Assert.False(left != right);
        }

        [Test]
        public void TestTwist_PositivePositive()
        {
            var source = new Maybe<Result<int>>(Result.Success(5));
            var result = source.Twist().Twist();
            Assert.True(result.HasValue, "source.HasValue");
            Assert.True(result.Value.IsSucceed, "source.Value.IsSucceed");
            Assert.AreEqual(source.Value.Value, result.Value.Value);
        }

        [Test]
        public void TestTwist_PositiveNegative()
        {
            var source = new Maybe<Result<int>>(Result.Fail<int>());
            var result = source.Twist().Twist();
            Assert.True(result.HasValue, "source.HasValue");
            Assert.True(result.Value.IsFailed, "source.Value.IsFailed");
        }

        [Test]
        public void TestTwist_Negative()
        {
            var source = Maybe<Result<int>>.Nothing;
            var result = source.Twist().Twist();
            Assert.False(result.HasValue, "source.HasValue");
        }

    }
}
