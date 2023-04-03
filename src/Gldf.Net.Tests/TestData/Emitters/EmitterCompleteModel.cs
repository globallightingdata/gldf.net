using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Domain.Xml.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.Emitters;

public class EmitterCompleteModel
{
    public static Root Root => new()
    {
        Header = new Header
        {
            Manufacturer = "DIAL",
            CreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code"
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
                    Id = "sensorFile",
                    ContentType = FileContentType.SensorSensXml,
                    Type = FileType.Url,
                    File = "https://example.org/sensor.xml"
                }
            },
            Sensors = new[]
            {
                new Sensor
                {
                    Id = "sensor",
                    SensorFileReference = new SensorFileReference
                    {
                        FileId = "sensorFile"
                    }
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
            LightSources = new LightSourceBase[]
            {
                new ChangeableLightSource
                {
                    Id = "lightSource",
                    Name = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "LightSource name"
                        }
                    },
                    RatedInputPower = 50,
                    RatedLuminousFlux = 250
                }
            },
            Equipments = new[]
            {
                new Equipment
                {
                    Id = "equipment",
                    LightSourceReference = new LightSourceReference
                    {
                        ChangeableLightSourceId = "lightSource"
                    },
                    RatedInputPower = 10
                }
            },
            Emitters = new[]
            {
                new Emitter
                {
                    Id = "emitter-1",
                    PossibleFittings = new EmitterBase[]
                    {
                        new ChangeableLightEmitter
                        {
                            Name = new[]
                            {
                                new Locale
                                {
                                    Language = "en",
                                    Text = "Display name"
                                },
                                new Locale
                                {
                                    Language = "de",
                                    Text = "Anzeigename"
                                }
                            },
                            PhotometryReference = new PhotometryReference
                            {
                                PhotometryId = "photometry"
                            },
                            Rotation = new Rotation
                            {
                                X = 1,
                                Y = 2,
                                Z = 3,
                                G0 = 4
                            }
                        },
                        new ChangeableLightEmitter
                        {
                            PhotometryReference = new PhotometryReference
                            {
                                PhotometryId = "photometry"
                            },
                            EquipmentReference = new EquipmentReference
                            {
                                EquipmentId = "equipment"
                            }
                        },
                        new ChangeableLightEmitter
                        {
                            EmergencyBehaviour = EmergencyBehaviour.None,
                            PhotometryReference = new PhotometryReference
                            {
                                PhotometryId = "photometry"
                            }
                        },
                        new ChangeableLightEmitter
                        {
                            EmergencyBehaviour = EmergencyBehaviour.Combined,
                            PhotometryReference = new PhotometryReference
                            {
                                PhotometryId = "photometry"
                            }
                        },
                        new ChangeableLightEmitter
                        {
                            EmergencyBehaviour = EmergencyBehaviour.EmergencyOnly,
                            PhotometryReference = new PhotometryReference
                            {
                                PhotometryId = "photometry"
                            }
                        }
                    }
                },
                new Emitter
                {
                    Id = "emitter-2",
                    PossibleFittings = new EmitterBase[]
                    {
                        new SensorEmitter
                        {
                            SensorId = "sensor",
                            Name = new[]
                            {
                                new Locale
                                {
                                    Language = "en",
                                    Text = "Display name"
                                },
                                new Locale
                                {
                                    Language = "de",
                                    Text = "Anzeigename"
                                }
                            },
                            Rotation = new Rotation
                            {
                                X = 10.1,
                                Y = 11.2,
                                Z = 12.3,
                                G0 = 13.4
                            }
                        },
                        new SensorEmitter
                        {
                            SensorId = "sensor"
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
                        Reference = new EmitterReference
                        {
                            EmitterId = "emitter-1"
                        }
                    }
                }
            }
        }
    };
}