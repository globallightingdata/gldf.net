using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class LedMaintenanceFactor : LightSourceMaintenanceTypeBase
    {
        [XmlAttribute("hours")]
        public int Hours { get; set; }

        [XmlText]
        public double Factor { get; set; }
    }
}