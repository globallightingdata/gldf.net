using Gldf.Net.Abstract;
using Gldf.Net.Exceptions;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Gldf.Net.Container
{
    internal class ZipArchiveWriter
    {
        private readonly IGldfXmlSerializer _gldfXmlSerializer;
        private readonly CompressionLevel _compressionLevel;
        private readonly Encoding _encoding;

        public ZipArchiveWriter()
        {
            _gldfXmlSerializer = new GldfXmlSerializer();
            _compressionLevel = CompressionLevel.Optimal;
            _encoding = Encoding.UTF8;
        }

        public void Write(string filePath, GldfArchive gldfArchive)
        {
            PrepareDirectory(filePath, true);
            using var zipArchive = ZipFile.Open(filePath, ZipArchiveMode.Create, _encoding);
            AddRootZipEntry(gldfArchive, zipArchive);
            AddAssetZipEntries(zipArchive, gldfArchive);
        }

        public void CreateFromDirectory(string sourceDirectory, string targetFilePath)
        {
            PrepareDirectory(targetFilePath, true);
            ZipFile.CreateFromDirectory(sourceDirectory, targetFilePath);
        }

        public void ExtractToDirectory(string sourceFilePath, string targetDirectory)
        {
            PrepareDirectory(targetDirectory, false);
            ZipFile.ExtractToDirectory(sourceFilePath, targetDirectory);
        }

        private static void PrepareDirectory(string filePath, bool deleteContainerIfExists)
        {
            if (File.Exists(filePath) && deleteContainerIfExists)
                File.Delete(filePath);
            var directoryName = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrWhiteSpace(directoryName) && !Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
        }

        private void AddRootZipEntry(GldfArchive gldfArchive, ZipArchive zipArchive)
        {
            var product = gldfArchive.Product ?? throw new RootNotFoundException("Product must not be null");
            var xml = _gldfXmlSerializer.SerializeToXml(product);
            var productEntry = zipArchive.CreateEntry("product.xml", _compressionLevel);
            using var entryStream = productEntry.Open();
            using var streamWriter = new StreamWriter(entryStream, _encoding);
            streamWriter.Write(xml);
        }

        private void AddAssetZipEntries(ZipArchive zipArchive, GldfArchive gldfArchive)
        {
            AddAssetsFor(zipArchive, gldfArchive.Assets.Photometries, AssetFolderNames.Photometries);
            AddAssetsFor(zipArchive, gldfArchive.Assets.Geometries, AssetFolderNames.Geometries);
            AddAssetsFor(zipArchive, gldfArchive.Assets.Images, AssetFolderNames.Images);
            AddAssetsFor(zipArchive, gldfArchive.Assets.Documents, AssetFolderNames.Documents);
            AddAssetsFor(zipArchive, gldfArchive.Assets.Sensors, AssetFolderNames.Sensors);
            AddAssetsFor(zipArchive, gldfArchive.Assets.Spectrums, AssetFolderNames.Spectrums);
            AddAssetsFor(zipArchive, gldfArchive.Assets.Symbols, AssetFolderNames.Symbols);
            AddAssetsFor(zipArchive, gldfArchive.Assets.Other, AssetFolderNames.Other);
        }

        private void AddAssetsFor(ZipArchive zipArchive, IEnumerable<ContainerFile> collection, string folder)
        {
            foreach (var file in collection)
            {
                var zipEntryName = $"{folder}/{file.FileName}";
                var zipFileEntry = zipArchive.CreateEntry(zipEntryName, _compressionLevel);
                using var entryStream = zipFileEntry.Open();
                entryStream.Write(file.Bytes, 0, file.Bytes.Length);
            }
        }
    }
}