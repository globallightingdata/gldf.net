using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive.Types;

public enum ApplicationArea
{
    [XmlEnum("Interior: Traffic Zones")]
    InteriorTrafficZones,

    [XmlEnum("Interior: Traffic Zones: Corridors")]
    InteriorTrafficZonesCorridors,

    [XmlEnum("Interior: Traffic Zones: Staircases")]
    InteriorTrafficZonesStaircases,

    [XmlEnum("Interior: Traffic Zones: Loading Zones")]
    InteriorTrafficZonesLoadingZones,

    [XmlEnum("Interior: Traffic Zones: Cove Lighting / Cornices (Indoor)")]
    InteriorTrafficZonesCoveLightingCornices,

    [XmlEnum("Interior: General Areas (Interior)")]
    InteriorGeneralAreasInterior,

    [XmlEnum("Interior: General Areas (Interior): Break Rooms")]
    InteriorGeneralAreasInteriorBreakRooms,

    [XmlEnum("Interior: General Areas (Interior): Reception Areas")]
    InteriorGeneralAreasInteriorReceptionAreas,

    [XmlEnum("Interior: Office")]
    InteriorOffice,

    [XmlEnum("Interior: Office: Office Desks")]
    InteriorOfficeOfficeDesks,

    [XmlEnum("Interior: Office: Group Offices")]
    InteriorOfficeGroupOffices,

    [XmlEnum("Interior: Office: Discussions")]
    InteriorOfficeDiscussions,

    [XmlEnum("Interior: Office: Archives")]
    InteriorOfficeArchives,

    [XmlEnum("Interior: Industry/Craft")]
    InteriorIndustryCraft,

    [XmlEnum("Interior: Industry/Craft: Industrial Workshops")]
    InteriorIndustryCraftIndustrialWorkshops,

    [XmlEnum("Interior: Industry/Craft: Warehouses")]
    InteriorIndustryCraftWarehouses,

    [XmlEnum("Interior: Industry/Craft: Cold Storage Facilities")]
    InteriorIndustryCraftColdStorageFacilities,

    [XmlEnum("Interior: Industry/Craft: Kitchens")]
    InteriorIndustryCraftKitchens,

    [XmlEnum("Interior: Industry/Craft: Assembly Work Stations")]
    InteriorIndustryCraftAssemblyWorkStations,

    [XmlEnum("Interior: Industry/Craft: Machine Illumination")]
    InteriorIndustryCraftMachineIllumination,

    [XmlEnum("Interior: Industry/Craft: Control Work Stations")]
    InteriorIndustryCraftControlWorkStations,

    [XmlEnum("Interior: Industry/Craft: Laboratories")]
    InteriorIndustryCraftLaboratories,

    [XmlEnum("Interior: Industry/Craft: Hangars")]
    InteriorIndustryCraftHangars,

    [XmlEnum("Interior: Shop Lighting")]
    InteriorShopLighting,

    [XmlEnum("Interior: Shop Lighting: Retail")]
    InteriorShopLightingRetail,

    [XmlEnum("Interior: Shop Lighting: Food")]
    InteriorShopLightingFood,

    [XmlEnum("Interior: Shop Lighting: Clothing")]
    InteriorShopLightingClothing,

    [XmlEnum("Interior: Shop Lighting: Display Windows")]
    InteriorShopLightingDisplayWindows,

    [XmlEnum("Interior: Shop Lighting: Halls")]
    InteriorShopLightingHalls,

    [XmlEnum("Interior: Shop Lighting: Great Halls")]
    InteriorShopLightingGreatHalls,

    [XmlEnum("Interior: Shop Lighting: Mirrors")]
    InteriorShopLightingMirrors,

    [XmlEnum("Interior: Public Areas")]
    InteriorPublicAreas,

    [XmlEnum("Interior: Public Areas: Restaurants")]
    InteriorPublicAreasRestaurants,

    [XmlEnum("Interior: Public Areas: Theatres")]
    InteriorPublicAreasTheatres,

    [XmlEnum("Interior: Public Areas: Railway Stations")]
    InteriorPublicAreasRailwayStations,

    [XmlEnum("Interior: Public Areas: Museums")]
    InteriorPublicAreasMuseums,

    [XmlEnum("Interior: Public Areas: Fairs")]
    InteriorPublicAreasFairs,

    [XmlEnum("Interior: Public Areas: Prisons")]
    InteriorPublicAreasPrisons,

    [XmlEnum("Interior: Public Areas: Canteens")]
    InteriorPublicAreasCanteens,

    [XmlEnum("Interior: Emergency Lighting")]
    InteriorEmergencyLighting,

    [XmlEnum("Interior: Emergency Lighting: Emergency Lighting")]
    InteriorEmergencyLightingEmergencyLighting,

