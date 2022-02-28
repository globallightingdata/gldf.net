using Gldf.Net.Domain;
using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
using Gldf.Net.Domain.Global;
using Gldf.Net.Domain.Head;
using Gldf.Net.Domain.Product;
using Gldf.Net.Domain.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.Emitters
{
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
                LightSources = new[]
                {
                    new LightSource
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
                        LightSourceType = new FixedLightSource()
                    }
                },
                Equipments = new[]
                {
                    new Equipment
                    {
                        Id = "equipment",
                        LightSourceReference = new LightSourceReference
                        {
                            LightSourceId = "lightSource"
                        },
                        RatedInputPower = 10,
                        RatedLuminousFlux = 50
                    }
                },
                Emitters = new[]
                {
                    new Emitter
                    {
                        Id = "emitter-1",
                        PossibleFittings = new EmitterBase[]
                        {
                            new LightEmitter
                            {
                                PhotometryId = "photometry",
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
                                    X = 0,
                                    Y = 1,
                                    Z = 2,
                                    G0 = 3
                                }
                            },
                            new LightEmitter
                            {
                                PhotometryId = "photometry",
                                EquipmentId = "equipment"
                            },
                            new LightEmitter
                            {
                                PhotometryId = "photometry",
                                EmergencyBehaviour = EmergencyBehaviour.None
                            },
                            new LightEmitter
                            {
                                PhotometryId = "photometry",
                                EmergencyBehaviour = EmergencyBehaviour.Combined
                            },
                            new LightEmitter
                            {
                                PhotometryId = "photometry",
                                EmergencyBehaviour = EmergencyBehaviour.EmergencyOnly
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
                        EmitterReference = new EmitterReference
                        {
                            EmitterId = "emitter-1"
                        }
                    }
                }
            }
        };
    }
}