using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using System;
using System.Xml;

namespace Gldf.Net.Tests.TestHelper
{
    public class XmlStringAssertions : ReferenceTypeAssertions<string, XmlStringAssertions>
    {
        protected override string Identifier => "string";

        public XmlStringAssertions(string xml)
        {
            Subject = xml;
        }

        public AndConstraint<XmlStringAssertions> EquivalentTo(
            string xml, string because = "", params object[] becauseArgs)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .ForCondition(!string.IsNullOrEmpty(xml))
                .FailWith($"{nameof(xml)} may not be null or empty")
                .Then
                .Given(() =>
                {
                    var xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(Subject);
                    return xmlDocument.InnerXml;
                })
                .ForCondition(expected =>
                {
                    var xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(xml!);
                    return xmlDocument.InnerXml.Equals(expected, StringComparison.OrdinalIgnoreCase);
                })
                .FailWith($"{xml}\n\n does not match\n\n{Subject}");
            return new AndConstraint<XmlStringAssertions>(this);
        }
    }
}