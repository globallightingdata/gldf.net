using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Xml.Definition.Types;
using System;

namespace Gldf.Net.Tests.TestData.Geometries;

public static class GeometryCompleteTyped
{
    public static RootTyped RootTyped => new()
    {
        Header = new HeaderTyped
        {
            Manufacturer = "DIAL",
            CreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code"
        },
        GeneralDefinitions = new GeneralDefinitionsTyped
        {
            Files = new()
            {
                new GldfFileTyped
                {
                    Id = "eulumdat",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    Uri = "https://example.org/eulumdat.ldt"
                },
                new GldfFileTyped
                {
                    Id = "geometryFile",
                    ContentType = FileContentType.GeoL3d,
                    Type = FileType.Url,
                    Uri = "https://example.org/geometry.l3d"
                }
            },
            Photometries = new()
            {
                new PhotometryTyped
                {
                    Id = "photometry",
                    PhotometryFile = new GldfFileTyped
                    {
                        Id = "eulumdat"
                    }
                }
            },
            Emitter = new()
            {
                new EmitterTyped
                {
                    Id = "emitter",
                    ChangeableEmitterOptions = new[]
                    {
                        new ChangeableLightEmitterTyped
                        {
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometry"
                            }
                        }
                    }
                }
            },
            SimpleGeometries = new()
            {
                new SimpleGeometryTyped
                {
                    Id = "geometry1",
                    CuboidGeometry = new SimpleCuboidGeometryTyped
                    {
                        Width = 1,
                        Length = 2,
                        Height = 3
                    },
                    RectangularEmitter = new SimpleRectangularEmitterTyped
                    {
                        Width = 4,
                        Length = 5
                    },
                    CHeights = new CHeightsTyped
                    {
                        C0 = 6,
                        C90 = 7,
                        C180 = 8,
                        C270 = 9
                    }
                },
                new SimpleGeometryTyped
                {
                    Id = "geometry2",
                    CylinderGeometry = new SimpleCylinderGeometryTyped
                    {
                        Plane = SimpleCylinderPlane.X,
                        Diameter = 1,
                        Height = 2
                    },
                    CircularEmitter = new SimpleCircularEmitterTyped
                    {
                        Diameter = 3
                    }
                },
                new SimpleGeometryTyped
                {
                    Id = "geometry3",
                    CylinderGeometry = new SimpleCylinderGeometryTyped
                    {
                        Plane = SimpleCylinderPlane.Y,
                        Diameter = 1,
                        Height = 2
                    },
                    RectangularEmitter = new SimpleRectangularEmitterTyped
                    {
                        Width = 3,
                        Length = 4
                    }
                },
                new SimpleGeometryTyped
                {
                    Id = "geometry4",
                    CylinderGeometry = new SimpleCylinderGeometryTyped
                    {
                        Plane = SimpleCylinderPlane.Z,
                        Diameter = 1,
                        Height = 2
                    },
                    CircularEmitter = new SimpleCircularEmitterTyped
                    {
                        Diameter = 3
                    }
                }
            }
        },
        ProductDefinitions = new ProductDefinitionsTyped
        {
            ProductMetaData = new ProductMetaDataTyped
            {
                ProductNumber = new[]
                {
                    new LocaleTyped
                    {
                        Language = "en",
                        Text = "Product number"
                    }
                },
                Name = new[]
                {
                    new LocaleTyped
                    {
                        Language = "en",
                        Text = "Product name"
                    }
                }
            },
            Variants = new()
            {
                new VariantTyped
                {
                    Id = "variant-1",
                    Name = new[]
                    {
                        new LocaleTyped { Language = "en", Text = "Variant 1" }
                    },
                    Geometry = new GeometryTyped
                    {
                        EmitterOnly = new EmitterTyped
                        {
                            Id = "emitter"
                        }
                    }
                }
            }
        }
    };
}