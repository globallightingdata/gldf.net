using Gldf.Net.Domain.Xml.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types;

public class MultiChannelLightSource : LightSourceBase
{
    public ActivePowerTable ActivePowerTable { get; set; }

    public ColorInformation ColorInformation { get; set; }

    public Image[] LightSourceImages { get; set; }
    
    public Channel[] Channels { get; set; }

    [XmlElement("LightSourceMaintenance")]
    public LightSourceMaintenance Maintenance { get; set; }

    public double? EmergencyBallastLumenFactor { get; set; }
    
    public bool ShouldSerializeEmergencyBallastLumenFactor() => EmergencyBallastLumenFactor != null;
}