    [XmlEnum("Interior: Emergency Lighting: Signal Lighting")]
    InteriorEmergencyLightingSignalLighting,

    [XmlEnum("Interior: Educational Facilities")]
    InteriorEducationalFacilities,

    [XmlEnum("Interior: Educational Facilities: Classrooms")]
    InteriorEducationalFacilitiesClassrooms,

    [XmlEnum("Interior: Educational Facilities: Libraries")]
    InteriorEducationalFacilitiesLibraries,

    [XmlEnum("Interior: Educational Facilities: Lounges")]
    InteriorEducationalFacilitiesLounges,

    [XmlEnum("Interior: Educational Facilities: Sports Halls")]
    InteriorEducationalFacilitiesSportsHalls,

    [XmlEnum("Interior: Private Areas")]
    InteriorPrivateAreas,

    [XmlEnum("Interior: Private Areas: Living Areas")]
    InteriorPrivateAreasLivingAreas,

    [XmlEnum("Interior: Private Areas: Baths")]
    InteriorPrivateAreasBaths,

    [XmlEnum("Interior: Private Areas: Kitchens")]
    InteriorPrivateAreasKitchens,

    [XmlEnum("Interior: Hospitals and Care Places")]
    InteriorHospitalsandCarePlaces,

    [XmlEnum("Interior: Hospitals and Care Places: Hospital Wards")]
    InteriorHospitalsandCarePlacesHospitalWards,

    [XmlEnum("Interior: Hospitals and Care Places: Health Care Patient Rooms")]
    InteriorHospitalsandCarePlacesPatientRooms,

    [XmlEnum("Interior: Hospitals and Care Places: Health Care Clean Room Areas")]
    InteriorHospitalsandCarePlacesCleanRoomAreas,

    [XmlEnum("Interior: Hospitals and Care Places: Health Care Examination Rooms")]
    InteriorHospitalsandCarePlacesExaminationRooms,

    [XmlEnum("Interior: Hospitals and Care Places: Health Care Circulation Areas")]
    InteriorHospitalsandCarePlacesCirculationAreas,

    [XmlEnum("Exterior: General Areas (Exterior)")]
    ExteriorGeneralAreasExterior,

    [XmlEnum("Exterior: General Areas (Exterior): Places")]
    ExteriorGeneralAreasPlaces,

    [XmlEnum("Exterior: General Areas (Exterior): Parks")]
    ExteriorGeneralAreasParks,

    [XmlEnum("Exterior: General Areas (Exterior): Underpasses")]
    ExteriorGeneralAreasUnderpasses,

    [XmlEnum("Exterior: General Areas (Exterior): (Outdoor) Stairs")]
    ExteriorGeneralAreasOutdoorStairs,

    [XmlEnum("Exterior: General Areas (Exterior): Platform-Roofs")]
    ExteriorGeneralAreasPlatformRoofs,

    [XmlEnum("Exterior: General Areas (Exterior): Parking Spaces (Indoor)")]
    ExteriorGeneralAreasParkingSpacesIndoor,

    [XmlEnum("Exterior: General Areas (Exterior): Outdoor Parkings")]
    ExteriorGeneralAreasOutdoorParkings,

    [XmlEnum("Exterior: General Areas (Exterior): Pools")]
    ExteriorGeneralAreasPools,

    [XmlEnum("Exterior: General Areas (Exterior): Fountains")]
    ExteriorGeneralAreasFountains,

    [XmlEnum("Exterior: Streets")]
    ExteriorStreets,

    [XmlEnum("Exterior: Streets: Motorways")]
    ExteriorStreetsMotorways,

    [XmlEnum("Exterior: Streets: Access Roads")]
    ExteriorStreetsAccessRoads,

    [XmlEnum("Exterior: Streets: Residential Areas")]
    ExteriorStreetsResidentialAreas,

    [XmlEnum("Exterior: Streets: Bicycle Paths")]
    ExteriorStreetsBicyclePaths,

    [XmlEnum("Exterior: Streets: Footpaths")]
    ExteriorStreetsFootpaths,

    [XmlEnum("Exterior: Streets: Petrol-Gas Stations")]
    ExteriorStreetsPetrolGasStations,

    [XmlEnum("Exterior: Streets: Tunnels")]
    ExteriorStreetsTunnels,

    [XmlEnum("Exterior: Sports Fields")]
    ExteriorSportsFields,

    [XmlEnum("Exterior: Sports Fields: Spotlightings")]
    ExteriorSportsFieldsSpotlightings,

    [XmlEnum("Exterior: Other")]
    ExteriorOther,

    [XmlEnum("Exterior: Other: Facades")]
    ExteriorOtherFacades
}