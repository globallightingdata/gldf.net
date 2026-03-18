using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Xml.Definition.Types;
using System;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Head.Types;
using Gldf.Net.Domain.Typed.Product;

namespace Gldf.Net.Tests.TestData.Equipments;

public static class EquipmentCompleteTyped
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
            ChangeableLightSources =
            [
                new()
                {
                    Id = "lightSource",
                    Name =
                    [
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "LightSource name"
                        }
                    ],
                    RatedInputPower = 50,
                    RatedLuminousFlux = 250
                }
            ],
            ControlGears =
            [
                new()
                {
                    Id = "controlGear",
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
                    ]
                }
            ],
            Equipments =
            [
                new()
                {
                    Id = "equipment-1",
                    ChangeableLightSource = new ChangeableLightSourceTyped
                    {
                        Id = "lightSource",
                        RatedLuminousFlux = 250,
                        Name =
                        [
                            new()
                            {
                                Language = "en",
                                Text = "LightSource name"
                            }
                        ],
                        RatedInputPower = 50
                    },
                    ControlGear = new ControlGearTyped
                    {
                        Id = "controlGear",
                        Name =
                        [
                            new()
                            {
                                Language = "en",
                                Text = "ControlGear name"
                            }
                        ],
                        Description =
                        [
                            new()
                            {
                                Language = "en",
                                Text = "ControlGear description"
                            }
                        ]
                    },
                    ControlGearCount = 2,
                    RatedInputPower = 0.1,
                    EmergencyBallastLumenFactor = 0.2
                },

                new()
                {
                    Id = "equipment-2",
                    ChangeableLightSource = new ChangeableLightSourceTyped
                    {
                        Id = "lightSource",
                        RatedLuminousFlux = 250,
                        RatedInputPower = 50,
                        Name =
                        [
                            new()
                            {
                                Language = "en",
                                Text = "LightSource name"
                            }
                        ]
                    },
                    ControlGear = new ControlGearTyped
                    {
                        Id = "controlGear",
                        Name =
                        [
                            new()
                            {
                                Language = "en",
                                Text = "ControlGear name"
                            }
                        ],
                        Description =
                        [
                            new()
                            {
                                Language = "en",
                                Text = "ControlGear description"
                            }
                        ]
                    },
                    RatedInputPower = 0.1,
                    EmergencyRatedLuminousFlux = 2
                }
            ],
            Emitter =
            [
                new()
                {
                    Id = "emitter-1",
                    ChangeableEmitterOptions =
                    [
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
                            },
                            Equipment = new EquipmentTyped
                            {
                                Id = "equipment-1",
                                ChangeableLightSource = new ChangeableLightSourceTyped
                                {
                                    Id = "lightSource",
                                    RatedLuminousFlux = 250,
                                    Name =
                                    [
                                        new()
                                        {
                                            Language = "en",
                                            Text = "LightSource name"
                                        }
                                    ],
                                    RatedInputPower = 50
                                },
                                ControlGear = new ControlGearTyped
                                {
                                    Id = "controlGear",
                                    Name =
                                    [
                                        new()
                                        {
                                            Language = "en",
                                            Text = "ControlGear name"
                                        }
                                    ],
                                    Description =
                                    [
                                        new()
                                        {
                                            Language = "en",
                                            Text = "ControlGear description"
                                        }
                                    ]
                                },
                                ControlGearCount = 2,
                                RatedInputPower = 0.1,
                                EmergencyBallastLumenFactor = 0.2
                            }
                        }
                    ]
                },

                new()
                {
                    Id = "emitter-2",
                    ChangeableEmitterOptions =
                    [
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
                            },
                            Equipment = new EquipmentTyped
                            {
                                Id = "equipment-2",
                                ChangeableLightSource = new ChangeableLightSourceTyped
                                {
                                    Id = "lightSource",
                                    RatedLuminousFlux = 250,
                                    RatedInputPower = 50,
                                    Name =
                                    [
                                        new()
                                        {
                                            Language = "en",
                                            Text = "LightSource name"
                                        }
                                    ]
                                },
                                ControlGear = new ControlGearTyped
                                {
                                    Id = "controlGear",
                                    Name =
                                    [
                                        new()
                                        {
                                            Language = "en",
                                            Text = "ControlGear name"
                                        }
                                    ],
                                    Description =
                                    [
                                        new()
                                        {
                                            Language = "en",
                                            Text = "ControlGear description"
                                        }
                                    ]
                                },
                                RatedInputPower = 0.1,
                                EmergencyRatedLuminousFlux = 2
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
                    ProductNumber =
                    [
                        new()
                        {
                            Language = "en",
                            Text = "Product number"
                        }
                    ],
                    Geometry = new GeometryTyped
                    {
                        EmitterOnly = new EmitterTyped
                        {
                            Id = "emitter-1",
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
                                    },
                                    Equipment = new EquipmentTyped
                                    {
                                        Id = "equipment-1",
                                        ChangeableLightSource = new ChangeableLightSourceTyped
                                        {
                                            Id = "lightSource",
                                            Name =
                                            [
                                                new()
                                                {
                                                    Language = "en",
                                                    Text = "LightSource name"
                                                }
                                            ],
                                            RatedLuminousFlux = 250,
                                            RatedInputPower = 50
                                        },
                                        ControlGear = new ControlGearTyped
                                        {
                                            Id = "controlGear",
                                            Name =
                                            [
                                                new()
                                                {
                                                    Language = "en",
                                                    Text = "ControlGear name"
                                                }
                                            ],
                                            Description =
                                            [
                                                new()
                                                {
                                                    Language = "en",
                                                    Text = "ControlGear description"
                                                }
                                            ]
                                        },
                                        ControlGearCount = 2,
                                        RatedInputPower = 0.1,
                                        EmergencyBallastLumenFactor = 0.2
                                    }
                                }
                            ]
                        }
                    }
                }
            ]
        }
    };
}