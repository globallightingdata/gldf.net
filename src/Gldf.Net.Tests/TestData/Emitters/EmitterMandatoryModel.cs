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
    public class EmitterMandatoryModel
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
                        Id = "sensorXml",
                        ContentType = FileContentType.SensorSensXml,
                        Type = FileType.Url,
                        File = "https://example.org/sens.xml"
                    }
                },
                Sensors = new[]
                {
                    new Sensor
                    {
                        Id = "sensor",
                        SensorFileReference = new SensorFileReference
                        {
                            FileId = "sensorXml"
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
                    new FixedLightSource
                    {
                        Id = "fixedLightSource",
                        Name = new[]
                        {
                            new Locale
                            {
                                Language = "en",
                                Text = "FixedLightSource"
                            }
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
                            new FixedLightEmitter
                            {
                                PhotometryReference = new PhotometryReference
                                {
                                    PhotometryId = "photometry"
                                },
                                LightSourceReference = new FixedLightSourceReference
                                {
                                    FixedLightSourceId = "fixedLightSource"
                                },
                                RatedLuminousFlux = 50
                            }
                        }
                    },
                    new Emitter
                    {
                        Id = "emitter-3",
                        PossibleFittings = new EmitterBase[]
                        {
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
                        Geometry = new Geometry
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
}