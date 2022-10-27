using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Domain.Xml.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.ControlGears
{
    public class ControlGearCompleteModel
    {
        public static Root Root => new()
        {
            Header = new Header
            {
                Manufacturer = "DIAL",
                CreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
                CreatedWithApplication = "Visual Studio Code",
                FormatVersion = FormatVersion.V100
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
                ControlGears = new[]
                {
                    new ControlGear
                    {
                        Id = "controlGear-1",
                        Name = new[]
                        {
                            new Locale
                            {
                                Language = "en",
                                Text = "ControlGear name"
                            }
                        },
                        Description = new[]
                        {
                            new Locale
                            {
                                Language = "en",
                                Text = "ControlGear description"
                            }
                        },
                        NominalVoltage = new Voltage
                        {
                            Value = new VoltageRange
                            {
                                Min = 120,
                                Max = 230
                            },
                            Type = VoltageType.DC,
                            Frequency = VoltageFrequency.Hz400
                        },
                        StandbyPower = 0.1,
                        ConstantLightOutputStartPower = 0.2,
                        ConstantLightOutputEndPower = 0.3,
                        PowerConsumptionControls = 0.4,
                        IsDimmable = true,
                        IsColorControllable = false,
                        Interfaces = new[]
                        {
                            Interface.DaliBroadcast,
                            Interface.DaliAddressable
                        },
                        EnergyLabels = new[]
                        {
                            new EnergyLabel { Region = "eu", Label = "A+" },
                            new EnergyLabel { Region = "us", Label = "B" }
                        }
                    },
                    new ControlGear
                    {
                        Id = "controlGear-2",
                        Name = new[]
                        {
                            new Locale
                            {
                                Language = "en",
                                Text = "ControlGear name"
                            }
                        },
                        Description = new[]
                        {
                            new Locale
                            {
                                Language = "en",
                                Text = "ControlGear description"
                            }
                        },
                        Interfaces = new[]
                        {
                            Interface.Knx,
                            Interface.Volt0To10,
                            Interface.Volt1To10,
                            Interface.Volt230,
                            Interface.Rf,
                            Interface.WiFi,
                            Interface.Bluetooth,
                            Interface.InterConnection,
                            Interface.Dmx,
                            Interface.DmxRdm
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
                                EmitterId = "emitter"
                            }
                        }
                    }
                }
            }
        };
    }
}