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
            var gldfArchive = new GldfArchive(new Root());

            _zipArchiveWriter.Write(tempPath, gldfArchive);
            var archiveExists = File.Exists(tempPath);
            Directory.Delete(tempSubDirectory, true);

            archiveExists.Should().BeTrue();
        }

        [Test]
        public void Write_ShouldOverwrite_Container_WhenAlreadyExists()
        {
            var gldfArchive1 = new GldfArchive(new Root {Checksum = "Old"});
            var gldfArchive2 = new GldfArchive(new Root {Checksum = "New"});
            var zipArchiveReader = new ZipArchiveReader();

            _zipArchiveWriter.Write(_tempFile1, gldfArchive1);
            var checksumBefore = zipArchiveReader.ReadArchive(_tempFile1).Product.Checksum;
            _zipArchiveWriter.Write(_tempFile1, gldfArchive2);
            var checksumAfter = zipArchiveReader.ReadArchive(_tempFile1).Product.Checksum;

            checksumBefore.Should().Be(gldfArchive1.Product.Checksum);
            checksumAfter.Should().Be(gldfArchive2.Product.Checksum);
        }

        [Test]
        public void Write_ShouldCreate_SameGldfArchive_AsExpected()
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

            _zipArchiveWriter.Write(_tempFile1, gldfArchive);
            File.WriteAllBytes(_tempFile2, expectedArchiveBytes);

            var loadedWrittenArchive = zipArchiveReader.ReadArchive(_tempFile1);
            var expectedArchive = zipArchiveReader.ReadArchive(_tempFile2);

            loadedWrittenArchive.Should().BeEquivalentTo(expectedArchive);
        }

        [Test]
        public void Write_Should_OnlyCreate_ProductEntry_WhenNoAssets()
        {
            var gldfArchive = new GldfArchive(new Root());

            _zipArchiveWriter.Write(_tempFile1, gldfArchive);
            using var zipArchive = ZipFile.Open(_tempFile1, ZipArchiveMode.Read);
            var archiveEntryCount = zipArchive.Entries.Count;
            var firstEntryName = zipArchive.Entries.First().Name;

            archiveEntryCount.Should().Be(1);
            firstEntryName.Should().Be("product.xml");
        }

        [Test]
        public void Write_ShouldThrow_ArgumentNullException_When_PathIsNull()
        {
            Action act = () => _zipArchiveWriter.Write(null, new GldfArchive());

            act.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("Path cannot be null. (Parameter 'path')");
        }

        [Test]
        public void Write_ShouldThrow_RootNotFoundException_When_ProductIsNull()
        {
            Action act = () => _zipArchiveWriter.Write(_tempFile1, new GldfArchive(null));

            act.Should()
                .Throw<RootNotFoundException>()
                .WithMessage("Product must not be null");
        }

        [Test]
        public void CreateFromDirectory_ShouldCreate_GldfArchive_WithExpectedContent()
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

        [Test]
        public void ExtractToDirectory_ShouldExtract_ExpectedContent()
        {
            var tempSubDirectory = Path.Combine(Path.GetTempPath(), $"gldf-{DateTime.Now.Ticks}");
            var gldfWithFiles = EmbeddedGldfTestData.GetGldfWithFiles();
            var expectedDirectoryFilePaths = EmbeddedGldfTestData.ExpectedDirectoryFilePaths;
            File.WriteAllBytes(_tempFile1, gldfWithFiles);

            _zipArchiveWriter.ExtractToDirectory(_tempFile1, tempSubDirectory);
            var options = new EnumerationOptions {RecurseSubdirectories = true};
            var filesInsideDirectory = Directory.EnumerateFiles(tempSubDirectory, "*.*", options).ToList();
            Directory.Delete(tempSubDirectory, true);

            filesInsideDirectory.Should().HaveCount(12);
            expectedDirectoryFilePaths.ForEach(e => filesInsideDirectory.Should().ContainMatch(e));
        }
    }
}