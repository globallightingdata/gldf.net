using FluentAssertions;
using Gldf.Net.Domain;
using Gldf.Net.Tests.TestData;
using Gldf.Net.Tests.TestHelper;
using NUnit.Framework;
using System.Collections.Generic;

namespace Gldf.Net.Tests
{
    [TestFixture]
    public class ModelSerializationTests
    {
        [TestCaseSource(nameof(TestCaseData))]
        public void Serialize_Model_Should_Return_Expected_Xml(Root model, string expectedXml)
        {
            var gldfSerializer = new GldfXmlSerializer();
            var serializedXml = gldfSerializer.SerializeToXml(model);
            expectedXml.ShouldBe().EquivalentTo(serializedXml);
        }

        [TestCaseSource(nameof(TestCaseData))]
        public void SerializeAndDeserialize_Model_Should_BeSameAs_Origin(Root model, string _)
        {
            var gldfSerializer = new GldfXmlSerializer();
            var xml = gldfSerializer.SerializeToXml(model);
            var resultModel = gldfSerializer.DeserializeFromXml(xml);
            resultModel.Should().BeEquivalentTo(model);
        }

        public static IEnumerable<TestCaseData> TestCaseData => new[]
        {
            new TestCaseData(EmbeddedXmlTestData.GetHeaderMandatoryModel(),
                    EmbeddedXmlTestData.GetHeaderMandatoryXml())
                {TestName = "Header mandatory property set"},
            new TestCaseData(EmbeddedXmlTestData.GetHeaderCompleteModel(),
                    EmbeddedXmlTestData.GetHeaderCompleteXml())
                {TestName = "Header complete property set"},
            new TestCaseData(EmbeddedXmlTestData.GetFileMandatoryModel(),
                    EmbeddedXmlTestData.GetFileMandatoryXml())
                {TestName = "Files mandatory property set"},
            new TestCaseData(EmbeddedXmlTestData.GetFileCompleteModel(),
                    EmbeddedXmlTestData.GetFileCompleteXml())
                {TestName = "Files complete property set"},
            new TestCaseData(EmbeddedXmlTestData.GetSensorMandatoryModel(),
                    EmbeddedXmlTestData.GetSensorMandatoryXml())
                {TestName = "Sensors mandatory property set"},
            new TestCaseData(EmbeddedXmlTestData.GetSensorCompleteModel(),
                    EmbeddedXmlTestData.GetSensorCompleteXml())
                {TestName = "Sensors complete property set"},
            new TestCaseData(EmbeddedXmlTestData.GetPhotometryMandatoryModel(),
                    EmbeddedXmlTestData.GetPhotometryMandatoryXml())
                {TestName = "Photometry mandatory property set"},
            new TestCaseData(EmbeddedXmlTestData.GetPhotometryCompleteModel(),
                    EmbeddedXmlTestData.GetPhotometryCompleteXml())
                {TestName = "Photometry complete property set"},
            new TestCaseData(EmbeddedXmlTestData.GetSpectrumMandatoryModel(),
                    EmbeddedXmlTestData.GetSpectrumMandatoryXml())
                {TestName = "Spectrum mandatory property set"},
            new TestCaseData(EmbeddedXmlTestData.GetSpectrumCompleteModel(),
                    EmbeddedXmlTestData.GetSpectrumCompleteXml())
                {TestName = "Spectrum complete property set"},
            new TestCaseData(EmbeddedXmlTestData.GetLightSourceMandatoryModel(),
                    EmbeddedXmlTestData.GetLightSourceMandatoryXml())
                {TestName = "LightSource mandatory property set"},
            new TestCaseData(EmbeddedXmlTestData.GetLightSourceCompleteModel(),
                    EmbeddedXmlTestData.GetLightSourceCompleteXml())
                {TestName = "LightSource complete property set"},
            new TestCaseData(EmbeddedXmlTestData.GetControlGearMandatoryModel(),
                    EmbeddedXmlTestData.GetControlGearMandatoryXml())
                {TestName = "ControlGear mandatory property set"},
            new TestCaseData(EmbeddedXmlTestData.GetControlGearCompleteModel(),
                    EmbeddedXmlTestData.GetControlGearCompleteXml())
                {TestName = "ControlGear complete property set"},
            new TestCaseData(EmbeddedXmlTestData.GetEquipmentMandatoryModel(),
                    EmbeddedXmlTestData.GetEquipmentMandatoryXml())
                {TestName = "Equipment mandatory property set"},
            new TestCaseData(EmbeddedXmlTestData.GetEquipmentCompleteModel(),
                    EmbeddedXmlTestData.GetEquipmentCompleteXml())
                {TestName = "Equipment complete property set"},
            new TestCaseData(EmbeddedXmlTestData.GetGeometryMandatoryModel(),
                    EmbeddedXmlTestData.GetGeometryMandatoryXml())
                {TestName = "Geometry mandatory property set"},
            new TestCaseData(EmbeddedXmlTestData.GetGeometryCompleteModel(),
                    EmbeddedXmlTestData.GetGeometryCompleteXml())
                {TestName = "Geometry complete property set"},
            new TestCaseData(EmbeddedXmlTestData.GetMetaDataMandatoryModel(),
                    EmbeddedXmlTestData.GetMetaDataMandatoryXml())
                {TestName = "ProductMetaData mandatory property set"},
            new TestCaseData(EmbeddedXmlTestData.GetMetaDataCompleteModel(),
                    EmbeddedXmlTestData.GetMetaDataCompleteXml())
                {TestName = "ProductMetaData complete property set"},
            new TestCaseData(EmbeddedXmlTestData.GetVariantMandatoryModel(),
                    EmbeddedXmlTestData.GetVariantMandatoryXml())
                {TestName = "ProductVariant mandatory property set"},
            new TestCaseData(EmbeddedXmlTestData.GetVariantCompleteModel(),
                    EmbeddedXmlTestData.GetVariantCompleteXml())
                {TestName = "ProductVariant complete property set"},
            new TestCaseData(EmbeddedXmlTestData.GetDescriptiveAttributesModel(),
                    EmbeddedXmlTestData.GetDescriptiveAttributesXml())
                {TestName = "DescriptiveAttributes"}
        };
    }
}