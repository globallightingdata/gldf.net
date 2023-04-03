using Gldf.Net.Domain.Xml.Descriptive.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive;

public class Emergency
{
    [XmlArrayItem("Flux")]
    public EmergencyFlux[] DurationTimeAndFlux { get; set; }

    public EmergencyLightingType? DedicatedEmergencyLightingType { get; set; }
}