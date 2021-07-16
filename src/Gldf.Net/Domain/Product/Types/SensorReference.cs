using Gldf.Net.Domain.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types
{
    public class SensorReference : EmissionObjectReference
    {
        public Locale[] DisplayName { get; set; }

        [XmlAttribute(DataType = "NCName", AttributeName = "sensorId")]
        public string SensorId { get; set; }
    }
}