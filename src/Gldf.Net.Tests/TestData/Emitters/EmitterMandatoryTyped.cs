using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Head.Types;
using Gldf.Net.Domain.Typed.Product;
using Gldf.Net.Domain.Xml.Definition.Types;
using System;
using System.Collections.Generic;

namespace Gldf.Net.Tests.TestData.Emitters;

public static class EmitterMandatoryTyped
{
    public static RootTyped RootTyped => new()
    {
        Header = new HeaderTyped
        {
            Manufacturer = "DIAL",
            GldfCreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code",
            FormatVersion = new FormatVersionTyped { Major = 1, Minor = 0, PreRelease = 3 },
            UniqueGldfId = "3BE556FF-9061-4592-AEB1-1BC9D507280E"
        },
        GeneralDefinitions = new GeneralDefinitionsTyped
        {
            Files = new List<GldfFileTyped>
            {
                new()
                {
                    Id = "eulumdat",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    Uri = "https://example.org/eulumdat.ldt",
                    FileName = "eulumdat.ldt"
                },
                new()
                {
                    Id = "sensorXml",
                    ContentType = FileContentType.SensorSensXml,
                    Type = FileType.Url,
                    Uri = "https://example.org/sens.xml",
                    FileName = "sens.xml"
                }
            },
            Sensors = new List<SensorTyped>
            {
                new()
                {
                    Id = "sensor",
                    SensorFile = new GldfFileTyped
                    {
                        Id = "sensorXml",
                        ContentType = FileContentType.SensorSensXml,
                        Type = FileType.Url,
                        Uri = "https://example.org/sens.xml",
                        FileName = "sens.xml"
                    }
                }
            },
            Photometries = new List<PhotometryTyped>
            {
                new()
                {
                    Id = "photometry",
                    PhotometryFile = new GldfFileTyped
                    {
                        Id = "eulumdat",
                        ContentType = FileContentType.LdcEulumdat,
                        Type = FileType.Url,
                        Uri = "https://example.org/eulumdat.ldt",
                        FileName = "eulumdat.ldt"
                    }
                }
            },
            FixedLightSources = new List<FixedLightSourceTyped>
            {
                new()
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
                    RatedInputPower = 10
                }
            },
            Emitter = new List<EmitterTyped>
            {
                new()
                {
                    Id = "emitter-1",
                    ChangeableEmitterOptions = new[]
                    {
                        new ChangeableLightEmitterTyped
                        {
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometry",
                                PhotometryFile = new GldfFileTyped
                                {
                                    Id = "eulumdat",
                                    ContentType = FileContentType.LdcEulumdat,
                                    Type = FileType.Url,
                                    Uri = "https://example.org/eulumdat.ldt",
                                    FileName = "eulumdat.ldt"
                                }
                            }
                        }
                    }
                },
                new()
                {
                    Id = "emitter-2",
                    FixedEmitterOptions = new[]
                    {
                        new FixedLightEmitterTyped
                        {
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometry",
                                PhotometryFile = new GldfFileTyped
                                {
                                    Id = "eulumdat",
                                    ContentType = FileContentType.LdcEulumdat,
                                    Type = FileType.Url,
                                    Uri = "https://example.org/eulumdat.ldt",
                                    FileName = "eulumdat.ldt"
                                }
                            },
                            FixedLightSource = new FixedLightSourceTyped
                            {
                                Id = "fixedLightSource",
                                Name = new LocaleTyped[]
                                {
                                    new()
                                    {
                                        Language = "en",
                                        Text = "FixedLightSource"
                                    }
                                },
                                RatedInputPower = 10
                            },
                            RatedLuminousFlux = 50
                        }
                    }
                },
                new()
                {
                    Id = "emitter-3",
                    SensorEmitterOptions = new[]
                    {
                        new SensorEmitterTyped
                        {
                            Sensor = new SensorTyped
                            {
                                Id = "sensor",
                                SensorFile = new GldfFileTyped
                                {
                                    Id = "sensorXml",
                                    ContentType = FileContentType.SensorSensXml,
                                    Type = FileType.Url,
                                    Uri = "https://example.org/sens.xml",
                                    FileName = "sens.xml"
                                }
                            }
                        }
                    }
                }
            }
        },
        ProductDefinitions = new ProductDefinitionsTyped
        {
            ProductMetaData = new ProductMetaDataTyped
            {
                UniqueProductId = "Product 1",
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
            Variants = new List<VariantTyped>
            {
                new()
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
                            Id = "emitter-1",
                            ChangeableEmitterOptions = new ChangeableLightEmitterTyped[]
                            {
                                new()
                                {
                                    Photometry = new PhotometryTyped
                                    {
                                        Id = "photometry",
                                        PhotometryFile = new GldfFileTyped
                                        {
                                            Id = "eulumdat",
                                            ContentType = FileContentType.LdcEulumdat,
                                            Type = FileType.Url,
                                            Uri = "https://example.org/eulumdat.ldt",
                                            FileName = "eulumdat.ldt"
                                        }
                                    }
                                }
                            }
                        }
                    },
                    ProductNumber = new LocaleTyped[]
                    {
                        new()
                        {
                            Language = "en",
                            Text = "Product number"
                        }
                    }
                }
            }
        }
    };
}