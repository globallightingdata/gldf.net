using FluentAssertions;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Tests.TestData;
using Gldf.Net.XmlHelper;
using NUnit.Framework;
using System.IO;
using System.Xml.Schema;

namespace Gldf.Net.Tests.XmlHelperTests;

[TestFixture]
public class GldfXmlSchemaFactoryTests
{
    [Test]
    public void CreateXmlSchema_ShouldCreateSchemaAsExpected()
    {
        var xsd = GldfEmbeddedXsdLoader.Load(new FormatVersion(1, 0, 2));
        var xmlSchema = GldfXmlSchemaFactory.CreateXmlSchema(xsd);
        xmlSchema.Schemas().Count.Should().Be(1);
        foreach (var generatedSchema in xmlSchema.Schemas())
        {
            using var stringWriter = new StringWriter();
            generatedSchema.As<XmlSchema>().Write(stringWriter);
            stringWriter.ToString().Should().Contain(@"xs:schema version=""1.0.0-rc.2""");
        }
    }

    [Test]
    public void GetEmbeddedXmlSchema_ShouldReturnExpecteSchema_WhenXmlParameter()
    {
        var xml = EmbeddedXmlTestData.GetHeaderMandatoryXml();
        var xmlSchema = GldfXmlSchemaFactory.GetEmbeddedXmlSchema(xml);
        xmlSchema.Schemas().Count.Should().Be(1);
        foreach (var generatedSchema in xmlSchema.Schemas())
        {
            using var stringWriter = new StringWriter();
            generatedSchema.As<XmlSchema>().Write(stringWriter);
            stringWriter.ToString().Should().Contain(@"xs:schema version=""1.0.0-rc.2""");
        }
    }
    
    [Test]
    public void GetEmbeddedXmlSchema_ShouldReturnExpecteSchema_WhenKnownFormatVersionParameter()
    {
        var xmlSchema = GldfXmlSchemaFactory.GetEmbeddedXmlSchema(new FormatVersion(1, 0, 1));
        xmlSchema.Schemas().Count.Should().Be(1);
        foreach (var generatedSchema in xmlSchema.Schemas())
        {
            using var stringWriter = new StringWriter();
            generatedSchema.As<XmlSchema>().Write(stringWriter);
            stringWriter.ToString().Should().Contain(@"xs:schema version=""1.0.0-rc.1""");
        }
    }

    [Test]
    public void GetEmbeddedXmlSchema_ShouldReturnLatestSchema_WhenUnknownVersion()
    {
        var xmlSchema = GldfXmlSchemaFactory.GetEmbeddedXmlSchema(new FormatVersion(int.MaxValue, 0));
        xmlSchema.Schemas().Count.Should().Be(1);
        foreach (var generatedSchema in xmlSchema.Schemas())
        {
            using var stringWriter = new StringWriter();
            generatedSchema.As<XmlSchema>().Write(stringWriter);
            stringWriter.ToString().Should().Contain(@"xs:schema version=""1.0.0-rc.2""");
        }
    }
}