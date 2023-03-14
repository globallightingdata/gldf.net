using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Tests.TestData.ControlGears;
using Gldf.Net.Tests.TestData.Descriptive;
using Gldf.Net.Tests.TestData.Emitters;
using Gldf.Net.Tests.TestData.Equipments;
using Gldf.Net.Tests.TestData.Files;
using Gldf.Net.Tests.TestData.Geometries;
using Gldf.Net.Tests.TestData.Head;
using Gldf.Net.Tests.TestData.LightSources;
using Gldf.Net.Tests.TestData.MetaData;
using Gldf.Net.Tests.TestData.Photometries;
using Gldf.Net.Tests.TestData.Sensors;
using Gldf.Net.Tests.TestData.Simple;
using Gldf.Net.Tests.TestData.Spectrums;
using Gldf.Net.Tests.TestData.Variants;
using Gldf.Net.Tests.TestHelper;
using NUnit.Framework;
using System.Collections.Generic;

namespace Gldf.Net.Tests.TestData
{
    public static class EmbeddedXmlTestData
    {
        private const string HeaderMandatoryXml = "TestData.Head.HeaderMandatoryXml.xml";
        private const string HeaderCompleteXml = "TestData.Head.HeaderCompleteXml.xml";
        private const string FilesMandatoryXml = "TestData.Files.FilesMandatoryXml.xml";
        private const string FilesCompleteXml = "TestData.Files.FilesCompleteXml.xml";
        private const string SensorsMandatoryXml = "TestData.Sensors.SensorsMandatoryXml.xml";
        private const string SensorsCompleteXml = "TestData.Sensors.SensorsCompleteXml.xml";
        private const string PhotometryMandatoryXml = "TestData.Photometries.PhotometryMandatoryXml.xml";
        private const string PhotometryCompleteXml = "TestData.Photometries.PhotometryCompleteXml.xml";
        private const string SpectrumMandatoryXml = "TestData.Spectrums.SpectrumMandatoryXml.xml";
        private const string SpectrumCompleteXml = "TestData.Spectrums.SpectrumCompleteXml.xml";
        private const string LightSourceMandatoryXml = "TestData.LightSources.LightSourceMandatoryXml.xml";
        private const string ChangeableCompleteXml = "TestData.LightSources.ChangeableCompleteXml.xml";
        private const string FixedCompleteXml = "TestData.LightSources.FixedCompleteXml.xml";
        private const string ControlGearMandatoryXml = "TestData.ControlGears.ControlGearMandatoryXml.xml";
        private const string ControlGearCompleteXml = "TestData.ControlGears.ControlGearCompleteXml.xml";
        private const string EquipmentMandatoryXml = "TestData.Equipments.EquipmentMandatoryXml.xml";
        private const string EquipmentCompleteXml = "TestData.Equipments.EquipmentCompleteXml.xml";
        private const string EmitterMandatoryXml = "TestData.Emitters.EmitterMandatoryXml.xml";
        private const string EmitterCompleteXml = "TestData.Emitters.EmitterCompleteXml.xml";
        private const string GeometryMandatoryXml = "TestData.Geometries.GeometryMandatoryXml.xml";
        private const string GeometryCompleteXml = "TestData.Geometries.GeometryCompleteXml.xml";
        private const string MetaDataMandatoryXml = "TestData.MetaData.ProductMetaDataMandatoryXml.xml";
        private const string MetaDataCompleteXml = "TestData.MetaData.ProductMetaDataCompleteXml.xml";
        private const string VariantMandatoryXml = "TestData.Variants.VariantMandatoryXml.xml";
        private const string VariantCompleteXml = "TestData.Variants.VariantCompleteXml.xml";
        private const string DescriptiveAttributesXml = "TestData.Descriptive.DescriptiveAttributesXml.xml";
        private const string RootWithHeaderXml = "TestData.Simple.RootWithHeaderXml.xml";
        private const string RootWithUnintendedXml = "TestData.Simple.RootWithHeaderUnintendedXml.xml";

