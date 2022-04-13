using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class CieLampMaintenanceFactors : LightSourceMaintenanceTypeBase
    {
        [XmlElement("CieLampMaintenanceFactor")]
        public CieLampMaintenanceFactor[] CieLampMaintenanceFactor { get; set; }
    }
}