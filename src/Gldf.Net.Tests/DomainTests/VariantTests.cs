using FluentAssertions;
using Gldf.Net.Domain.Product;
using Gldf.Net.Domain.Product.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests;

public class VariantTests
{
    [Test]
    public void GetAsEmitterReference_ShouldReturnNull_WhenValueNotSet()
    {
        var variant = new Variant();
        variant.GetAsEmitterReference().Should().BeNull();
    }

    [Test]
    public void GetAsModelGeometryReference_ShouldReturnNull_WhenValueNotSet()
    {
        var variant = new Variant();
        variant.GetAsModelGeometryReference().Should().BeNull();
    }

    [Test]
    public void GetAsGetAsSimpleGeometryReference_ShouldReturnNull_WhenValueNotSet()
    {
        var variant = new Variant();
        variant.GetAsSimpleGeometryReference().Should().BeNull();
    }

    [Test]
    public void GetAsEmitterReference_ShouldReturnNull_WhenValueSetToOtherTyp()
    {
        var variant = new Variant { EmitterReference = new ModelGeometryReference() };
        variant.GetAsEmitterReference().Should().BeNull();
    }

    [Test]
    public void GetAsModelGeometryReference_ShouldReturnNull_WhenValueSetToOtherTyp()
    {
        var variant = new Variant { EmitterReference = new SimpleGeometryReference() };
        variant.GetAsModelGeometryReference().Should().BeNull();
    }

    [Test]
    public void GetAsGetAsSimpleGeometryReference_ShouldReturnNull_WhenValueSetToOtherTyp()
    {
        var variant = new Variant { EmitterReference = new ModelGeometryReference() };
        variant.GetAsSimpleGeometryReference().Should().BeNull();
    }

    [Test]
    public void GetAsEmitterReference_ShouldReturnExpected()
    {
        var expected = new EmitterReference();
        var variant = new Variant { EmitterReference = expected };
        variant.GetAsEmitterReference().Should().BeSameAs(expected);
    }

    [Test]
    public void GetAsModelGeometryReference_ShouldReturnExpected()
    {
        var expected = new ModelGeometryReference();
        var variant = new Variant { EmitterReference = expected };
        variant.GetAsModelGeometryReference().Should().BeSameAs(expected);
    }

    [Test]
    public void GetAsGetAsSimpleGeometryReference_ShouldReturnExpected()
    {
        var expected = new SimpleGeometryReference();
        var variant = new Variant { EmitterReference = expected };
        variant.GetAsSimpleGeometryReference().Should().BeSameAs(expected);
    }
}