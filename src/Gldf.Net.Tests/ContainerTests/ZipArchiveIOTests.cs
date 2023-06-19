using FluentAssertions;
using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Tests.TestData;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

// ReSharper disable InconsistentNaming
namespace Gldf.Net.Tests.ContainerTests;

[TestFixture]
public class ZipArchiveIOTests
{
    [Test]
    public void Ctor_Should_SetParameterDefaults_AsExpected()
    {
        var zipArchiveIODerived = new ZipArchiveIODerived();

        zipArchiveIODerived.GldfSerializerBase.Should().NotBeNull();
        zipArchiveIODerived.GldfSerializerBase.Encoding.Should().Be(Encoding.UTF8);
        zipArchiveIODerived.MetaInfoSerializerBase.Should().NotBeNull();
        zipArchiveIODerived.MetaInfoSerializerBase.Encoding.Should().Be(Encoding.UTF8);
        zipArchiveIODerived.CompressionLevelBase.Should().Be(CompressionLevel.Optimal);
    }

    [Test]
    public void Ctor_Should_SetParameter_InBaseClass()
    {
        var expectedEncoding = Encoding.UTF32;
        var sut = new ZipArchiveIODerived(expectedEncoding);
        sut.GldfSerializerBase.Encoding.Should().Be(expectedEncoding);
        sut.MetaInfoSerializerBase.Encoding.Should().Be(expectedEncoding);
    }

    [Test, TestCaseSource(nameof(TestGldfsWithEncoding))]
    public void OpenReadFile_ShouldReadExpectedFileName(byte[] gldf)
    {
        var tempFile = Path.GetTempFileName();
        try
        {
            File.WriteAllBytes(tempFile, gldf);
            using var zipArchive = ZipArchiveIODerived.OpenRead(tempFile);
            zipArchive.Entries.Select(e => e.Name).Should().Contain("Äöü°§.ldt");
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [Test, TestCaseSource(nameof(TestGldfsWithEncoding))]
    public void OpenReadStream_ShouldReadExpectedFileName(byte[] gldf)
    {
        using var memoryStream = new MemoryStream(gldf);
        using var zipArchive = ZipArchiveIODerived.OpenRead(memoryStream, false);
        zipArchive.Entries.Select(e => e.Name).Should().Contain("Äöü°§.ldt");
    }

    public static IEnumerable<TestCaseData> TestGldfsWithEncoding => new[]
    {
        new TestCaseData(EmbeddedGldfTestData.GetGldfWithEncodingUtf8()).SetName("When Encoding Utf8"),
        new TestCaseData(EmbeddedGldfTestData.GetGldfWithCodepage850()).SetName("When CodePage 850")
    };

    internal class ZipArchiveIODerived : ZipArchiveIO
    {
        internal IGldfXmlSerializer GldfSerializerBase => GldfXmlSerializer;
        internal IMetaInfoSerializer MetaInfoSerializerBase => MetaInfoSerializer;
        internal CompressionLevel CompressionLevelBase => CompressionLevel;

        public ZipArchiveIODerived()
        {
        }

        public ZipArchiveIODerived(Encoding encoding) : base(encoding)
        {
        }

        public new static ZipArchive OpenRead(string filepath) =>
            ZipArchiveIO.OpenRead(filepath);

        public new static ZipArchive OpenRead(Stream zipStream, bool leaveOpen) =>
            ZipArchiveIO.OpenRead(zipStream, leaveOpen);
    }
}