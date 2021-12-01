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

namespace Gldf.Net.Tests.TestData.Descriptive
{
    public class DescriptiveAttributesModel
    {
        public static Root Root => new()
        {
            Header = new Header
            {
                Manufacturer = "Manufacturer",
                CreationTimeCode = new DateTime(2021, 3, 29, 14, 30, 0, DateTimeKind.Utc),
                CreatedWithApplication = "CreatedWithApplication"
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
                        VariantName = new[]
                        {
                            new Locale { Language = "en", Text = "Variant 1" }
                        },
                        Reference = new EmitterReference
                        {
                            EmitterId = "emitter"
                        },
                        VariantDescriptiveAttributes = new DescriptiveAttributes
                        {
                            Electrical = new Electrical
                            {
                                ElectricalSafetyClass = SafetyClass.Class0,
                                IngressProtectionIPCode = IngressProtectionIPCode.IP20,
                                IKRating = IKRating.IK00,
                                ConstantLightOutput = true
                            },
                            Emergency = new Emergency
                            {
                                DedicatedEmergencyLightingType = EmergencyLightingType.ExitLight
                            },
                            Marketing = new Marketing
                            {
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
                            }
                        }
                    },
                    new Variant
                    {
                        Id = "variant-2",
                        VariantName = new[]
                        {
                            new Locale { Language = "en", Text = "Variant 2" }
                        },
                        Reference = new EmitterReference
                        {
                            EmitterId = "emitter"
                        },
                        VariantDescriptiveAttributes = new DescriptiveAttributes
                        {
                            Electrical = new Electrical
                            {
                                ElectricalSafetyClass = SafetyClass.ClassI,
                                IngressProtectionIPCode = IngressProtectionIPCode.IP30,
                                IKRating = IKRating.IK01,
                                ConstantLightOutput = false
                            },
                            Emergency = new Emergency
                            {
                                DedicatedEmergencyLightingType = EmergencyLightingType.GuideLight
                            },
                            MountingAndAccessory = new MountingAndAccessory
                            {
                                Atex = new Atex
                                {
                                    Directives = new[]
                                    {
                                        AtexDirective.ATEX,
                                        AtexDirective.IECEx,
                                        AtexDirective.CEC,
                                        AtexDirective.NEC
                                    },
                                    Classes = new[]
                                    {
                                        AtexClass.I,
                                        AtexClass.II,
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
                                            AtexDivisionGroupGas.B,
                                            AtexDivisionGroupGas.C,
                                            AtexDivisionGroupGas.D
                                        },
                                        Dust = new[]
                                        {
                                            AtexDivisionGroupDust.E,
                                            AtexDivisionGroupDust.F,
                                            AtexDivisionGroupDust.G
                                        }
                                    },
                                    Zones = new AtexZones
                                    {
                                        Gas = new[]
                                        {
                                            AtexZoneGas.Zone0,
                                            AtexZoneGas.Zone1,
                                            AtexZoneGas.Zone2
                                        },
                                        Dust = new[]
                                        {
                                            AtexZoneDust.Zone20,
                                            AtexZoneDust.Zone21,
                                            AtexZoneDust.Zone22
                                        }
                                    },
                                    ZoneGroups = new AtexZoneGroups
                                    {
                                        Gas = new[]
                                        {
                                            AtexZoneGroupGas.IIC,
                                            AtexZoneGroupGas.IIBH2,
                                            AtexZoneGroupGas.IIB,
                                            AtexZoneGroupGas.IIA
                                        },
                                        Dust = new[]
                                        {
                                            AtexZoneGroupDust.IIIC,
                                            AtexZoneGroupDust.IIIB,
                                            AtexZoneGroupDust.IIIA
                                        }
                                    },
                                    MaximumSurfaceTemperature = "MaximumSurfaceTemperature",
                                    TemperatureClasses = new[]
                                    {
                                        AtexTemperatureClass.T1,
                                        AtexTemperatureClass.T2,
                                        AtexTemperatureClass.T2A,
                                        AtexTemperatureClass.T2B,
                                        AtexTemperatureClass.T2C,
                                        AtexTemperatureClass.T2D,
                                        AtexTemperatureClass.T3,
                                        AtexTemperatureClass.T3A,
                                        AtexTemperatureClass.T3B,
                                        AtexTemperatureClass.T3C,
                                        AtexTemperatureClass.T4,
                                        AtexTemperatureClass.T4A,
                                        AtexTemperatureClass.T5,
                                        AtexTemperatureClass.T6
                                    },
                                    ExCodes = new[]
                                    {
                                        AtexExCode.da,
                                        AtexExCode.db,
                                        AtexExCode.dc,
                                        AtexExCode.eb,
                                        AtexExCode.ec,
                                        AtexExCode.ia,
                                        AtexExCode.ib,
                                        AtexExCode.ic,
                                        AtexExCode.ma,
                                        AtexExCode.mb,
                                        AtexExCode.mc,
                                        AtexExCode.nC,
                                        AtexExCode.nR,
                                        AtexExCode.ob,
                                        AtexExCode.oc,
                                        AtexExCode.opis,
                                        AtexExCode.oppr,
                                        AtexExCode.opsh,
                                        AtexExCode.pxb,
                                        AtexExCode.pyb,
                                        AtexExCode.pyc,
                                        AtexExCode.pzc,
                                        AtexExCode.q,
                                        AtexExCode.ta,
                                        AtexExCode.tb,
                                        AtexExCode.tc
                                    },
                                    EquipmentProtectionLevels = new[]
                                    {
                                        AtexEquipmentProtectionLevel.Ga,
                                        AtexEquipmentProtectionLevel.Gb,
                                        AtexEquipmentProtectionLevel.Gc,
                                        AtexEquipmentProtectionLevel.Da,
                                        AtexEquipmentProtectionLevel.Db,
                                        AtexEquipmentProtectionLevel.Dc,
                                        AtexEquipmentProtectionLevel.Ma,
                                        AtexEquipmentProtectionLevel.Mb
                                    },
                                    EquipmentGroups = new[]
                                    {
                                        AtexEquipmentGroup.GroupI,
                                        AtexEquipmentGroup.GroupII
                                    },
                                    EquipmentCategories = new[]
                                    {
                                        AtexEquipmentCategory.CategoryM1,
                                        AtexEquipmentCategory.CategoryM2,
                                        AtexEquipmentCategory.Category1G,
                                        AtexEquipmentCategory.Category2G,
                                        AtexEquipmentCategory.Category3G,
                                        AtexEquipmentCategory.Category1D,
                                        AtexEquipmentCategory.Category2D,
                                        AtexEquipmentCategory.Category3D
                                    },
                                    Atmospheres = new[]
                                    {
                                        AtexAtmosphere.G,
                                        AtexAtmosphere.D
                                    },
                                    Groups = new[]
                                    {
                                        AtexGroup.I,
                                        AtexGroup.II,
                                        AtexGroup.IIA,
                                        AtexGroup.IIB,
                                        AtexGroup.IIC,
                                        AtexGroup.III,
                                        AtexGroup.IIIA,
                                        AtexGroup.IIIB,
                                        AtexGroup.IIIC
                                    }
                                }
                            }
                        }
                    },
                    new Variant
                    {
                        Id = "variant-3",
                        VariantName = new[]
                        {
                            new Locale { Language = "en", Text = "Variant 3" }
                        },
                        Reference = new EmitterReference
                        {
                            EmitterId = "emitter"
                        },
                        VariantDescriptiveAttributes = new DescriptiveAttributes
                        {
                            Electrical = new Electrical
                            {
                                ElectricalSafetyClass = SafetyClass.ClassII,
                                IngressProtectionIPCode = IngressProtectionIPCode.IP40,
                                IKRating = IKRating.IK02
                            },
                            Emergency = new Emergency
                            {
                                DedicatedEmergencyLightingType = EmergencyLightingType.EvacuationLight
                            }
                        }
                    },
                    new Variant
                    {
                        Id = "variant-4",
                        VariantName = new[]
                        {
                            new Locale { Language = "en", Text = "Variant 4" }
                        },
                        Reference = new EmitterReference
                        {
                            EmitterId = "emitter"
                        },
                        VariantDescriptiveAttributes = new DescriptiveAttributes
                        {
                            Electrical = new Electrical
                            {
                                ElectricalSafetyClass = SafetyClass.ClassIII,
                                IngressProtectionIPCode = IngressProtectionIPCode.IP40,
                                IKRating = IKRating.IK03
                            },
                            Emergency = new Emergency
                            {
                                DedicatedEmergencyLightingType = EmergencyLightingType.ReferenceLight
                            }
                        }
                    },
                    new Variant
                    {
                        Id = "variant-5",
                        VariantName = new[]
                        {
                            new Locale { Language = "en", Text = "Variant 5" }
                        },
                        Reference = new EmitterReference
                        {
                            EmitterId = "emitter"
                        },
                        VariantDescriptiveAttributes = new DescriptiveAttributes
                        {
                            Electrical = new Electrical
                            {
                                ElectricalSafetyClass = SafetyClass.Item0I,
                                IngressProtectionIPCode = IngressProtectionIPCode.IP50,
                                IKRating = IKRating.IK09
                            },
                            Emergency = new Emergency
                            {
                                DedicatedEmergencyLightingType = EmergencyLightingType.ForSignage
                            }
                        }
                    },
                    new Variant
                    {
                        Id = "variant-6",
                        VariantName = new[]
                        {
                            new Locale { Language = "en", Text = "Variant 6" }
                        },
                        Reference = new EmitterReference
                        {
                            EmitterId = "emitter"
                        },
                        VariantDescriptiveAttributes = new DescriptiveAttributes
                        {
                            Electrical = new Electrical
                            {
                                IngressProtectionIPCode = IngressProtectionIPCode.IP69,
                                IKRating = IKRating.IK10
                            },
                            Emergency = new Emergency
                            {
                                DedicatedEmergencyLightingType = EmergencyLightingType.ForLighting
                            }
                        }
                    },
                    new Variant
                    {
                        Id = "variant-7",
                        VariantName = new[]
                        {
                            new Locale { Language = "en", Text = "Variant 7" }
                        },
                        Reference = new EmitterReference
                        {
                            EmitterId = "emitter"
                        },
                        VariantDescriptiveAttributes = new DescriptiveAttributes
                        {
                            Electrical = new Electrical
                            {
                                IngressProtectionIPCode = IngressProtectionIPCode.IP69K,
                                IKRating = IKRating.IK10Plus
                            }
                        }
                    }
                }
            }
        };
    }
}