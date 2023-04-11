using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types;

public class SensorEmitter : EmitterBase
{
    [XmlElement("SensorReference")]
    public SensorReference SensorReference { get; set; }
}