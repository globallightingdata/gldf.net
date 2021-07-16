using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class PhotometryReference
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "photometryId")]
        public string PhotometryId { get; set; }
    }
}