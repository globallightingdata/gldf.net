using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class PhotometryFileReference : PhotometryContent
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "fileId")]
        public string FileId { get; set; }
    }
}