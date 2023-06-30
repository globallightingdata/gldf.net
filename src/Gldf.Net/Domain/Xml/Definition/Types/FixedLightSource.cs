using Gldf.Net.Domain.Xml.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types;

public class FixedLightSource : LightSourceBase
{
    public SpectrumReference SpectrumReference { get; set; }

    public ActivePowerTable ActivePowerTable { get; set; }

    public ColorInformation ColorInformation { get; set; }

    public Image[] LightSourceImages { get; set; }

    [XmlElement("LightSourceMaintenance")]
    public LightSourceMaintenance Maintenance { get; set; }

    public bool? ZhagaStandard { get; set; }

    public bool ShouldSerializeZhagaStandard() => ZhagaStandard != null;
}