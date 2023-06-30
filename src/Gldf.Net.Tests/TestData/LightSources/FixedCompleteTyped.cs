using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Product.Types;
using System;
using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Head.Types;
using Gldf.Net.Domain.Typed.Product;
using System.Collections.Generic;

namespace Gldf.Net.Tests.TestData.LightSources;

public static class FixedCompleteTyped
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
            FixedLightSources = new List<FixedLightSourceTyped>
            {
                new()
                {
                    Id = "fixedLightSource",
                    Name = new[]
                    {
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "Fixed lightsource"
                        },
                        new LocaleTyped
                        {
                            Language = "de",
                            Text = "Absolute Lichtquelle"
                        }
                    },
                    Description = new[]
                    {
                        new LocaleTyped
                        {
                            Language = "en",
                            Text = "Fixed lightsource description"
                        },
                        new LocaleTyped
                        {
                            Language = "de",
                            Text = "Absolute Lichtquelle Beschreibung"
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
                            FileName = "image.jpg",
                            ImageType = ImageType.ProductPicture,
                            Uri = "https://example.org/image.jpg",
                            Type = FileType.Url,
                            ContentType = FileContentType.ImageJpg
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
                    ZhagaStandard = true
                }
            },
            ControlGears = new List<ControlGearTyped>
            {
                new()
                {
                    Id = "controlGear",
                    Name = new LocaleTyped[]
                    {
                        new()
                        {
                            Language = "en",
                            Text = "ControlGear"
                        }
                    }
                }
            },
            Emitter = new List<EmitterTyped>
            {
                new()
                {
                    Id = "emitter-1",
                    FixedEmitterOptions = new[]
                    {
                        new FixedLightEmitterTyped
                        {
                            EmergencyBehaviour = EmergencyBehaviour.Combined,
                            Name = new[]
                            {
                                new LocaleTyped
                                {
                                    Language = "en",
                                    Text = "FixedLightEmitter"
                                }
                            },
                            Rotation = new RotationTyped
                            {
                                X = 1,
                                Y = 2,
                                Z = 3,
                                G0 = 4
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
                            FixedLightSource = new FixedLightSourceTyped
                            {
                                Id = "fixedLightSource",
                                Maintenance = new LightSourceMaintenanceTyped
                                {
                                    LedMaintenanceFactor = new LedMaintenanceFactorTyped
                                    {
                                        Factor = 0.11,
                                        Hours = 10
                                    },
                                    Lifetime = 9
                                },
                                ZhagaStandard = true,
                                Name = new LocaleTyped[]
                                {
                                    new()
                                    {
                                        Language = "en",
                                        Text = "Fixed lightsource"
                                    },
                                    new()
                                    {
                                        Language = "de",
                                        Text = "Absolute Lichtquelle"
                                    }
                                },
                                Description = new LocaleTyped[]
                                {
                                    new()
                                    {
                                        Language = "en",
                                        Text = "Fixed lightsource description"
                                    },
                                    new()
                                    {
                                        Language = "de",
                                        Text = "Absolute Lichtquelle Beschreibung"
                                    }
                                },
                                Manufacturer = "DIAL",
                                Gtin = "12345678",
                                RatedInputPower = 1,
                                RatedInputVoltage = new VoltageTyped
                                {
                                    FixedVoltage = 230,
                                    Frequency = VoltageFrequency.Hz50,
                                    Type = VoltageType.AC
                                },
                                PowerRange = new LightSourcePowerRangeTyped
                                {
                                    Default = 5,
                                    Lower = 3,
                                    Upper = 4
                                },
                                LightSourcePositionOfUsage = "LightSourcePositionOfUsage",
                                EnergyLabels = new EnergyLabelTyped[]
                                {
                                    new()
                                    {
                                        Label = "A+",
                                        Region = "de"
                                    },
                                    new()
                                    {
                                        Label = "A++",
                                        Region = "gb"
                                    }
                                },
                                Spectrum = new SpectrumTyped
                                {
                                    Id = "spectrum",
                                    SpectrumFile = new GldfFileTyped
                                    {
                                        Id = "spectrumFile",
                                        ContentType = FileContentType.SpectrumText,
                                        FileName = "spectrum.txt",
                                        Type = FileType.Url,
                                        Uri = "https://example.org/spectrum.txt"
                                    }
                                },
                                ActivePowerTable = new ActivePowerTableTyped
                                {
                                    Type = ActivePowerTableType.Continuously,
                                    FluxFactor = new FluxFactorTyped[]
                                    {
                                        new()
                                        {
                                            Description = "Description 1",
                                            Factor = 0.2,
                                            FlickerPstLm = "flicker 1",
                                            InputPower = 0.1,
                                            StroboscopicEffectsSvm = "stroboscopic 1"
                                        },
                                        new()
                                        {
                                            Description = "Description 2",
                                            Factor = 0.4,
                                            FlickerPstLm = "flicker 2",
                                            InputPower = 0.3,
                                            StroboscopicEffectsSvm = "stroboscopic 2"
                                        }
                                    }
                                },
                                ColorInformation = new ColorInformationTyped
                                {
                                    Cie1931ColorAppearance = new Cie1931ColorAppearanceTyped
                                    {
                                        X = 0.1,
                                        Y = 0.2,
                                        Z = 0.3
                                    },
                                    ColorRenderingIndex = 1,
                                    ColorTemperatureAdjustingRange = new ColorTemperatureAdjustingRangeTyped
                                    {
                                        Lower = 3,
                                        Upper = 4
                                    },
                                    CorrelatedColorTemperature = 2,
                                    IesTm3015 = new IesTm3015Typed
                                    {
                                        Rf = 6,
                                        Rg = 7
                                    },
                                    InitialColorTolerance = MacAdamEllipse.SDCM3,
                                    MaintainedColorTolerance = MacAdamEllipse.SDCM4,
                                    MelanopicFactor = 0.8,
                                    RatedChromacityCoordinateValues = new ChromacityCoordinateValuesTyped
                                    {
                                        X = 0.4,
                                        Y = 0.5
                                    },
                                    Tlci = 5
                                },
                                LightSourceImages = new ImageFileTyped[]
                                {
                                    new()
                                    {
                                        ContentType = FileContentType.ImageJpg,
                                        Type = FileType.Url,
                                        ImageType = ImageType.ProductPicture,
                                        FileName = "image.jpg",
                                        Uri = "https://example.org/image.jpg"
                                    }
                                }
                            },
                            ControlGear = new ControlGearTyped
                            {
                                Id = "controlGear",
                                Name = new LocaleTyped[]
                                {
                                    new()
                                    {
                                        Language = "en",
                                        Text = "ControlGear"
                                    }
                                }
                            },
                            ControlGearCount = 2,
                            RatedLuminousFlux = 250,
                            RatedLuminousFluxRGB = 251,
                            EmergencyBallastLumenFactor = 0.1
                        }
                    }
                },
                new()
                {
                    Id = "emitter-2",
                    FixedEmitterOptions = new[]
                    {
                        new FixedLightEmitterTyped
                        {
                            EmergencyBehaviour = EmergencyBehaviour.EmergencyOnly,
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
                                Id = "fixedLightSource",
                                Maintenance = new LightSourceMaintenanceTyped
                                {
                                    LedMaintenanceFactor = new LedMaintenanceFactorTyped
                                    {
                                        Factor = 0.11,
                                        Hours = 10
                                    },
                                    Lifetime = 9
                                },
                                ZhagaStandard = true,
                                Name = new LocaleTyped[]
                                {
                                    new()
                                    {
                                        Language = "en",
                                        Text = "Fixed lightsource"
                                    },
                                    new()
                                    {
                                        Language = "de",
                                        Text = "Absolute Lichtquelle"
                                    }
                                },
                                Description = new LocaleTyped[]
                                {
                                    new()
                                    {
                                        Language = "en",
                                        Text = "Fixed lightsource description"
                                    },
                                    new()
                                    {
                                        Language = "de",
                                        Text = "Absolute Lichtquelle Beschreibung"
                                    }
                                },
                                Manufacturer = "DIAL",
                                Gtin = "12345678",
                                RatedInputPower = 1,
                                RatedInputVoltage = new VoltageTyped
                                {
                                    FixedVoltage = 230,
                                    Frequency = VoltageFrequency.Hz50,
                                    Type = VoltageType.AC
                                },
                                PowerRange = new LightSourcePowerRangeTyped
                                {
                                    Default = 5,
                                    Lower = 3,
                                    Upper = 4
                                },
                                LightSourcePositionOfUsage = "LightSourcePositionOfUsage",
                                EnergyLabels = new EnergyLabelTyped[]
                                {
                                    new()
                                    {
                                        Label = "A+",
                                        Region = "de"
                                    },
                                    new()
                                    {
                                        Label = "A++",
                                        Region = "gb"
                                    }
                                },
                                Spectrum = new SpectrumTyped
                                {
                                    Id = "spectrum",
                                    SpectrumFile = new GldfFileTyped
                                    {
                                        Id = "spectrumFile",
                                        ContentType = FileContentType.SpectrumText,
                                        FileName = "spectrum.txt",
                                        Type = FileType.Url,
                                        Uri = "https://example.org/spectrum.txt"
                                    }
                                },
                                ActivePowerTable = new ActivePowerTableTyped
                                {
                                    Type = ActivePowerTableType.Continuously,
                                    FluxFactor = new FluxFactorTyped[]
                                    {
                                        new()
                                        {
                                            Description = "Description 1",
                                            Factor = 0.2,
                                            FlickerPstLm = "flicker 1",
                                            InputPower = 0.1,
                                            StroboscopicEffectsSvm = "stroboscopic 1"
                                        },
                                        new()
                                        {
                                            Description = "Description 2",
                                            Factor = 0.4,
                                            FlickerPstLm = "flicker 2",
                                            InputPower = 0.3,
                                            StroboscopicEffectsSvm = "stroboscopic 2"
                                        }
                                    }
                                },
                                ColorInformation = new ColorInformationTyped
                                {
                                    Cie1931ColorAppearance = new Cie1931ColorAppearanceTyped
                                    {
                                        X = 0.1,
                                        Y = 0.2,
                                        Z = 0.3
                                    },
                                    ColorRenderingIndex = 1,
                                    ColorTemperatureAdjustingRange = new ColorTemperatureAdjustingRangeTyped
                                    {
                                        Lower = 3,
                                        Upper = 4
                                    },
                                    CorrelatedColorTemperature = 2,
                                    IesTm3015 = new IesTm3015Typed
                                    {
                                        Rf = 6,
                                        Rg = 7
                                    },
                                    InitialColorTolerance = MacAdamEllipse.SDCM3,
                                    MaintainedColorTolerance = MacAdamEllipse.SDCM4,
                                    MelanopicFactor = 0.8,
                                    RatedChromacityCoordinateValues = new ChromacityCoordinateValuesTyped
                                    {
                                        X = 0.4,
                                        Y = 0.5
                                    },
                                    Tlci = 5
                                },
                                LightSourceImages = new ImageFileTyped[]
                                {
                                    new()
                                    {
                                        ContentType = FileContentType.ImageJpg,
                                        Type = FileType.Url,
                                        ImageType = ImageType.ProductPicture,
                                        FileName = "image.jpg",
                                        Uri = "https://example.org/image.jpg"
                                    }
                                }
                            },
                            RatedLuminousFlux = 250,
                            EmergencyRatedLuminousFlux = 240
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
                    Geometry = new GeometryTyped
                    {
                        EmitterOnly = new EmitterTyped
                        {
                            Id = "emitter-1",
                            FixedEmitterOptions = new FixedLightEmitterTyped[]
                            {
                                new()
                                {
                            EmergencyBehaviour = EmergencyBehaviour.Combined,
                            Name = new[]
                            {
                                new LocaleTyped
                                {
                                    Language = "en",
                                    Text = "FixedLightEmitter"
                                }
                            },
                            Rotation = new RotationTyped
                            {
                                X = 1,
                                Y = 2,
                                Z = 3,
                                G0 = 4
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
                            FixedLightSource = new FixedLightSourceTyped
                            {
                                Id = "fixedLightSource",
                                Maintenance = new LightSourceMaintenanceTyped
                                {
                                    LedMaintenanceFactor = new LedMaintenanceFactorTyped
                                    {
                                        Factor = 0.11,
                                        Hours = 10
                                    },
                                    Lifetime = 9
                                },
                                ZhagaStandard = true,
                                Name = new LocaleTyped[]
                                {
                                    new()
                                    {
                                        Language = "en",
                                        Text = "Fixed lightsource"
                                    },
                                    new()
                                    {
                                        Language = "de",
                                        Text = "Absolute Lichtquelle"
                                    }
                                },
                                Description = new LocaleTyped[]
                                {
                                    new()
                                    {
                                        Language = "en",
                                        Text = "Fixed lightsource description"
                                    },
                                    new()
                                    {
                                        Language = "de",
                                        Text = "Absolute Lichtquelle Beschreibung"
                                    }
                                },
                                Manufacturer = "DIAL",
                                Gtin = "12345678",
                                RatedInputPower = 1,
                                RatedInputVoltage = new VoltageTyped
                                {
                                    FixedVoltage = 230,
                                    Frequency = VoltageFrequency.Hz50,
                                    Type = VoltageType.AC
                                },
                                PowerRange = new LightSourcePowerRangeTyped
                                {
                                    Default = 5,
                                    Lower = 3,
                                    Upper = 4
                                },
                                LightSourcePositionOfUsage = "LightSourcePositionOfUsage",
                                EnergyLabels = new EnergyLabelTyped[]
                                {
                                    new()
                                    {
                                        Label = "A+",
                                        Region = "de"
                                    },
                                    new()
                                    {
                                        Label = "A++",
                                        Region = "gb"
                                    }
                                },
                                Spectrum = new SpectrumTyped
                                {
                                    Id = "spectrum",
                                    SpectrumFile = new GldfFileTyped
                                    {
                                        Id = "spectrumFile",
                                        ContentType = FileContentType.SpectrumText,
                                        FileName = "spectrum.txt",
                                        Type = FileType.Url,
                                        Uri = "https://example.org/spectrum.txt"
                                    }
                                },
                                ActivePowerTable = new ActivePowerTableTyped
                                {
                                    Type = ActivePowerTableType.Continuously,
                                    FluxFactor = new FluxFactorTyped[]
                                    {
                                        new()
                                        {
                                            Description = "Description 1",
                                            Factor = 0.2,
                                            FlickerPstLm = "flicker 1",
                                            InputPower = 0.1,
                                            StroboscopicEffectsSvm = "stroboscopic 1"
                                        },
                                        new()
                                        {
                                            Description = "Description 2",
                                            Factor = 0.4,
                                            FlickerPstLm = "flicker 2",
                                            InputPower = 0.3,
                                            StroboscopicEffectsSvm = "stroboscopic 2"
                                        }
                                    }
                                },
                                ColorInformation = new ColorInformationTyped
                                {
                                    Cie1931ColorAppearance = new Cie1931ColorAppearanceTyped
                                    {
                                        X = 0.1,
                                        Y = 0.2,
                                        Z = 0.3
                                    },
                                    ColorRenderingIndex = 1,
                                    ColorTemperatureAdjustingRange = new ColorTemperatureAdjustingRangeTyped
                                    {
                                        Lower = 3,
                                        Upper = 4
                                    },
                                    CorrelatedColorTemperature = 2,
                                    IesTm3015 = new IesTm3015Typed
                                    {
                                        Rf = 6,
                                        Rg = 7
                                    },
                                    InitialColorTolerance = MacAdamEllipse.SDCM3,
                                    MaintainedColorTolerance = MacAdamEllipse.SDCM4,
                                    MelanopicFactor = 0.8,
                                    RatedChromacityCoordinateValues = new ChromacityCoordinateValuesTyped
                                    {
                                        X = 0.4,
                                        Y = 0.5
                                    },
                                    Tlci = 5
                                },
                                LightSourceImages = new ImageFileTyped[]
                                {
                                    new()
                                    {
                                        ContentType = FileContentType.ImageJpg,
                                        Type = FileType.Url,
                                        ImageType = ImageType.ProductPicture,
                                        FileName = "image.jpg",
                                        Uri = "https://example.org/image.jpg"
                                    }
                                }
                            },
                            ControlGear = new ControlGearTyped
                            {
                                Id = "controlGear",
                                Name = new LocaleTyped[]
                                {
                                    new()
                                    {
                                        Language = "en",
                                        Text = "ControlGear"
                                    }
                                }
                            },
                            ControlGearCount = 2,
                            RatedLuminousFlux = 250,
                            RatedLuminousFluxRGB = 251,
                            EmergencyBallastLumenFactor = 0.1
                        }
                            }
                        }
                    },
                    ProductNumber = new LocaleTyped[]
                    {
                        new()
                        {
                            Language = "en",
                            Text = "Product number"
                        }
                    }
                }
            }
        }
    };
}