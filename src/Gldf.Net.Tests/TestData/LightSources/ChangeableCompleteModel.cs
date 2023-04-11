using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Domain.Xml.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.LightSources;

public static class ChangeableCompleteModel
{
    public static Root Root => new()
    {
        Header = new Header
        {
            Manufacturer = "DIAL",
            GldfCreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
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
                    Id = "spectrumFile",
                    ContentType = FileContentType.SpectrumText,
                    Type = FileType.Url,
                    File = "https://example.org/spectrum.txt"
                },
                new GldfFile
                {
                    Id = "image",
                    ContentType = FileContentType.ImageJpg,
                    Type = FileType.Url,
                    File = "https://example.org/image.jpg"
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
            Spectrums = new[]
            {
                new Spectrum
                {
                    Id = "spectrum",
                    FileReference = new SpectrumFileReference
                    {
                        FileId = "spectrumFile"
                    }
                }
            },
            LightSources = new LightSourceBase[]
            {
                new ChangeableLightSource
                {
                    Id = "lightSource-1",
                    Name = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "LightSource1"
                        },
                        new Locale
                        {
                            Language = "de",
                            Text = "Lichtquelle1"
                        }
                    },
                    Description = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "Description"
                        },
                        new Locale
                        {
                            Language = "de",
                            Text = "Beschreibung"
                        }
                    },
                    Manufacturer = "DIAL",
                    Gtin = "12345678",
                    RatedInputPower = 1,
                    RatedInputVoltage = new Voltage
                    {
                        Value = new FixedVoltage
                        {
                            Value = 230
                        },
                        Type = VoltageType.AC,
                        Frequency = VoltageFrequency.Hz50
                    },
                    PowerRange = new LightSourcePowerRange
                    {
                        Lower = 3,
                        Upper = 4,
                        Default = 5
                    },
                    LightSourcePositionOfUsage = "LightSourcePositionOfUsage",
                    EnergyLabels = new[]
                    {
                        new EnergyLabel { Region = "de", Label = "A+" },
                        new EnergyLabel { Region = "gb", Label = "A++" }
                    },
                    SpectrumReference = new SpectrumReference { SpectrumId = "spectrum" },
                    ActivePowerTable = new ActivePowerTable
                    {
                        Type = ActivePowerTableType.Continuously,
                        FluxFactor = new[]
                        {
                            new FluxFactor
                            {
                                InputPower = 0.1,
                                Factor = 0.2,
                                FlickerPstLm = "flicker 1",
                                StroboscopicEffectsSvm = "stroboscopic 1",
                                Description = "Description 1"
                            },
                            new FluxFactor
                            {
                                InputPower = 0.3,
                                Factor = 0.4,
                                FlickerPstLm = "flicker 2",
                                StroboscopicEffectsSvm = "stroboscopic 2",
                                Description = "Description 2"
                            }
                        }
                    },
                    ColorInformation = new ColorInformation
                    {
                        ColorRenderingIndex = 1,
                        CorrelatedColorTemperature = 2,
                        ColorTemperatureAdjustingRange = new ColorTemperatureAdjustingRange
                        {
                            Lower = 3,
                            Upper = 4
                        },
                        Cie1931ColorAppearance = new Cie1931ColorAppearance
                        {
                            X = 0.1,
                            Y = 0.2,
                            Z = 0.3
                        },
                        InitialColorTolerance = MacAdamEllipse.SDCM3,
                        MaintainedColorTolerance = MacAdamEllipse.SDCM4,
                        RatedChromacityCoordinateValues = new ChromacityCoordinateValues
                        {
                            X = 0.4,
                            Y = 0.5
                        },
                        Tlci = 5,
                        IesTm3015 = new IesTm3015
                        {
                            Rf = 6,
                            Rg = 7
                        },
                        MelanopicFactor = 0.8
                    },
                    LightSourceImages = new[]
                    {
                        new Image
                        {
                            FileId = "image",
                            ImageType = ImageType.ProductPicture
                        }
                    },
                    Zvei = "ZVEI",
                    Socket = "Socket",
                    Ilcos = "ILCOS",
                    RatedLuminousFlux = 8,
                    RatedLuminousFluxRGB = 9,
                    PhotometryReference = new PhotometryReference
                    {
                        PhotometryId = "photometry"
                    },
                    Maintenance = new LightSourceMaintenance
                    {
                        MaintenanceType = new Cie97LampType
                        {
                            Cie97LampTypeEnum = Cie97LampTypeEnum.Mercury
                        }
                    }
                },
                new ChangeableLightSource
                {
                    Id = "lightSource-2",
                    Name = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "LightSource2"
                        }
                    },
                    RatedInputPower = 10,
                    RatedInputVoltage = new Voltage
                    {
                        Value = new VoltageRange
                        {
                            Min = 120,
                            Max = 130
                        },
                        Type = VoltageType.DC,
                        Frequency = VoltageFrequency.Hz60
                    },
                    RatedLuminousFlux = 11,
                    Maintenance = new LightSourceMaintenance
                    {
                        Lifetime = 12,
                        LifetimeSpecified = true,
                        MaintenanceType = new CieLampMaintenanceFactors
                        {
                            CieLampMaintenanceFactor = new[]
                            {
                                new CieLampMaintenanceFactor
                                {
                                    BurningTime = 13,
                                    LampLumenMaintenanceFactor = 0.14,
                                    LampSurvivalFactor = 0.15
                                },
                                new CieLampMaintenanceFactor
                                {
                                    BurningTime = 16,
                                    LampLumenMaintenanceFactor = 0.17,
                                    LampSurvivalFactor = 0.18
                                }
                            }
                        }
                    }
                },
                new ChangeableLightSource
                {
                    Id = "lightSource-3",
                    Name = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "LightSource3"
                        }
                    },
                    RatedInputPower = 19,
                    RatedInputVoltage = new Voltage
                    {
                        Value = new FixedVoltage
                        {
                            Value = 230
                        },
                        Type = VoltageType.UC,
                        Frequency = VoltageFrequency.Hz5060
                    },
                    RatedLuminousFlux = 20,
                    Maintenance = new LightSourceMaintenance
                    {
                        MaintenanceType = new LedMaintenanceFactor
                        {
                            Hours = 22,
                            Factor = 23.24
                        }
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
                    Geometry = new GeometryReference
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