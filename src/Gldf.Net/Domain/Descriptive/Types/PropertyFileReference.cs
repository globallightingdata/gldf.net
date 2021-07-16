using System.Xml.Serialization;

namespace Gldf.Net.Domain.Descriptive.Types
{
    public class PropertyFileReference : PropertyContent
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "fileId")]
        public string FileId { get; set; }
    }
}