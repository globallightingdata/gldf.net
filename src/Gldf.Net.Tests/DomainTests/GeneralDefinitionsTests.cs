using FluentAssertions;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using NUnit.Framework;

namespace Gldf.Net.Tests.DomainTests;

[TestFixture]
public class GeneralDefinitionsTests
{
    [Test]
    public void GetAsSimpleGeometries_ShouldReturnEmptyArray_WhenGeometriesIsNull()
    {
        var definitions = new GeneralDefinitions();
        definitions.GetAsSimpleGeometries().Should().BeEmpty();
    }

    [Test]
    public void GetAsModelGeometries_ShouldReturnEmptyArray_WhenGeometriesIsNull()
    {
        var definitions = new GeneralDefinitions();
        definitions.GetAsModelGeometries().Should().BeEmpty();
    }

    [Test]
    public void GetAsSimpleGeometries_ShouldReturnExpected()
    {
        var simpleGeometry = new SimpleGeometry();
        var modelGeometry = new ModelGeometry();
        var definitions = new GeneralDefinitions { Geometries = new Geometry[] { simpleGeometry, modelGeometry } };

        definitions.GetAsSimpleGeometries().Should().HaveCount(1);
        definitions.GetAsSimpleGeometries().Should().OnlyContain(geo => geo == simpleGeometry);
    }

    [Test]
    public void GetAsModelGeometries_ShouldReturnExpected()
    {
        var simpleGeometry = new SimpleGeometry();
        var modelGeometry = new ModelGeometry();
        var definitions = new GeneralDefinitions { Geometries = new Geometry[] { simpleGeometry, modelGeometry } };

        definitions.GetAsModelGeometries().Should().HaveCount(1);
        definitions.GetAsModelGeometries().Should().OnlyContain(geo => geo == modelGeometry);
    }
    
    [Test]
    public void GetAsChangeableLightSources_ShouldReturnExpected()
    {
        var expected = new ChangeableLightSource();
        var definitions = new GeneralDefinitions { LightSources = new LightSourceBase[] { expected } };

        definitions.GetAsChangeableLightSources().Should().HaveCount(1);
        definitions.GetAsChangeableLightSources().Should().OnlyContain(ls => ls == expected);
    }

    [Test]
    public void GetAsFixedLightSource_ShouldReturnExpected()
    {
        var expected = new FixedLightSource();
        var definitions = new GeneralDefinitions { LightSources = new LightSourceBase[] { expected } };

        definitions.GetAsFixedLightSources().Should().HaveCount(1);
        definitions.GetAsFixedLightSources().Should().OnlyContain(ls => ls == expected);
    }
}