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
        var gldfParser = new GldfParser(new ParserSettings
        {
            LocalFileLoadBehaviour = LocalFileLoadBehaviour.Skip,
            OnlineFileLoadBehaviour = OnlineFileLoadBehaviour.Skip
        });
        var rootTyped = gldfParser.ParseFromXml(xml);
        rootTyped.Should().BeEquivalentTo(expected);
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
        
        // todo SpectrumComplete
        // new TestCaseData(EmbeddedXmlTestData.GetSpectrumCompleteXml(),
        //         EmbeddedXmlTestData.GetSpectrumCompleteTyped())
        //     { TestName = "Spectrum complete property set" },
        
        // todo LightSourceMandatory
        // todo LightSourceChangeableComplete
        // todo LightSourceFixedComplete
        // todo ControlGearMandatory
        // todo ControlGearComplete
        // todo EquipmentMandatory
        // todo EquipmentComplete
        // todo EquipmentMandatory
        // todo EquipmentComplete
        // todo GeometryMandatory
        // todo GeometryComplete
        // todo EmitterMandatory
        // todo EmitterComplete
        // todo ProductMetaDataMandatory
        // todo ProductMetaDataComplete
        // todo VariantMandatory
        // todo VariantComplete
    };
}