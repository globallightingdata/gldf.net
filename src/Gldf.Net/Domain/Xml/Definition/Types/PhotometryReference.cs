using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types
{
    public class PhotometryReference
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "photometryId")]
        public string PhotometryId { get; set; }
    }
}