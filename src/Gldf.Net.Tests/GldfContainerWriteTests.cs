using FluentAssertions;
using Gldf.Net.Container;
using Gldf.Net.Domain;
using Gldf.Net.Exceptions;
using Gldf.Net.Tests.TestData;
using NUnit.Framework;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Gldf.Net.Tests
{
    [TestFixture]
    public class GldfContainerWriteTests
    {
        private GldfContainer _gldfContainer;
        private string _tempFile1;
        private string _tempFile2;

        [SetUp]
        public void SetUp()
        {
            _gldfContainer = new GldfContainer();
            _tempFile1 = Path.GetTempFileName();
            _tempFile2 = Path.GetTempFileName();
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_tempFile1);
            File.Delete(_tempFile2);
        }

        [Test]
        public void WriteToFile_ShouldCreateArchive_InSubDirectory_When_SubDirectoryNotExists()
        {
            var tempFileName = $"{Guid.NewGuid()}.gldf";
            var tempSubDirectory = Path.Combine(Path.GetTempPath(), $"gldf-{DateTime.Now.Ticks}");
            var tempPath = Path.Combine(tempSubDirectory, tempFileName);
            var gldfArchive = new GldfArchive(new Root());

            _gldfContainer.WriteToFile(tempPath, gldfArchive);
            var archiveExists = File.Exists(tempPath);
            Directory.Delete(tempSubDirectory, true);

            archiveExists.Should().BeTrue();
        }

        [Test]
        public void WriteToFile_ShouldOverwrite_Container_WhenAlreadyExists()
        {
            var gldfArchive1 = new GldfArchive(new Root {Checksum = "Old"});
            var gldfArchive2 = new GldfArchive(new Root {Checksum = "New"});
            var zipArchiveReader = new ZipArchiveReader();

            _gldfContainer.WriteToFile(_tempFile1, gldfArchive1);
            var checksumBefore = zipArchiveReader.ReadArchive(_tempFile1).Product.Checksum;
            _gldfContainer.WriteToFile(_tempFile1, gldfArchive2);
            var checksumAfter = zipArchiveReader.ReadArchive(_tempFile1).Product.Checksum;

            checksumBefore.Should().Be(gldfArchive1.Product.Checksum);
            checksumAfter.Should().Be(gldfArchive2.Product.Checksum);
        }

        [Test]
        public void WriteToFile_ShouldCreate_SameGldfArchive_AsExpected()
        {
            var rootWithHeaderModel = EmbeddedXmlTestData.GetRootWithHeaderModel();
            var gldfArchive = new GldfArchive(rootWithHeaderModel);
            var expectedArchiveBytes = EmbeddedGldfTestData.GetGldfWithFiles();
            var zipArchiveReader = new ZipArchiveReader();

            gldfArchive.Assets.Geometries.Add(new ContainerFile("geometry.l3d", new byte[1]));
            gldfArchive.Assets.Geometries.Add(new ContainerFile("geometry.r3d", new byte[2]));
            gldfArchive.Assets.Images.Add(new ContainerFile("image.jpg", new byte[3]));
            gldfArchive.Assets.Images.Add(new ContainerFile("image.png", new byte[4]));
            gldfArchive.Assets.Photometries.Add(new ContainerFile("lvk.ldt", new byte[5]));
            gldfArchive.Assets.Photometries.Add(new ContainerFile("lvk.ies", new byte[6]));
            gldfArchive.Assets.Documents.Add(new ContainerFile("document.docx", new byte[7]));
            gldfArchive.Assets.Sensors.Add(new ContainerFile("sensor.xml", new byte[8]));
            gldfArchive.Assets.Spectrums.Add(new ContainerFile("spectrum.txt", new byte[9]));
            gldfArchive.Assets.Symbols.Add(new ContainerFile("symbol.svg", new byte[10]));
            gldfArchive.Assets.Other.Add(new ContainerFile("project.c4d", new byte[11]));

            _gldfContainer.WriteToFile(_tempFile1, gldfArchive);
            File.WriteAllBytes(_tempFile2, expectedArchiveBytes);

            var loadedWrittenArchive = zipArchiveReader.ReadArchive(_tempFile1);
            var expectedArchive = zipArchiveReader.ReadArchive(_tempFile2);

            loadedWrittenArchive.Should().BeEquivalentTo(expectedArchive);
        }

        [Test]
        public void WriteToFile_Should_OnlyCreate_ProductEntry_WhenNoAssets()
        {
            var gldfArchive = new GldfArchive(new Root());
            _gldfContainer.WriteToFile(_tempFile1, gldfArchive);
            using var zipArchive = ZipFile.Open(_tempFile1, ZipArchiveMode.Read);

            var archiveEntryCount = zipArchive.Entries.Count;
            var firstEntryName = zipArchive.Entries.First().Name;

            archiveEntryCount.Should().Be(1);
            firstEntryName.Should().Be("product.xml");
        }

        [Test]
        public void WriteToFile_ShouldThrow_ArgumentNullException_When_PathIsNull()
        {
            Action act = () => _gldfContainer.WriteToFile(null, new GldfArchive());

            act.Should()
                .ThrowExactly<GldfContainerException>()
                .WithMessage("Failed to create GldfArchive*")
                .WithInnerExceptionExactly<ArgumentNullException>()
                .WithMessage("Path cannot be null. (Parameter 'path')");
        }

        [Test]
        public void WriteToFile_ShouldThrow_RootNotFoundException_When_ProductIsNull()
        {
            Action act = () => _gldfContainer.WriteToFile(_tempFile1, new GldfArchive(null));

            act.Should()
                .ThrowExactly<GldfContainerException>()
                .WithMessage("Failed to create GldfArchive*")
                .WithInnerExceptionExactly<RootNotFoundException>()
                .WithMessage("Product must not be null");
        }
    }
}