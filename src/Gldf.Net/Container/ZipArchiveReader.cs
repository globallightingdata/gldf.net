using Gldf.Net.Abstract;
using Gldf.Net.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace Gldf.Net.Container
{
    internal class ZipArchiveReader
    {
        private readonly IGldfXmlSerializer _gldfXmlSerializer;
        private readonly Encoding _encoding;

        public ZipArchiveReader()
        {
            _gldfXmlSerializer = new GldfXmlSerializer();
            _encoding = Encoding.UTF8;
        }

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

        public GldfArchive ReadArchive(string filePath)
        {
            return ReadArchive(filePath, ContainerLoadSettings.Default);
        }

        public GldfArchive ReadArchive(string filePath, ContainerLoadSettings settings)
        {
            var archive = new GldfArchive();
            using var zipArchive = ZipFile.OpenRead(filePath);
            if (settings.ProductLoadBehaviour == ProductLoadBehaviour.Load)
                AddDeserializedRoot(archive, zipArchive);
            if (settings.AssetLoadBehaviour != AssetLoadBehaviour.Skip)
                AddAssets(zipArchive, archive, settings.AssetLoadBehaviour);
            if (settings.SignatureLoadBehaviour == SignatureLoadBehaviour.Load)
                AddSignature(zipArchive, archive);
            return archive;
        }

        public string ReadRootXml(string filePath)
        {
            using var zipArchive = ZipFile.OpenRead(filePath);
            return ReadRootXml(zipArchive);
        }

        private string ReadRootXml(ZipArchive zipArchive)
        {
            var productEntry = zipArchive.GetEntry("product.xml");
            if (productEntry == null)
                throw new RootNotFoundException($"Required product.xml not found in root of {nameof(GldfContainer)}");
            using var stream = productEntry.Open();
            using var streamReader = new StreamReader(stream, _encoding);
            return streamReader.ReadToEnd();
        }

        public IEnumerable<string> GetLargeFileNames(string filePath, long minBytes)
        {
            using var zipArchive = ZipFile.OpenRead(filePath);
            return zipArchive.Entries.Where(e => e.Length >= minBytes).Select(e => e.FullName);
        }

        private void AddDeserializedRoot(GldfArchive archive, ZipArchive zipArchive)
        {
            var rootXml = ReadRootXml(zipArchive);
            var deserializedRoot = _gldfXmlSerializer.DeserializeFromString(rootXml);
            archive.Product = deserializedRoot;
        }

        private void AddSignature(ZipArchive zipArchive, GldfArchive archive)
        {
            var signatureEntry = zipArchive.GetEntry("signature");
            if (signatureEntry == null) return;
            using var stream = signatureEntry.Open();
            using var streamReader = new StreamReader(stream, _encoding);
            archive.Signature = streamReader.ReadToEnd();
        }

        private void AddAssets(ZipArchive zipArchive, GldfArchive archive, AssetLoadBehaviour loadBehaviour)
        {
            var fileEntries = zipArchive.Entries.Where(entry => !string.IsNullOrEmpty(entry.Name));
            foreach (var entry in fileEntries)
                _ = HandleAssetEntry(archive, entry, loadBehaviour);
        }

        private string HandleAssetEntry(GldfArchive archive, ZipArchiveEntry entry, AssetLoadBehaviour loadBehaviour)
        {
            var firstPathPart = entry.FullName.Split('/')[0].ToLower();
            return firstPathPart switch
            {
                AssetFolderNames.Geometries => AddFileFromEntry(archive.Assets.Geometries, entry, loadBehaviour),
                AssetFolderNames.Photometries => AddFileFromEntry(archive.Assets.Photometries, entry, loadBehaviour),
                AssetFolderNames.Images => AddFileFromEntry(archive.Assets.Images, entry, loadBehaviour),
                AssetFolderNames.Documents => AddFileFromEntry(archive.Assets.Documents, entry, loadBehaviour),
                AssetFolderNames.Sensors => AddFileFromEntry(archive.Assets.Sensors, entry, loadBehaviour),
                AssetFolderNames.Symbols => AddFileFromEntry(archive.Assets.Symbols, entry, loadBehaviour),
                AssetFolderNames.Spectrums => AddFileFromEntry(archive.Assets.Spectrums, entry, loadBehaviour),
                AssetFolderNames.Other => AddFileFromEntry(archive.Assets.Other, entry, loadBehaviour),
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
            try { return checkFunc(); }
            catch { return false; }
        }
    }
}