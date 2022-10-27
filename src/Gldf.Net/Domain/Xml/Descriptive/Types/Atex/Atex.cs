using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive.Types.Atex
{
    public class Atex
    {
        [XmlArrayItem("Directive")]
        public AtexDirective[] Directives { get; set; }

        [XmlArrayItem("Class")]
        public AtexClass[] Classes { get; set; }

        [XmlArrayItem("Division")]
        public AtexDivision[] Divisions { get; set; }

        public AtexDivisionGroups DivisionGroups { get; set; }

        public AtexZones Zones { get; set; }

        public AtexZoneGroups ZoneGroups { get; set; }

        public string MaximumSurfaceTemperature { get; set; }

        [XmlArrayItem("TemperatureClass")]
        public AtexTemperatureClass[] TemperatureClasses { get; set; }

        [XmlArrayItem("ExCode")]
        public AtexExCode[] ExCodes { get; set; }

        [XmlArrayItem("EquipmentProtectionLevel")]
        public AtexEquipmentProtectionLevel[] EquipmentProtectionLevels { get; set; }

        [XmlArrayItem("EquipmentGroup")]
        public AtexEquipmentGroup[] EquipmentGroups { get; set; }

        [XmlArrayItem("EquipmentCategory")]
        public AtexEquipmentCategory[] EquipmentCategories { get; set; }

        [XmlArrayItem("Atmosphere")]
        public AtexAtmosphere[] Atmospheres { get; set; }

        [XmlArrayItem("Group")]
        public AtexGroup[] Groups { get; set; }
    }
}