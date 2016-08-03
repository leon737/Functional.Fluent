using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Functional.Fluent;

namespace FluentTests
{
    [TestClass]
    public class DisposableTests
    {
        
        [TestMethod]
        public void TestDisposable()
        {
            var disposableMock = new Mock<IDisposable>();
            var result = Disposable.Using(() => disposableMock.Object, d => d.ToString());
            Assert.IsTrue(result.Contains("Mock"));           
            disposableMock.Verify(v => v.Dispose());
        }

        [TestMethod]
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
