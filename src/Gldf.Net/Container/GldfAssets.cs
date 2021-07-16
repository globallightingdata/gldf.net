using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Container
{
    public class GldfAssets
    {
        public List<ContainerFile> Photometries { get; } = new();

        public List<ContainerFile> Images { get; } = new();

        public List<ContainerFile> Geometries { get; } = new();

        public List<ContainerFile> Documents { get; } = new();

        public List<ContainerFile> Symbols { get; } = new();

        public List<ContainerFile> Sensors { get; } = new();

        public List<ContainerFile> Spectrums { get; } = new();

        public List<ContainerFile> Other { get; } = new();

        public IEnumerable<ContainerFile> All => Photometries.Union(Images).Union(Geometries)
            .Union(Documents).Union(Symbols).Union(Sensors).Union(Spectrums).Union(Other);
    }
}