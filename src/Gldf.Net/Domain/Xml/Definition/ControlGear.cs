using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition;

public class ControlGear
{
    [XmlAttribute(DataType = "ID", AttributeName = "id")]
    public string Id { get; set; }

    public Locale[] Name { get; set; }

    public Locale[] Description { get; set; }

    public Voltage NominalVoltage { get; set; }

    public double? StandbyPower { get; set; }

    public double? ConstantLightOutputStartPower { get; set; }

    public double? ConstantLightOutputEndPower { get; set; }

    public double? PowerConsumptionControls { get; set; }

    [XmlElement(ElementName = "Dimmable")]
    public bool? IsDimmable { get; set; }

    [XmlElement(ElementName = "ColorControllable")]
    public bool? IsColorControllable { get; set; }

    [XmlArrayItem("Interface")]
    public Interface[] Interfaces { get; set; }

    [XmlArrayItem("EnergyLabel")]
    public EnergyLabel[] EnergyLabels { get; set; }

    public bool ShouldSerializeStandbyPower() => StandbyPower != null;

    public bool ShouldSerializeConstantLightOutputStartPower() => ConstantLightOutputStartPower != null;

    public bool ShouldSerializeConstantLightOutputEndPower() => ConstantLightOutputEndPower != null;

    public bool ShouldSerializePowerConsumptionControls() => PowerConsumptionControls != null;

    public bool ShouldSerializeIsDimmable() => IsDimmable != null;

    public bool ShouldSerializeIsColorControllable() => IsColorControllable != null;
}