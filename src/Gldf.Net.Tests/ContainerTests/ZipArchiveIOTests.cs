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
        zipArchiveIODerived.MetaInfoSerializerBase.Should().NotBeNull();
        zipArchiveIODerived.CompressionLevelBase.Should().Be(CompressionLevel.Optimal);
        zipArchiveIODerived.EncodingBase.Should().BeEquivalentTo(Encoding.UTF8);
    }

    [Test]
    public void Ctor_Should_SetParameter_InBaseClass()
    {
        var gldfSerializer = new GldfXmlSerializer();
        var metaInfoSerializer = new MetaInfoSerializer();
        var compressionLevel = CompressionLevel.NoCompression;
        var encoding = Encoding.ASCII;

        var sut = new ZipArchiveIODerived(gldfSerializer, metaInfoSerializer, compressionLevel, encoding);

        sut.GldfSerializerBase.Should().BeSameAs(gldfSerializer);
        sut.MetaInfoSerializerBase.Should().BeSameAs(metaInfoSerializer);
        sut.CompressionLevelBase.Should().Be(compressionLevel);
        sut.EncodingBase.Should().BeSameAs(encoding);
    }

    internal class ZipArchiveIODerived : ZipArchiveIO
    {
        internal IGldfXmlSerializer GldfSerializerBase => GldfXmlSerializer;
        internal IMetaInfoSerializer MetaInfoSerializerBase => MetaInfoSerializer;
        internal Encoding EncodingBase => Encoding;
        internal CompressionLevel CompressionLevelBase => CompressionLevel;

        public ZipArchiveIODerived()
        {
        }

        public ZipArchiveIODerived(IGldfXmlSerializer gldfXmlSerializer, IMetaInfoSerializer metaInfoSerializer, CompressionLevel compressionLevel,
            Encoding encoding)
            : base(gldfXmlSerializer, metaInfoSerializer, compressionLevel, encoding)
        {
        }
    }
}