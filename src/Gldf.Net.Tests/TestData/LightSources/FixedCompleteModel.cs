﻿using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Domain.Xml.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.LightSources;

public static class FixedCompleteModel
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
                new FixedLightSource
                {
                    Id = "fixedLightSource",
                    Name = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "Fixed lightsource"
                        },
                        new Locale
                        {
                            Language = "de",
                            Text = "Absolute Lichtquelle"
                        }
                    },
                    Description = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "Fixed lightsource description"
                        },
                        new Locale
                        {
                            Language = "de",
                            Text = "Absolute Lichtquelle Beschreibung"
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
                    Maintenance = new LightSourceMaintenance
                    {
                        Lifetime = 9,
                        MaintenanceType = new LedMaintenanceFactor
                        {
                            Hours = 10,
                            Factor = 0.11
                        }
                    },
                    ZhagaStandard = true
                }
            },
            ControlGears = new []
            {
                new ControlGear
                {
                    Id = "controlGear",
                    Name = new Locale[]
                    {
                        new()
                        {
                            Language = "en",
                            Text = "ControlGear"
                        }
                    }
                }
            },
            Emitters = new[]
            {
                new Emitter
                {
                    Id = "emitter-1",
                    PossibleFittings = new EmitterBase[]
                    {
                        new FixedLightEmitter
                        {
                            EmergencyBehaviour = EmergencyBehaviour.Combined,
                            Name = new[]
                            {
                                new Locale
                                {
                                    Language = "en",
                                    Text = "FixedLightEmitter"
                                }
                            },
                            Rotation = new Rotation
                            {
                                X = 1,
                                Y = 2,
                                Z = 3,
                                G0 = 4
                            },
                            PhotometryReference = new PhotometryReference
                            {
                                PhotometryId = "photometry"
                            },
                            LightSourceReference = new FixedLightSourceReference
                            {
                                FixedLightSourceId = "fixedLightSource"
                            },
                            ControlGearReference = new ControlGearReference
                            {
                                ControlGearId = "controlGear",
                                ControlGearCount = 2
                            },
                            RatedLuminousFlux = 250,
                            RatedLuminousFluxRGB = 251,
                            EmergencyModeOutput = new EmergencyBallastLumenFactor
                            {
                                Factor = 0.1
                            }
                        }
                    }
                },
                new Emitter
                {
                    Id = "emitter-2",
                    PossibleFittings = new EmitterBase[]
                    {
                        new FixedLightEmitter
                        {
                            EmergencyBehaviour = EmergencyBehaviour.EmergencyOnly,
                            PhotometryReference = new PhotometryReference
                            {
                                PhotometryId = "photometry"
                            },
                            LightSourceReference = new FixedLightSourceReference
                            {
                                FixedLightSourceId = "fixedLightSource"
                            },
                            RatedLuminousFlux = 250,
                            EmergencyModeOutput = new EmergencyRatedLuminousFlux
                            {
                                Flux = 240
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
                            EmitterId = "emitter-1"
                        }
                    }
                }
            }
        }
    };
}