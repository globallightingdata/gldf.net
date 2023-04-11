using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.Emitters;

public static class EmitterCompleteTyped
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
                    Id = "sensorFile",
                    ContentType = FileContentType.SensorSensXml,
                    Type = FileType.Url,
                    Uri = "https://example.org/sensor.xml"
                }
            },
            Sensors = new()
            {
                new SensorTyped
                {
                    Id = "sensor",
                    SensorFile = new GldfFileTyped
                    {
                        Id = "sensorFile"
                    }
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
            ChangeableLightSources = new()
            {
                new ChangeableLightSourceTyped
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
            Equipments = new()
            {
                new EquipmentTyped
                {
                    Id = "equipment",
                    ChangeableLightSource = new ChangeableLightSourceTyped
                    {
                        Id = "lightSource"
                    },
                    RatedInputPower = 10
                }
            },
            Emitter = new()
            {
                new EmitterTyped
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
                new EmitterTyped
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
                        new SensorEmitterTyped
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