using Gldf.Net.Domain.Definition.Types;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition
{
    public class GldfFile
    {
        [XmlAttribute(DataType = "ID", AttributeName = "id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "contentType")]
        public FileContentType ContentType { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public FileType Type { get; set; }

        [XmlAttribute(DataType = "language", AttributeName = "language")]
        public string Language { get; set; }

        [XmlText]
        public string File { get; set; }
    }
}