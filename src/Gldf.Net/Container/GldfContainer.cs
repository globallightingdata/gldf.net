using Gldf.Net.Domain;
using Gldf.Net.Domain.Definition.Types;
using System;

namespace Gldf.Net.Container
{
    public class GldfContainer
    {
        public Root Product { get; set; } = new();

        public GldfAssets Assets { get; set; } = new();

        public string Signature { get; set; } = string.Empty;

        public GldfContainer()
        {
        }

        public GldfContainer(Root root) => Product = root;

        public GldfContainer(Root root, GldfAssets assets) : this(root) => Assets = assets;

        public GldfContainer(Root root, string signature) : this(root) => Signature = signature;

        public GldfContainer(Root root, GldfAssets assets, string signature) : this(root)
        {
            Assets = assets;
            Signature = signature;
        }

        public void AddAssetFile(FileContentType fileContentType, string fileName, byte[] fileContent)
        {
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
                    throw new ArgumentOutOfRangeException(nameof(fileContentType));
            }
        }
    }
}