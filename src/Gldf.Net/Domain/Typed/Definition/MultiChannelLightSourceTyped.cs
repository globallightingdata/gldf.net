using Gldf.Net.Domain.Typed.Definition.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Typed.Definition;

public class MultiChannelLightSourceTyped : LightSourceBaseTyped
{
    public ActivePowerTableTyped ActivePowerTable { get; set; }

    public ColorInformationTyped ColorInformation { get; set; }

    public ImageFileTyped[] LightSourceImages { get; set; }

    public ChannelTyped[] Channels { get; set; }

    [XmlElement("LightSourceMaintenance")]
    public LightSourceMaintenanceTyped Maintenance { get; set; }

    public double? EmergencyBallastLumenFactor { get; set; }

    public bool ShouldSerializeEmergencyBallastLumenFactor() => EmergencyBallastLumenFactor != null;
}