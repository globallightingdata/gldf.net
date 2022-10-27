using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Product.Types.Mounting
{
    public class Wall
    {
        [XmlAttribute("mountingHeight")]
        public int MountingHeight { get; set; }

        public WallRecessed Recessed { get; set; }

        public WallSurfaceMounted SurfaceMounted { get; set; }
    }
}