using System.Linq;
using Functional.Fluent.Extensions;
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
                .IsNull("");
            Assert.AreEqual("hello", result.Value);

            result = new MyClass { StringField = "hello!" }.ToMaybe().
                With(x => x.StringField)
                .ApplyIf(x => x.Length > 5, x => new string(x.Reverse().ToArray()))
                .IsNull("");
            Assert.AreEqual("!olleh", result.Value);

            result = new MyClass().ToMaybe().
                With(x => x.StringField)
                .ApplyIf(x => x.Length > 5, x => new string(x.Reverse().ToArray()))
                .IsNull("");
            Assert.AreEqual("", result.Value);
        }

        [Test]
        public void TestApplyUnless()
        {
            var result = new MyClass { StringField = "hello" }.ToMaybe().
                With(x => x.StringField)
                .ApplyUnless(x => x.Length > 5, x => new string(x.Reverse().ToArray()))
                .IsNull("");
            Assert.AreEqual("olleh", result.Value);

            result = new MyClass { StringField = "hello!" }.ToMaybe().
                With(x => x.StringField)
                .ApplyUnless(x => x.Length > 5, x => new string(x.Reverse().ToArray()))
                .IsNull("");
            Assert.AreEqual("hello!", result.Value);

            result = new MyClass().ToMaybe().
                With(x => x.StringField)
                .ApplyUnless(x => x.Length > 5, x => new string(x.Reverse().ToArray()))
                .IsNull("");
            Assert.AreEqual("", result.Value);
        }

        [Test]
        public void TestIsNull()
        {
            var result = new MyClass { StringField = "hello" }.ToMaybe().
                With(x => x.StringField)
                .IsNull("default");
            Assert.AreEqual("hello", result.Value);

            result = new MyClass().ToMaybe().
                With(x => x.StringField)
                .IsNull("default");
            Assert.AreEqual("default", result.Value);
        }

        [Test]
        public void TestIsNullWithLambda()
        {
            var result = new MyClass { StringField = "hello" }.ToMaybe().
                With(x => x.StringField)
                .IsNull(() => "default");
            Assert.AreEqual("hello", result.Value);

            result = new MyClass().ToMaybe().
                With(x => x.StringField)
                .IsNull(() => "default");
            Assert.AreEqual("default", result.Value);
        }

        [Test]
        public void TestSelectOne()
        {
            var result = new MyClass {StringField = "hello", StringField2 = "world"}.ToMaybe()
                .SelectOne(x => x.With(z => z.StringField), x => x.With(z => z.StringField2))
                .IsNull("default");
            Assert.AreEqual("hello", result.Value);

            result = new MyClass { StringField = "hello" }.ToMaybe()
                .SelectOne(x => x.With(z => z.StringField), x => x.With(z => z.StringField2))
                .IsNull("default");
            Assert.AreEqual("hello", result.Value);

            result = new MyClass { StringField2 = "world" }.ToMaybe()
                .SelectOne(x => x.With(z => z.StringField), x => x.With(z => z.StringField2))
                .IsNull("default");
            Assert.AreEqual("world", result.Value);

            result = new MyClass().ToMaybe()
                .SelectOne(x => x.With(z => z.StringField), x => x.With(z => z.StringField2))
                .IsNull("default");
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
        }
    }
}
