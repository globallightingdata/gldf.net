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
        if (gldfContainer.Product == null) return; // todo Unit tests
        var xml = GldfXmlSerializer.SerializeToString(gldfContainer.Product);
        var productEntry = zipArchive.CreateEntry(GldfStaticNames.Files.Product, CompressionLevel);
        using var entryStream = productEntry.Open();
        using var streamWriter = new StreamWriter(entryStream, Encoding);
        streamWriter.Write(xml);
    }

    private void AddAssetZipEntries(ZipArchive zipArchive, GldfContainer gldfContainer)
    {
        AddAssetsFor(zipArchive, gldfContainer.Assets.Photometries, GldfStaticNames.Folder.Photometries);
        AddAssetsFor(zipArchive, gldfContainer.Assets.Geometries, GldfStaticNames.Folder.Geometries);
        AddAssetsFor(zipArchive, gldfContainer.Assets.Images, GldfStaticNames.Folder.Images);
        AddAssetsFor(zipArchive, gldfContainer.Assets.Documents, GldfStaticNames.Folder.Documents);
        AddAssetsFor(zipArchive, gldfContainer.Assets.Sensors, GldfStaticNames.Folder.Sensors);
        AddAssetsFor(zipArchive, gldfContainer.Assets.Spectrums, GldfStaticNames.Folder.Spectrums);
        AddAssetsFor(zipArchive, gldfContainer.Assets.Symbols, GldfStaticNames.Folder.Symbols);
        AddAssetsFor(zipArchive, gldfContainer.Assets.Other, GldfStaticNames.Folder.Other);
    }

    private void AddMetaInfo(ZipArchive zipArchive, GldfContainer gldfContainer)
    {
        if (gldfContainer.MetaInformation == null) return;
        var xml = MetaInfoSerializer.SerializeToString(gldfContainer.MetaInformation);
        var metaInfoEntry = zipArchive.CreateEntry(GldfStaticNames.Files.MetaInfo, CompressionLevel);
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