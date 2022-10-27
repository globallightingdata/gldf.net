using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Product.Types
{
    public class Symbol
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "fileId")]
        public string FileId { get; set; }
    }
}