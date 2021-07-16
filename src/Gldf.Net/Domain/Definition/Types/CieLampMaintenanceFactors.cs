using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class CieLampMaintenanceFactors : LampMaintenanceType
    {
        [XmlElement("CieLampMaintenanceFactor")]
        public CieLampMaintenanceFactor[] CieLampMaintenanceFactor { get; set; }
    }
}