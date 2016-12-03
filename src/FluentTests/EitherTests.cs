using Functional.Fluent.Extensions;
using Functional.Fluent.Helpers;
using NUnit.Framework;

namespace FluentTests
{
    [TestFixture]
    public class EitherTests
    {
        [TestCase(5, null, true, false)]
        [TestCase(null, "hello", false, true)]
        public void TestMakeEither(int? left, string right, bool hasLeft, bool hasRight)
        {
            var e = left != null ? Either.Create<int, string>(() => left.Value) : Either.Create<int, string>(() => right);
            Assert.AreEqual(hasLeft, e().HasLeft);
            Assert.AreEqual(hasRight, e().HasRight);
            if (hasLeft)
                Assert.AreEqual(left.Value, e().Left);
            if (hasRight)
                Assert.AreEqual(right, e().Right);
        }

        private Either<string, int> GetNumber() => () => 5;
        private Either<string, int> GetError() => () => "Error";
        
        [Test]
        public void TestBind()
        {
            var x = from v in GetNumber()
                    select v;
            Assert.True(x.HasRight());
            Assert.AreEqual(5, x.Right());
        }

        [Test]
        public void TestBind2()
        {
            var x = from v1 in GetNumber()
                    from v2 in GetNumber()
                    select v1 + v2;
            Assert.True(x.HasRight());
            Assert.AreEqual(10, x.Right());
        }

        [Test]
        public void TestBind3()
        {
            var x = from v1 in GetNumber()
                    from v2 in GetError()
                    from v3 in GetNumber()
                    select v1 + v2 + v3;
            Assert.True(x.HasLeft());
            Assert.False(x.HasRight());
            Assert.AreEqual("Error", x.Left());
        }

    }
}