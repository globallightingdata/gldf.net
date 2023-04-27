using Gldf.Net.Abstract;
using Gldf.Net.Domain.Xml;
using System.Xml;

namespace Gldf.Net;

/// <summary>
///     Provides functionality to serialize instances of type <see cref="Root" /> into GLDF-XML
///     text and to deserialize GLDF-XML text into instances of type <see cref="Root" />.
///     This type is threadsafe.
/// </summary>
public class GldfXmlSerializer : XmlSerializerBase<Root>, IGldfXmlSerializer
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="GldfXmlSerializer" /> class that can serialize
    ///     instances of type <see cref="Root" /> into GLDF-XML text and to deserialize GLDF-XML
    ///     text into instances of type <see cref="Root" />.
    /// </summary>
    public GldfXmlSerializer()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="GldfXmlSerializer" /> class that can serialize
    ///     instances of type <see cref="Root" /> into GLDF-XML text and to deserialize GLDF-XML
    ///     text into instances of type <see cref="Root" /> This overload also specifies
    ///     <see cref="System.Xml.XmlWriterSettings" /> which allows the control of XML indentation, Encoding
    ///     and more.
    /// </summary>
    public GldfXmlSerializer(XmlWriterSettings writerSettings, XmlReaderSettings readerSettings) : base(writerSettings, readerSettings)
    {
    }
}