using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Gldf.Net.Container;

internal class ZipArchiveReader : ZipArchiveIO
{
    public ZipArchiveReader() : base(Encoding.UTF8)
    {
    }

    public ZipArchiveReader(Encoding encoding) : base(encoding)
    {
    }

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
        return ReadXml(zipArchive, GldfStaticNames.Files.Product, GldfXmlSerializer.Encoding);
    }

    public string ReadRootXml(Stream zipStream, bool leaveOpen)
    {
        using var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Read, leaveOpen);
        return ReadXml(zipArchive, GldfStaticNames.Files.Product, GldfXmlSerializer.Encoding);
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
            AddDeserializedRoot(zipArchive, container);
        if (settings.MetaInfoLoadBehaviour == MetaInfoLoadBehaviour.Load)
            AddDeserializedMetaInfo(zipArchive, container);
        if (settings.AssetLoadBehaviour != AssetLoadBehaviour.Skip)
            AddAssets(zipArchive, container, settings.AssetLoadBehaviour);
        return container;
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

    private void AddDeserializedRoot(ZipArchive zipArchive, GldfContainer gldfContainer)
    {
        var rootXml = ReadXml(zipArchive, GldfStaticNames.Files.Product, GldfXmlSerializer.Encoding);
        gldfContainer.Product = rootXml != null ? GldfXmlSerializer.DeserializeFromXml(rootXml) : null;
    }

    private void AddDeserializedMetaInfo(ZipArchive zipArchive, GldfContainer gldfContainer)
    {
        var xml = ReadXml(zipArchive, GldfStaticNames.Files.MetaInfo, MetaInfoSerializer.Encoding);
        gldfContainer.MetaInformation = xml != null ? MetaInfoSerializer.DeserializeFromXml(xml) : null;
    }

    private string ReadXml(ZipArchive zipArchive, string fileName, Encoding encoding)
    {
        var zipEntry = zipArchive.GetEntry(fileName);
        if (zipEntry is null) return null;
        using var stream = zipEntry.Open();
        using var streamReader = new StreamReader(stream, encoding);
        return streamReader.ReadToEnd();
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
        else if (IsFolder(name, GldfStaticNames.Folder.Photometries)) AddFile(container.Assets.Photometries, entry, behaviour);
        else if (IsFolder(name, GldfStaticNames.Folder.Images)) AddFile(container.Assets.Images, entry, behaviour);
        else if (IsFolder(name, GldfStaticNames.Folder.Documents)) AddFile(container.Assets.Documents, entry, behaviour);
        else if (IsFolder(name, GldfStaticNames.Folder.Sensors)) AddFile(container.Assets.Sensors, entry, behaviour);
        else if (IsFolder(name, GldfStaticNames.Folder.Symbols)) AddFile(container.Assets.Symbols, entry, behaviour);
        else if (IsFolder(name, GldfStaticNames.Folder.Spectrums)) AddFile(container.Assets.Spectrums, entry, behaviour);
        else if (IsFolder(name, GldfStaticNames.Folder.Other)) AddFile(container.Assets.Other, entry, behaviour);
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