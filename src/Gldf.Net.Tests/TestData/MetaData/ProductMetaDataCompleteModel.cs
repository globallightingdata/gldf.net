using Gldf.Net.Domain;
using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
using Gldf.Net.Domain.Descriptive;
using Gldf.Net.Domain.Descriptive.Types;
using Gldf.Net.Domain.Descriptive.Types.Atex;
using Gldf.Net.Domain.Global;
using Gldf.Net.Domain.Head;
using Gldf.Net.Domain.Product;
using Gldf.Net.Domain.Product.Types;
using System;

namespace Gldf.Net.Tests.TestData.MetaData
{
    public class ProductMetaDataCompleteModel
    {
        public static Root Root => new()
        {
            Header = new Header
            {
                Manufacturer = "DIAL",
                CreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
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
                        Id = "image",
                        ContentType = FileContentType.ImagePng,
                        Type = FileType.Url,
                        File = "https://example.org/image.png"
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
                Emitters = new[]
                {
                    new Emitter
                    {
                        Id = "emitter",
                        PossibleFittings = new EmitterBase[]
                        {
                            new LightEmitter
                            {
                                PhotometryId = "photometry"
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
                        },
                        new Locale
                        {
                            Language = "de",
                            Text = "Produktnummer"
                        }
                    },
                    ProductName = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "Product name"
                        },
                        new Locale
                        {
                            Language = "de",
                            Text = "Produktname"
                        }
                    },
                    Description = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "Product description"
                        },
                        new Locale
                        {
                            Language = "de",
                            Text = "Produktbeschreibung"
                        }
                    },
                    TenderText = new[]
                    {
                        new Locale
                        {
                            Language = "en",
                            Text = "Product tendertext"
                        },
                        new Locale
                        {
                            Language = "de",
                            Text = "Produkt Auschreibungstext"
                        }
                    },
                    ProductSeries = new[]
                    {
                        new ProductSerie
                        {
                            Name = new[]
                            {
                                new Locale
                                {
                                    Language = "en",
                                    Text = "Product series name"
                                },
                                new Locale
                                {
                                    Language = "de",
                                    Text = "Produktserienname"
                                }
                            },
                            Description = new[]
                            {
                                new Locale
                                {
                                    Language = "en",
                                    Text = "Product series description"
                                },
                                new Locale
                                {
                                    Language = "de",
                                    Text = "Produktserienbeschreibung"
                                }
                            },
                            Pictures = new[]
                            {
                                new Image
                                {
                                    FileId = "image",
                                    ImageType = ImageType.ProductPicture
                                },
                                new Image
                                {
                                    FileId = "image",
                                    ImageType = ImageType.ApplicationPicture
                                },
                                new Image
                                {
                                    FileId = "image",
                                    ImageType = ImageType.TechnicalSketch
                                },
                                new Image
                                {
                                    FileId = "image",
                                    ImageType = ImageType.Other
                                }
                            },
                            Hyperlinks = new[]
                            {
                                new Hyperlink
                                {
                                    Href = "https://example.org",
                                    Language = "en",
                                    Region = "eu",
                                    CountryCode = "gb",
                                    PlainText = "Hyperlink PlainText"
                                }
                            }
                        }
                    },
                    Pictures = new[]
                    {
                        new Image
                        {
                            FileId = "image",
                            ImageType = ImageType.Other
                        }
                    },
                    Maintenance = new LuminaireMaintenance
                    {
                        Cie97LuminaireType = Cie97LuminaireType.DustProofIp5X,
                        CieMaintenanceFactors = new[]
                        {
                            new CieMaintenanceFactor
                            {
                                Years = 1,
                                RoomCondition = MfRoomCondition.Dirty,
                                Factor = 0.1
                            },
                            new CieMaintenanceFactor
                            {
                                Years = 2,
                                RoomCondition = MfRoomCondition.Normal,
                                Factor = 0.2
                            },
                            new CieMaintenanceFactor
                            {
                                Years = 3,
                                RoomCondition = MfRoomCondition.VeryClean,
                                Factor = 0.2
                            },
                            new CieMaintenanceFactor
                            {
                                Years = 4,
                                RoomCondition = MfRoomCondition.Clean,
                                Factor = 0.2
                            }
                        },
                        IesLightLossFactors = new[]
                        {
                            new IesDirtDepreciation
                            {
                                Years = 5,
                                RoomCondition = DdRoomCondition.VeryClean,
                                Factor = 0.3
                            },
                            new IesDirtDepreciation
                            {
                                Years = 6,
                                RoomCondition = DdRoomCondition.VeryDirty,
                                Factor = 0.4
                            },
                            new IesDirtDepreciation
                            {
                                Years = 7,
                                RoomCondition = DdRoomCondition.Dirty,
                                Factor = 0.4
                            },
                            new IesDirtDepreciation
                            {
                                Years = 8,
                                RoomCondition = DdRoomCondition.Clean,
                                Factor = 0.4
                            },
                            new IesDirtDepreciation
                            {
                                Years = 9,
                                RoomCondition = DdRoomCondition.Moderate,
                                Factor = 0.4
                            }
                        },
                        JiegMaintenanceFactors = new[]
                        {
                            new JiegMaintenanceFactor
                            {
                                Years = 10,
                                RoomCondition = JiegRoomCondition.Normal,
                                Factor = 0.5
                            },
                            new JiegMaintenanceFactor
                            {
                                Years = 11,
                                RoomCondition = JiegRoomCondition.Dirty,
                                Factor = 0.6
                            },
                            new JiegMaintenanceFactor
                            {
                                Years = 12,
                                RoomCondition = JiegRoomCondition.Clean,
                                Factor = 0.6
                            }
                        }

                        // <CieLuminaireMaintenanceFactors>
                        // <LuminaireMaintenanceFactor years="1" roomCondition="Dirty">0.1</LuminaireMaintenanceFactor>
                        // <LuminaireMaintenanceFactor years="2" roomCondition="Normal">0.2</LuminaireMaintenanceFactor>
                        // </CieLuminaireMaintenanceFactors>
                        // <IesLuminaireLightLossFactors>
                        // <LuminaireDirtDepreciation years="3" roomCondition="Very Clean">0.3</LuminaireDirtDepreciation>
                        // <LuminaireDirtDepreciation years="4" roomCondition="Very Dirty">0.4</LuminaireDirtDepreciation>
                        // </IesLuminaireLightLossFactors>
                        // <JiegMaintenanceFactors>
                        // <LuminaireMaintenanceFactor years="5" roomCondition="Normal">0.5</LuminaireMaintenanceFactor>
                        // <LuminaireMaintenanceFactor years="6" roomCondition="Dirty">0.6</LuminaireMaintenanceFactor>
                        // </JiegMaintenanceFactors>
                    },
                    DescriptiveAttributes = new DescriptiveAttributes
                    {
                        Mechanical = new Mechanical
                        {
                            ProductSize = new ProductSize
                            {
                                Length = 1,
                                Width = 2,
                                Height = 3
                            },
                            OperatingTemperature = new TemperatureRange
                            {
                                Lower = 4,
                                Upper = 5
                            },
                            SealingMaterial = new[]
                            {
                                new Locale
                                {
                                    Language = "en",
                                    Text = "Sealing Metarial"
                                },
                                new Locale
                                {
                                    Language = "de",
                                    Text = "Gehäusematerial"
                                }
                            },
                            Weight = 0.01
                        },
                        Electrical = new Electrical
                        {
                            ClampingRange = new ClampingRange
                            {
                                Lower = 0.02,
                                Upper = 0.03
                            },
                            SwitchingCapacity = "SwitchingCapacity",
                            ElectricalSafetyClass = SafetyClass.ClassII,
                            IngressProtectionIPCode = IngressProtectionIPCode.IP26,
                            IKRating = IKRating.IK06,
                            PowerFactor = 0.04,
                            ConstantLightOutput = true
                        },
                        Emergency = new Emergency
                        {
                            DurationTimeAndFlux = new[]
                            {
                                new EmergencyFlux { Hours = 3, Flux = 4 },
                                new EmergencyFlux { Hours = 5, Flux = 6 }
                            },
                            DedicatedEmergencyLightingType = EmergencyLightingType.ForSignage
                        },
                        MountingAndAccessory = new MountingAndAccessory
                        {
                            Atex = new Atex
                            {
                                Directives = new[]
                                {
                                    AtexDirective.IECEx,
                                    AtexDirective.ATEX
                                },
                                Classes = new[]
                                {
                                    AtexClass.I,
                                    AtexClass.III
                                },
                                Divisions = new[]
                                {
                                    AtexDivision.Division1,
                                    AtexDivision.Division2
                                },
                                DivisionGroups = new AtexDivisionGroups
                                {
                                    Gas = new[]
                                    {
                                        AtexDivisionGroupGas.A,
                                        AtexDivisionGroupGas.C
                                    },
                                    Dust = new[]
                                    {
                                        AtexDivisionGroupDust.F,
                                        AtexDivisionGroupDust.G
                                    }
                                },
                                Zones = new AtexZones
                                {
                                    Gas = new[]
                                    {
                                        AtexZoneGas.Zone0,
                                        AtexZoneGas.Zone2
                                    },
                                    Dust = new[]
                                    {
                                        AtexZoneDust.Zone21,
                                        AtexZoneDust.Zone22
                                    }
                                },
                                ZoneGroups = new AtexZoneGroups
                                {
                                    Gas = new[]
                                    {
                                        AtexZoneGroupGas.IIB,
                                        AtexZoneGroupGas.IIBH2
                                    },
                                    Dust = new[]
                                    {
                                        AtexZoneGroupDust.IIIA,
                                        AtexZoneGroupDust.IIIC
                                    }
                                },
                                MaximumSurfaceTemperature = "MaximumSurfaceTemperature",
                                TemperatureClasses = new[]
                                {
                                    AtexTemperatureClass.T2B,
                                    AtexTemperatureClass.T2C
                                },
                                ExCodes = new[]
                                {
                                    AtexExCode.eb,
                                    AtexExCode.ib
                                },
                                EquipmentProtectionLevels = new[]
                                {
                                    AtexEquipmentProtectionLevel.Ga,
                                    AtexEquipmentProtectionLevel.Ma
                                },
                                EquipmentGroups = new[]
                                {
                                    AtexEquipmentGroup.GroupI,
                                    AtexEquipmentGroup.GroupII
                                },
                                EquipmentCategories = new[]
                                {
                                    AtexEquipmentCategory.Category2G,
                                    AtexEquipmentCategory.CategoryM1
                                },
                                Atmospheres = new[]
                                {
                                    AtexAtmosphere.D,
                                    AtexAtmosphere.G
                                },
                                Groups = new[]
                                {
                                    AtexGroup.II,
                                    AtexGroup.IIA
                                }
                            },
                            AmbientTemperature = new TemperatureRange
                            {
                                Lower = 7,
                                Upper = 8
                            }
                        },
                        Marketing = new Marketing
                        {
                            ListPrices = new[]
                            {
                                new ListPrice { Currency = "eur", Price = 9 },
                                new ListPrice { Currency = "usd", Price = 10 }
                            },
                            HousingColors = new[]
                            {
                                new HousingColor
                                {
                                    Ral = "3000", ColorNames = new[]
                                    {
                                        new Locale
                                        {
                                            Language = "en",
                                            Text = "Red"
                                        },
                                        new Locale
                                        {
                                            Language = "de",
                                            Text = "Rot"
                                        }
                                    }
                                }
                            },
                            Markets = new[]
                            {
                                new Region
                                {
                                    RegionName = new[]
                                    {
                                        new Locale
                                        {
                                            Language = "en",
                                            Text = "South europe"
                                        },
                                        new Locale
                                        {
                                            Language = "de",
                                            Text = "Südeuropa"
                                        }
                                    }
                                }
                            },
                            Hyperlinks = new[]
                            {
                                new Hyperlink
                                {
                                    Href = "https://example.org",
                                    Language = "en",
                                    Region = "Europe",
                                    CountryCode = "gb",
                                    PlainText = "Hyperlink PlainText"
                                }
                            },
                            Designer = "Designer",
                            ApprovalMarks = new[] { "ApprovalMark 1", "ApprovalMark 2" },
                            DesignAwards = new[] { "DesignAward 1", "DesignAward 2" },
                            Applications = new[]
                            {
                                ApplicationArea.ExteriorStreetsMotorways,
                                ApplicationArea.InteriorTrafficZonesCorridors
                            }
                        },
                        OperationsAndMaintenance = new OperationsAndMaintenance
                        {
                            UsefulLifeTimes = new[]
                            {
                                "L80B50 50000h 25°C",
                                "L80B75 40000h 25°C"
                            },
                            MedianUsefulLifeTimes = new[]
                            {
                                "L100B50 40000h 20°C",
                                "L80B50 50000h 20°C"
                            },
                            RatedAmbientTemperature = 11,
                            AcousticAbsorptionRates = new[]
                            {
                                new AbsorptionRate { Hertz = 12, Rate = 0.05 },
                                new AbsorptionRate { Hertz = 13, Rate = 0.06 }
                            }
                        },
                        CustomProperties = new[]
                        {
                            new CustomProperty
                            {
                                Id = "propertyWithFileReference",
                                Name = new[]
                                {
                                    new Locale
                                    {
                                        Language = "en",
                                        Text = "Property 1"
                                    },
                                    new Locale
                                    {
                                        Language = "de",
                                        Text = "Eigenschaft 1"
                                    }
                                },
                                PropertySource = "PropertySource 1",
                                Content = new PropertyFileReference
                                {
                                    FileId = "image"
                                }
                            },
                            new CustomProperty
                            {
                                Id = "propertyWithValue",
                                Name = new[]
                                {
                                    new Locale
                                    {
                                        Language = "en",
                                        Text = "Property 2"
                                    },
                                    new Locale
                                    {
                                        Language = "de",
                                        Text = "Eigenschaft 2"
                                    }
                                },
                                PropertySource = "PropertySource 2",
                                Content = new PropertyText
                                {
                                    Value = "Value 2"
                                }
                            }
                        }
                    }
                },
                Variants = new[]
                {
                    new Variant
                    {
                        Id = "variant-1",
                        VariantName = new[]
                        {
                            new Locale { Language = "en", Text = "Variant 1" }
                        },
                        Reference = new EmitterReference
                        {
                            EmitterId = "emitter"
                        }
                    }
                }
            }
        };
    }
}