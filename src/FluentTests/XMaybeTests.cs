using System.Linq;
using System.Xml.Linq;
using Functional.Fluent;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluentTests
{
    [TestClass]
    public class XMaybeTests
    {

        private XElement GetTestElement()
        {
            return new XElement("root",
                new XElement("child", new XAttribute("attribute1", "value1"),
                    new XElement("subchild", "somevalue")),
                new XElement("child", "some other value")   
             );
        }


        [TestMethod]
        public void TestElement()
        {
            var m = GetTestElement().ToMaybe();
            
            var result = m.Element("child").Element("subchild").Value();
            Assert.AreEqual("somevalue", result);

            result = m.Element("child2").Element("subchild").Value();
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void TestElements()
        {
            var m = GetTestElement().ToMaybe();

            var result = m.Elements("child");
            Assert.AreEqual(2, result.Count());

            result = m.Elements("child2");
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void TestAttribute()
        {
            var m = GetTestElement().ToMaybe();

            var result = m.Element("child").Attribute("attribute1").Value();
            Assert.AreEqual("value1", result);

            result = m.Element("child").Attribute("attribute2").Value();
            Assert.AreEqual("", result);

            result = m.Element("child2").Attribute("attribute1").Value();
            Assert.AreEqual("", result);
        }

        [TestMethod]
        public void TestGetValue()
        {
            var m = GetTestElement().ToMaybe();

            var result = m.Element("child").Element("subchild");
            Assert.AreEqual(result.Value.Value, result.Value());

            result = m.Element("child2").Element("subchild");
            Assert.IsNull(result.Value);
            Assert.IsNotNull(result.Value());
        }

        [TestMethod]
        public void TestGetValueForAttributes()
        {
            var m = GetTestElement().ToMaybe();

            var result = m.Element("child").Attribute("attribute1");
            Assert.AreEqual(result.Value.Value, result.Value());

            result = m.Element("child2").Attribute("attribute1");
            Assert.IsNull(result.Value);
            Assert.IsNotNull(result.Value());
        }

        [TestMethod]
        public void TestGetValueWithLambda()
        {
            var m = GetTestElement().ToMaybe();

            var result = m.Element("child").Element("subchild");
            Assert.AreEqual(9, result.Value(x => x.Length, -1));

            result = m.Element("child2").Element("subchild");
            Assert.AreEqual(-1, result.Value(x => x.Length, -1));
        }

        [TestMethod]
        public void TestGetValueForAtttributesWithLambda()
        {
            var m = GetTestElement().ToMaybe();

            var result = m.Element("child").Attribute("attribute1");
            Assert.AreEqual(6, result.Value(x => x.Length, -1));

            result = m.Element("child2").Attribute("attribute1");
            Assert.AreEqual(-1, result.Value(x => x.Length, -1));
        }
    }
}
