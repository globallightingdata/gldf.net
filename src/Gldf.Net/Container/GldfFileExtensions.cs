using Gldf.Net.Domain.Definition;
using Gldf.Net.Domain.Definition.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Container
{
    public static class GldfFileExtensions
    {
        public static byte[] GetBytesFromContainer(this GldfFile file, GldfArchive gldfArchive)
        {
            switch (file.ContentType)
            {
                case FileContentType.LdcEulumdat:
                case FileContentType.LdcIes:
                case FileContentType.LdcIesXml:
                    return GetBytes(gldfArchive.Assets.Photometries, file.File);
                case FileContentType.ImagePng:
                case FileContentType.ImageSvg:
                case FileContentType.ImageJpg:
                    return GetBytes(gldfArchive.Assets.Images, file.File);
                case FileContentType.GeoL3d:
                case FileContentType.GeoR3d:
                case FileContentType.GeoM3d:
                    return GetBytes(gldfArchive.Assets.Geometries, file.File);
                case FileContentType.DocPdf:
                    return GetBytes(gldfArchive.Assets.Documents, file.File);
                case FileContentType.SymbolDxf:
                case FileContentType.SymbolSvg:
                    return GetBytes(gldfArchive.Assets.Symbols, file.File);
                case FileContentType.SensorSensXml:
                case FileContentType.SensorSensLdt:
                    return GetBytes(gldfArchive.Assets.Sensors, file.File);
                case FileContentType.SpectrumText:
                    return GetBytes(gldfArchive.Assets.Spectrums, file.File);
                case FileContentType.Other:
                    return GetBytes(gldfArchive.Assets.Other, file.File);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static byte[] GetBytes(IEnumerable<ContainerFile> assetCollection, string fileName)
        {
            return assetCollection.FirstOrDefault(p =>
                string.Equals(p.FileName, fileName, StringComparison.OrdinalIgnoreCase))?.Bytes;
        }
    }
}