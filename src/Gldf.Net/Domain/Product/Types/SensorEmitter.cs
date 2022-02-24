using Gldf.Net.Domain.Definition.Types;
using Gldf.Net.Domain.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types
{
    public class SensorEmitter : EmitterBase
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "sensorId")]
        public string SensorId { get; set; }

        public Locale[] Name { get; set; }
    }
}