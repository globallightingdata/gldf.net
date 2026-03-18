using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Head.Types;
using Gldf.Net.Domain.Typed.Product;
using Gldf.Net.Domain.Xml.Definition.Types;
using System;

namespace Gldf.Net.Tests.TestData.LightSources;

public static class LightSourceMandatoryTyped
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
                    FileName = "eulumdat.ldt",
                    Uri = "https://example.org/eulumdat.ldt"
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
                        FileName = "eulumdat.ldt",
                        Uri = "https://example.org/eulumdat.ldt"
                    }
                }
            ],
            Spectrums =
            [
                new()
                {
                    Id = "spectrum",
                    Intensities =
                    [
                        new SpectrumIntensityTyped
                        {
                            Wavelength = 380,
                            Intensity = 0.8
                        }
                    ]
                }
            ],
            FixedLightSources =
            [
                new()
                {
                    Id = "lightSource-1",
                    Name =
                    [
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "LightSource name"
                        }
                    ],
                    RatedInputPower = 50
                }
            ],
            ChangeableLightSources =
            [
                new()
                {
                    Id = "lightSource-2",
                    Name =
                    [
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "LightSource name 2"
                        }
                    ],
                    RatedInputPower = 60,
                    RatedLuminousFlux = 500,
                    ColorInformation = new ColorInformationTyped()
                }
            ],
            MultiChannelLightSources =
            [
                new()
                {
                    Id = "lightSource-3",
                    Name =
                    [
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "LightSource name 3"
                        }
                    ],
                    RatedInputPower = 30,
                    Channels =
                    [
                        new()
                        {
                            Type = ChannelType.WarmWhite,
                            DisplayName =
                            [
                                new()
                                {
                                    Language = "en",
                                    Text = "WarmWhite channel"
                                }
                            ],
                            Spectrum = new SpectrumTyped
                            {
                                Id = "spectrum",
                                Intensities =
                                [
                                    new SpectrumIntensityTyped
                                    {
                                        Wavelength = 380,
                                        Intensity = 0.8
                                    }
                                ]
                            },
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometry",
                                PhotometryFile = new GldfFileTyped
                                {
                                    Id = "eulumdat",
                                    ContentType = FileContentType.LdcEulumdat,
                                    Type = FileType.Url,
                                    FileName = "eulumdat.ldt",
                                    Uri = "https://example.org/eulumdat.ldt"
                                }
                            },
                            RatedLuminousFlux = 150
                        }
                    ]
                }
            ],
            Emitter =
            [
                new()
                {
                    Id = "emitter",
                    FixedEmitterOptions =
                    [
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
                                    FileName = "eulumdat.ldt",
                                    Uri = "https://example.org/eulumdat.ldt"
                                }
                            },
                            FixedLightSource = new FixedLightSourceTyped
                            {
                                Id = "lightSource-1",
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
                            RatedLuminousFlux = 250
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
                            FixedEmitterOptions =
                            [
                                new()
                                {
                                    FixedLightSource = new FixedLightSourceTyped
                                    {
                                        Id = "lightSource-1",
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
                                    Photometry = new PhotometryTyped
                                    {
                                        Id = "photometry",
                                        PhotometryFile = new GldfFileTyped
                                        {
                                            Id = "eulumdat",
                                            FileName = "eulumdat.ldt",
                                            Type = FileType.Url,
                                            Uri = "https://example.org/eulumdat.ldt"
                                        }
                                    },
                                    RatedLuminousFlux = 250
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