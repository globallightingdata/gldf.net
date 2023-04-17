using Gldf.Net.Container;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.MetaInfo;
using Gldf.Net.Tests.TestHelper;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Tests.TestData;

public static class EmbeddedGldfTestData
{
    private const string GldfWithHeaderMandatory = "TestData.Container.GldfWithHeaderMandatory.gldf";
    private const string GldfWithMissingProduct = "TestData.Container.GldfWithMissingProduct.gldf";
    private const string GldfWithMetaInfo = "TestData.Container.GldfWithMetaInfo.gldf";
    private const string GldfWithFiles = "TestData.Container.GldfWithFiles.gldf";
    private const string GldfWithFilesComplete = "TestData.Container.GldfWithFilesComplete.gldf";
    private const string GldfWithNoFiles = "TestData.Container.GldfWithNoFiles.gldf";
    private const string GldfWithLargeFiles = "TestData.Container.GldfWithLargeFiles.gldf";
    private const string GldfWithInvalidRoot = "TestData.Container.GldfWithInvalidRoot.gldf";
    private const string GldfWithOrphanedFiles = "TestData.Container.GldfWithOrphanedFiles.gldf";
    private const string GldfWithMissingFiles = "TestData.Container.GldfWithMissingFiles.gldf";

    public static byte[] GetGldfWithHeaderMandatory() => ResourceLoader.LoadEmbeddedBytes(GldfWithHeaderMandatory);
    public static byte[] GetGldfWithMissingProduct() => ResourceLoader.LoadEmbeddedBytes(GldfWithMissingProduct);
    public static byte[] GetGldfNoFiles() => ResourceLoader.LoadEmbeddedBytes(GldfWithNoFiles);
    public static byte[] GetGldfWithMetaInfo() => ResourceLoader.LoadEmbeddedBytes(GldfWithMetaInfo);
    public static byte[] GetGldfWithFiles() => ResourceLoader.LoadEmbeddedBytes(GldfWithFiles);
    public static byte[] GetGldfWithFilesComplete() => ResourceLoader.LoadEmbeddedBytes(GldfWithFilesComplete);
    public static byte[] GetGldfWithLargeFiles() => ResourceLoader.LoadEmbeddedBytes(GldfWithLargeFiles);
    public static byte[] GetGldfWithInvalidRoot() => ResourceLoader.LoadEmbeddedBytes(GldfWithInvalidRoot);
    public static byte[] GetGldfWithOrphanedFiles() => ResourceLoader.LoadEmbeddedBytes(GldfWithOrphanedFiles);
    public static byte[] GetGldfWithMissingFiles() => ResourceLoader.LoadEmbeddedBytes(GldfWithMissingFiles);

    public static IEnumerable<string> ExpectedZipEntryNames => new[]
    {
        GldfStaticNames.Files.Product,
        $"{GldfStaticNames.Folder.Documents}/document.docx",
        $"{GldfStaticNames.Folder.Geometries}/geometry.l3d",
        $"{GldfStaticNames.Folder.Geometries}/geometry.r3d",
        $"{GldfStaticNames.Folder.Images}/image.jpg",
        $"{GldfStaticNames.Folder.Images}/image.png",
        $"{GldfStaticNames.Folder.Photometries}/lvk.ies",
        $"{GldfStaticNames.Folder.Photometries}/lvk.ldt",
        $"{GldfStaticNames.Folder.Other}/project.c4d",
        $"{GldfStaticNames.Folder.Sensors}/sensor.xml",
        $"{GldfStaticNames.Folder.Spectrums}/spectrum.txt",
        $"{GldfStaticNames.Folder.Symbols}/symbol.svg"
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
        $"*{Path.DirectorySeparatorChar}{GldfStaticNames.Files.Product}",
        $"*{Path.DirectorySeparatorChar}{GldfStaticNames.Folder.Documents}{Path.DirectorySeparatorChar}document.docx",
        $"*{Path.DirectorySeparatorChar}{GldfStaticNames.Folder.Geometries}{Path.DirectorySeparatorChar}geometry.l3d",
        $"*{Path.DirectorySeparatorChar}{GldfStaticNames.Folder.Geometries}{Path.DirectorySeparatorChar}geometry.r3d",
        $"*{Path.DirectorySeparatorChar}{GldfStaticNames.Folder.Images}{Path.DirectorySeparatorChar}image.jpg",
        $"*{Path.DirectorySeparatorChar}{GldfStaticNames.Folder.Images}{Path.DirectorySeparatorChar}image.png",
        $"*{Path.DirectorySeparatorChar}{GldfStaticNames.Folder.Photometries}{Path.DirectorySeparatorChar}lvk.ies",
        $"*{Path.DirectorySeparatorChar}{GldfStaticNames.Folder.Photometries}{Path.DirectorySeparatorChar}lvk.ldt",
        $"*{Path.DirectorySeparatorChar}{GldfStaticNames.Folder.Other}{Path.DirectorySeparatorChar}project.c4d",
        $"*{Path.DirectorySeparatorChar}{GldfStaticNames.Folder.Sensors}{Path.DirectorySeparatorChar}sensor.xml",
        $"*{Path.DirectorySeparatorChar}{GldfStaticNames.Folder.Spectrums}{Path.DirectorySeparatorChar}spectrum.txt",
        $"*{Path.DirectorySeparatorChar}{GldfStaticNames.Folder.Symbols}{Path.DirectorySeparatorChar}symbol.svg"
    };
}