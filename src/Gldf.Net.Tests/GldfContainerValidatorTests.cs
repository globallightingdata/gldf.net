using FluentAssertions;
using Gldf.Net.Container;
using Gldf.Net.Tests.TestData;
using Gldf.Net.Validation;
using NUnit.Framework;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Gldf.Net.Tests
{
    [TestFixture]
    public class GldfContainerValidatorTests
    {
        private GldfContainerValidator _validator;
        private string _tempFile;

        [SetUp]
        public void SetUp()
        {
            _validator = new GldfContainerValidator();
            _tempFile = Path.GetTempFileName();
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete(_tempFile);
        }

        [Test]
        public void ValidateFilepath_ShouldThrow_WhenFilePathParameterIsNull()
        {
            Action act = () => _validator.Validate((string)null);

            act.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'filePath')");
        }

        [Test]
        public void ValidateFilepath_ShouldReturnEmptyHintList_WhenMandatoryGldf()
        {
            var gldfWithInvalidRoot = EmbeddedGldfTestData.GetGldfWithHeaderMandatory();
            File.WriteAllBytes(_tempFile, gldfWithInvalidRoot);

            var hints = _validator.Validate(_tempFile);

            hints.Should().BeEmpty();
        }
        
        [Test]
        public void ValidateFilepath_ShouldReturnEmptyHintList_WhenCompleteGldf()
        {
            var gldfWithInvalidRoot = EmbeddedGldfTestData.GetGldfWithFilesComplete();
            File.WriteAllBytes(_tempFile, gldfWithInvalidRoot);

            var hints = _validator.Validate(_tempFile);

            hints.Should().BeEmpty();
        }

        [Test]
        public void ValidateFilepath_ShouldReturnInvalidZipFileError_WhenGldfIsInvalid()
        {
            File.WriteAllBytes(_tempFile, new byte[1]);
            var message = $"The GLDF container '{_tempFile}' seems not to be a valid ZIP file or can't be accessed";
            var expected = new ValidationHint(SeverityType.Error, message, ErrorType.InvalidZipFile);

            var hints = _validator.Validate(_tempFile).ToList();

            foreach (var hint in hints)
            {
                Console.WriteLine(hint);
            }

            hints.Should().HaveCount(5);
            hints.Should().ContainEquivalentOf(expected);
        }

        [Test]
        public void Validate_ShouldReturnRootMissingError_WhenProductXmlEntryIsMissing()
        {
            ZipFile.Open(_tempFile, ZipArchiveMode.Update).Dispose();
            var message = $"The GLDF container '{_tempFile}' does not contain a product.xml entry.";
            var expected = new ValidationHint(SeverityType.Error, message, ErrorType.ProductXmlNotFound);

            var hints = _validator.Validate(_tempFile).ToList();

            hints.Should().HaveCount(3);
            hints.Should().ContainEquivalentOf(expected);
        }

        [Test]
        public void ValidateFilepath_ShouldReturnInvalidRootError_WhenProductXmlIsInvalid()
        {
            var gldfWithInvalidRoot = EmbeddedGldfTestData.GetGldfWithInvalidRoot();
            File.WriteAllBytes(_tempFile, gldfWithInvalidRoot);
            const string message = "The 'contentType' attribute is invalid - " +
                                   "The value 'invalid' is invalid according to its datatype 'String' - " +
                                   "The Enumeration constraint failed.";
            var expected = new ValidationHint(SeverityType.Error, message, ErrorType.XmlSchema);

            var hints = _validator.Validate(_tempFile).ToList();

            hints.Should().HaveCount(2);
            hints.Should().ContainEquivalentOf(expected);
        }

        [Test]
        public void ValidateFilepath_ShouldReturnLargeFileWarning()
        {
            var gldfWithLargeFiles = EmbeddedGldfTestData.GetGldfWithLargeFiles();
            File.WriteAllBytes(_tempFile, gldfWithLargeFiles);
            const string message = "Large files found. It is recommended to limit the maximum file " +
                                   "size to 5MB each: doc/5MbTextFile.txt";
            var expected = new ValidationHint(SeverityType.Warning, message, ErrorType.ToLargeFiles);

            var hints = _validator.Validate(_tempFile).ToList();

            hints.Should().HaveCount(1);
            hints.Should().ContainEquivalentOf(expected);
        }

        [Test]
        public void ValidateFilepath_ShouldReturnMissingFiles()
        {
            var gldfWithLargeFiles = EmbeddedGldfTestData.GetGldfWithMissingFiles();
            File.WriteAllBytes(_tempFile, gldfWithLargeFiles);
            const string message = "The product.xml contains File definitions that are missing in the GLDF " +
                                   "container: file.ldt (LdcEulumdat), file.ies (LdcIes), file.xml (LdcIesXml), " +
                                   "file.l3d (GeoL3d), file.m3d (GeoM3d), file.r3d (GeoR3d), file.pdf (DocPdf), " +
                                   "file.jpg (ImageJpg), file.png (ImagePng), file.svg (ImageSvg), file.ldt " +
                                   "(SensorSensLdt), file.xml (SensorSensXml), file.txt (SpectrumText), file.dxf " +
                                   "(SymbolDxf), file.svg (SymbolSvg), file.doc (Other)";
            var expected = new ValidationHint(SeverityType.Error, message, ErrorType.MissingContainerAssets);

            var hints = _validator.Validate(_tempFile).ToList();

            hints.Should().HaveCount(1);
            hints.Should().ContainEquivalentOf(expected);
        }

        [Test]
        public void ValidateFilepath_ShouldReturnOrphanedFiles()
        {
            var gldfWithLargeFiles = EmbeddedGldfTestData.GetGldfWithOrphanedFiles();
            File.WriteAllBytes(_tempFile, gldfWithLargeFiles);
            const string message = "The GLDF container contains assets that are not referenced in the product.xml. " +
                                   "They should be deleted: orphan.txt";
            var expected = new ValidationHint(SeverityType.Warning, message, ErrorType.OrphanedContainerAssets);

            var hints = _validator.Validate(_tempFile).ToList();

            hints.Should().HaveCount(1);
            hints.Should().ContainEquivalentOf(expected);
        }

        [Test]
        public void ValidateContainer_ShouldThrow_WhenContainerParameterIsNull()
        {
            Action act = () => _validator.Validate((GldfContainer)null);

            act.Should()
                .ThrowExactly<ArgumentNullException>()
                .WithMessage("Value cannot be null. (Parameter 'container')");
        }

        [Test]
        public void ValidateContainer_ShouldReturnMissingFiles()
        {
            var gldfWithLargeFiles = EmbeddedGldfTestData.GetGldfWithMissingFiles();
            var zipArchiveReader = new ZipArchiveReader();
            File.WriteAllBytes(_tempFile, gldfWithLargeFiles);
            var gldfContainer = zipArchiveReader.ReadContainer(_tempFile);
            const string message = "The product.xml contains File definitions that are missing in the GLDF " +
                                   "container: file.ldt (LdcEulumdat), file.ies (LdcIes), file.xml (LdcIesXml), " +
                                   "file.l3d (GeoL3d), file.m3d (GeoM3d), file.r3d (GeoR3d), file.pdf (DocPdf), " +
                                   "file.jpg (ImageJpg), file.png (ImagePng), file.svg (ImageSvg), file.ldt " +
                                   "(SensorSensLdt), file.xml (SensorSensXml), file.txt (SpectrumText), file.dxf " +
                                   "(SymbolDxf), file.svg (SymbolSvg), file.doc (Other)";
            var expected = new ValidationHint(SeverityType.Error, message, ErrorType.MissingContainerAssets);

            var hints = _validator.Validate(gldfContainer).ToList();

            hints.Should().HaveCount(1);
            hints.Should().ContainEquivalentOf(expected);
        }

        [Test]
        public void ValidateContainer_ShouldReturnOrphanedFiles()
        {
            var gldfWithLargeFiles = EmbeddedGldfTestData.GetGldfWithOrphanedFiles();
            var zipArchiveReader = new ZipArchiveReader();
            File.WriteAllBytes(_tempFile, gldfWithLargeFiles);
            var gldfArchive = zipArchiveReader.ReadContainer(_tempFile);
            const string message = "The GLDF container contains assets that are not referenced in the product.xml. " +
                                   "They should be deleted: orphan.txt";
            var expected = new ValidationHint(SeverityType.Warning, message, ErrorType.OrphanedContainerAssets);

            var hints = _validator.Validate(gldfArchive).ToList();

            hints.Should().HaveCount(1);
            hints.Should().ContainEquivalentOf(expected);
        }
    }
}