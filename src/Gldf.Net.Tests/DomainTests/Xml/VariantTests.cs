using FluentAssertions;
using Gldf.Net.Domain.Xml.Product;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests.Xml;

public class VariantTests
{
    [Test]
    public void SortOrderSpecified_ShouldBeTrue_WhenSet()
    {
        var variant = new Variant { SortOrder = 1};
        var sortOrderSpecified = variant.SortOrderSpecified;
        sortOrderSpecified.Should().BeTrue();
    }

    [Test]
    public void SortOrderSpecified_ShouldBeFalse_WhenNotSet()
    {
        var variant = new Variant();
        var sortOrderSpecified = variant.SortOrderSpecified;
        sortOrderSpecified.Should().BeFalse();
    }
}