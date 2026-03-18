using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Head.Types;
using Gldf.Net.Domain.Typed.Product;
using Gldf.Net.Domain.Xml.Definition.Types;
using System;

namespace Gldf.Net.Tests.TestData.Spectrums;

public static class SpectrumCompleteTyped
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
                },

                new()
                {
                    Id = "spectrumFile",
                    ContentType = FileContentType.SpectrumText,
                    Type = FileType.Url,
                    FileName = "spectrum.txt",
                    Uri = "https://example.org/spectrum.txt"
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
                    Id = "spectrum-1",
                    SpectrumFile = new GldfFileTyped
                    {
                        Id = "spectrumFile",
                        ContentType = FileContentType.SpectrumText,
                        FileName = "spectrum.txt",
                        Type = FileType.Url,
                        Uri = "https://example.org/spectrum.txt"
                    }
                },

                new()
                {
                    Id = "spectrum-2",
                    Intensities =
                    [
                        new SpectrumIntensityTyped
                        {
                            Wavelength = 380,
                            Intensity = 0.1
                        },
                        new SpectrumIntensityTyped
                        {
                            Wavelength = 385,
                            Intensity = 0.2
                        },
                        new SpectrumIntensityTyped
                        {
                            Wavelength = 390,
                            Intensity = 0.3
                        }
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
                                    FileName = "eulumdat.ldt",
                                    Uri = "https://example.org/eulumdat.ldt"
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
                            Text = "Variant 1"
                        }
                    ],
                    Geometry = new GeometryTyped
                    {
                        EmitterOnly = new EmitterTyped
                        {
                            Id = "emitter",
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
                                            FileName = "eulumdat.ldt",
                                            Uri = "https://example.org/eulumdat.ldt"
                                        }
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