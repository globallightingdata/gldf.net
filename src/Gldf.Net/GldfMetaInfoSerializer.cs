using Gldf.Net.Abstract;
using Gldf.Net.Domain.Xml;
using System.Xml;

namespace Gldf.Net;

/// <summary>
///     Provides functionality to serialize instances of type <see cref="MetaInformation" /> into XML
///     text and to deserialize XML text into instances of type <see cref="MetaInformation" />.
///     This type is threadsafe.
/// </summary>
public class MetaInfoSerializer : XmlSerializerBase<MetaInformation>, IMetaInfoSerializer
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="MetaInfoSerializer" /> class that can serialize
    ///     instances of type <see cref="MetaInformation" /> into XML text and to deserialize XML
    ///     text into instances of type <see cref="MetaInformation" />.
    /// </summary>
    public MetaInfoSerializer()
    {
    }

    /// <summary>
    ///     Initializes a new instance of the <see cref="MetaInfoSerializer" /> class that can serialize
    ///     instances of type <see cref="MetaInformation" /> into XML text and to deserialize XML
    ///     text into instances of type <see cref="MetaInformation" />. This overload also specifies
    ///     <see cref="System.Xml.XmlWriterSettings" /> and <see cref="System.Xml.XmlReaderSettings" /> which allow the
    ///     control of XML indentation, Encoding and more.
    /// </summary>
    public MetaInfoSerializer(XmlWriterSettings writerSettings, XmlReaderSettings readerSettings) : base(writerSettings, readerSettings)
    {
    }
}