using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Product.Types;

public class LuminaireMaintenance
{
    public Cie97LuminaireType? Cie97LuminaireType { get; set; }

    [XmlArray("CieLuminaireMaintenanceFactors"), XmlArrayItem("LuminaireMaintenanceFactor")]
    public CieMaintenanceFactor[] CieMaintenanceFactors { get; set; }

    [XmlArray("IesLuminaireLightLossFactors"), XmlArrayItem("LuminaireDirtDepreciation")]
    public IesDirtDepreciation[] IesLightLossFactors { get; set; }

    [XmlArray("JiegMaintenanceFactors"), XmlArrayItem("LuminaireMaintenanceFactor")]
    public JiegMaintenanceFactor[] JiegMaintenanceFactors { get; set; }

    public bool ShouldSerializeCie97LuminaireType() => Cie97LuminaireType != null;
}