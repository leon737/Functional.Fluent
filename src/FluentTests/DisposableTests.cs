using System;
using Moq;
using Functional.Fluent.Helpers;
using NUnit.Framework;

namespace FluentTests
{
    [TestFixture]
    public class DisposableTests
    {
        
        [Test]
        public void TestDisposable()
        {
            var disposableMock = new Mock<IDisposable>();
            var result = Disposable.Using(() => disposableMock.Object, d => d.ToString());
            Assert.IsTrue(result.Contains("Mock"));           
            disposableMock.Verify(v => v.Dispose());
        }

        [Test]
        public void TestDisposableWithExpression()
        {
            var disposableMock = new Mock<IDisposable>();
            var result = Disposable.UsingExpression(() => disposableMock.Object, d => d.ToString());
            Assert.IsNotNull(result);
            disposableMock.Verify(v => v.Dispose(), Times.Never);
        }

        [Test]
        public void TestDisposableWithExpressionMaterialized()
        {
            var disposableMock = new Mock<IDisposable>();
            var result = Disposable.UsingExpression(() => disposableMock.Object, d => d.ToString()).Compile()();
            Assert.IsNotNull(result);
            disposableMock.Verify(v => v.Dispose(), Times.Once);
        }

        [Test]
        public void TestDisposableShouldDisposeEvenAfterExceptionThrown()
        {
            var disposableMock = new Mock<IDisposable>();
            try
            {
                var result = Disposable.Using(() => disposableMock.Object, d =>
                {
                    throw new Exception();
                    return "";
                });
            }
            catch (Exception) { }
            disposableMock.Verify(v => v.Dispose());
        }
    }
}
