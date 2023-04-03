using Gldf.Net.Domain.Xml;
using Gldf.Net.Domain.Xml.Definition.Types;
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
            throw new InvalidEnumArgumentException(nameof(fileContentType), (int)fileContentType,
                typeof(FileContentType));
        if (fileName == null) throw new ArgumentNullException(nameof(fileName));
        if (fileContent == null) throw new ArgumentNullException(nameof(fileContent));

        switch (fileContentType)
        {
            case FileContentType.LdcEulumdat:
            case FileContentType.LdcIes:
            case FileContentType.LdcIesXml:
                Assets.Photometries.Add(new ContainerFile(fileName, fileContent));
                break;
            case FileContentType.ImagePng:
            case FileContentType.ImageSvg:
            case FileContentType.ImageJpg:
                Assets.Images.Add(new ContainerFile(fileName, fileContent));
                break;
            case FileContentType.GeoL3d:
            case FileContentType.GeoR3d:
            case FileContentType.GeoM3d:
                Assets.Geometries.Add(new ContainerFile(fileName, fileContent));
                break;
            case FileContentType.DocPdf:
                Assets.Documents.Add(new ContainerFile(fileName, fileContent));
                break;
            case FileContentType.SymbolDxf:
            case FileContentType.SymbolSvg:
                Assets.Symbols.Add(new ContainerFile(fileName, fileContent));
                break;
            case FileContentType.SensorSensXml:
            case FileContentType.SensorSensLdt:
                Assets.Sensors.Add(new ContainerFile(fileName, fileContent));
                break;
            case FileContentType.SpectrumText:
                Assets.Spectrums.Add(new ContainerFile(fileName, fileContent));
                break;
            case FileContentType.Other:
                Assets.Other.Add(new ContainerFile(fileName, fileContent));
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(fileContentType), fileContentType, null);
        }
    }
}