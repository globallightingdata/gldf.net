using Gldf.Net.Domain.Xml.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types;

public class Channel
{
    [XmlAttribute("type")]
    public ChannelType Type { get; set; }

    public Locale[] DisplayName { get; set; }

    public SpectrumReference SpectrumReference { get; set; }

    public PhotometryReference PhotometryReference { get; set; }

    public int RatedLuminousFlux { get; set; }

    public ColorInformation ColorInformation { get; set; }
}