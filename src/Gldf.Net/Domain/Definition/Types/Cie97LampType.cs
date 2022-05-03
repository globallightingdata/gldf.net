using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class Cie97LampType : LightSourceMaintenanceTypeBase
    {
        [XmlText]
        public Cie97LampTypeEnum Cie97LampTypeEnum { get; set; }
    }
}