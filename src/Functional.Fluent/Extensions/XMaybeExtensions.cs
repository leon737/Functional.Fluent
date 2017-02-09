using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Functional.Fluent.MonadicTypes;

namespace Functional.Fluent.Extensions
{
    public static class XMaybeExtensions
    {
        public static Maybe<XElement> Element(this Maybe<XElement> o, string name) =>
            o.With(x => x.Element(name));

        public static IEnumerable<Maybe<XElement>> Elements(this Maybe<XElement> o, string name) => 
            o.With(x => x.Elements(name)).Lift();

        public static Maybe<XAttribute> Attribute(this Maybe<XElement> o, string name) => 
            o.With(x => x.Attribute(name));

        public static Maybe<XElement> Element(this Maybe<XElement> o, XName name) =>
            o.With(x => x.Element(name));

        public static IEnumerable<Maybe<XElement>> Elements(this Maybe<XElement> o, XName name) =>
            o.With(x => x.Elements(name)).Lift();

        public static Maybe<XAttribute> Attribute(this Maybe<XElement> o, XName name) =>
            o.With(x => x.Attribute(name));

        public static string Value(this Maybe<XElement> o) => 
            o.Return(x => x.Value, string.Empty);

        public static T Value<T>(this Maybe<XElement> o, Func<string, T> convertFunc, T defaultValue = default(T)) => 
            o.Return(x => convertFunc(x.Value), defaultValue);

        public static string Value(this Maybe<XAttribute> o) => 
            o.Return(x => x.Value, string.Empty);

        public static T Value<T>(this Maybe<XAttribute> o, Func<string, T> convertFunc, T defaultValue = default(T)) => 
            o.Return(x => convertFunc(x.Value), defaultValue);
    }
}
