using FluentAssertions;
using Gldf.Net.Domain.Typed;
using Gldf.Net.Parser;
using Gldf.Net.Tests.TestData;
using NUnit.Framework;
using System.Collections.Generic;

namespace Gldf.Net.Tests;

[TestFixture]
public class ModelParserTests
{
    [TestCaseSource(nameof(TestCaseData))]
    public void ParseXml_ShouldBeExpected(string xml, RootTyped expected)
    {
        var gldfParser = new GldfParser(new ParserSettings(LocalFileLoadBehaviour.Skip));
        var rootTyped = gldfParser.ParseFromXml(xml);
        AssertionOptions.FormattingOptions.MaxDepth = 10;
        AssertionOptions.FormattingOptions.MaxLines = 1000;
        rootTyped.Should().BeEquivalentTo(expected, opt => opt.WithStrictOrdering());
    }

    public static IEnumerable<TestCaseData> TestCaseData => new[]
    {
        new TestCaseData(EmbeddedXmlTestData.GetHeaderMandatoryXml(),
                EmbeddedXmlTestData.GetHeaderMandatoryTyped())
            { TestName = "Header mandatory property set" },
        new TestCaseData(EmbeddedXmlTestData.GetHeaderCompleteXml(),
                EmbeddedXmlTestData.GetHeaderCompleteTyped())
            { TestName = "Header complete property set" },
        new TestCaseData(EmbeddedXmlTestData.GetFileMandatoryXml(),
                EmbeddedXmlTestData.GetFileMandatoryTyped())
            { TestName = "File mandatory property set" },
        new TestCaseData(EmbeddedXmlTestData.GetFileCompleteXml(),
                EmbeddedXmlTestData.GetFileCompleteTyped())
            { TestName = "File complete property set" },
        new TestCaseData(EmbeddedXmlTestData.GetSensorMandatoryXml(),
                EmbeddedXmlTestData.GetSensorMandatoryTyped())
            { TestName = "Sensor mandatory property set" },
        new TestCaseData(EmbeddedXmlTestData.GetSensorCompleteXml(),
                EmbeddedXmlTestData.GetSensorCompleteTyped())
            { TestName = "Sensor complete property set" },
        new TestCaseData(EmbeddedXmlTestData.GetPhotometryMandatoryXml(),
                EmbeddedXmlTestData.GetPhotometryMandatoryTyped())
            { TestName = "Photometry mandatory property set" },
        new TestCaseData(EmbeddedXmlTestData.GetPhotometryCompleteXml(),
                EmbeddedXmlTestData.GetPhotometryCompleteTyped())
            { TestName = "Photometry complete property set" },
        new TestCaseData(EmbeddedXmlTestData.GetSpectrumMandatoryXml(),
                EmbeddedXmlTestData.GetSpectrumMandatoryTyped())
            { TestName = "Spectrum mandatory property set" },
        new TestCaseData(EmbeddedXmlTestData.GetSpectrumCompleteXml(),
                EmbeddedXmlTestData.GetSpectrumCompleteTyped())
            { TestName = "Spectrum complete property set" },
        new TestCaseData(EmbeddedXmlTestData.GetLightSourceMandatoryXml(),
                EmbeddedXmlTestData.GetLightSourceMandatoryTyped())
            { TestName = "LightSource mandatory property set" },
        new TestCaseData(EmbeddedXmlTestData.GetChangeableCompleteXml(),
                EmbeddedXmlTestData.GetChangeableCompleteTyped())
            { TestName = "Changeable complete property set" },
        new TestCaseData(EmbeddedXmlTestData.GetFixedCompleteXml(),
                EmbeddedXmlTestData.GetFixedCompleteTyped())
            { TestName = "Fixed complete property set" },
        new TestCaseData(EmbeddedXmlTestData.GetMultiChannelCompleteXml(),
                EmbeddedXmlTestData.GetMultiChannelCompleteTyped())
        { TestName = "MultiChannel complete property set" },
        new TestCaseData(EmbeddedXmlTestData.GetControlGearMandatoryXml(),
                EmbeddedXmlTestData.GetControlGearMandatoryTyped())
            { TestName = "ControlGear mandatory property set" },
        new TestCaseData(EmbeddedXmlTestData.GetControlGearCompleteXml(),
                EmbeddedXmlTestData.GetControlGearCompleteTyped())
            { TestName = "ControlGear complete property set" },
        new TestCaseData(EmbeddedXmlTestData.GetEquipmentMandatoryXml(),
                EmbeddedXmlTestData.GetEquipmentMandatoryTyped())
            { TestName = "Equipment mandatory property set" },
        new TestCaseData(EmbeddedXmlTestData.GetEquipmentCompleteXml(),
                EmbeddedXmlTestData.GetEquipmentCompleteTyped())
            { TestName = "Equipment complete property set" },
        new TestCaseData(EmbeddedXmlTestData.GetGeometryMandatoryXml(),
                EmbeddedXmlTestData.GetGeometryMandatoryTyped())
            { TestName = "Geometry mandatory property set" },
        new TestCaseData(EmbeddedXmlTestData.GetGeometryCompleteXml(),
                EmbeddedXmlTestData.GetGeometryCompleteTyped())
            { TestName = "Geometry complete property set" },
        new TestCaseData(EmbeddedXmlTestData.GetEmitterMandatoryXml(),
                EmbeddedXmlTestData.GetEmitterMandatoryTyped())
            { TestName = "Emitter mandatory property set" },
        new TestCaseData(EmbeddedXmlTestData.GetEmitterCompleteXml(),
                EmbeddedXmlTestData.GetEmitterCompleteTyped())
            { TestName = "Emitter complete property set" },
        new TestCaseData(EmbeddedXmlTestData.GetMetaDataMandatoryXml(),
                EmbeddedXmlTestData.GetMetaDataMandatoryTyped())
            { TestName = "MetaData mandatory property set" },
        new TestCaseData(EmbeddedXmlTestData.GetMetaDataCompleteXml(),
                EmbeddedXmlTestData.GetMetaDataCompleteTyped())
            { TestName = "MetaData complete property set" },
        new TestCaseData(EmbeddedXmlTestData.GetVariantMandatoryXml(),
                EmbeddedXmlTestData.GetVariantMandatoryTyped())
            { TestName = "Variant mandatory property set" },
        new TestCaseData(EmbeddedXmlTestData.GetVariantCompleteXml(),
                EmbeddedXmlTestData.GetVariantCompleteTyped())
            { TestName = "Variant complete property set" }
    };
}