using Gldf.Net.Domain.Definition.Types;
using Gldf.Net.Domain.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition
{
    public class LightSource
    {
        [XmlAttribute(DataType = "ID", AttributeName = "id")]
        public string Id { get; set; }

        public Locale[] Name { get; set; }

        public Locale[] Description { get; set; }

        [XmlElement("Changeable", typeof(ChangeableLightSource))]
        [XmlElement("Fixed", typeof(FixedLightSource))]
        public LightSourceType LightSourceType { get; set; }

        public SpectrumReference SpectrumReference { get; set; }

        public PhotometryReference PhotometryReference { get; set; }

        public ActivePowerTable ActivePowerTable { get; set; }

        [XmlElement("LightSourceMaintenance")]
        public LightSourceMaintenance Maintenance { get; set; }

        public ColorInformation ColorInformation { get; set; }

        public Image[] LightSourceImages { get; set; }

        public ChangeableLightSource GetAsChangeableLightSource() => LightSourceType as ChangeableLightSource;

        public FixedLightSource GetAsFixedLightSource() => LightSourceType as FixedLightSource;
    }
}