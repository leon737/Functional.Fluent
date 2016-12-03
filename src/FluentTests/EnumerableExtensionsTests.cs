﻿using System.Collections.Generic;
using System.Linq;
using Functional.Fluent.Extensions;
using NUnit.Framework;

namespace FluentTests
{
    [TestFixture]
    public class EnumerableExtensionsTests
    {
        [Test]
        public void TestApplyNonMaterialize()
        {
            var source = new[] { 1, 2, 3, 4, 5 };
            var result = new List<int>();
            source.Apply(v =>
            {
                result.Add(v);
            });
            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public void TestDistinctByProperties()
        {
            var source = new[]
            {
                new Foo {StringProperty = "AAA"},
                new Foo {StringProperty = "BBB"},
                new Foo {StringProperty = "CCC"},
                new Foo {StringProperty = "BBB"},
                new Foo {StringProperty = "AAA"}
            };

            var result = source.DistinctBy(v => v.StringProperty).ToList();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, result.Count(x => x.StringProperty == "AAA"));
            Assert.AreEqual(1, result.Count(x => x.StringProperty == "BBB"));
            Assert.AreEqual(1, result.Count(x => x.StringProperty == "CCC"));
        }

        [Test]
        public void TestDistinctByFields()
        {
            var source = new[]
            {
                new Foo {IntegerField = 1},
                new Foo {IntegerField = 2},
                new Foo {IntegerField = 1},
                new Foo {IntegerField = 3},
                new Foo {IntegerField = 2},
                new Foo {IntegerField = 1},
                new Foo {IntegerField = 3},
            };

            var result = source.DistinctBy(v => v.IntegerField).ToList();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, result.Count(x => x.IntegerField == 1));
            Assert.AreEqual(1, result.Count(x => x.IntegerField == 2));
            Assert.AreEqual(1, result.Count(x => x.IntegerField == 3));
        }

        [Test]
        public void TestDistinctByObject()
        {
            var source = new[]
            {
                new Foo {StringProperty = "AAA", IntegerField = 1},
                new Foo {StringProperty = "BBB", IntegerField = 2},
                new Foo {StringProperty = "CCC", IntegerField = 3},
                new Foo {StringProperty = "BBB", IntegerField = 2},
                new Foo {StringProperty = "AAA", IntegerField = 1}
            };

            var result = source.DistinctBy(v => new { v.StringProperty, v.IntegerField }).ToList();

            Assert.AreEqual(3, result.Count);
            Assert.AreEqual(1, result.Count(x => x.StringProperty == "AAA"));
            Assert.AreEqual(1, result.Count(x => x.StringProperty == "BBB"));
            Assert.AreEqual(1, result.Count(x => x.StringProperty == "CCC"));
        }

        class Foo
        {
            public string StringProperty { get; set; }

            public int IntegerField;
        }


        [Test]
        public void TestPassingNullReferenceToWhereJoiner()
        {
            List<int> list = null;
            var result = list.Where(EnumerableExtensions.PredicateCombination.AndAlso, x => x > 0, x => x%2 == 0).ToList();
        }
    }
}