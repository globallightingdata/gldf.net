using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Head.Types;
using Gldf.Net.Domain.Typed.Product;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using System;

namespace Gldf.Net.Tests.TestData.ControlGears;

public static class ControlGearCompleteTyped
{
    public static RootTyped RootTyped => new()
    {
        Header = new HeaderTyped
        {
            Manufacturer = "DIAL",
            GldfCreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code",
            FormatVersion = new FormatVersionTyped {Major = 1, Minor = 0, PreRelease = 3},
            UniqueGldfId = "3BE556FF-9061-4592-AEB1-1BC9D507280E"
        },
        GeneralDefinitions = new GeneralDefinitionsTyped
        {
            Files =
            [
                new()
                {
                    Id = "eulumdat",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    Uri = "https://example.org/eulumdat.ldt",
                    FileName = "eulumdat.ldt"
                }
            ],
            Photometries =
            [
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
            ],
            ControlGears =
            [
                new()
                {
                    Id = "controlGear-1",
                    Name =
                    [
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "ControlGear name"
                        }
                    ],
                    Description =
                    [
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "ControlGear description"
                        }
                    ],
                    NominalVoltage = new VoltageTyped
                    {
                        VoltageRangeMin = 120,
                        VoltageRangeMax = 230,
                        Type = VoltageType.DC,
                        Frequency = VoltageFrequency.Hz400
                    },
                    StandbyPower = 0.1,
                    ConstantLightOutputStartPower = 0.2,
                    ConstantLightOutputEndPower = 0.3,
                    PowerConsumptionControls = 0.4,
                    IsDimmable = true,
                    IsColorControllable = false,
                    Interfaces =
                    [
                        Interface.DaliBroadcast,
                        Interface.DaliAddressable
                    ],
                    EnergyLabels =
                    [
                        new EnergyLabelTyped {Region = "eu", Label = "A+"},
                        new EnergyLabelTyped {Region = "us", Label = "B"}
                    ]
                },

                new()
                {
                    Id = "controlGear-2",
                    Name =
                    [
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "ControlGear name"
                        }
                    ],
                    Description =
                    [
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "ControlGear description"
                        }
                    ],
                    Interfaces =
                    [
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
                    ]
                }
            ],
            Emitter =
            [
                new()
                {
                    Id = "emitter",
                    ChangeableEmitterOptions =
                    [
                        new()
                        {
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometry",
                                PhotometryFile = new GldfFileTyped
                                {
                                    FileName = "eulumdat.ldt",
                                    Uri = "https://example.org/eulumdat.ldt",
                                    Type = FileType.Url,
                                    Id = "eulumdat"
                                }
                            }
                        }
                    ]
                }
            ]
        },
        ProductDefinitions = new ProductDefinitionsTyped
        {
            ProductMetaData = new ProductMetaDataTyped
            {
                UniqueProductId = "Product 1",
                ProductNumber =
                [
                    new LocaleTyped
                    {
                        Language = "en",
                        Text = "Product number"
                    }
                ],
                Name =
                [
                    new LocaleTyped
                    {
                        Language = "en",
                        Text = "Product name"
                    }
                ]
            },
            Variants =
            [
                new()
                {
                    Id = "variant-1",
                    Name =
                    [
                        new LocaleTyped {Language = "en", Text = "Variant 1"}
                    ],
                    Geometry = new GeometryTyped
                    {
                        EmitterOnly = new EmitterTyped
                        {
                            Id = "emitter",
                            ChangeableEmitterOptions =
                            [
                                new()
                                {
                                    Photometry = new PhotometryTyped
                                    {
                                        Id = "photometry",
                                        PhotometryFile = new GldfFileTyped
                                        {
                                            Id = "eulumdat",
                                            ContentType = FileContentType.LdcEulumdat,
                                            FileName = "eulumdat.ldt",
                                            Type = FileType.Url,
                                            Uri = "https://example.org/eulumdat.ldt"
                                        }
                                    }
                                }
                            ]
                        }
                    },
                    ProductNumber =
                    [
                        new()
                        {
                            Language = "en",
                            Text = "Product number"
                        }
                    ]
                }
            ]
        }
    };
}