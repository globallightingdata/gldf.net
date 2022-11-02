using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Descriptive;
using Gldf.Net.Domain.Xml.Descriptive.Types;
using Gldf.Net.Domain.Xml.Descriptive.Types.Atex;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Domain.Xml.Product.Types;
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
                        },
                        new Locale
                        {
                            Language = "de",
                            Text = "Produktnummer"
                        }
                    },
                    Name = new[]
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
                            ProductForm = ProductForm.Cylinder,
                            Adjustabilities = new []
                            {
                                Adjustability.Fixed,
                                Adjustability.Orientation,
                                Adjustability.Turn,
                                Adjustability.Tilt,
                                Adjustability.Cardanic,
                                Adjustability.HeightAdjustable,
                                Adjustability.UserDefined,
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
                            IKRating = IKRating.IK06,
                            ProtectiveAreas = new []
                            {
                                ProtectiveArea.BallimpactProof,
                                ProtectiveArea.CleanroomSuitable,
                                ProtectiveArea.DriveOrRollOverProof,
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
                            PowerFactor = 0.04,
                            ConstantLightOutput = true,
                            LightDistribution = LightDistribution.Asymmetrical
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
                            Labels = new []
                            {
                                Label.CE,
                                Label.GS,
                                Label.ENEC,
                                Label.CCC,
                                Label.VDE,
                                Label.EAC,
                                Label.D,
                                Label.M,
                                Label.MM,
                                Label.F,
                                Label.FF,
                                Label.UL,
                                Label.Handwarm,
                                Label.IFSFood
                            },
                            Applications = new[]
                            {
                                ApplicationArea.InteriorTrafficZones,
                                ApplicationArea.InteriorTrafficZonesCorridors,
                                ApplicationArea.InteriorTrafficZonesStaircases,
                                ApplicationArea.InteriorTrafficZonesLoadingZones,
                                ApplicationArea.InteriorTrafficZonesCoveLightingCornices,
                                ApplicationArea.InteriorGeneralAreasInterior,
                                ApplicationArea.InteriorGeneralAreasInteriorBreakRooms,
                                ApplicationArea.InteriorGeneralAreasInteriorReceptionAreas,
                                ApplicationArea.InteriorOffice,
                                ApplicationArea.InteriorOfficeOfficeDesks,
                                ApplicationArea.InteriorOfficeGroupOffices,
                                ApplicationArea.InteriorOfficeDiscussions,
                                ApplicationArea.InteriorOfficeArchives,
                                ApplicationArea.InteriorIndustryCraft,
                                ApplicationArea.InteriorIndustryCraftIndustrialWorkshops,
                                ApplicationArea.InteriorIndustryCraftWarehouses,
                                ApplicationArea.InteriorIndustryCraftColdStorageFacilities,
                                ApplicationArea.InteriorIndustryCraftKitchens,
                                ApplicationArea.InteriorIndustryCraftAssemblyWorkStations,
                                ApplicationArea.InteriorIndustryCraftMachineIllumination,
                                ApplicationArea.InteriorIndustryCraftControlWorkStations,
                                ApplicationArea.InteriorIndustryCraftLaboratories,
                                ApplicationArea.InteriorIndustryCraftHangars,
                                ApplicationArea.InteriorShopLighting,
                                ApplicationArea.InteriorShopLightingRetail,
                                ApplicationArea.InteriorShopLightingFood,
                                ApplicationArea.InteriorShopLightingClothing,
                                ApplicationArea.InteriorShopLightingDisplayWindows,
                                ApplicationArea.InteriorShopLightingHalls,
                                ApplicationArea.InteriorShopLightingGreatHalls,
                                ApplicationArea.InteriorShopLightingMirrors,
                                ApplicationArea.InteriorPublicAreas,
                                ApplicationArea.InteriorPublicAreasRestaurants,
                                ApplicationArea.InteriorPublicAreasTheatres,
                                ApplicationArea.InteriorPublicAreasRailwayStations,
                                ApplicationArea.InteriorPublicAreasMuseums,
                                ApplicationArea.InteriorPublicAreasFairs,
                                ApplicationArea.InteriorPublicAreasPrisons,
                                ApplicationArea.InteriorPublicAreasCanteens,
                                ApplicationArea.InteriorEmergencyLighting,
                                ApplicationArea.InteriorEmergencyLightingEmergencyLighting,
                                ApplicationArea.InteriorEmergencyLightingSignalLighting,
                                ApplicationArea.InteriorEducationalFacilities,
                                ApplicationArea.InteriorEducationalFacilitiesClassrooms,
                                ApplicationArea.InteriorEducationalFacilitiesLibraries,
                                ApplicationArea.InteriorEducationalFacilitiesLounges,
                                ApplicationArea.InteriorEducationalFacilitiesSportsHalls,
                                ApplicationArea.InteriorPrivateAreas,
                                ApplicationArea.InteriorPrivateAreasLivingAreas,
                                ApplicationArea.InteriorPrivateAreasBaths,
                                ApplicationArea.InteriorPrivateAreasKitchens,
                                ApplicationArea.InteriorHospitalsandCarePlaces,
                                ApplicationArea.InteriorHospitalsandCarePlacesHospitalWards,
                                ApplicationArea.InteriorHospitalsandCarePlacesPatientRooms,
                                ApplicationArea.InteriorHospitalsandCarePlacesCleanRoomAreas,
                                ApplicationArea.InteriorHospitalsandCarePlacesExaminationRooms,
                                ApplicationArea.InteriorHospitalsandCarePlacesCirculationAreas,
                                ApplicationArea.ExteriorGeneralAreasExterior,
                                ApplicationArea.ExteriorGeneralAreasPlaces,
                                ApplicationArea.ExteriorGeneralAreasParks,
                                ApplicationArea.ExteriorGeneralAreasUnderpasses,
                                ApplicationArea.ExteriorGeneralAreasOutdoorStairs,
                                ApplicationArea.ExteriorGeneralAreasPlatformRoofs,
                                ApplicationArea.ExteriorGeneralAreasParkingSpacesIndoor,
                                ApplicationArea.ExteriorGeneralAreasOutdoorParkings,
                                ApplicationArea.ExteriorGeneralAreasPools,
                                ApplicationArea.ExteriorGeneralAreasFountains,
                                ApplicationArea.ExteriorStreets,
                                ApplicationArea.ExteriorStreetsMotorways,
                                ApplicationArea.ExteriorStreetsAccessRoads,
                                ApplicationArea.ExteriorStreetsResidentialAreas,
                                ApplicationArea.ExteriorStreetsBicyclePaths,
                                ApplicationArea.ExteriorStreetsFootpaths,
                                ApplicationArea.ExteriorStreetsPetrolGasStations,
                                ApplicationArea.ExteriorStreetsTunnels,
                                ApplicationArea.ExteriorSportsFields,
                                ApplicationArea.ExteriorSportsFieldsSpotlightings,
                                ApplicationArea.ExteriorOther,
                                ApplicationArea.ExteriorOtherFacades
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
                            OperatingTemperature = new TemperatureRange
                            {
                                Lower = 4,
                                Upper = 5
                            },
                            AmbientTemperature = new TemperatureRange
                            {
                                Lower = 7,
                                Upper = 8
                            },
                            RatedAmbientTemperature = 11,
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
}