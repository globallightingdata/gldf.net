using FluentAssertions;
using Gldf.Net.Abstract;
using Gldf.Net.Container;
using NUnit.Framework;
using System.IO.Compression;
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

    }
}