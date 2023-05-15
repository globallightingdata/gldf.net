using FluentAssertions;
using Gldf.Net.Container;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Gldf.Net.Tests.Extensions;

[TestFixture]
public class GldfContainerExtensionsTests
{
    [Test, TestCaseSource(nameof(TestData))]
    public void GetAssetCollection_ShouldReturnExpected(GldfContainer gldf, FileContentType type, List<ContainerFile> expected)
    {
        var assetCollection = gldf.GetAssetCollection(type);
        assetCollection.Should().BeSameAs(expected);
    }
    
    [Test]
    public void GetAssetCollection_ShouldThrow_WhenUnknownFileContentType()
    {
        const FileContentType unknownContentType = (FileContentType)int.MaxValue;
        var gldf = new GldfContainer();
        var act = () => gldf.GetAssetCollection(unknownContentType);
        act.Should()
            .Throw<ArgumentOutOfRangeException>()
            .WithMessage("Specified argument was out of the range*");
    }
    
    [Test]
    public void GetAssetCollection_ShouldThrow_WhenParameterIsNull()
    {
        var act = () => ((GldfContainer)null).GetAssetCollection(FileContentType.ImageJpg);
        act.Should()
            .Throw<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'gldf')");
    }

    private static IEnumerable<TestCaseData> TestData() 
    {
        var gldf = new GldfContainer();
        return new List<TestCaseData>
        {
            new(gldf, FileContentType.ImageJpg, gldf.Assets.Images),
            new(gldf, FileContentType.ImagePng, gldf.Assets.Images),
            new(gldf, FileContentType.ImageSvg, gldf.Assets.Images),
            new(gldf, FileContentType.DocPdf, gldf.Assets.Documents),
            new(gldf, FileContentType.LdcEulumdat, gldf.Assets.Photometries),
            new(gldf, FileContentType.LdcIesXml, gldf.Assets.Photometries),
            new(gldf, FileContentType.LdcIes, gldf.Assets.Photometries),
            new(gldf, FileContentType.Other, gldf.Assets.Other),
            new(gldf, FileContentType.GeoL3d, gldf.Assets.Geometries),
            new(gldf, FileContentType.GeoM3d, gldf.Assets.Geometries),
            new(gldf, FileContentType.GeoR3d, gldf.Assets.Geometries),
            new(gldf, FileContentType.SpectrumText, gldf.Assets.Spectrums),
            new(gldf, FileContentType.SymbolDxf, gldf.Assets.Symbols),
            new(gldf, FileContentType.SymbolSvg, gldf.Assets.Symbols),
            new(gldf, FileContentType.SensorSensLdt, gldf.Assets.Sensors),
            new(gldf, FileContentType.SensorSensXml, gldf.Assets.Sensors),
        };
    }
}