using FluentAssertions;
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
    public class GldfContainerDirectoryTests
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
        public void CreateFromDirectory_ShouldCreate_GldfArchive_WithExpectedContent()
        {
            var expectedZipEntryNames = EmbeddedGldfTestData.ExpectedZipEntryNames;
            var tempSubDirectory = Path.Combine(Path.GetTempPath(), $"gldf-{DateTime.Now.Ticks}");
            var gldfWithFiles = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile1, gldfWithFiles);
            ZipFile.ExtractToDirectory(_tempFile1, tempSubDirectory);

            _gldfContainer.CreateFromDirectory(tempSubDirectory, _tempFile2);
            var zipArchive = ZipFile.OpenRead(_tempFile2);
            var zipArchiveEntries = zipArchive.Entries;
            zipArchive.Dispose();
            Directory.Delete(tempSubDirectory, true);

            zipArchiveEntries.Select(e => e.FullName).Should().HaveCount(12);
            zipArchiveEntries.Select(e => e.FullName).Should().BeEquivalentTo(expectedZipEntryNames);
        }

        [Test]
        public void CreateFromDirectory_ShouldThrow_When_InvalidPath()
        {
            Action act = () => _gldfContainer.CreateFromDirectory(null, null);

            act.Should()
                .Throw<GldfContainerException>()
                .WithMessage("Failed to create GLDF container*");
        }

        [Test]
        public void ExtractToDirectory_ShouldExtract_ExpectedContent()
        {
            var expectedDirectoryFilePaths = EmbeddedGldfTestData.ExpectedDirectoryFilePaths;
            var tempSubDirectory = Path.Combine(Path.GetTempPath(), $"gldf-{DateTime.Now.Ticks}");
            var gldfWithFiles = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile1, gldfWithFiles);

            _gldfContainer.ExtractToDirectory(_tempFile1, tempSubDirectory);
            var options = new EnumerationOptions {RecurseSubdirectories = true};
            var filesInsideDirectory = Directory.EnumerateFiles(tempSubDirectory, "*.*", options).ToList();
            Directory.Delete(tempSubDirectory, true);

            filesInsideDirectory.Should().HaveCount(12);
            expectedDirectoryFilePaths.ForEach(e => filesInsideDirectory.Should().ContainMatch(e));
        }

        [Test]
        public void ExtractToDirectory_ShouldThrow_When_InvalidPath()
        {
            Action act = () => _gldfContainer.ExtractToDirectory(null, null);

            act.Should()
                .Throw<GldfContainerException>()
                .WithMessage("Failed to extract*");
        }
    }
}