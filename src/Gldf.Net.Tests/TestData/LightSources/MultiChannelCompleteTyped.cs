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
using System.Collections.Generic;

namespace Gldf.Net.Tests.TestData.LightSources;

public static class MultiChannelCompleteTyped
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
            Files = new List<GldfFileTyped>
            {
                new()
                {
                    Id = "photometryRedFile",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    FileName = "photometryRed.ldt",
                    Uri = "https://example.org/photometryRed.ldt"
                },
                new()
                {
                    Id = "photometryGreenFile",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    FileName = "photometryGreen.ldt",
                    Uri = "https://example.org/photometryGreen.ldt"
                },
                new()
                {
                    Id = "photometryBlueFile",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    FileName = "photometryBlue.ldt",
                    Uri = "https://example.org/photometryBlue.ldt"
                },
                new()
                {
                    Id = "lightSourceImage",
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
                    Id = "photometryRed",
                    PhotometryFile = new GldfFileTyped
                    {
                        Id = "photometryRedFile",
                        ContentType = FileContentType.LdcEulumdat,
                        Type = FileType.Url,
                        FileName = "photometryRed.ldt",
                        Uri = "https://example.org/photometryRed.ldt"
                    }
                },
                new()
                {
                    Id = "photometryGreen",
                    PhotometryFile = new GldfFileTyped
                    {
                        Id = "photometryGreenFile",
                        ContentType = FileContentType.LdcEulumdat,
                        Type = FileType.Url,
                        FileName = "photometryGreen.ldt",
                        Uri = "https://example.org/photometryGreen.ldt"
                    }
                },
                new()
                {
                    Id = "photometryBlue",
                    PhotometryFile = new GldfFileTyped
                    {
                        Id = "photometryBlueFile",
                        ContentType = FileContentType.LdcEulumdat,
                        Type = FileType.Url,
                        FileName = "photometryBlue.ldt",
                        Uri = "https://example.org/photometryBlue.ldt"
                    }
                }
            },
            Spectrums = new List<SpectrumTyped>
            {
                new()
                {
                    Id = "spectrumRed",
                    Intensities = new SpectrumIntensityTyped[]
                    {
                        new()
                        {
                            Wavelength = 380,
                            Intensity = 0.7
                        }
                    }
                },
                new()
                {
                    Id = "spectrumGreen",
                    Intensities = new SpectrumIntensityTyped[]
                    {
                        new()
                        {
                            Wavelength = 380,
                            Intensity = 0.8
                        }
                    }
                },
                new()
                {
                    Id = "spectrumBlue",
                    Intensities = new SpectrumIntensityTyped[]
                    {
                        new()
                        {
                            Wavelength = 380,
                            Intensity = 0.9
                        }
                    }
                }
            },
            MultiChannelLightSources = new List<MultiChannelLightSourceTyped>
            {
                new()
                {
                    Id = "multiChannelLightSource",
                    Name = new LocaleTyped[]
                    {
                        new()
                        {
                            Language = "en",
                            Text = "RGB MultiChannel"
                        },
                        new()
                        {
                            Language = "de",
                            Text = "RGB Mehrkanal"
                        }
                    },
                    Description = new LocaleTyped[]
                    {
                        new()
                        {
                            Language = "en",
                            Text = "MultiChannel description"
                        },
                        new()
                        {
                            Language = "de",
                            Text = "Mehrkanal Beschreibung"
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
                    EnergyLabels = new EnergyLabelTyped[]
                    {
                        new() { Region = "de", Label = "A+" },
                        new() { Region = "gb", Label = "A++" }
                    },
                    ActivePowerTable = new ActivePowerTableTyped
                    {
                        Type = ActivePowerTableType.Continuously,
                        FluxFactor = new FluxFactorTyped[]
                        {
                            new()
                            {
                                InputPower = 0.1,
                                Factor = 0.2,
                                FlickerPstLm = "flicker 1",
                                StroboscopicEffectsSvm = "stroboscopic 1",
                                Description = "Description 1"
                            },
                            new()
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
                        MaintainedColorTolerance = MacAdamEllipse.SDCM4,
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
                            ImageType = ImageType.TechnicalSketch,
                            FileName = "image.jpg",
                            Uri = "https://example.org/image.jpg"
                        }
                    },
                    Channels = new ChannelTyped[]
                    {
                        new()
                        {
                            Type = ChannelType.Red,
                            DisplayName = new LocaleTyped[]
                            {
                                new()
                                {
                                    Language = "en",
                                    Text = "Red"
                                }
                            },
                            Spectrum = new SpectrumTyped
                            {
                                Id = "spectrumRed",
                                Intensities = new SpectrumIntensityTyped[]
                                {
                                    new()
                                    {
                                        Wavelength = 380,
                                        Intensity = 0.7
                                    }
                                }
                            },
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometryRed",
                                PhotometryFile = new GldfFileTyped
                                {
                                    Id = "photometryRedFile",
                                    ContentType = FileContentType.LdcEulumdat,
                                    Type = FileType.Url,
                                    FileName = "photometryRed.ldt",
                                    Uri = "https://example.org/photometryRed.ldt"
                                }
                            },
                            RatedLuminousFlux = 150,
                            ColorInformation = new ColorInformationTyped
                            {
                                ColorRenderingIndex = 8,
                                CorrelatedColorTemperature = 9,
                                ColorTemperatureAdjustingRange = new ColorTemperatureAdjustingRangeTyped
                                {
                                    Lower = 10,
                                    Upper = 11
                                },
                                Cie1931ColorAppearance = new Cie1931ColorAppearanceTyped
                                {
                                    X = 0.12,
                                    Y = 0.13,
                                    Z = 0.14
                                },
                                InitialColorTolerance = MacAdamEllipse.SDCM5,
                                MaintainedColorTolerance = MacAdamEllipse.SDCM6,
                                RatedChromacityCoordinateValues = new ChromacityCoordinateValuesTyped
                                {
                                    X = 0.17,
                                    Y = 0.18
                                },
                                Tlci = 19,
                                IesTm3015 = new IesTm3015Typed
                                {
                                    Rf = 20,
                                    Rg = 21
                                },
                                MelanopicFactor = 22.1
                            }
                        },
                        new()
                        {
                            Type = ChannelType.Green,
                            DisplayName = new LocaleTyped[]
                            {
                                new()
                                {
                                    Language = "en",
                                    Text = "Green"
                                }
                            },
                            Spectrum = new SpectrumTyped
                            {
                                Id = "spectrumGreen",
                                Intensities = new SpectrumIntensityTyped[]
                                {
                                    new()
                                    {
                                        Wavelength = 380,
                                        Intensity = 0.8
                                    }
                                }
                            },
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometryGreen",
                                PhotometryFile = new GldfFileTyped
                                {
                                    Id = "photometryGreenFile",
                                    ContentType = FileContentType.LdcEulumdat,
                                    Type = FileType.Url,
                                    FileName = "photometryGreen.ldt",
                                    Uri = "https://example.org/photometryGreen.ldt"
                                }
                            },
                            RatedLuminousFlux = 160,
                            ColorInformation = new ColorInformationTyped()
                        },
                        new()
                        {
                            Type = ChannelType.Blue,
                            DisplayName = new LocaleTyped[]
                            {
                                new()
                                {
                                    Language = "en",
                                    Text = "Blue"
                                }
                            },
                            Spectrum = new SpectrumTyped
                            {
                                Id = "spectrumBlue",
                                Intensities = new SpectrumIntensityTyped[]
                                {
                                    new()
                                    {
                                        Wavelength = 380,
                                        Intensity = 0.9
                                    }
                                }
                            },
                            Photometry = new PhotometryTyped
                            {
                                Id = "photometryBlue",
                                PhotometryFile = new GldfFileTyped
                                {
                                    Id = "photometryBlueFile",
                                    ContentType = FileContentType.LdcEulumdat,
                                    Type = FileType.Url,
                                    FileName = "photometryBlue.ldt",
                                    Uri = "https://example.org/photometryBlue.ldt"
                                }
                            },
                            RatedLuminousFlux = 170
                        }
                    },
                    Maintenance = new LightSourceMaintenanceTyped
                    {
                        Lifetime = 9,
                        LedMaintenanceFactor = new LedMaintenanceFactorTyped
                        {
                            Hours = 10,
                            Factor = 0.11
                        }
                    },
                    EmergencyBallastLumenFactor = 0.7
                }
            },
            Emitter = new List<EmitterTyped>
            {
                new()
                {
                    Id = "emitter",
                    MultiChannelEmitterOptions = new[]
                    {
                        new MultiChannelLightEmitterTyped
                        {
                            MultiChannelLightSource = new()
                            {
                                Id = "multiChannelLightSource",
                                Name = new LocaleTyped[]
                                {
                                    new()
                                    {
                                        Language = "en",
                                        Text = "RGB MultiChannel"
                                    },
                                    new()
                                    {
                                        Language = "de",
                                        Text = "RGB Mehrkanal"
                                    }
                                },
                                Description = new LocaleTyped[]
                                {
                                    new()
                                    {
                                        Language = "en",
                                        Text = "MultiChannel description"
                                    },
                                    new()
                                    {
                                        Language = "de",
                                        Text = "Mehrkanal Beschreibung"
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
                                EnergyLabels = new EnergyLabelTyped[]
                                {
                                    new() { Region = "de", Label = "A+" },
                                    new() { Region = "gb", Label = "A++" }
                                },
                                ActivePowerTable = new ActivePowerTableTyped
                                {
                                    Type = ActivePowerTableType.Continuously,
                                    FluxFactor = new FluxFactorTyped[]
                                    {
                                        new()
                                        {
                                            InputPower = 0.1,
                                            Factor = 0.2,
                                            FlickerPstLm = "flicker 1",
                                            StroboscopicEffectsSvm = "stroboscopic 1",
                                            Description = "Description 1"
                                        },
                                        new()
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
                                    MaintainedColorTolerance = MacAdamEllipse.SDCM4,
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
                                        ImageType = ImageType.TechnicalSketch,
                                        FileName = "image.jpg",
                                        Uri = "https://example.org/image.jpg"
                                    }
                                },
                                Channels = new ChannelTyped[]
                                {
                                    new()
                                    {
                                        Type = ChannelType.Red,
                                        DisplayName = new LocaleTyped[]
                                        {
                                            new()
                                            {
                                                Language = "en",
                                                Text = "Red"
                                            }
                                        },
                                        Spectrum = new SpectrumTyped
                                        {
                                            Id = "spectrumRed",
                                            Intensities = new SpectrumIntensityTyped[]
                                            {
                                                new()
                                                {
                                                    Wavelength = 380,
                                                    Intensity = 0.7
                                                }
                                            }
                                        },
                                        Photometry = new PhotometryTyped
                                        {
                                            Id = "photometryRed",
                                            PhotometryFile = new GldfFileTyped
                                            {
                                                Id = "photometryRedFile",
                                                ContentType = FileContentType.LdcEulumdat,
                                                Type = FileType.Url,
                                                FileName = "photometryRed.ldt",
                                                Uri = "https://example.org/photometryRed.ldt"
                                            }
                                        },
                                        RatedLuminousFlux = 150,
                                        ColorInformation = new ColorInformationTyped
                                        {
                                            ColorRenderingIndex = 8,
                                            CorrelatedColorTemperature = 9,
                                            ColorTemperatureAdjustingRange = new ColorTemperatureAdjustingRangeTyped
                                            {
                                                Lower = 10,
                                                Upper = 11
                                            },
                                            Cie1931ColorAppearance = new Cie1931ColorAppearanceTyped
                                            {
                                                X = 0.12,
                                                Y = 0.13,
                                                Z = 0.14
                                            },
                                            InitialColorTolerance = MacAdamEllipse.SDCM5,
                                            MaintainedColorTolerance = MacAdamEllipse.SDCM6,
                                            RatedChromacityCoordinateValues = new ChromacityCoordinateValuesTyped
                                            {
                                                X = 0.17,
                                                Y = 0.18
                                            },
                                            Tlci = 19,
                                            IesTm3015 = new IesTm3015Typed
                                            {
                                                Rf = 20,
                                                Rg = 21
                                            },
                                            MelanopicFactor = 22.1
                                        }
                                    },
                                    new()
                                    {
                                        Type = ChannelType.Green,
                                        DisplayName = new LocaleTyped[]
                                        {
                                            new()
                                            {
                                                Language = "en",
                                                Text = "Green"
                                            }
                                        },
                                        Spectrum = new SpectrumTyped
                                        {
                                            Id = "spectrumGreen",
                                            Intensities = new SpectrumIntensityTyped[]
                                            {
                                                new()
                                                {
                                                    Wavelength = 380,
                                                    Intensity = 0.8
                                                }
                                            }
                                        },
                                        Photometry = new PhotometryTyped
                                        {
                                            Id = "photometryGreen",
                                            PhotometryFile = new GldfFileTyped
                                            {
                                                Id = "photometryGreenFile",
                                                ContentType = FileContentType.LdcEulumdat,
                                                Type = FileType.Url,
                                                FileName = "photometryGreen.ldt",
                                                Uri = "https://example.org/photometryGreen.ldt"
                                            }
                                        },
                                        RatedLuminousFlux = 160,
                                        ColorInformation = new ColorInformationTyped()
                                    },
                                    new()
                                    {
                                        Type = ChannelType.Blue,
                                        DisplayName = new LocaleTyped[]
                                        {
                                            new()
                                            {
                                                Language = "en",
                                                Text = "Blue"
                                            }
                                        },
                                        Spectrum = new SpectrumTyped
                                        {
                                            Id = "spectrumBlue",
                                            Intensities = new SpectrumIntensityTyped[]
                                            {
                                                new()
                                                {
                                                    Wavelength = 380,
                                                    Intensity = 0.9
                                                }
                                            }
                                        },
                                        Photometry = new PhotometryTyped
                                        {
                                            Id = "photometryBlue",
                                            PhotometryFile = new GldfFileTyped
                                            {
                                                Id = "photometryBlueFile",
                                                ContentType = FileContentType.LdcEulumdat,
                                                Type = FileType.Url,
                                                FileName = "photometryBlue.ldt",
                                                Uri = "https://example.org/photometryBlue.ldt"
                                            }
                                        },
                                        RatedLuminousFlux = 170
                                    }
                                },
                                Maintenance = new LightSourceMaintenanceTyped
                                {
                                    Lifetime = 9,
                                    LedMaintenanceFactor = new LedMaintenanceFactorTyped
                                    {
                                        Hours = 10,
                                        Factor = 0.11
                                    }
                                },
                                EmergencyBallastLumenFactor = 0.7
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
                ProductNumber = new LocaleTyped[]
                {
                    new()
                    {
                        Language = "en",
                        Text = "Product number"
                    }
                },
                Name = new LocaleTyped[]
                {
                    new()
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
                    Name = new LocaleTyped[]
                    {
                        new() { Language = "en", Text = "Variant 1" }
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
                            MultiChannelEmitterOptions = new MultiChannelLightEmitterTyped[]
                            {
                                new()
                                {
                                    MultiChannelLightSource = new MultiChannelLightSourceTyped
                                    {
                                        Id = "multiChannelLightSource",
                                        Name = new LocaleTyped[]
                                        {
                                            new()
                                            {
                                                Language = "en",
                                                Text = "RGB MultiChannel"
                                            },
                                            new()
                                            {
                                                Language = "de",
                                                Text = "RGB Mehrkanal"
                                            }
                                        },
                                        Description = new LocaleTyped[]
                                        {
                                            new()
                                            {
                                                Language = "en",
                                                Text = "MultiChannel description"
                                            },
                                            new()
                                            {
                                                Language = "de",
                                                Text = "Mehrkanal Beschreibung"
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
                                        EnergyLabels = new EnergyLabelTyped[]
                                        {
                                            new() { Region = "de", Label = "A+" },
                                            new() { Region = "gb", Label = "A++" }
                                        },
                                        ActivePowerTable = new ActivePowerTableTyped
                                        {
                                            Type = ActivePowerTableType.Continuously,
                                            FluxFactor = new FluxFactorTyped[]
                                            {
                                                new()
                                                {
                                                    InputPower = 0.1,
                                                    Factor = 0.2,
                                                    FlickerPstLm = "flicker 1",
                                                    StroboscopicEffectsSvm = "stroboscopic 1",
                                                    Description = "Description 1"
                                                },
                                                new()
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
                                            MaintainedColorTolerance = MacAdamEllipse.SDCM4,
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
                                                ImageType = ImageType.TechnicalSketch,
                                                FileName = "image.jpg",
                                                Uri = "https://example.org/image.jpg"
                                            }
                                        },
                                        Channels = new ChannelTyped[]
                                        {
                                            new()
                                            {
                                                Type = ChannelType.Red,
                                                DisplayName = new LocaleTyped[]
                                                {
                                                    new()
                                                    {
                                                        Language = "en",
                                                        Text = "Red"
                                                    }
                                                },
                                                Spectrum = new SpectrumTyped
                                                {
                                                    Id = "spectrumRed",
                                                    Intensities = new SpectrumIntensityTyped[]
                                                    {
                                                        new()
                                                        {
                                                            Wavelength = 380,
                                                            Intensity = 0.7
                                                        }
                                                    }
                                                },
                                                Photometry = new PhotometryTyped
                                                {
                                                    Id = "photometryRed",
                                                    PhotometryFile = new GldfFileTyped
                                                    {
                                                        Id = "photometryRedFile",
                                                        ContentType = FileContentType.LdcEulumdat,
                                                        Type = FileType.Url,
                                                        FileName = "photometryRed.ldt",
                                                        Uri = "https://example.org/photometryRed.ldt"
                                                    }
                                                },
                                                RatedLuminousFlux = 150,
                                                ColorInformation = new ColorInformationTyped
                                                {
                                                    ColorRenderingIndex = 8,
                                                    CorrelatedColorTemperature = 9,
                                                    ColorTemperatureAdjustingRange = new ColorTemperatureAdjustingRangeTyped
                                                    {
                                                        Lower = 10,
                                                        Upper = 11
                                                    },
                                                    Cie1931ColorAppearance = new Cie1931ColorAppearanceTyped
                                                    {
                                                        X = 0.12,
                                                        Y = 0.13,
                                                        Z = 0.14
                                                    },
                                                    InitialColorTolerance = MacAdamEllipse.SDCM5,
                                                    MaintainedColorTolerance = MacAdamEllipse.SDCM6,
                                                    RatedChromacityCoordinateValues = new ChromacityCoordinateValuesTyped
                                                    {
                                                        X = 0.17,
                                                        Y = 0.18
                                                    },
                                                    Tlci = 19,
                                                    IesTm3015 = new IesTm3015Typed
                                                    {
                                                        Rf = 20,
                                                        Rg = 21
                                                    },
                                                    MelanopicFactor = 22.1
                                                }
                                            },
                                            new()
                                            {
                                                Type = ChannelType.Green,
                                                DisplayName = new LocaleTyped[]
                                                {
                                                    new()
                                                    {
                                                        Language = "en",
                                                        Text = "Green"
                                                    }
                                                },
                                                Spectrum = new SpectrumTyped
                                                {
                                                    Id = "spectrumGreen",
                                                    Intensities = new SpectrumIntensityTyped[]
                                                    {
                                                        new()
                                                        {
                                                            Wavelength = 380,
                                                            Intensity = 0.8
                                                        }
                                                    }
                                                },
                                                Photometry = new PhotometryTyped
                                                {
                                                    Id = "photometryGreen",
                                                    PhotometryFile = new GldfFileTyped
                                                    {
                                                        Id = "photometryGreenFile",
                                                        ContentType = FileContentType.LdcEulumdat,
                                                        Type = FileType.Url,
                                                        FileName = "photometryGreen.ldt",
                                                        Uri = "https://example.org/photometryGreen.ldt"
                                                    }
                                                },
                                                RatedLuminousFlux = 160,
                                                ColorInformation = new ColorInformationTyped()
                                            },
                                            new()
                                            {
                                                Type = ChannelType.Blue,
                                                DisplayName = new LocaleTyped[]
                                                {
                                                    new()
                                                    {
                                                        Language = "en",
                                                        Text = "Blue"
                                                    }
                                                },
                                                Spectrum = new SpectrumTyped
                                                {
                                                    Id = "spectrumBlue",
                                                    Intensities = new SpectrumIntensityTyped[]
                                                    {
                                                        new()
                                                        {
                                                            Wavelength = 380,
                                                            Intensity = 0.9
                                                        }
                                                    }
                                                },
                                                Photometry = new PhotometryTyped
                                                {
                                                    Id = "photometryBlue",
                                                    PhotometryFile = new GldfFileTyped
                                                    {
                                                        Id = "photometryBlueFile",
                                                        ContentType = FileContentType.LdcEulumdat,
                                                        Type = FileType.Url,
                                                        FileName = "photometryBlue.ldt",
                                                        Uri = "https://example.org/photometryBlue.ldt"
                                                    }
                                                },
                                                RatedLuminousFlux = 170
                                            }
                                        },
                                        Maintenance = new LightSourceMaintenanceTyped
                                        {
                                            Lifetime = 9,
                                            LedMaintenanceFactor = new LedMaintenanceFactorTyped
                                            {
                                                Hours = 10,
                                                Factor = 0.11
                                            }
                                        },
                                        EmergencyBallastLumenFactor = 0.7
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