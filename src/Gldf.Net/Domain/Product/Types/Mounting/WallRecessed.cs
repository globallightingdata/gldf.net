using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types.Mounting
{
    public class WallRecessed
    {
        [XmlAttribute("recessedDepth")]
        public double RecessedDepth { get; set; }

        [XmlElement("CircularCutout", typeof(CircularCutout))]
        [XmlElement("RectangularCutout", typeof(RectangularCutout))]
        public MountingCutout Cutout { get; set; }
    }
}