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
        private GldfContainerReader _gldfContainerReader;
        private GldfContainerWriter _gldfContainerWriter;
        private string _tempFile1;
        private string _tempFile2;

        [SetUp]
        public void SetUp()
        {
            _gldfContainerReader = new GldfContainerReader();
            _gldfContainerWriter = new GldfContainerWriter();
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
        public void CreateFromDirectory_ShouldThrow_When_SourceDirectory_IsNull()
        {
            Action act = () => _gldfContainerWriter.CreateFromDirectory(null, "");

            act.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'sourceDirectory')");
        }

        [Test]
        public void CreateFromDirectory_ShouldThrow_When_TargetFilePath_IsNull()
        {
            Action act = () => _gldfContainerWriter.CreateFromDirectory("", null);

            act.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'targetContainerFilePath')");
        }

        [Test]
        public void CreateFromDirectory_ShouldThrow_When_FilePath_IsInvalid()
        {
            Action act = () => _gldfContainerWriter.CreateFromDirectory(@"AB:\UnknownPath", @"AB:\UnknownPath");

            act.Should()
                .ThrowExactly<GldfContainerException>()
                .WithMessage("Failed to create GldfContainer *")
                .WithInnerException<IOException>();
        }

        [Test]
        public void CreateFromDirectory_ShouldCreate_GldfContainer_WithExpectedContent()
        {
            var expectedZipEntryNames = EmbeddedGldfTestData.ExpectedZipEntryNames;
            var tempSubDirectory = Path.Combine(Path.GetTempPath(), $"gldf-{DateTime.Now.Ticks}");
            var gldfWithFiles = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile1, gldfWithFiles);
            ZipFile.ExtractToDirectory(_tempFile1, tempSubDirectory);

            _gldfContainerWriter.CreateFromDirectory(tempSubDirectory, _tempFile2);
            var zipArchive = ZipFile.OpenRead(_tempFile2);
            var zipArchiveEntries = zipArchive.Entries;
            zipArchive.Dispose();
            Directory.Delete(tempSubDirectory, true);

            zipArchiveEntries.Select(e => e.FullName).Should().HaveCount(12);
            zipArchiveEntries.Select(e => e.FullName).Should().BeEquivalentTo(expectedZipEntryNames);
        }

        [TestCase("", null)]
        [TestCase(null, "")]
        public void CreateFromDirectory_ShouldThrow_When_InvalidPath(string sourceDirectory, string containerFilePath)
        {
            Action act = () => _gldfContainerWriter.CreateFromDirectory(sourceDirectory, containerFilePath);

            act.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithMessage("Value cannot be null*");
        }

        [Test]
        public void ExtractToDirectory_ShouldExtract_ExpectedContent()
        {
            var expectedDirectoryFilePaths = EmbeddedGldfTestData.ExpectedDirectoryFilePaths;
            var tempSubDirectory = Path.Combine(Path.GetTempPath(), $"gldf-{DateTime.Now.Ticks}");
            var gldfWithFiles = EmbeddedGldfTestData.GetGldfWithFiles();
            File.WriteAllBytes(_tempFile1, gldfWithFiles);

            _gldfContainerReader.ExtractToDirectory(_tempFile1, tempSubDirectory);
            var options = new EnumerationOptions { RecurseSubdirectories = true };
            var filesInsideDirectory = Directory.EnumerateFiles(tempSubDirectory, "*.*", options).ToList();
            Directory.Delete(tempSubDirectory, true);

            filesInsideDirectory.Should().HaveCount(12);
            expectedDirectoryFilePaths.ForEach(e => filesInsideDirectory.Should().ContainMatch(e));
        }

        [TestCase(null, "")]
        [TestCase("", null)]
        public void ExtractToDirectory_ShouldThrow_When_PathIsNull(string containerPath, string targetDirectory)
        {
            Action act = () => _gldfContainerReader.ExtractToDirectory(containerPath, targetDirectory);

            act.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithMessage("Value cannot be null.*");
        }

        [Test]
        public void ExtractToDirectory_ShouldThrow_When_SourcePath_IsInvalid()
        {
            Action act = () => _gldfContainerReader.ExtractToDirectory(Guid.NewGuid().ToString(), Path.GetTempPath());

            act.Should()
                .ThrowExactly<GldfContainerException>()
                .WithMessage("Failed to extract *")
                .WithInnerException<FileNotFoundException>();
        }

        [Test]
        public void ExtractToDirectory_ShouldThrow_When_TargetDirectory_IsInvalid()
        {
            Action act = () => _gldfContainerReader.ExtractToDirectory(Path.GetTempPath(), Guid.NewGuid().ToString());

            act.Should()
                .ThrowExactly<GldfContainerException>()
                .WithMessage("Failed to extract *")
                .WithInnerException<DirectoryNotFoundException>();
        }
    }
}