        public static readonly List<TestCaseData> ValidXmlTestCases = new()
        {
            new TestCaseData(GetHeaderMandatoryXml()).SetName("Header Mandatory"),
            new TestCaseData(GetHeaderCompleteXml()).SetName("Header Complete"),
            new TestCaseData(GetFileMandatoryXml()).SetName("File Mandatory"),
            new TestCaseData(GetFileCompleteXml()).SetName("File Complete"),
            new TestCaseData(GetSensorMandatoryXml()).SetName("Sensor Mandatory"),
            new TestCaseData(GetSensorCompleteXml()).SetName("Sensor Complete"),
            new TestCaseData(GetPhotometryMandatoryXml()).SetName("Photometry Mandatory"),
            new TestCaseData(GetPhotometryCompleteXml()).SetName("Photometry Complete"),
            new TestCaseData(GetSpectrumMandatoryXml()).SetName("Spectrum Mandatory"),
            new TestCaseData(GetSpectrumCompleteXml()).SetName("Spectrum Complete"),
            new TestCaseData(GetLightSourceMandatoryXml()).SetName("LightSource Mandatory"),
            new TestCaseData(GetChangeableCompleteXml()).SetName("LightSource Changeable Complete"),
            new TestCaseData(GetFixedCompleteXml()).SetName("LightSource Fixed Complete"),
            new TestCaseData(GetControlGearMandatoryXml()).SetName("ControlGear Mandatory"),
            new TestCaseData(GetControlGearCompleteXml()).SetName("ControlGear Complete"),
            new TestCaseData(GetEquipmentMandatoryXml()).SetName("Equipment Mandatory"),
            new TestCaseData(GetEquipmentCompleteXml()).SetName("Equipment Complete"),
            new TestCaseData(GetEmitterMandatoryXml()).SetName("Emitter Mandatory"),
            new TestCaseData(GetEmitterCompleteXml()).SetName("Emitter Complete"),
            new TestCaseData(GetGeometryMandatoryXml()).SetName("Geometry Mandatory"),
            new TestCaseData(GetGeometryCompleteXml()).SetName("Geometry Complete"),
            new TestCaseData(GetMetaDataMandatoryXml()).SetName("MetaData Mandatory"),
            new TestCaseData(GetMetaDataCompleteXml()).SetName("MetaData Complete"),
            new TestCaseData(GetVariantMandatoryXml()).SetName("Variant Mandatory"),
            new TestCaseData(GetVariantCompleteXml()).SetName("Variant Complete"),
            new TestCaseData(GetDescriptiveAttributesXml()).SetName("Descriptive Attributes")
        };

        public static readonly List<TestCaseData> InvalidXmlTestCases = new()
        {
            new TestCaseData(GetRootWithHeaderXml()).SetName("Root with Header only")
        };

        // Header
        public static string GetHeaderMandatoryXml() => ResourceLoader.LoadEmbeddedXml(HeaderMandatoryXml);
        public static string GetHeaderCompleteXml() => ResourceLoader.LoadEmbeddedXml(HeaderCompleteXml);
        public static Root GetHeaderMandatoryModel() => HeaderMandatoryModel.Root;
        public static RootTyped GetHeaderMandatoryTyped() => HeaderMandatoryTyped.RootTyped;
        public static Root GetHeaderCompleteModel() => HeaderCompleteModel.Root;
        public static RootTyped GetHeaderCompleteTyped() => HeaderCompleteTyped.RootTyped;

        // GeneralDefinitions => Files
        public static string GetFileMandatoryXml() => ResourceLoader.LoadEmbeddedXml(FilesMandatoryXml);
        public static string GetFileCompleteXml() => ResourceLoader.LoadEmbeddedXml(FilesCompleteXml);
        public static Root GetFileMandatoryModel() => FilesMandatoryModel.Root;
        public static RootTyped GetFileMandatoryTyped() => FilesMandatoryTyped.RootTyped;
        public static Root GetFileCompleteModel() => FilesCompleteModel.Root;
        public static RootTyped GetFileCompleteTyped() => FilesCompleteTyped.RootTyped;

        // GeneralDefinitions => Sensors
        public static string GetSensorMandatoryXml() => ResourceLoader.LoadEmbeddedXml(SensorsMandatoryXml);
        public static string GetSensorCompleteXml() => ResourceLoader.LoadEmbeddedXml(SensorsCompleteXml);
        public static Root GetSensorMandatoryModel() => SensorsMandatoryModel.Root;
        public static RootTyped GetSensorMandatoryTyped() => SensorsMandatoryTyped.RootTyped;
        public static Root GetSensorCompleteModel() => SensorsCompleteModel.Root;
        public static RootTyped GetSensorCompleteTyped() => SensorsCompleteTyped.RootTyped;

        // GeneralDefinitions => Photometries
        public static string GetPhotometryMandatoryXml() => ResourceLoader.LoadEmbeddedXml(PhotometryMandatoryXml);
        public static string GetPhotometryCompleteXml() => ResourceLoader.LoadEmbeddedXml(PhotometryCompleteXml);
        public static Root GetPhotometryMandatoryModel() => PhotometryMandatoryModel.Root;
        public static RootTyped GetPhotometryMandatoryTyped() => PhotometryMandatoryTyped.RootTyped;
        public static Root GetPhotometryCompleteModel() => PhotometryCompleteModel.Root;
        public static RootTyped GetPhotometryCompleteTyped() => PhotometryCompleteTyped.RootTyped;
        
