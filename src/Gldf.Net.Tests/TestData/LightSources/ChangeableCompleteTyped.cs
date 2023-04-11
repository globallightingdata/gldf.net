using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using System;
using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Head.Types;
using System.Collections.Generic;

namespace Gldf.Net.Tests.TestData.LightSources;

public static class ChangeableCompleteTyped
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
                },
                new()
                {
                    Id = "image",
                    ContentType = FileContentType.ImageJpg,
                    Type = FileType.Url,
                    FileName = "image.jpg",
                    Uri = "https://example.org/image.jpg"
                }
            },
            Photometries = new List<PhotometryTyped>
            {
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
            },
            Spectrums = new List<SpectrumTyped>
            {
                new()
                {
                    Id = "spectrum",
                    SpectrumFile = new GldfFileTyped
                    {
                        Id = "spectrumFile",
                        ContentType = FileContentType.SpectrumText,
                        Type = FileType.Url,
                        FileName = "spectrum.txt",
                        Uri = "https://example.org/spectrum.txt"
                    }
                }
            },
            ChangeableLightSources = new List<ChangeableLightSourceTyped>
            {
                new()
                {
                    Id = "lightSource-1",
                    Name = new[]
                    {
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "LightSource1"
                        },
                        new LocaleTyped
                        {
                            Language = "de",
                            Text = "Lichtquelle1"
                        }
                    },
                    Description = new[]
                    {
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "Description"
                        },
                        new LocaleTyped
                        {
                            Language = "de",
                            Text = "Beschreibung"
                        }
                    },
                    Manufacturer = "DIAL",
                    Gtin = "12345678",
                    RatedInputPower = 1,
                    RatedInputVoltage = new VoltageTyped
                    {
                        FixedVoltage = 230,
                        Type = VoltageType.AC,
                        Frequency = VoltageFrequency.Hz50
                    },
                    PowerRange = new LightSourcePowerRangeTyped
                    {
                        Lower = 3,
                        Upper = 4,
                        Default = 5
                    },
                    LightSourcePositionOfUsage = "LightSourcePositionOfUsage",
                    EnergyLabels = new[]
                    {
                        new EnergyLabelTyped { Region = "de", Label = "A+" },
                        new EnergyLabelTyped { Region = "gb", Label = "A++" }
                    },
                    Spectrum = new SpectrumTyped
                    {
                        Id = "spectrum",
                        SpectrumFile = new GldfFileTyped
                        {
                            Id = "spectrumFile",
                            ContentType = FileContentType.SpectrumText,
                            Type = FileType.Url,
                            FileName = "spectrum.txt",
                            Uri = "https://example.org/spectrum.txt"
                        }
                    },
                    ActivePowerTable = new ActivePowerTableTyped
                    {
                        Type = ActivePowerTableType.Continuously,
                        FluxFactor = new[]
                        {
                            new FluxFactorTyped
                            {
                                InputPower = 0.1,
                                Factor = 0.2,
                                FlickerPstLm = "flicker 1",
                                StroboscopicEffectsSvm = "stroboscopic 1",
                                Description = "Description 1"
                            },
                            new FluxFactorTyped
                            {
                                InputPower = 0.3,
                                Factor = 0.4,
                                FlickerPstLm = "flicker 2",
                                StroboscopicEffectsSvm = "stroboscopic 2",
                                Description = "Description 2"
                            }
                        }
                    },
                    ColorInformation = new ColorInformationTyped
                    {
                        ColorRenderingIndex = 1,
                        CorrelatedColorTemperature = 2,
                        ColorTemperatureAdjustingRange = new ColorTemperatureAdjustingRangeTyped
                        {
                            Lower = 3,
                            Upper = 4
                        },
                        Cie1931ColorAppearance = new Cie1931ColorAppearanceTyped
                        {
                            X = 0.1,
                            Y = 0.2,
                            Z = 0.3
                        },
                        InitialColorTolerance = MacAdamEllipse.SDCM3,
                        MaintainedColorTolerance = MacAdamEllipse.SDCM3,
                        RatedChromacityCoordinateValues = new ChromacityCoordinateValuesTyped
                        {
                            X = 0.4,
                            Y = 0.5
                        },
                        Tlci = 5,
                        IesTm3015 = new IesTm3015Typed
                        {
                            Rf = 6,
                            Rg = 7
                        },
                        MelanopicFactor = 0.8
                    },
                    LightSourceImages = new[]
                    {
                        new ImageFileTyped
                        {
                            ContentType = FileContentType.ImageJpg,
                            Type = FileType.Url,
                            FileName = "image.jpg",
                            ImageType = ImageType.ProductPicture,
                            Uri = "https://example.org/image.jpg"
                        }
                    },
                    Zvei = "ZVEI",
                    Socket = "Socket",
                    Ilcos = "ILCOS",
                    RatedLuminousFlux = 8,
                    RatedLuminousFluxRGB = 9,
                    Photometry = new PhotometryTyped
                    {
                        PhotometryFile = new GldfFileTyped
                        {
                            Id = "eulumdat",
                            ContentType = FileContentType.LdcEulumdat,
                            Type = FileType.Url,
                            FileName = "eulumdat.ldt",
                            Uri = "https://example.org/eulumdat.ldt"
                        }
                    },
                    Maintenance = new LightSourceMaintenanceTyped
                    {
                        Cie97LampType = new Cie97LampTypeTyped
                        {
                            Cie97LampTypeEnum = Cie97LampTypeEnum.Mercury
                        }
                    }
                },
                new()
                {
                    Id = "lightSource-2",
                    Name = new[]
                    {
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "LightSource2"
                        }
                    },
                    RatedInputPower = 10,
                    RatedInputVoltage = new VoltageTyped
                    {
                        VoltageRangeMin = 120,
                        VoltageRangeMax = 130,
                        Type = VoltageType.DC,
                        Frequency = VoltageFrequency.Hz60
                    },
                    RatedLuminousFlux = 11,
                    Maintenance = new LightSourceMaintenanceTyped
                    {
                        Lifetime = 12,
                        CieLampMaintenanceFactor = new[]
                        {
                            new CieLampMaintenanceFactorTyped
                            {
                                BurningTime = 13,
                                LampLumenMaintenanceFactor = 0.14,
                                LampSurvivalFactor = 0.15
                            },
                            new CieLampMaintenanceFactorTyped
                            {
                                BurningTime = 16,
                                LampLumenMaintenanceFactor = 0.17,
                                LampSurvivalFactor = 0.18
                            }
                        }
                    }
                },
                new()
                {
                    Id = "lightSource-3",
                    Name = new[]
                    {
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "LightSource3"
                        }
                    },
                    RatedInputPower = 19,
                    RatedInputVoltage = new VoltageTyped
                    {
                        FixedVoltage = 230,
                        Type = VoltageType.UC,
                        Frequency = VoltageFrequency.Hz5060
                    },
                    RatedLuminousFlux = 20,
                    Maintenance = new LightSourceMaintenanceTyped
                    {
                        LedMaintenanceFactor = new LedMaintenanceFactorTyped
                        {
                            Hours = 22,
                            Factor = 23.24
                        }
                    }
                }
            },
            Emitter = new List<EmitterTyped>
            {
                new()
                {
                    Id = "emitter",
                    ChangeableEmitterOptions = new[]
                    {
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
                    ProductNumber = new LocaleTyped[]
                    {
                        new()
                        {
                            Language = "en",
                            Text = "Product number"
                        }
                    },
                    Geometry = new GeometryTyped
                    {
                        EmitterOnly = new EmitterTyped
                        {
                            Id = "emitter",
                            ChangeableEmitterOptions = new ChangeableLightEmitterTyped[]
                            {
                                new()
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
                            }
                        }
                    }
                }
            }
        }
    };
}