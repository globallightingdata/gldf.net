using System.Xml.Serialization;

namespace Gldf.Net.Domain.Definition.Types
{
    public class FixedLightSource : LightSourceBase
    {
        [XmlElement("LightSourceMaintenance")]
        public LightSourceMaintenance Maintenance { get; set; }
        
        public bool? ZhagaStandard { get; set; }

        public bool ShouldSerializeZhagaStandard() => ZhagaStandard != null;
    }
}