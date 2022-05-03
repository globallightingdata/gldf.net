using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class CieLampMaintenanceFactor : LightSourceMaintenanceTypeBase
    {
        [XmlAttribute("burningTime")]
        public int BurningTime { get; set; }

        public double LampLumenMaintenanceFactor { get; set; }

        public double LampSurvivalFactor { get; set; }
    }
}