using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types;

public class FluxFactor
{
    [XmlAttribute("inputPower")]
    public double InputPower { get; set; }

    [XmlAttribute("flickerPstLM")]
    public string FlickerPstLm { get; set; }

    [XmlAttribute("stroboscopicEffectsSVM")]
    public string StroboscopicEffectsSvm { get; set; }

    [XmlAttribute("description")]
    public string Description { get; set; }

    [XmlText]
    public double Factor { get; set; }
}