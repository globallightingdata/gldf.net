using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class LightSourceMaintenance
    {
        private int _lifetime;

        [XmlAttribute("lifetime")]
        public int Lifetime
        {
            get => _lifetime;
            set
            {
                _lifetime = value;
                LifetimeSpecified = value > 0;
            }
        }

        [XmlElement("Cie97LampType", typeof(Cie97LampType))]
        [XmlElement("CieLampMaintenanceFactors", typeof(CieLampMaintenanceFactors))]
        [XmlElement("LedMaintenanceFactor", typeof(LedMaintenanceFactor))]
        public LampMaintenanceType Content { get; set; }

        [XmlIgnore]
        public bool LifetimeSpecified { get; set; }

        public Cie97LampType GetAsCie97LampType() => Content as Cie97LampType;

        public CieLampMaintenanceFactors GetAsLampMaintenanceFactors() => Content as CieLampMaintenanceFactors;

        public LedMaintenanceFactor GetAsLedMaintenanceFactor() => Content as LedMaintenanceFactor;
    }
}