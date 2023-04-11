using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Head.Types;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Product.Types;
using System;
using System.Collections.Generic;

namespace Gldf.Net.Tests.TestData.Emitters;

public static class EmitterCompleteTyped
{
    public static RootTyped RootTyped => new()
    {
        Header = new HeaderTyped
        {
            Manufacturer = "DIAL",
            GldfCreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code",
            FormatVersion = new FormatVersionTyped { Major = 1, Minor = 0, PreRelease = 2 },
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
                    Uri = "https://example.org/eulumdat.ldt"
                },
                new()
                {
                    Id = "sensorFile",
                    ContentType = FileContentType.SensorSensXml,
                    Type = FileType.Url,
                    Uri = "https://example.org/sensor.xml"
                }
            },
            Sensors = new List<SensorTyped>
            {
                new()
                {
                    Id = "sensor",
                    SensorFile = new GldfFileTyped
                    {
                        Id = "sensorFile"
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
                        Id = "eulumdat"
                    }
                }
            },
            ChangeableLightSources = new List<ChangeableLightSourceTyped>
            {
                new()
                {
                    Id = "lightSource",
                    Name = new[]
                    {
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "LightSource name"
                        }
                    },
                    RatedInputPower = 50,
                    RatedLuminousFlux = 250
                }
            },
            Equipments = new List<EquipmentTyped>
            {
                new()
                {
                    Id = "equipment",
                    ChangeableLightSource = new ChangeableLightSourceTyped
                    {
                        Id = "lightSource"
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
                            Name = new[]
                            {
                                new LocaleTyped
                                {
                                    Language = "en",
                                    Text = "Display name"
                                },
                                new LocaleTyped
                                {
                                    Language = "de",
                                    Text = "Anzeigename"
                                }
                            },
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometry"
                            },
                            Rotation = new RotationTyped
                            {
                                X = 1,
                                Y = 2,
                                Z = 3,
                                G0 = 4
                            }
                        },
                        new ChangeableLightEmitterTyped
                        {
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometry"
                            },
                            Equipment = new EquipmentTyped
                            {
                                Id = "equipment"
                            }
                        },
                        new ChangeableLightEmitterTyped
                        {
                            EmergencyBehaviour = EmergencyBehaviour.None,
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometry"
                            }
                        },
                        new ChangeableLightEmitterTyped
                        {
                            EmergencyBehaviour = EmergencyBehaviour.Combined,
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometry"
                            }
                        },
                        new ChangeableLightEmitterTyped
                        {
                            EmergencyBehaviour = EmergencyBehaviour.EmergencyOnly,
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometry"
                            }
                        }
                    }
                },
                new()
                {
                    Id = "emitter-2",
                    SensorEmitterOptions = new[]
                    {
                        new SensorEmitterTyped
                        {
                            Name = new[]
                            {
                                new LocaleTyped
                                {
                                    Language = "en",
                                    Text = "Display name"
                                },
                                new LocaleTyped
                                {
                                    Language = "de",
                                    Text = "Anzeigename"
                                }
                            },
                            Rotation = new RotationTyped
                            {
                                X = 10.1,
                                Y = 11.2,
                                Z = 12.3,
                                G0 = 13.4
                            }
                        },
                        new SensorEmitterTyped()
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
                            Id = "emitter-1"
                        }
                    }
                }
            }
        }
    };
}