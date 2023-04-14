using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Gldf.Net.Container;

internal class ZipArchiveReader : ZipArchiveIO
{
    public static bool IsZipArchive(string filePath) =>
        EvaluateFuncSafe(() =>
        {
            using var _ = ZipFile.OpenRead(filePath);
            return true;
        });

    public static bool IsZipArchive(Stream stream, bool leaveOpen) =>
        EvaluateFuncSafe(() =>
        {
            using var _ = new ZipArchive(stream, ZipArchiveMode.Read, leaveOpen);
            return true;
        });

    public static bool ContainsRootXml(string filePath)
    {
        using var zipArchive = ZipFile.OpenRead(filePath);
        return ContainsProductXmlEntry(zipArchive);
    }

    public static bool ContainsRootXml(Stream zipStream, bool leaveOpen)
    {
        using var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Read, leaveOpen);
        return ContainsProductXmlEntry(zipArchive);
    }

    public GldfContainer ReadContainer(string filePath) =>
        ReadContainer(filePath, ContainerLoadSettings.Default);

    public GldfContainer ReadContainer(Stream zipStream, bool leaveOpen) =>
        ReadContainer(zipStream, leaveOpen, ContainerLoadSettings.Default);

    public GldfContainer ReadContainer(string filePath, ContainerLoadSettings settings)
    {
        using var zipArchive = ZipFile.OpenRead(filePath);
        return ReadZipContent(zipArchive, settings);
    }

    public GldfContainer ReadContainer(Stream zipStream, bool leaveOpen, ContainerLoadSettings settings)
    {
        using var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Read, leaveOpen);
        return ReadZipContent(zipArchive, settings);
    }

    public string ReadRootXml(string filePath)
    {
        using var zipArchive = ZipFile.OpenRead(filePath);
        return ReadRootXml(zipArchive);
    }

    public string ReadRootXml(Stream zipStream, bool leaveOpen)
    {
        using var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Read, leaveOpen);
        return ReadRootXml(zipArchive);
    }

    public static void ExtractToDirectory(string sourceFilePath, string targetDirectory)
    {
        PrepareDirectory(targetDirectory, false);
        ZipFile.ExtractToDirectory(sourceFilePath, targetDirectory);
    }

    private GldfContainer ReadZipContent(ZipArchive zipArchive, ContainerLoadSettings settings)
    {
        var container = new GldfContainer();
        if (settings.ProductLoadBehaviour == ProductLoadBehaviour.Load)
            AddDeserializedRoot(container, zipArchive);
        if (settings.AssetLoadBehaviour != AssetLoadBehaviour.Skip)
            AddAssets(zipArchive, container, settings.AssetLoadBehaviour);
        if (settings.MetaInfoLoadBehaviour == MetaInfoLoadBehaviour.Load)
            AddDeserializedMetaInfo(zipArchive, container);
        return container;
    }

    private string ReadRootXml(ZipArchive zipArchive)
    {
        var productEntry = zipArchive.GetEntry(GldfStaticNames.Files.Product);
        if (productEntry is null) return null; // todo Unit test ReadRootXml (product.xml is missing) 
        using var stream = productEntry.Open();
        using var streamReader = new StreamReader(stream, Encoding);
        return streamReader.ReadToEnd();
    }

    public static IEnumerable<string> GetLargeFileNames(string filePath, long minBytes)
    {
        using var zipArchive = ZipFile.OpenRead(filePath);
        return zipArchive.Entries.Where(e => e.Length >= minBytes).Select(e => e.FullName);
    }

    public static IEnumerable<string> GetLargeFileNames(Stream zipStream, bool leaveOpen, long minBytes)
    {
        using var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Read, leaveOpen);
        return zipArchive.Entries.Where(e => e.Length >= minBytes).Select(e => e.FullName);
    }

    private static bool ContainsProductXmlEntry(ZipArchive zipArchive)
    {
        return zipArchive.Entries.Any(entry => entry.FullName.Equals(
            GldfStaticNames.Files.Product, StringComparison.OrdinalIgnoreCase));
    }

    private void AddDeserializedRoot(GldfContainer container, ZipArchive zipArchive)
    {
        var rootXml = ReadRootXml(zipArchive);
        container.Product = rootXml != null
            ? GldfXmlSerializer.DeserializeFromString(rootXml)
            : null;
    }

    private void AddDeserializedMetaInfo(ZipArchive zipArchive, GldfContainer container)
    {
        var metaInfoEntry = zipArchive.GetEntry(GldfStaticNames.Files.MetaInfo);
        if (metaInfoEntry == null) return;
        using var stream = metaInfoEntry.Open();
        using var streamReader = new StreamReader(stream, Encoding);
        var metaInfo = streamReader.ReadToEnd();
        container.MetaInformation = MetaInfoSerializer.DeserializeFromString(metaInfo);
    }

    private static void AddAssets(ZipArchive zipArchive, GldfContainer container, AssetLoadBehaviour loadBehaviour)
    {
        var fileEntries = zipArchive.Entries.Where(entry => !string.IsNullOrEmpty(entry.Name));
        foreach (var entry in fileEntries)
            HandleAssetEntry(container, entry, loadBehaviour);
    }

    private static void HandleAssetEntry(GldfContainer container, ZipArchiveEntry entry, AssetLoadBehaviour behaviour)
    {
        var name = entry.FullName;
        bool IsFolder(string fullName, string value) => fullName.StartsWith($"{value}/", StringComparison.OrdinalIgnoreCase);
        if (IsFolder(name, GldfStaticNames.Folder.Geometries)) AddFile(container.Assets.Geometries, entry, behaviour);
        if (IsFolder(name, GldfStaticNames.Folder.Photometries)) AddFile(container.Assets.Photometries, entry, behaviour);
        if (IsFolder(name, GldfStaticNames.Folder.Images)) AddFile(container.Assets.Images, entry, behaviour);
        if (IsFolder(name, GldfStaticNames.Folder.Documents)) AddFile(container.Assets.Documents, entry, behaviour);
        if (IsFolder(name, GldfStaticNames.Folder.Sensors)) AddFile(container.Assets.Sensors, entry, behaviour);
        if (IsFolder(name, GldfStaticNames.Folder.Symbols)) AddFile(container.Assets.Symbols, entry, behaviour);
        if (IsFolder(name, GldfStaticNames.Folder.Spectrums)) AddFile(container.Assets.Spectrums, entry, behaviour);
        if (IsFolder(name, GldfStaticNames.Folder.Other)) AddFile(container.Assets.Other, entry, behaviour);
    }

    private static void AddFile(ICollection<ContainerFile> collection, ZipArchiveEntry entry,
        AssetLoadBehaviour loadBehaviour)
    {
        var loadComplete = loadBehaviour == AssetLoadBehaviour.Load;
        var fileEntryBytes = loadComplete ? entry.GetBytes() : Array.Empty<byte>();
        var containerFile = new ContainerFile(entry.Name, fileEntryBytes);
        collection.Add(containerFile);
    }

    private static bool EvaluateFuncSafe(Func<bool> checkFunc)
    {
        try
        {
            return checkFunc();
        }
        catch
        {
            return false;
        }
    }
}