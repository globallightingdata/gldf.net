using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Product.Types.Mounting
{
    public class Recessed
    {
        [XmlAttribute("recessedDepth")]
        public int RecessedDepth { get; set; }

        [XmlElement("CircularCutout", typeof(CircularCutout))]
        [XmlElement("RectangularCutout", typeof(RectangularCutout))]
        public MountingCutoutBase Cutout { get; set; }
    }
}