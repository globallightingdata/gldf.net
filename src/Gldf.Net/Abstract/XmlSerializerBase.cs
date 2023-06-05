using Gldf.Net.Exceptions;
using Gldf.Net.XmlHelper;
using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Gldf.Net.Abstract;

public abstract class XmlSerializerBase<T>
{
    public Encoding Encoding => WriterSettings.Encoding;

    protected readonly XmlWriterSettings WriterSettings;
    protected readonly XmlReaderSettings ReaderSettings;
    protected readonly XmlSerializer XmlSerializer;
    protected readonly XmlSerializerNamespaces XmlNamespaces;

    /// <summary>
    ///     Initializes a new instance that can serialize <see cref="T" /> to and from XML.
    /// </summary>
    protected XmlSerializerBase() : this(
        new XmlWriterSettings { Indent = true },
        new XmlReaderSettings { IgnoreWhitespace = true })
    {
    }

    /// <summary>
    ///     Initializes a new instance that can serialize <see cref="T" /> to and from XML. This overload also specifies
    ///     <see cref="System.Xml.XmlWriterSettings" /> and <see cref="System.Xml.XmlReaderSettings" /> which allows the
    ///     control of XML indentation, Encoding and more.
    ///     <exception cref="ArgumentNullException">If the reader/writer settings are null.</exception>
    /// </summary>
    protected XmlSerializerBase(XmlWriterSettings writerSettings, XmlReaderSettings readerSettings)
    {
        WriterSettings = writerSettings ?? throw new ArgumentNullException(nameof(writerSettings));
        ReaderSettings = readerSettings ?? throw new ArgumentNullException(nameof(readerSettings));
        XmlSerializer = new XmlSerializer(typeof(T));
        XmlNamespaces = GldfNamespaceProvider.GetNamespaces();
    }

