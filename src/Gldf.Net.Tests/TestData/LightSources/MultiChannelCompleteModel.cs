using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Domain.Xml.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.LightSources;

public static class MultiChannelCompleteModel
{
    public static Root Root => new()
    {
        Header = new Header
        {
            Manufacturer = "DIAL",
            GldfCreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
            CreatedWithApplication = "Visual Studio Code",
            FormatVersion = new FormatVersion { Major = 1, Minor = 0, PreRelease = 3, PreReleaseSpecified = true },
            UniqueGldfId = "3BE556FF-9061-4592-AEB1-1BC9D507280E"
        },
        GeneralDefinitions = new GeneralDefinitions
        {
            Files = new[]
            {
                new GldfFile
                {
                    Id = "photometryRedFile",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    File = "https://example.org/photometryRed.ldt"
                },
                new GldfFile
                {
                    Id = "photometryGreenFile",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    File = "https://example.org/photometryGreen.ldt"
                },
                new GldfFile
                {
                    Id = "photometryBlueFile",
                    ContentType = FileContentType.LdcEulumdat,
                    Type = FileType.Url,
                    File = "https://example.org/photometryBlue.ldt"
                },
                new GldfFile
                {
                    Id = "lightSourceImage",
                    ContentType = FileContentType.ImageJpg,
                    Type = FileType.Url,
                    File = "https://example.org/image.jpg"
                }
            },
            Photometries = new[]
            {
                new Photometry
                {
                    Id = "photometryRed",
                    Content = new PhotometryFileReference
                    {
                        FileId = "photometryRedFile"
                    }
                },
                new Photometry
                {
                    Id = "photometryGreen",
                    Content = new PhotometryFileReference
                    {
                        FileId = "photometryGreenFile"
                    }
                },
                new Photometry
                {
                    Id = "photometryBlue",
                    Content = new PhotometryFileReference
                    {
                        FileId = "photometryBlueFile"
                    }
                }
            },
            Spectrums = new[]
            {
                new Spectrum
                {
                    Id = "spectrumRed",
                    Intensities = new[]
                    {
                        new SpectrumIntensity
                        {
                            Wavelength = 380,
                            Intensity = 0.7
                        }
                    }
                },
                new Spectrum
                {
                    Id = "spectrumGreen",
                    Intensities = new[]
                    {
                        new SpectrumIntensity
                        {
                            Wavelength = 380,
                            Intensity = 0.8
                        }
                    }
                },
                new Spectrum
                {
                    Id = "spectrumBlue",
                    Intensities = new[]
                    {
                        new SpectrumIntensity
                        {
                            Wavelength = 380,
                            Intensity = 0.9
                        }
                    }
                }
            },
            LightSources = new LightSourceBase[]
            {
                new MultiChannelLightSource
                {
                    Id = "multiChannelLightSource",
                    Name = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "RGB MultiChannel"
                        },
                        new Locale
                        {
                            Language = "de",
                            Text = "RGB Mehrkanal"
                        }
                    },
                    Description = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "MultiChannel description"
                        },
                        new Locale
                        {
                            Language = "de",
                            Text = "Mehrkanal Beschreibung"
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
                            FileId = "lightSourceImage",
                            ImageType = ImageType.TechnicalSketch
                        }
                    },
                    Channels = new[]
                    {
                        new Channel
                        {
                            Type = ChannelType.Red,
                            DisplayName = new Locale[]
                            {
                                new()
                                {
                                    Language = "en",
                                    Text = "Red"
                                }
                            },
                            SpectrumReference = new SpectrumReference
                            {
                                SpectrumId = "spectrumRed"
                            },
                            PhotometryReference = new PhotometryReference
                            {
                                PhotometryId = "photometryRed"
                            },
                            RatedLuminousFlux = 150,
                            ColorInformation = new ColorInformation
                            {
                                ColorRenderingIndex = 8,
                                CorrelatedColorTemperature = 9,
                                ColorTemperatureAdjustingRange = new ColorTemperatureAdjustingRange
                                {
                                    Lower = 10,
                                    Upper = 11
                                },
                                Cie1931ColorAppearance = new Cie1931ColorAppearance
                                {
                                    X = 0.12,
                                    Y = 0.13,
                                    Z = 0.14
                                },
                                InitialColorTolerance = MacAdamEllipse.SDCM5,
                                MaintainedColorTolerance = MacAdamEllipse.SDCM6,
                                RatedChromacityCoordinateValues = new ChromacityCoordinateValues
                                {
                                    X = 0.17,
                                    Y = 0.18
                                },
                                Tlci = 19,
                                IesTm3015 = new IesTm3015
                                {
                                    Rf = 20,
                                    Rg = 21
                                },
                                MelanopicFactor = 22.1
                            }
                        },
                        new Channel
                        {
                            Type = ChannelType.Green,
                            DisplayName = new Locale[]
                            {
                                new()
                                {
                                    Language = "en",
                                    Text = "Green"
                                }
                            },
                            SpectrumReference = new SpectrumReference
                            {
                                SpectrumId = "spectrumGreen"
                            },
                            PhotometryReference = new PhotometryReference
                            {
                                PhotometryId = "photometryGreen"
                            },
                            RatedLuminousFlux = 160,
                            ColorInformation = new ColorInformation()
                        },
                        new Channel
                        {
                            Type = ChannelType.Blue,
                            DisplayName = new Locale[]
                            {
                                new()
                                {
                                    Language = "en",
                                    Text = "Blue"
                                }
                            },
                            SpectrumReference = new SpectrumReference
                            {
                                SpectrumId = "spectrumBlue"
                            },
                            PhotometryReference = new PhotometryReference
                            {
                                PhotometryId = "photometryBlue"
                            },
                            RatedLuminousFlux = 170
                        }
                    },
                    Maintenance = new LightSourceMaintenance
                    {
                        Lifetime = 9,
                        MaintenanceType = new LedMaintenanceFactor
                        {
                            Hours = 10,
                            Factor = 0.11
                        }
                    },
                    EmergencyBallastLumenFactor = 0.7
                }
            },
            Emitters = new[]
            {
                new Emitter
                {
                    Id = "emitter",
                    PossibleFittings = new EmitterBase[]
                    {
                        new MultiChannelLightEmitter
                        {
                            LightSourceReference = new MultiChannelLightSourceReference
                            {
                                MultiChannelLightSourceId = "multiChannelLightSource"
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
                UniqueProductId = "Product 1",
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