        // GeneralDefinitions => Spectrums
        public static string GetSpectrumMandatoryXml() => ResourceLoader.LoadEmbeddedXml(SpectrumMandatoryXml);
        public static string GetSpectrumCompleteXml() => ResourceLoader.LoadEmbeddedXml(SpectrumCompleteXml);
        public static Root GetSpectrumMandatoryModel() => SpectrumMandatoryModel.Root;
        public static RootTyped GetSpectrumMandatoryTyped() => SpectrumMandatoryTyped.RootTyped;
        public static Root GetSpectrumCompleteModel() => SpectrumCompleteModel.Root;
        public static RootTyped GetSpectrumCompleteTyped() => SensorsCompleteTyped.RootTyped;

        // GeneralDefinitions => LightSources
        public static string GetLightSourceMandatoryXml() => ResourceLoader.LoadEmbeddedXml(LightSourceMandatoryXml);
        public static string GetChangeableCompleteXml() => ResourceLoader.LoadEmbeddedXml(ChangeableCompleteXml);
        public static string GetFixedCompleteXml() => ResourceLoader.LoadEmbeddedXml(FixedCompleteXml);
        public static Root GetLightSourceMandatoryModel() => LightSourceMandatoryModel.Root;
        public static Root GetChangeableCompleteModel() => ChangeableCompleteModel.Root;
        public static Root GetFixedCompleteModel() => FixedCompleteModel.Root;

        // GeneralDefinitions => ControlGears
        public static string GetControlGearMandatoryXml() => ResourceLoader.LoadEmbeddedXml(ControlGearMandatoryXml);
        public static string GetControlGearCompleteXml() => ResourceLoader.LoadEmbeddedXml(ControlGearCompleteXml);
        public static Root GetControlGearMandatoryModel() => ControlGearMandatoryModel.Root;
        public static Root GetControlGearCompleteModel() => ControlGearCompleteModel.Root;

        // GeneralDefinitions => Equipments
        public static string GetEquipmentMandatoryXml() => ResourceLoader.LoadEmbeddedXml(EquipmentMandatoryXml);
        public static string GetEquipmentCompleteXml() => ResourceLoader.LoadEmbeddedXml(EquipmentCompleteXml);
        public static Root GetEquipmentMandatoryModel() => EquipmentMandatoryModel.Root;
        public static Root GetEquipmentCompleteModel() => EquipmentCompleteModel.Root;

        // GeneralDefinitions => Emitters
        public static string GetEmitterMandatoryXml() => ResourceLoader.LoadEmbeddedXml(EmitterMandatoryXml);
        public static string GetEmitterCompleteXml() => ResourceLoader.LoadEmbeddedXml(EmitterCompleteXml);
        public static Root GetEmitterMandatoryModel() => EmitterMandatoryModel.Root;
        public static Root GetEmitterCompleteModel() => EmitterCompleteModel.Root;

        // GeneralDefinitions => Geometries
        public static string GetGeometryMandatoryXml() => ResourceLoader.LoadEmbeddedXml(GeometryMandatoryXml);
        public static string GetGeometryCompleteXml() => ResourceLoader.LoadEmbeddedXml(GeometryCompleteXml);
        public static Root GetGeometryMandatoryModel() => GeometryMandatoryModel.Root;
        public static Root GetGeometryCompleteModel() => GeometryCompleteModel.Root;

        // GeneralDefinitions => ProductMetaData
        public static string GetMetaDataMandatoryXml() => ResourceLoader.LoadEmbeddedXml(MetaDataMandatoryXml);
        public static string GetMetaDataCompleteXml() => ResourceLoader.LoadEmbeddedXml(MetaDataCompleteXml);
        public static Root GetMetaDataMandatoryModel() => ProductMetaDataMandatoryModel.Root;
        public static Root GetMetaDataCompleteModel() => ProductMetaDataCompleteModel.Root;

        // GeneralDefinitions => Emitters
        public static string GetVariantMandatoryXml() => ResourceLoader.LoadEmbeddedXml(VariantMandatoryXml);
        public static string GetVariantCompleteXml() => ResourceLoader.LoadEmbeddedXml(VariantCompleteXml);
        public static Root GetVariantMandatoryModel() => VariantMandatoryModel.Root;
        public static Root GetVariantCompleteModel() => VariantCompleteModel.Root;

        // DescriptiveAttributes
        public static string GetDescriptiveAttributesXml() => ResourceLoader.LoadEmbeddedXml(DescriptiveAttributesXml);
        public static Root GetDescriptiveAttributesModel() => DescriptiveAttributesModel.Root;

        // Simple
        public static string GetRootWithHeaderXml() => ResourceLoader.LoadEmbeddedXml(RootWithHeaderXml);
        public static string GetRootWithHeaderUnintendXml() => ResourceLoader.LoadEmbeddedXml(RootWithUnintendedXml);
        public static Root GetRootWithHeaderModel() => RootWithHeaderModel.Root;
    }
}