using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Head.Types;
using Gldf.Net.Domain.Xml.Definition.Types;
using System;

namespace Gldf.Net.Tests.TestData.Geometries;

public static class GeometryMandatoryTyped
{
    public static RootTyped RootTyped => new()
    {
        Header = new HeaderTyped
        {
            Manufacturer = "DIAL",
            CreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code",
            FormatVersion = FormatVersionTyped.V100
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
            ModelGeometries = new()
            {
                new ModelGeometryTyped
                {
                    Id = "geometry",
                    GeometryFiles = new ModelFileTyped[]
                    {
                        new()
                        {
                        },
                        new()
                        {
                        },
                        new()
                        {
                        }
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
                        Model = new ModelGeometryEmitterTyped
                        {
                            Geometry = new ModelGeometryTyped
                            {
                                Id = "geometry"
                            },
                            Emitter = new[]
                            {
                                new ModelEmitterTyped
                                {
                                    Emitter = new EmitterTyped
                                    {
                                        Id = "emitter"
                                    },
                                    EmitterObjectExtrernalName = "Leo"
                                }
                            }
                        }
                    }
                }
            }
        }
    };
}