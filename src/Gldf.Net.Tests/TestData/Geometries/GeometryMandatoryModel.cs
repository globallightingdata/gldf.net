using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Domain.Xml.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.Geometries;

public static class GeometryMandatoryModel
{
    public static Root Root => new()
    {
        Header = new Header
        {
            Manufacturer = "DIAL",
            GldfCreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code",
            FormatVersion  = new FormatVersion
            {
                Major = 1, 
                Minor = 0, 
                PreRelease = 2
            }
        },
        GeneralDefinitions = new GeneralDefinitions
        {
            Files = new[]
            {
                new GldfFile
                {
                    Id = "eulumdat",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    File = "https://example.org/eulumdat.ldt"
                },
                new GldfFile
                {
                    Id = "geometryFile",
                    ContentType = FileContentType.GeoL3d,
                    Type = FileType.Url,
                    File = "https://example.org/geometry.l3d"
                }
            },
            Photometries = new[]
            {
                new Photometry
                {
                    Id = "photometry",
                    Content = new PhotometryFileReference
                    {
                        FileId = "eulumdat"
                    }
                }
            },
            Emitters = new[]
            {
                new Emitter
                {
                    Id = "emitter",
                    PossibleFittings = new EmitterBase[]
                    {
                        new ChangeableLightEmitter
                        {
                            PhotometryReference = new PhotometryReference
                            {
                                PhotometryId = "photometry"
                            }
                        }
                    }
                }
            },
            Geometries = new GeometryBase[]
            {
                new ModelGeometry
                {
                    Id = "geometry",
                    GeometryFileReferences = new GeometryFileReference[]
                    {
                        new()
                        {
                            FileId = "geometryFile",
                            LevelOfDetail = LevelOfDetail.Low
                        },
                        new()
                        {
                            FileId = "geometryFile",
                            LevelOfDetail = LevelOfDetail.Medium
                        },
                        new()
                        {
                            FileId = "geometryFile",
                            LevelOfDetail = LevelOfDetail.High
                        }
                    }
                }
            }
        },
        ProductDefinitions = new ProductDefinitions
        {
            ProductMetaData = new ProductMetaData
            {
                ProductNumber = new[]
                {
                    new Locale
                    {
                        Language = "en",
                        Text = "Product number"
                    }
                },
                Name = new[]
                {
                    new Locale
                    {
                        Language = "en",
                        Text = "Product name"
                    }
                }
            },
            Variants = new[]
            {
                new Variant
                {
                    Id = "variant-1",
                    Name = new[]
                    {
                        new Locale { Language = "en", Text = "Variant 1" }
                    },
                    Geometry = new GeometryReference
                    {
                        Reference = new ModelGeometryReference
                        {
                            GeometryId = "geometry",
                            EmitterReferences = new[]
                            {
                                new GeometryEmitterReference
                                {
                                    EmitterId = "emitter",
                                    EmitterObjectExternalName = "Leo"
                                }
                            }
                        }
                    }
                }
            }
        }
    };
}