using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Container;

public class GldfAssets
{
    public List<ContainerFile> Photometries { get; } = [];

    public List<ContainerFile> Images { get; } = [];

    public List<ContainerFile> Geometries { get; } = [];

    public List<ContainerFile> Documents { get; } = [];

    public List<ContainerFile> Symbols { get; } = [];

    public List<ContainerFile> Sensors { get; } = [];

    public List<ContainerFile> Spectrums { get; } = [];

    public List<ContainerFile> Other { get; } = [];

    public IEnumerable<ContainerFile> All => Photometries.Concat(Images).Concat(Geometries)
        .Concat(Documents).Concat(Symbols).Concat(Sensors).Concat(Spectrums).Concat(Other);
}