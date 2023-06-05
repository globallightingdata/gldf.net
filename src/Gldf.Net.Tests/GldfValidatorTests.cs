using FluentAssertions;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Tests.TestData;
using Gldf.Net.Validation.Model;
using Gldf.Net.XmlHelper;
using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Xml.Schema;

namespace Gldf.Net.Tests;

[TestFixture]
public class GldfValidatorTests
{

    private string _tempGldfPath;

    private static readonly TestCaseData[] ValidGldfTestCases = EmbeddedGldfTestData.ValidGldfTestCases;

    [OneTimeSetUp]
    public void SetUp()
    {
        _tempGldfPath = Path.GetTempFileName();
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        File.Delete(_tempGldfPath);
    }

    [Test]
    public void Ctor_ShouldThrow_WhenEncodingIsNull()
    {
        var act = new Action(() => _ = new GldfValidator((Encoding)null));
        act.Should()
            .Throw<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'encoding')");
    }
    
    [Test]
    public void Ctor_ShouldThrow_WhenXmlSchemaSetIsNull()
    {
        var act = new Action(() => _ = new GldfValidator((XmlSchemaSet)null));
        act.Should()
            .Throw<ArgumentNullException>()
            .WithMessage("Value cannot be null. (Parameter 'xmlSchema')");
    }
    
    [Test]
    public void Ctor_ShouldThrow_WhenXmlSchemaSetIsNull_AndEncodingIsNull()
    {
        void Test(Action test, string expectedMessage) => test.Should()
            .ThrowExactly<ArgumentNullException>()
            .WithMessage(expectedMessage);

        Test(() => _ = new GldfValidator(null, null), "Value cannot be null. (Parameter 'encoding')");
        Test(() => _ = new GldfValidator(null, new XmlSchemaSet()), "Value cannot be null. (Parameter 'encoding')");
        Test(() => _ = new GldfValidator(Encoding.UTF8, null), "Value cannot be null. (Parameter 'xmlSchema')");
    }
    
    [Test, TestCaseSource(nameof(ValidGldfTestCases))]
    public void ValidateGldf_ShouldReturnNoHints(byte[] gldf)
    {
        using var memoryStream = new MemoryStream(gldf);
        var container = new GldfContainerReader().ReadFromGldfStream(memoryStream, false);
        var gldfValidator = new GldfValidator();
        var validationHints = gldfValidator.ValidateGldf(container);
        validationHints.Should().HaveCount(0);
    }
    
    [Test, TestCaseSource(nameof(ValidGldfTestCases))]
    public void ValidateGldf_ShouldReturnNoHints_WhenCustomSchemaIsSet(byte[] gldf)
    {
        var schema = GldfEmbeddedXsdLoader.Load(new FormatVersion(1, 0, 2));
        var xmlSchema = GldfXmlSchemaFactory.CreateXmlSchema(schema);
        using var memoryStream = new MemoryStream(gldf);
        var container = new GldfContainerReader().ReadFromGldfStream(memoryStream, false);
        var gldfValidator = new GldfValidator(xmlSchema);
        var validationHints = gldfValidator.ValidateGldf(container);
        validationHints.Should().HaveCount(0);
    }
    
    [Test, TestCaseSource(nameof(ValidGldfTestCases))]
    public void ValidateGldf_ShouldReturnNoHints_WhenEncodingIsSet(byte[] gldf)
    {
        using var memoryStream = new MemoryStream(gldf);
        var container = new GldfContainerReader().ReadFromGldfStream(memoryStream, false);
        var gldfValidator = new GldfValidator(Encoding.UTF8);
        var validationHints = gldfValidator.ValidateGldf(container);
        validationHints.Should().HaveCount(0);
    }
    
    [Test, TestCaseSource(nameof(ValidGldfTestCases))]
    public void ValidateGldf_ShouldReturnNoHints_WhenSchemaAndEncodingIsSet(byte[] gldf)
    {
        var schema = GldfEmbeddedXsdLoader.Load(new FormatVersion(1, 0, 2));
        var xmlSchema = GldfXmlSchemaFactory.CreateXmlSchema(schema);
        using var memoryStream = new MemoryStream(gldf);
        var container = new GldfContainerReader().ReadFromGldfStream(memoryStream, false);
        var gldfValidator = new GldfValidator(Encoding.UTF8, xmlSchema);
        var validationHints = gldfValidator.ValidateGldf(container);
        validationHints.Should().HaveCount(0);
    }
    
    [Test, TestCaseSource(nameof(ValidGldfTestCases))]
    public void ValidateGldfFile_ShouldReturnNoHints(byte[] gldf)
    {
        File.WriteAllBytes(_tempGldfPath, gldf);
        var gldfValidator = new GldfValidator();
        var validationHints = gldfValidator.ValidateGldfFile(_tempGldfPath, ValidationFlags.All);
        validationHints.Should().HaveCount(0);
    }
    
    [Test, TestCaseSource(nameof(ValidGldfTestCases))]
    public void ValidateGldfStream_ShouldReturnNoHints(byte[] gldf)
    {
        using var memoryStream = new MemoryStream(gldf);
        var gldfValidator = new GldfValidator();
        var validationHints = gldfValidator.ValidateGldfStream(memoryStream, false, ValidationFlags.All);
        validationHints.Should().HaveCount(0);
    }
}