using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Container
{
    public static class GldfFileExtensions
    {
        public static byte[] GetBytesFromContainer(this GldfFile file, GldfContainer container)
        {
            if (file == null) throw new ArgumentNullException(nameof(file));
            if (container == null) throw new ArgumentNullException(nameof(container));

            switch (file.ContentType)
            {
                case FileContentType.LdcEulumdat:
                case FileContentType.LdcIes:
                case FileContentType.LdcIesXml:
                    return GetBytes(container.Assets.Photometries, file.File);
                case FileContentType.ImagePng:
                case FileContentType.ImageSvg:
                case FileContentType.ImageJpg:
                    return GetBytes(container.Assets.Images, file.File);
                case FileContentType.GeoL3d:
                case FileContentType.GeoR3d:
                case FileContentType.GeoM3d:
                    return GetBytes(container.Assets.Geometries, file.File);
                case FileContentType.DocPdf:
                    return GetBytes(container.Assets.Documents, file.File);
                case FileContentType.SymbolDxf:
                case FileContentType.SymbolSvg:
                    return GetBytes(container.Assets.Symbols, file.File);
                case FileContentType.SensorSensXml:
                case FileContentType.SensorSensLdt:
                    return GetBytes(container.Assets.Sensors, file.File);
                case FileContentType.SpectrumText:
                    return GetBytes(container.Assets.Spectrums, file.File);
                case FileContentType.Other:
                    return GetBytes(container.Assets.Other, file.File);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static byte[] GetBytes(IEnumerable<ContainerFile> assetCollection, string fileName)
        {
            return assetCollection.FirstOrDefault(file =>
                string.Equals(file.FileName, fileName, StringComparison.OrdinalIgnoreCase))?.Bytes;
        }
    }
}