using Gldf.Net.Domain.Descriptive.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Descriptive
{
    public class Emergency
    {
        [XmlArrayItem("Flux")]
        public EmergencyFlux[] DurationTimeAndFlux { get; set; }

        public EmergencyLightingType? DedicatedEmergencyLightingType { get; set; }
    }
}