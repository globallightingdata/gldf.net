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

namespace Gldf.Net.Tests.ContainerTests
{
    [TestFixture]
    public class ZipArchiveWriterTests
    {
        private ZipArchiveWriter _zipArchiveWriter;
        private string _tempFile1;
        private string _tempFile2;

        [SetUp]
        public void SetUp()
        {
            _zipArchiveWriter = new ZipArchiveWriter();
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
        public void Write_ShouldCreateArchive_InSubDirectory_When_SubDirectoryNotExists()
        {
            var tempFileName = $"{Guid.NewGuid()}.gldf";
            var tempSubDirectory = Path.Combine(Path.GetTempPath(), $"gldf-{DateTime.Now.Ticks}");
            var tempPath = Path.Combine(tempSubDirectory, tempFileName);
            var gldfContainer = new GldfContainer(new Root());

            _zipArchiveWriter.Write(tempPath, gldfContainer);
            var containerExists = File.Exists(tempPath);
            Directory.Delete(tempSubDirectory, true);

            containerExists.Should().BeTrue();
        }

        [Test]
        public void Write_ShouldOverwrite_Container_WhenAlreadyExists()
        {
            var gldfContainer1 = new GldfContainer(new Root { Checksum = "Old" });
            var gldfContainer2 = new GldfContainer(new Root { Checksum = "New" });
            var zipArchiveReader = new ZipArchiveReader();

            _zipArchiveWriter.Write(_tempFile1, gldfContainer1);
            var checksumBefore = zipArchiveReader.ReadContainer(_tempFile1).Product.Checksum;
            _zipArchiveWriter.Write(_tempFile1, gldfContainer2);
            var checksumAfter = zipArchiveReader.ReadContainer(_tempFile1).Product.Checksum;

            checksumBefore.Should().Be(gldfContainer1.Product.Checksum);
            checksumAfter.Should().Be(gldfContainer2.Product.Checksum);
        }

        [Test]
        public void Write_ShouldCreate_SameGldfArchive_AsExpected()
        {
            var rootWithHeaderModel = EmbeddedXmlTestData.GetRootWithHeaderModel();
            var gldfContainer = new GldfContainer(rootWithHeaderModel);
            var expectedBytes = EmbeddedGldfTestData.GetGldfWithFiles();
            var zipArchiveReader = new ZipArchiveReader();

            gldfContainer.Assets.Geometries.Add(new ContainerFile("geometry.l3d", new byte[1]));
            gldfContainer.Assets.Geometries.Add(new ContainerFile("geometry.r3d", new byte[2]));
            gldfContainer.Assets.Images.Add(new ContainerFile("image.jpg", new byte[3]));
            gldfContainer.Assets.Images.Add(new ContainerFile("image.png", new byte[4]));
            gldfContainer.Assets.Photometries.Add(new ContainerFile("lvk.ldt", new byte[5]));
            gldfContainer.Assets.Photometries.Add(new ContainerFile("lvk.ies", new byte[6]));
            gldfContainer.Assets.Documents.Add(new ContainerFile("document.docx", new byte[7]));
            gldfContainer.Assets.Sensors.Add(new ContainerFile("sensor.xml", new byte[8]));
            gldfContainer.Assets.Spectrums.Add(new ContainerFile("spectrum.txt", new byte[9]));
            gldfContainer.Assets.Symbols.Add(new ContainerFile("symbol.svg", new byte[10]));
            gldfContainer.Assets.Other.Add(new ContainerFile("project.c4d", new byte[11]));

            _zipArchiveWriter.Write(_tempFile1, gldfContainer);
            File.WriteAllBytes(_tempFile2, expectedBytes);

            var loadedWrittenContainer = zipArchiveReader.ReadContainer(_tempFile1);
            var expectedContainer = zipArchiveReader.ReadContainer(_tempFile2);

            loadedWrittenContainer.Should().BeEquivalentTo(expectedContainer);
        }

        [Test]
        public void Write_Should_OnlyCreate_ProductEntry_WhenNoAssets()
        {
            var gldfContainer = new GldfContainer(new Root());

            _zipArchiveWriter.Write(_tempFile1, gldfContainer);
            using var zipArchive = ZipFile.Open(_tempFile1, ZipArchiveMode.Read);
            var containerEntryCount = zipArchive.Entries.Count;
            var firstEntryName = zipArchive.Entries.First().Name;

            containerEntryCount.Should().Be(1);
            firstEntryName.Should().Be("product.xml");
        }

        [Test]
        public void Write_ShouldThrow_ArgumentNullException_When_PathIsNull()
        {
            Action act = () => _zipArchiveWriter.Write(null, new GldfContainer());

            act.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Path cannot be null. (Parameter 'path')");
        }

        [Test]
        public void Write_ShouldThrow_RootNotFoundException_When_ProductIsNull()
        {
            Action act = () => _zipArchiveWriter.Write(_tempFile1, new GldfContainer(null));

            act.Should()
                .Throw<RootNotFoundException>()
                .WithMessage("Product must not be null");
        }

        [Test]
        public void CreateFromDirectory_ShouldCreate_GldfContainer_WithExpectedContent()
        {
            var tempSubDirectory = Path.Combine(Path.GetTempPath(), $"gldf-{DateTime.Now.Ticks}");
            var gldfWithFiles = EmbeddedGldfTestData.GetGldfWithFiles();
            var expectedZipEntryNames = EmbeddedGldfTestData.ExpectedZipEntryNames;
            File.WriteAllBytes(_tempFile1, gldfWithFiles);
            ZipFile.ExtractToDirectory(_tempFile1, tempSubDirectory);

            _zipArchiveWriter.CreateFromDirectory(tempSubDirectory, _tempFile2);
            var zipArchive = ZipFile.OpenRead(_tempFile2);
            var zipArchiveEntries = zipArchive.Entries;
            zipArchive.Dispose();
            Directory.Delete(tempSubDirectory, true);

            zipArchiveEntries.Select(e => e.FullName).Should().HaveCount(12);
            zipArchiveEntries.Select(e => e.FullName).Should().BeEquivalentTo(expectedZipEntryNames);
        }
    }
}