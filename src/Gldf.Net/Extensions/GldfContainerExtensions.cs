using Gldf.Net.Container;
using Gldf.Net.Domain.Xml.Definition.Types;
using System;
using System.Collections.Generic;

namespace Gldf.Net.Extensions;

public static class GldfContainerExtensions
{
    public static List<ContainerFile> GetAssetCollection(this GldfContainer gldf, FileContentType contentType)
    {
        if (gldf == null) throw new ArgumentNullException(nameof(gldf));
        switch (contentType)
        {
            case FileContentType.LdcEulumdat:
            case FileContentType.LdcIes:
            case FileContentType.LdcIesXml:
                return gldf.Assets.Photometries;
            case FileContentType.ImagePng:
            case FileContentType.ImageSvg:
            case FileContentType.ImageJpg:
                return gldf.Assets.Images;
            case FileContentType.GeoL3d:
            case FileContentType.GeoR3d:
            case FileContentType.GeoM3d:
                return gldf.Assets.Geometries;
            case FileContentType.DocPdf:
                return gldf.Assets.Documents;
            case FileContentType.SymbolDxf:
            case FileContentType.SymbolSvg:
                return gldf.Assets.Symbols;
            case FileContentType.SensorSensXml:
            case FileContentType.SensorSensLdt:
                return gldf.Assets.Sensors;
            case FileContentType.SpectrumText:
                return gldf.Assets.Spectrums;
            case FileContentType.Other:
                return gldf.Assets.Other;
            default:
                throw new ArgumentOutOfRangeException(nameof(contentType));
        }
    }
}