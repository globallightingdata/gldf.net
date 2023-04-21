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

public static class GeometryCompleteModel
{
    public static Root Root => new()
    {
        Header = new Header
        {
            Manufacturer = "DIAL",
            GldfCreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code",
            FormatVersion = new FormatVersion { Major = 1, Minor = 0, PreRelease = 2, PreReleaseSpecified = true },
            UniqueGldfId = "3BE556FF-9061-4592-AEB1-1BC9D507280E"
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
                    File = "https://example.org/geometry.l3d",
                    Language = "en"
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
                new SimpleGeometry
                {
                    Id = "geometry1",
                    GeometryType = new SimpleCuboidGeometry
                    {
                        Width = 1,
                        Length = 2,
                        Height = 3
                    },
                    EmitterType = new SimpleRectangularEmitter
                    {
                        Width = 4,
                        Length = 5
                    },
                    CHeights = new CHeights
                    {
                        C0 = 6,
                        C90 = 7,
                        C180 = 8,
                        C270 = 9
                    }
                },
                new SimpleGeometry
                {
                    Id = "geometry2",
                    GeometryType = new SimpleCylinderGeometry
                    {
                        Plane = SimpleCylinderPlane.X,
                        Diameter = 1,
                        Height = 2
                    },
                    EmitterType = new SimpleCircularEmitter
                    {
                        Diameter = 3
                    }
                },
                new SimpleGeometry
                {
                    Id = "geometry3",
                    GeometryType = new SimpleCylinderGeometry
                    {
                        Plane = SimpleCylinderPlane.Y,
                        Diameter = 1,
                        Height = 2
                    },
                    EmitterType = new SimpleRectangularEmitter
                    {
                        Width = 3,
                        Length = 4
                    }
                },
                new SimpleGeometry
                {
                    Id = "geometry4",
                    GeometryType = new SimpleCylinderGeometry
                    {
                        Plane = SimpleCylinderPlane.Z,
                        Diameter = 1,
                        Height = 2
                    },
                    EmitterType = new SimpleCircularEmitter
                    {
                        Diameter = 3
                    }
                },
                new ModelGeometry
                {
                    Id = "geometry5",
                    GeometryFileReferences = new []
                    {
                        new GeometryFileReference
                        {
                            FileId = "geometryFile",
                            LevelOfDetail = LevelOfDetail.Low,
                            LevelOfDetailSpecified = true
                        }
                    }
                }
            }
        },
        ProductDefinitions = new ProductDefinitions
        {
            ProductMetaData = new ProductMetaData
            {
                UniqueProductId = "Product 1",
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
                        Reference = new EmitterReference
                        {
                            EmitterId = "emitter"
                        }
                    }
                }
            }
        }
    };
}