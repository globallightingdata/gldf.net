using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Xml.Definition.Types;
using System;

namespace Gldf.Net.Tests.TestData.Variants;

public static class VariantMandatoryTyped
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
            FixedLightSources = new()
            {
                new FixedLightSourceTyped
                {
                    Id = "fixedLightSource",
                    Name = new[]
                    {
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "FixedLightSource"
                        }
                    },
                    RatedInputPower = 50
                }
            },
            SimpleGeometries = new()
            {
                new SimpleGeometryTyped
                {
                    Id = "geometry",
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
                    }
                }
            },
            Emitter = new()
            {
                new EmitterTyped
                {
                    Id = "emitter",
                    FixedEmitterOptions = new FixedLightEmitterTyped[]
                    {
                        new()
                        {
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometry"
                            },
                            FixedLightSource = new FixedLightSourceTyped
                            {
                                Id = "fixedLightSource"
                            },
                            RatedLuminousFlux = 250
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
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "Variant 1"
                        }
                    }
                },
                new VariantTyped
                {
                    Id = "variant-2",
                    Name = new[]
                    {
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "Variant 2"
                        }
                    },
                    Geometry = new GeometryTyped
                    {
                        Simple = new SimpleGeometryEmitterTyped()
                        {
                            Emitter = new EmitterTyped
                            {
                                Id = "emitter"
                            },
                            Geometry = new SimpleGeometryTyped
                            {
                                Id = "geometry"
                            }
                        }
                    }
                }
            }
        }
    };
}