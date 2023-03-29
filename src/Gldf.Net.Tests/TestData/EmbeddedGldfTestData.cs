using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.MetaInfo;
using Gldf.Net.Tests.TestHelper;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Tests.TestData
{
    public static class EmbeddedGldfTestData
    {
        private const string GldfWithHeaderMandatory = "TestData.Container.GldfWithHeaderMandatory.gldf";
        private const string GldfWithSignature = "TestData.Container.GldfWithSignature.gldf";
        private const string GldfWithFiles = "TestData.Container.GldfWithFiles.gldf";
        private const string GldfWithFilesComplete = "TestData.Container.GldfWithFilesComplete.gldf";
        private const string GldfWithNoFiles = "TestData.Container.GldfWithNoFiles.gldf";
        private const string GldfWithLargeFiles = "TestData.Container.GldfWithLargeFiles.gldf";
        private const string GldfWithInvalidRoot = "TestData.Container.GldfWithInvalidRoot.gldf";
        private const string GldfWithOrphanedFiles = "TestData.Container.GldfWithOrphanedFiles.gldf";
        private const string GldfWithMissingFiles = "TestData.Container.GldfWithMissingFiles.gldf";

        public static byte[] GetGldfWithHeaderMandatory() => ResourceLoader.LoadEmbeddedBytes(GldfWithHeaderMandatory);
        public static byte[] GetGldfNoFiles() => ResourceLoader.LoadEmbeddedBytes(GldfWithNoFiles);
        public static byte[] GetGldfWithSignature() => ResourceLoader.LoadEmbeddedBytes(GldfWithSignature);
        public static byte[] GetGldfWithFiles() => ResourceLoader.LoadEmbeddedBytes(GldfWithFiles);
        public static byte[] GetGldfWithFilesComplete() => ResourceLoader.LoadEmbeddedBytes(GldfWithFilesComplete);
        public static byte[] GetGldfWithLargeFiles() => ResourceLoader.LoadEmbeddedBytes(GldfWithLargeFiles);
        public static byte[] GetGldfWithInvalidRoot() => ResourceLoader.LoadEmbeddedBytes(GldfWithInvalidRoot);
        public static byte[] GetGldfWithOrphanedFiles() => ResourceLoader.LoadEmbeddedBytes(GldfWithOrphanedFiles);
        public static byte[] GetGldfWithMissingFiles() => ResourceLoader.LoadEmbeddedBytes(GldfWithMissingFiles);

        public static IEnumerable<string> ExpectedZipEntryNames => new[]
        {
            "product.xml",
            "document/document.docx",
            "geo/geometry.l3d",
            "geo/geometry.r3d",
            "image/image.jpg",
            "image/image.png",
            "ldc/lvk.ies",
            "ldc/lvk.ldt",
            "other/project.c4d",
            "sensor/sensor.xml",
            "spectrum/spectrum.txt",
            "symbol/symbol.svg"
        };

        public static MetaInformation ExpectedMetaInformation => new()
        {
            SchemaLocation = null,
            Properties = new Property[]
            {
                new()
                {
                    Name = "Acme-Signature",
                    Content = "41dad678-14fe-4ea9-a7fe-2a5a22e79aae"
                },
                new()
                {
                    Name = "ExampleLLC-Signature",
                    Content = "5437af9d-18c4-485e-b396-1d3d6531fb29"
                }
            }
        };

        public static List<string> ExpectedDirectoryFilePaths => new()
        {
            $"*{Path.DirectorySeparatorChar}product.xml",
            $"*{Path.DirectorySeparatorChar}document{Path.DirectorySeparatorChar}document.docx",
            $"*{Path.DirectorySeparatorChar}geo{Path.DirectorySeparatorChar}geometry.l3d",
            $"*{Path.DirectorySeparatorChar}geo{Path.DirectorySeparatorChar}geometry.r3d",
            $"*{Path.DirectorySeparatorChar}image{Path.DirectorySeparatorChar}image.jpg",
            $"*{Path.DirectorySeparatorChar}image{Path.DirectorySeparatorChar}image.png",
            $"*{Path.DirectorySeparatorChar}ldc{Path.DirectorySeparatorChar}lvk.ies",
            $"*{Path.DirectorySeparatorChar}ldc{Path.DirectorySeparatorChar}lvk.ldt",
            $"*{Path.DirectorySeparatorChar}other{Path.DirectorySeparatorChar}project.c4d",
            $"*{Path.DirectorySeparatorChar}sensor{Path.DirectorySeparatorChar}sensor.xml",
            $"*{Path.DirectorySeparatorChar}spectrum{Path.DirectorySeparatorChar}spectrum.txt",
            $"*{Path.DirectorySeparatorChar}symbol{Path.DirectorySeparatorChar}symbol.svg"
        };
    }
}