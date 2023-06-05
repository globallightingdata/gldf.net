using Gldf.Net.Abstract;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace Gldf.Net.Container;

// ReSharper disable once InconsistentNaming
internal abstract class ZipArchiveIO
{
    protected readonly IGldfXmlSerializer GldfXmlSerializer;
    protected readonly IMetaInfoSerializer MetaInfoSerializer;
    protected readonly CompressionLevel CompressionLevel;

    protected ZipArchiveIO() : this(Encoding.UTF8)
    {
    }

    protected ZipArchiveIO(Encoding encoding)
    {
        var xmlWriterSettings = new XmlWriterSettings { Encoding = encoding, Indent = true };
        var xmlReaderSettings = new XmlReaderSettings { IgnoreWhitespace = true };
        GldfXmlSerializer = new GldfXmlSerializer(xmlWriterSettings, xmlReaderSettings);
        MetaInfoSerializer = new MetaInfoSerializer(xmlWriterSettings, xmlReaderSettings);
        CompressionLevel = CompressionLevel.Optimal;
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