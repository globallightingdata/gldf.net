using Gldf.Net.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Gldf.Net.Container
{
    internal class ZipArchiveReader : ZipArchiveIO
    {
        public bool IsZipArchive(string filePath)
        {
            return EvaluateFuncSafe(() =>
            {
                using var _ = ZipFile.OpenRead(filePath);
                return true;
            });
        }

        public bool ContainsRootXml(string filePath)
        {
            using var zipArchive = ZipFile.OpenRead(filePath);
            return zipArchive.Entries.Any(entry => entry.FullName == "product.xml");
        }

        public GldfContainer ReadContainer(string filePath)
        {
            return ReadContainer(filePath, ContainerLoadSettings.Default);
        }

        public GldfContainer ReadContainer(string filePath, ContainerLoadSettings settings)
        {
            var container = new GldfContainer();
            using var zipArchive = ZipFile.OpenRead(filePath);
            if (settings.ProductLoadBehaviour == ProductLoadBehaviour.Load)
                AddDeserializedRoot(container, zipArchive);
            if (settings.AssetLoadBehaviour != AssetLoadBehaviour.Skip)
                AddAssets(zipArchive, container, settings.AssetLoadBehaviour);
            if (settings.SignatureLoadBehaviour == SignatureLoadBehaviour.Load)
                AddDeserializedMetaInfo(zipArchive, container);
            return container;
        }

        public string ReadRootXml(string filePath)
        {
            using var zipArchive = ZipFile.OpenRead(filePath);
            return ReadRootXml(zipArchive);
        }

        public void ExtractToDirectory(string sourceFilePath, string targetDirectory)
        {
            PrepareDirectory(targetDirectory, false);
            ZipFile.ExtractToDirectory(sourceFilePath, targetDirectory);
        }

        private string ReadRootXml(ZipArchive zipArchive)
        {
            var productEntry = zipArchive.GetEntry("product.xml");
            if (productEntry == null)
                throw new RootNotFoundException(
                    $"Required product.xml not found in root of {nameof(GldfContainer)}");
            using var stream = productEntry.Open();
            using var streamReader = new StreamReader(stream, Encoding);
            return streamReader.ReadToEnd();
        }

        public IEnumerable<string> GetLargeFileNames(string filePath, long minBytes)
        {
            using var zipArchive = ZipFile.OpenRead(filePath);
            return zipArchive.Entries.Where(e => e.Length >= minBytes).Select(e => e.FullName);
        }

        private void AddDeserializedRoot(GldfContainer container, ZipArchive zipArchive)
        {
            var rootXml = ReadRootXml(zipArchive);
            var deserializedRoot = GldfXmlSerializer.DeserializeFromString(rootXml);
            container.Product = deserializedRoot;
        }

        private void AddDeserializedMetaInfo(ZipArchive zipArchive, GldfContainer container)
        {
            var signatureEntry = zipArchive.GetEntry("meta-information.xml");
            if (signatureEntry == null) return;
            using var stream = signatureEntry.Open();
            using var streamReader = new StreamReader(stream, Encoding);
            var metaInfo = streamReader.ReadToEnd();
            container.MetaInformation = MetaInfoSerializer.DeserializeFromString(metaInfo);
        }

        private void AddAssets(ZipArchive zipArchive, GldfContainer container, AssetLoadBehaviour loadBehaviour)
        {
            var fileEntries = zipArchive.Entries.Where(entry => !string.IsNullOrEmpty(entry.Name));
            foreach (var entry in fileEntries)
                _ = HandleAssetEntry(container, entry, loadBehaviour);
        }

        private string HandleAssetEntry(GldfContainer container, ZipArchiveEntry entry, AssetLoadBehaviour behaviour)
        {
            var firstPathPart = entry.FullName.Split('/')[0].ToLower();
            return firstPathPart switch
            {
                AssetFolderNames.Geometries => AddFileFromEntry(container.Assets.Geometries, entry, behaviour),
                AssetFolderNames.Photometries => AddFileFromEntry(container.Assets.Photometries, entry, behaviour),
                AssetFolderNames.Images => AddFileFromEntry(container.Assets.Images, entry, behaviour),
                AssetFolderNames.Documents => AddFileFromEntry(container.Assets.Documents, entry, behaviour),
                AssetFolderNames.Sensors => AddFileFromEntry(container.Assets.Sensors, entry, behaviour),
                AssetFolderNames.Symbols => AddFileFromEntry(container.Assets.Symbols, entry, behaviour),
                AssetFolderNames.Spectrums => AddFileFromEntry(container.Assets.Spectrums, entry, behaviour),
                AssetFolderNames.Other => AddFileFromEntry(container.Assets.Other, entry, behaviour),
                _ => $"File does not match any asset category: {entry.FullName}"
            };
        }

        private string AddFileFromEntry(ICollection<ContainerFile> collection, ZipArchiveEntry entry,
            AssetLoadBehaviour loadBehaviour)
        {
            var loadComplete = loadBehaviour == AssetLoadBehaviour.Load;
            var fileEntryBytes = loadComplete ? entry.GetBytes() : Array.Empty<byte>();
            var containerFile = new ContainerFile(entry.Name, fileEntryBytes);
            collection.Add(containerFile);
            return $"{entry.Name}: {containerFile.Bytes.Length} Bytes";
        }

        private bool EvaluateFuncSafe(Func<bool> checkFunc)
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
}