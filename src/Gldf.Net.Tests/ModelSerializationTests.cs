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
        public void SerializeModel_ShouldReturnExpectedXml(Root model, string expectedXml)
        {
            var gldfSerializer = new GldfXmlSerializer();
            var serializedXml = gldfSerializer.SerializeToString(model);
            expectedXml.ShouldBe().EquivalentTo(serializedXml);
        }
        
        [TestCaseSource(nameof(TestCaseData))]
        public void DeserializeXml_ShouldReturnExpectedModel(Root expectedModel, string xml)
        {
            var gldfSerializer = new GldfXmlSerializer();
            var serializedXml = gldfSerializer.DeserializeFromString(xml);
            expectedModel.Should().BeEquivalentTo(serializedXml);
        }

        [TestCaseSource(nameof(TestCaseData))]
        public void SerializeAndDeserializeModel_ShouldBeSameAsOrigin(Root model, string _)
        {
            var gldfSerializer = new GldfXmlSerializer();
            var xml = gldfSerializer.SerializeToString(model);
            var resultModel = gldfSerializer.DeserializeFromString(xml);
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
            new TestCaseData(EmbeddedXmlTestData.GetChangeableCompleteModel(),
                    EmbeddedXmlTestData.GetChangeableCompleteXml())
                {TestName = "LightSource changeable complete property set"},
            new TestCaseData(EmbeddedXmlTestData.GetFixedCompleteModel(),
                    EmbeddedXmlTestData.GetFixedCompleteXml())
                {TestName = "LightSource fixed complete property set"},
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
            new TestCaseData(EmbeddedXmlTestData.GetEmitterMandatoryModel(),
                    EmbeddedXmlTestData.GetEmitterMandatoryXml())
                {TestName = "Emitter mandatory property set"},
            new TestCaseData(EmbeddedXmlTestData.GetEmitterCompleteModel(),
                    EmbeddedXmlTestData.GetEmitterCompleteXml())
                {TestName = "Emitter complete property set"},
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
                {TestName = "Variant mandatory property set"},
            new TestCaseData(EmbeddedXmlTestData.GetVariantCompleteModel(),
                    EmbeddedXmlTestData.GetVariantCompleteXml())
                {TestName = "Variant complete property set"},
            new TestCaseData(EmbeddedXmlTestData.GetDescriptiveAttributesModel(),
                    EmbeddedXmlTestData.GetDescriptiveAttributesXml())
                {TestName = "DescriptiveAttributes"}
        };
    }
}