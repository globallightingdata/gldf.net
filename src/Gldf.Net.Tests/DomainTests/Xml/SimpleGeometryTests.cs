using FluentAssertions;
using Gldf.Net.Domain.Xml.Definition.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests.Xml;

[TestFixture]
public class SimpleGeometryTests
{
    [Test]
    public void GetAsCuboidGeometry_ShouldReturnExpected()
    {
        var expected = new SimpleCuboidGeometry();
        var simpleGeometry = new SimpleGeometry { GeometryType = expected };
        var geometry = simpleGeometry.GetAsCuboidGeometry();

        geometry.Should().Be(expected);
    }
    
    [Test]
    public void GetAsCylinderGeometry_ShouldReturnExpected()
    {
        var expected = new SimpleCylinderGeometry();
        var simpleGeometry = new SimpleGeometry { GeometryType = expected };
        var geometry = simpleGeometry.GetAsCylinderGeometry();

        geometry.Should().Be(expected);
    }
    
    [Test]
    public void GetAsRectangularEmitter_ShouldReturnExpected()
    {
        var expected = new SimpleRectangularEmitter();
        var simpleGeometry = new SimpleGeometry { EmitterType = expected };
        var geometry = simpleGeometry.GetAsRectangularEmitter();

        geometry.Should().Be(expected);
    }
    
    [Test]
    public void GetAsCircularEmitter_ShouldReturnExpected()
    {
        var expected = new SimpleCircularEmitter();
        var simpleGeometry = new SimpleGeometry { EmitterType = expected };
        var geometry = simpleGeometry.GetAsCircularEmitter();

        geometry.Should().Be(expected);
    }
}