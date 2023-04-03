using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types;

public class LedMaintenanceFactor : LightSourceMaintenanceTypeBase
{
    [XmlAttribute("hours")]
    public int Hours { get; set; }

    [XmlText]
    public double Factor { get; set; }
}