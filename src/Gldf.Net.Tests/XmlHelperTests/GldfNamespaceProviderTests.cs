using FluentAssertions;
using Gldf.Net.XmlHelper;
using NUnit.Framework;
using System.Xml;

namespace Gldf.Net.Tests.XmlHelperTests;

[TestFixture]
public class GldfNamespaceProviderTests
{
    [Test]
    public void GetNamespaces_Should_Return_OneNamespace()
    {
        const string prefix = "xsi";
        const string namespaceWithoutPrefix = "http://www.w3.org/2001/XMLSchema-instance";
        var expectedNamespace = new XmlQualifiedName(prefix, namespaceWithoutPrefix);

        var namespaces = GldfNamespaceProvider.GetNamespaces();

        namespaces.ToArray().Should().Contain(expectedNamespace);
    }
}