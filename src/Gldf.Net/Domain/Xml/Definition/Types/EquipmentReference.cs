using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types
{
    public class EquipmentReference
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "equipmentId")]
        public string EquipmentId { get; set; }
    }
}