    /// <summary>Converts the parameter of type <see cref="T" /> into XML.</summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>The XML representation of the value.</returns>
    /// <exception cref="ArgumentNullException">If the value is null.</exception>
    /// <exception cref="GldfException">if the input is invalid. See also InnerException.</exception>
    public string SerializeToXml(T value)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        try
        {
            var stringBuilder = new StringBuilder();
            using var xmlWriter = XmlWriter.Create(stringBuilder, WriterSettings);
            XmlSerializer.Serialize(xmlWriter, value, XmlNamespaces);
            return stringBuilder.ToString();
        }
        catch (Exception e)
        {
            throw new GldfException($"Failed to serialize {typeof(T).Name} to XML", e);
        }
    }

    /// <summary>
    ///     Converts the parameter of type <see cref="T" /> to XML and writes the result to a file.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="xmlFilePath">The path of the file to write to.</param>
    /// <exception cref="ArgumentNullException">If value or filepath is null.</exception>
    /// <exception cref="GldfException">
    ///     If the input is invalid or the filePath cannot be written to. See also InnerException.
    /// </exception>
    public void SerializeToXmlFile(T value, string xmlFilePath)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        if (xmlFilePath == null) throw new ArgumentNullException(nameof(xmlFilePath));
        try
        {
            using var streamWriter = new StreamWriter(xmlFilePath, false, WriterSettings.Encoding);
            using var xmlWriter = XmlWriter.Create(streamWriter, WriterSettings);
            XmlSerializer.Serialize(xmlWriter, value, XmlNamespaces);
        }
        catch (Exception e)
        {
            throw new GldfException($"Failed to serialize {typeof(T).Name} to disk", e);
        }
    }

    /// <summary>
    ///     Converts the parameter of type <see cref="T" /> into XML and writes  it to a
    ///     <see cref="System.IO.Stream" />.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <param name="xmlStream">The Stream to save to.</param>
    /// <param name="leaveOpen">Whether to close the stream after serialization.</param>
    /// <exception cref="ArgumentNullException">If value or Stream is null.</exception>
    /// <exception cref="GldfException">
    ///     Input is invalid or the Stream cannot be written to. See also InnerException.
    /// </exception>
    public void SerializeToXmlStream(T value, Stream xmlStream, bool leaveOpen)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));
        if (xmlStream == null) throw new ArgumentNullException(nameof(xmlStream));
        try
        {
            var settingsToUse = WriterSettings.Clone();
            settingsToUse.CloseOutput = !leaveOpen;
            using var xmlWriter = XmlWriter.Create(xmlStream, settingsToUse);
            XmlSerializer.Serialize(xmlWriter, value, XmlNamespaces);
        }
        catch (Exception e)
        {
            throw new GldfException($"Failed to serialize {typeof(T).Name} to stream", e);
        }
    }

    /// <summary>Deserializes the XML into an object of type <see cref="T" /></summary>
    /// <param name="xml">The XML to deserialize from.</param>
    /// <returns>Representation of the XML as instance of the type <see cref="T" /></returns>
    /// <exception cref="ArgumentNullException">The value is null.</exception>
    /// <exception cref="GldfException">Input is invalid XML. See also InnerException.</exception>
    public T DeserializeFromXml(string xml)
    {
        if (xml == null) throw new ArgumentNullException(nameof(xml));
        try
        {
            using var stringReader = new StringReader(xml);
            using var xmlReader = XmlReader.Create(stringReader, ReaderSettings);
            var deserializedXml = XmlSerializer.Deserialize(xmlReader);
            return (T)deserializedXml;
        }
        catch (Exception e)
        {
            throw new GldfException($"Failed to deserialize {typeof(T).Name} from XML", e);
        }
    }

    /// <summary>Deserializes the file containing XML into an object of type <see cref="T" /></summary>
    /// <param name="xmlFilePath">The file containing the XML to deserialize from.</param>
    /// <returns>Representation of the XML file as instance of the type <see cref="T" /></returns>
    /// <exception cref="ArgumentNullException">The xmlFilePath is null.</exception>
    /// <exception cref="GldfException">
    ///     Input is invalid XML or the xmlFilePath cannot be read from. See also InnerException.
    /// </exception>
    public T DeserializeFromXmlFile(string xmlFilePath)
    {
        if (xmlFilePath == null) throw new ArgumentNullException(nameof(xmlFilePath));
        try
        {
            using var streamIn = new StreamReader(xmlFilePath, true);
            using var xmlReader = XmlReader.Create(streamIn, ReaderSettings);
            var deserializedXml = XmlSerializer.Deserialize(xmlReader);
            return (T)deserializedXml;
        }
        catch (Exception e)
        {
            throw new GldfException($"Failed to deserialize {typeof(T).Name} from filepath '{xmlFilePath}'", e);
        }
    }

    /// <summary>Deserializes the Stream containing XML into an object of type <see cref="T" /></summary>
    /// <param name="xmlStream">The Stream containing the XML</param>
    /// <param name="leaveOpen">Whether to close the stream after deserialization.</param>
    /// <returns>Representation of the XML as instance of the type <see cref="T" /></returns>
    /// <exception cref="ArgumentNullException">If the stream is null.</exception>
    /// <exception cref="GldfException">
    ///     Input contains invalid XML or the Stream cannot be read from. See also InnerException.
    /// </exception>
    public T DeserializeFromXmlStream(Stream xmlStream, bool leaveOpen)
    {
        if (xmlStream == null) throw new ArgumentNullException(nameof(xmlStream));

        try
        {
            var settingsToUse = ReaderSettings.Clone();
            settingsToUse.CloseInput = !leaveOpen;
            using var xmlReader = XmlReader.Create(xmlStream, settingsToUse);
            var deserializedXml = XmlSerializer.Deserialize(xmlReader);
            return (T)deserializedXml;
        }
        catch (Exception e)
        {
            throw new GldfException($"Failed to deserialize {typeof(T).Name} from stream", e);
        }
    }
}