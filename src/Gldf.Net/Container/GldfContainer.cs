using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Extensions;
using System;
using System.ComponentModel;

namespace Gldf.Net.Container;

public class GldfContainer
{
    public Root Product { get; set; }

    public GldfAssets Assets { get; set; } = new();

    public MetaInformation MetaInformation { get; set; }

    public GldfContainer()
    {
    }

    public GldfContainer(Root root)
        => Product = root ?? throw new ArgumentNullException(nameof(root));

    public GldfContainer(Root root, GldfAssets assets) : this(root)
        => Assets = assets ?? throw new ArgumentNullException(nameof(assets));

    public GldfContainer(Root root, MetaInformation metaInformation) : this(root)
        => MetaInformation = metaInformation ?? throw new ArgumentNullException(nameof(metaInformation));

    public GldfContainer(Root root, GldfAssets assets, MetaInformation metaInformation) : this(root)
    {
        Assets = assets ?? throw new ArgumentNullException(nameof(assets));
        MetaInformation = metaInformation ?? throw new ArgumentNullException(nameof(metaInformation));
    }

    public void AddAssetFile(FileContentType fileContentType, string fileName, byte[] fileContent)
    {
        if (!Enum.IsDefined(typeof(FileContentType), fileContentType))
            throw new InvalidEnumArgumentException(nameof(fileContentType), (int)fileContentType, typeof(FileContentType));
        if (fileName == null) throw new ArgumentNullException(nameof(fileName));
        if (fileContent == null) throw new ArgumentNullException(nameof(fileContent));
        var assetCollection = this.GetAssetCollection(fileContentType);
        assetCollection.Add(new ContainerFile(fileName, fileContent));
    }
}