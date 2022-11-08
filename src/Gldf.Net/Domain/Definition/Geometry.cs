using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition
{
    public class GeometryBase
    {
        [XmlAttribute(DataType = "ID", AttributeName = "id")]
        public string Id { get; set; }
    }
}