using Gldf.Net.Abstract;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace Gldf.Net.Container
{
    // ReSharper disable once InconsistentNaming
    internal abstract class ZipArchiveIO
    {
        protected readonly IGldfXmlSerializer GldfXmlSerializer;
        protected readonly IMetaInfoSerializer MetaInfoSerializer;
        protected readonly CompressionLevel CompressionLevel;
        protected readonly Encoding Encoding;

        protected ZipArchiveIO()
        {
            GldfXmlSerializer = new GldfXmlSerializer();
            MetaInfoSerializer = new MetaInfoSerializer();
            CompressionLevel = CompressionLevel.Optimal;
            Encoding = Encoding.UTF8;
        }

        protected ZipArchiveIO(IGldfXmlSerializer gldfXmlSerializer, CompressionLevel compressionLevel,
            Encoding encoding)
        {
            GldfXmlSerializer = gldfXmlSerializer;
            CompressionLevel = compressionLevel;
            Encoding = encoding;
        }

        protected static void PrepareDirectory(string filePath, bool deleteContainerIfExists)
        {
            if (File.Exists(filePath) && deleteContainerIfExists)
                File.Delete(filePath);
            var directoryName = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrWhiteSpace(directoryName) && !Directory.Exists(directoryName))
                Directory.CreateDirectory(directoryName);
        }
    }
}