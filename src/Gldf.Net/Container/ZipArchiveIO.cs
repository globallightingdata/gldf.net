using Gldf.Net.Abstract;
using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Xml;

namespace Gldf.Net.Container;

// ReSharper disable once InconsistentNaming
internal abstract class ZipArchiveIO
{
    protected readonly IGldfXmlSerializer GldfXmlSerializer;
    protected readonly IMetaInfoSerializer MetaInfoSerializer;
    protected readonly CompressionLevel CompressionLevel;
    private const char Utf8ReplacementChar = (char)65533;

    private static readonly Lazy<Encoding> Codepage850Encoding = new(() =>
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        return Encoding.GetEncoding(850);
    });

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

    protected static ZipArchive OpenRead(Stream zipStream, bool leaveOpen)
    {
        var zipArchive = new ZipArchive(zipStream, ZipArchiveMode.Read, leaveOpen);
        var hasReplacementChars = zipArchive.Entries.Any(e => e.FullName.Contains(Utf8ReplacementChar));
        if (!hasReplacementChars) return zipArchive;
        zipStream.Seek(0, SeekOrigin.Begin);
        if (leaveOpen)
        {
            zipArchive.Dispose();
            return new ZipArchive(zipStream, ZipArchiveMode.Read, true, Codepage850Encoding.Value);
        }
        var zipStreamCopy = new MemoryStream();
        zipStream.CopyTo(zipStreamCopy);
        zipArchive.Dispose();
        return new ZipArchive(zipStreamCopy, ZipArchiveMode.Read, false, Codepage850Encoding.Value);
    }

    protected static ZipArchive OpenRead(string filepath)
    {
        var zipArchive = ZipFile.Open(filepath, ZipArchiveMode.Read);
        var hasReplacementChars = zipArchive.Entries.Any(e => e.FullName.Contains(Utf8ReplacementChar));
        if (!hasReplacementChars) return zipArchive;
        zipArchive.Dispose();
        return ZipFile.Open(filepath, ZipArchiveMode.Read, Codepage850Encoding.Value);
    }
}