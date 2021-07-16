using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class CieLampMaintenanceFactor : LampMaintenanceType
    {
        [XmlAttribute("burningTime")]
        public int BurningTime { get; set; }

        public double LampLumenMaintenanceFactor { get; set; }

        public double LampSurvivalFactor { get; set; }
    }
}