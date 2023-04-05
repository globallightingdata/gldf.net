using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Gldf.Net.Container;

internal class ZipArchiveWriter : ZipArchiveIO
{
    public void Write(string filePath, GldfContainer gldfContainer)
    {
        PrepareDirectory(filePath, true);
        using var zipArchive = ZipFile.Open(filePath, ZipArchiveMode.Create, Encoding);
        AddRootZipEntry(gldfContainer, zipArchive);
        AddAssetZipEntries(zipArchive, gldfContainer);
        AddMetaInfo(zipArchive, gldfContainer);
    }

    public void Write(Stream stream, bool leaveOpen, GldfContainer gldfContainer)
    {
        using var zipArchive = new ZipArchive(stream, ZipArchiveMode.Create, leaveOpen, Encoding);
        AddRootZipEntry(gldfContainer, zipArchive);
        AddAssetZipEntries(zipArchive, gldfContainer);
        AddMetaInfo(zipArchive, gldfContainer);
    }

    public static void CreateFromDirectory(string sourceDirectory, string targetFilePath)
    {
        PrepareDirectory(targetFilePath, true);
        ZipFile.CreateFromDirectory(sourceDirectory, targetFilePath);
    }

    private void AddRootZipEntry(GldfContainer gldfContainer, ZipArchive zipArchive)
    {
        var xml = GldfXmlSerializer.SerializeToString(gldfContainer.Product);
        var productEntry = zipArchive.CreateEntry("product.xml", CompressionLevel);
        using var entryStream = productEntry.Open();
        using var streamWriter = new StreamWriter(entryStream, Encoding);
        streamWriter.Write(xml);
    }

    private void AddAssetZipEntries(ZipArchive zipArchive, GldfContainer gldfContainer)
    {
        AddAssetsFor(zipArchive, gldfContainer.Assets.Photometries, AssetFolderNames.Photometries);
        AddAssetsFor(zipArchive, gldfContainer.Assets.Geometries, AssetFolderNames.Geometries);
        AddAssetsFor(zipArchive, gldfContainer.Assets.Images, AssetFolderNames.Images);
        AddAssetsFor(zipArchive, gldfContainer.Assets.Documents, AssetFolderNames.Documents);
        AddAssetsFor(zipArchive, gldfContainer.Assets.Sensors, AssetFolderNames.Sensors);
        AddAssetsFor(zipArchive, gldfContainer.Assets.Spectrums, AssetFolderNames.Spectrums);
        AddAssetsFor(zipArchive, gldfContainer.Assets.Symbols, AssetFolderNames.Symbols);
        AddAssetsFor(zipArchive, gldfContainer.Assets.Other, AssetFolderNames.Other);
    }

    private void AddMetaInfo(ZipArchive zipArchive, GldfContainer gldfContainer)
    {
        if (gldfContainer.MetaInformation == null) return;
        var xml = MetaInfoSerializer.SerializeToString(gldfContainer.MetaInformation);
        var metaInfoEntry = zipArchive.CreateEntry("meta-information.xml", CompressionLevel);
        using var entryStream = metaInfoEntry.Open();
        using var streamWriter = new StreamWriter(entryStream, Encoding);
        streamWriter.Write(xml);
    }

    private void AddAssetsFor(ZipArchive zipArchive, IEnumerable<ContainerFile> collection, string folder)
    {
        foreach (var file in collection)
        {
            var zipEntryName = $"{folder}/{file.FileName}";
            var zipFileEntry = zipArchive.CreateEntry(zipEntryName, CompressionLevel);
            using var entryStream = zipFileEntry.Open();
            entryStream.Write(file.Bytes, 0, file.Bytes.Length);
        }
    }

}