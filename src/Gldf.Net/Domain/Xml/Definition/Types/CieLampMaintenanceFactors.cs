using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types
{
    public class CieLampMaintenanceFactors : LightSourceMaintenanceTypeBase
    {
        [XmlElement("CieLampMaintenanceFactor")]
        public CieLampMaintenanceFactor[] CieLampMaintenanceFactor { get; set; }
    }
}