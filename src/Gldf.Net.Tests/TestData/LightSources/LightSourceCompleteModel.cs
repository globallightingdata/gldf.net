﻿using Gldf.Net.Domain;
using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
using Gldf.Net.Domain.Global;
using Gldf.Net.Domain.Head;
using Gldf.Net.Domain.Product;
using Gldf.Net.Domain.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.LightSources
{
    public class LightSourceCompleteModel
    {
        public static Root Root => new()
        {
            Header = new Header
            {
                Manufacturer = "DIAL",
                CreationTimeCode = new DateTime(2021, 3, 29, 16, 30, 0).ToUniversalTime(),
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
                LightSources = new[]
                {
                    new LightSource
                    {
                        Id = "lightSource-1",
                        LightSourceType = new FixedLightSource
                        {
                            ZhagaStandard = true
                        },
                        Maintenance = new LightSourceMaintenance
                        {
                            Content = new LedMaintenanceFactor
                            {
                                Hours = 1,
                                Factor = 0.1
                            }
                        }
                    },
                    new LightSource
                    {
                        Id = "lightSource-2",
                        LightSourceType = new ChangeableLightSource
                        {
                            RatedInputPower = 1,
                            RatedInputVoltage = new Voltage
                            {
                                Value = new VoltageRange
                                {
                                    Min = 0.3,
                                    Max = 0.4
                                },
                                Type = VoltageType.AC,
                                Frequency = VoltageFrequency.Hz50
                            },
                            RatedLuminousFlux = 2
                        },
                        Maintenance = new LightSourceMaintenance
                        {
                            Content = new Cie97LampType
                            {
                                Cie97LampTypeEnum = Cie97LampTypeEnum.Incandescent
                            }
                        }
                    },
                    new LightSource
                    {
                        Id = "lightSource-3",
                        Name = new[]
                        {
                            new Locale
                            {
                                Language = "en",
                                Text = "LightSource name"
                            }
                        },
                        Description = new[]
                        {
                            new Locale
                            {
                                Language = "en",
                                Text = "LightSource description"
                            }
                        },
                        LightSourceType = new ChangeableLightSource
                        {
                            Manufacturer = "MAnufacturer",
                            Gtin = "12345678",
                            Ilcos = "ILCOS",
                            Zvei = "ZVEI",
                            Socket = "Socket",
                            RatedInputPower = 1,
                            RatedInputVoltage = new Voltage
                            {
                                Value = new FixedVoltage {Value = 230},
                                Type = VoltageType.UC,
                                Frequency = VoltageFrequency.Hz5060
                            },
                            RatedLuminousFlux = 2,
                            PowerRange = new LightSourcePowerRange
                            {
                                Lower = 3,
                                Upper = 4,
                                Default = 5
                            },
                            LightSourcePositionOfUsage = "LightSourcePositionOfUsage",
                            EnergyLabels = new[]
                            {
                                new EnergyLabel {Region = "de", Label = "A+"},
                                new EnergyLabel {Region = "gb", Label = "A++"}
                            }
                        },
                        SpectrumReference = new SpectrumReference {SpectrumId = "spectrum"},
                        PhotometryReference = new PhotometryReference
                        {
                            PhotometryId = "photometry"
                        },
                        ActivePowerTable = new ActivePowerTable
                        {
                            Type = ActivePowerTableType.Continuously,
                            FluxFactor = new[]
                            {
                                new FluxFactor {InputPower = 0.1, Factor = 0.2, Description = "Description 1"},
                                new FluxFactor {InputPower = 0.3, Factor = 0.4, Description = "Description 2"}
                            }
                        },
                        Maintenance = new LightSourceMaintenance
                        {
                            Lifetime = 1,
                            LifetimeSpecified = true,
                            Content = new CieLampMaintenanceFactors
                            {
                                CieLampMaintenanceFactor = new[]
                                {
                                    new CieLampMaintenanceFactor
                                    {
                                        BurningTime = 2,
                                        LampLumenMaintenanceFactor = 0.1,
                                        LampSurvivalFactor = 0.2
                                    },
                                    new CieLampMaintenanceFactor
                                    {
                                        BurningTime = 3,
                                        LampLumenMaintenanceFactor = 0.3,
                                        LampSurvivalFactor = 0.4
                                    }
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
                        }
                    },
                    new LightSource
                    {
                        Id = "lightSource-4",
                        LightSourceType = new ChangeableLightSource
                        {
                            RatedInputPower = 1,
                            RatedInputVoltage = new Voltage
                            {
                                Value = new VoltageRange
                                {
                                    Min = 0.3,
                                    Max = 0.4
                                },
                                Type = VoltageType.DC,
                                Frequency = VoltageFrequency.Hz60
                            },
                            RatedLuminousFlux = 2
                        },
                        Maintenance = new LightSourceMaintenance
                        {
                            Content = new Cie97LampType
                            {
                                Cie97LampTypeEnum = Cie97LampTypeEnum.Halogen
                            }
                        },
                        LightSourceImages = new[]
                        {
                            new Image
                            {
                                FileId = "image",
                                ImageType = ImageType.ApplicationPicture
                            }
                        }
                    },
                    new LightSource
                    {
                        Id = "lightSource-5",
                        LightSourceType = new ChangeableLightSource
                        {
                            RatedInputPower = 1,
                            RatedInputVoltage = new Voltage
                            {
                                Value = new VoltageRange
                                {
                                    Min = 0.3,
                                    Max = 0.4
                                },
                                Type = VoltageType.DC,
                                Frequency = VoltageFrequency.Hz400
                            },
                            RatedLuminousFlux = 2
                        },
                        Maintenance = new LightSourceMaintenance
                        {
                            Content = new Cie97LampType
                            {
                                Cie97LampTypeEnum = Cie97LampTypeEnum.FlourescentTriphosphor
                            }
                        },
                        LightSourceImages = new[]
                        {
                            new Image
                            {
                                FileId = "image",
                                ImageType = ImageType.TechnicalSketch
                            }
                        }
                    },
                    new LightSource
                    {
                        Id = "lightSource-6",
                        LightSourceType = new FixedLightSource(),
                        Maintenance = new LightSourceMaintenance
                        {
                            Content = new Cie97LampType
                            {
                                Cie97LampTypeEnum = Cie97LampTypeEnum.FlourescentHalophosphate
                            }
                        },
                        LightSourceImages = new[]
                        {
                            new Image
                            {
                                FileId = "image",
                                ImageType = ImageType.Other
                            }
                        }
                    },
                    new LightSource
                    {
                        Id = "lightSource-7",
                        LightSourceType = new FixedLightSource(),
                        Maintenance = new LightSourceMaintenance
                        {
                            Content = new Cie97LampType
                            {
                                Cie97LampTypeEnum = Cie97LampTypeEnum.CompactFluorescent
                            }
                        }
                    },
                    new LightSource
                    {
                        Id = "lightSource-8",
                        LightSourceType = new FixedLightSource(),
                        Maintenance = new LightSourceMaintenance
                        {
                            Content = new Cie97LampType
                            {
                                Cie97LampTypeEnum = Cie97LampTypeEnum.Mercury
                            }
                        }
                    },
                    new LightSource
                    {
                        Id = "lightSource-9",
                        LightSourceType = new FixedLightSource(),
                        Maintenance = new LightSourceMaintenance
                        {
                            Content = new Cie97LampType
                            {
                                Cie97LampTypeEnum = Cie97LampTypeEnum.MetalHalide250400W
                            }
                        }
                    },
                    new LightSource
                    {
                        Id = "lightSource-10",
                        LightSourceType = new FixedLightSource(),
                        Maintenance = new LightSourceMaintenance
                        {
                            Content = new Cie97LampType
                            {
                                Cie97LampTypeEnum = Cie97LampTypeEnum.CeramicMetalHalide50150W
                            }
                        }
                    },
                    new LightSource
                    {
                        Id = "lightSource-11",
                        LightSourceType = new FixedLightSource(),
                        Maintenance = new LightSourceMaintenance
                        {
                            Content = new Cie97LampType
                            {
                                Cie97LampTypeEnum = Cie97LampTypeEnum.HighPressureSodium250400W
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
                    ProductName = new[]
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
                        EmitterReferences = new EmitterReferences
                        {
                            Reference = new LightEmitterReference
                            {
                                PhotometryId = "photometry"
                            }
                        }
                    }
                }
            }
        };
    }
}