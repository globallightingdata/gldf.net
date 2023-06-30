using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Xml.Definition.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Typed.Definition.Types;

public class ChannelTyped
{
    [XmlAttribute("type")]
    public ChannelType Type { get; set; }

    public LocaleTyped[] DisplayName { get; set; }

    public SpectrumTyped Spectrum { get; set; }

    public PhotometryTyped Photometry { get; set; }

    public int RatedLuminousFlux { get; set; }

    public ColorInformationTyped ColorInformation { get; set; }
}