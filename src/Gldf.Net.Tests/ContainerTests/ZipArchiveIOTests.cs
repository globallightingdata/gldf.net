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

        zipArchiveIODerived.SerializerBase.Should().NotBeNull();
        zipArchiveIODerived.CompressionLevelBase.Should().Be(CompressionLevel.Optimal);
        zipArchiveIODerived.EncodingBase.Should().BeEquivalentTo(Encoding.UTF8);
    }

    [Test]
    public void Ctor_Should_SetParameter_InBaseClass()
    {
        var serializer = new GldfXmlSerializer();
        var compressionLevel = CompressionLevel.NoCompression;
        var encoding = Encoding.ASCII;

        var sut = new ZipArchiveIODerived(serializer, compressionLevel, encoding);

        sut.SerializerBase.Should().BeSameAs(serializer);
        sut.CompressionLevelBase.Should().Be(compressionLevel);
        sut.EncodingBase.Should().BeSameAs(encoding);
    }

    internal class ZipArchiveIODerived : ZipArchiveIO
    {
        internal IGldfXmlSerializer SerializerBase => GldfXmlSerializer;
        internal Encoding EncodingBase => Encoding;
        internal CompressionLevel CompressionLevelBase => CompressionLevel;

        public ZipArchiveIODerived()
        {
        }

        public ZipArchiveIODerived(IGldfXmlSerializer gldfXmlSerializer, CompressionLevel compressionLevel,
            Encoding encoding)
            : base(gldfXmlSerializer, compressionLevel, encoding)
        {
        }
    }
}