﻿using System.Collections.Generic;
using System.Linq;
using Functional.Fluent.Extensions;
using NUnit.Framework;

namespace FluentTests
{
    [TestFixture]
    public class MaybeEnumerableTests
    {
        [Test]
        public void TestWith()
        {
            var i = (IEnumerable<string>)new[]{"hello", null, "world!"};
            var m = i.ToMaybe();
            var r = m.With(x => x.Length);
            Assert.AreEqual(2, r.Count());
            Assert.AreEqual(5, r.ElementAt(0).Value);
            Assert.AreEqual(6, r.ElementAt(1).Value);
        }

        [Test]
        public void TestReturn()
        {
            var i = (IEnumerable<string>)new[] { "hello", null, "world!" };
            var m = i.ToMaybe();
            var r = m.Return(x => x.Length, -1);
            Assert.AreEqual(3, r.Count());
            Assert.AreEqual(5, r.ElementAt(0).Value);
            Assert.AreEqual(-1, r.ElementAt(1).Value);
            Assert.AreEqual(6, r.ElementAt(2).Value);
        }

        [Test]
        public void TestReturnWithLambda()
        {
            var i = (IEnumerable<string>)new[] { "hello", null, "world!" };
            var m = i.ToMaybe();
            var r = m.Return(x => x.Length, () => -1);
            Assert.AreEqual(3, r.Count());
            Assert.AreEqual(5, r.ElementAt(0).Value);
            Assert.AreEqual(-1, r.ElementAt(1).Value);
            Assert.AreEqual(6, r.ElementAt(2).Value);
        }

        [Test]
        public void TestDo()
        {
            var i = (IEnumerable<string>)new[] { "hello", null, "world!" };
            var m = i.ToMaybe();
            int cnt = 0;
            var r = m.Do(x => cnt+=x.Length);
            Assert.AreEqual(11,cnt);
        }

        [Test]
        public void TestDoMultipleActions()
        {
            var i = (IEnumerable<string>)new[] { "hello", null, "world!" };
            var m = i.ToMaybe();
            int cnt = 0;
            string s = "";
            var r = m.Do(x => cnt += x.Length, x => s += x);
            Assert.AreEqual(11, cnt);
            Assert.AreEqual("helloworld!", s);
        }

        [Test]
        public void TestApplyIf()
        {
            var i = (IEnumerable<string>)new[] { "hello", null, "world!" };
            var m = i.ToMaybe();
            var r = m.ApplyIf(x => x.Length > 5, x => x.ToUpper());
            Assert.AreEqual("hello", r.ElementAt(0).Value);
            Assert.AreEqual("WORLD!", r.ElementAt(1).Value);
        }

        [Test]
        public void TestApplyUnless()
        {
            var i = (IEnumerable<string>)new[] { "hello", null, "world!" };
            var m = i.ToMaybe();
            var r = m.ApplyUnless(x => x.Length > 5, x => x.ToUpper());
            Assert.AreEqual("HELLO", r.ElementAt(0).Value);
            Assert.AreEqual("world!", r.ElementAt(1).Value);
        }
    }
}
