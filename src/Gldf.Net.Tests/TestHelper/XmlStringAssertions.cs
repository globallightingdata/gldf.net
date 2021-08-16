using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System;
using System.Xml.Linq;

namespace Gldf.Net.Tests.TestHelper
{
    public class XmlStringAssertions : ReferenceTypeAssertions<string, XmlStringAssertions>
    {
        protected override string Identifier => "string";

        public XmlStringAssertions(string xml)
        {
            Subject = xml;
        }

        public AndConstraint<XmlStringAssertions> EquivalentTo(string xml, string because = "",
            params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(!string.IsNullOrEmpty(xml))
                .FailWith($"{nameof(xml)} may not be null or empty")
                .Then
                .Given(() => XDocument.Parse(Subject).ToString())
                .ForCondition(expected =>
                {
                    var xDocument = XDocument.Parse(xml!).ToString();
                    return xDocument.Equals(expected, StringComparison.OrdinalIgnoreCase);
                })
                .FailWith($"{xml}\n\n does not match\n\n{Subject}");
            return new AndConstraint<XmlStringAssertions>(this);
        }
    }
}