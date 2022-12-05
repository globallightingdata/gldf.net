using Gldf.Net.Container;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Parser.DataFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gldf.Net.Parser;

internal class FilesLoadTransform : TransformBase
{
    public static ParserDto Map(ParserDto parserDto)
    {
        return ExecuteSafe(() =>
        {
            bool LoadLocalFiles(GldfFileTyped file) =>
                parserDto.Settings.LocalFileLoadBehaviour == LocalFileLoadBehaviour.Load && file.Type == FileType.LocalFileName;
            bool LoadOnlineFiles(GldfFileTyped file) =>
                parserDto.Settings.OnlineFileLoadBehaviour == OnlineFileLoadBehaviour.Load && file.Type == FileType.Url;
            Parallel.ForEach(parserDto.GeneralDefinitions.Files.Where(LoadLocalFiles), file => LoadLocalFile(file, parserDto));
            Parallel.ForEach(parserDto.GeneralDefinitions.Files.Where(LoadOnlineFiles), file => LoadOnlineFile(file, parserDto));
            return parserDto;
        }, parserDto);
    }

    private static void LoadOnlineFile(GldfFileTyped file, ParserDto parserDto)
    {
        try
        {
            file.BinaryContent = parserDto.Settings.HttpClient.GetByteArrayAsync(file.Uri).GetAwaiter().GetResult();
        }
        catch
        {
            file.BinaryContent = null;
        }
    }

    private static void LoadLocalFile(GldfFileTyped file, ParserDto parserDto)
    {
        try
        {
            switch (file.ContentType)
            {
                case FileContentType.LdcEulumdat:
                case FileContentType.LdcIes:
                case FileContentType.LdcIesXml:
                    file.BinaryContent = LoadLocalContent(file, parserDto.Container.Assets.Photometries);
                    break;
                case FileContentType.ImagePng:
                case FileContentType.ImageSvg:
                case FileContentType.ImageJpg:
                    file.BinaryContent = LoadLocalContent(file, parserDto.Container.Assets.Images);
                    break;
                case FileContentType.GeoL3d:
                case FileContentType.GeoR3d:
                case FileContentType.GeoM3d:
                    file.BinaryContent = LoadLocalContent(file, parserDto.Container.Assets.Geometries);
                    break;
                case FileContentType.DocPdf:
                    file.BinaryContent = LoadLocalContent(file, parserDto.Container.Assets.Documents);
                    break;
                case FileContentType.SymbolDxf:
                case FileContentType.SymbolSvg:
                    file.BinaryContent = LoadLocalContent(file, parserDto.Container.Assets.Symbols);
                    break;
                case FileContentType.SensorSensXml:
                case FileContentType.SensorSensLdt:
                    file.BinaryContent = LoadLocalContent(file, parserDto.Container.Assets.Sensors);
                    break;
                case FileContentType.SpectrumText:
                    file.BinaryContent = LoadLocalContent(file, parserDto.Container.Assets.Spectrums);
                    break;
                case FileContentType.Other:
                    file.BinaryContent = LoadLocalContent(file, parserDto.Container.Assets.Other);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(file.ContentType));
            }
        }
        catch
        {
            file.BinaryContent = null;
        }
    }

    private static byte[] LoadLocalContent(GldfFileTyped file, IEnumerable<ContainerFile> files)
        => files.FirstOrDefault(f => f.FileName?.Equals(file.FileName, StringComparison.OrdinalIgnoreCase) == true)?.Bytes;
}