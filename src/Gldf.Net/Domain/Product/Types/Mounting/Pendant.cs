using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types.Mounting
{
    public class Pendant
    {
        [XmlAttribute("pendantLength")]
        public double PendantLength { get; set; }
    }
}