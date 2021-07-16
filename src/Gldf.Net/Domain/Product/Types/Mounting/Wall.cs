using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types.Mounting
{
    public class Wall
    {
        [XmlAttribute("mountingHeight")]
        public double MountingHeight { get; set; }

        public WallRecessed Recessed { get; set; }

        public WallSurfaceMounted SurfaceMounted { get; set; }
    }
}