using Gldf.Net.Container;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Extensions;
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
            var collection = parserDto.Container.GetAssetCollection(file.ContentType);
            file.BinaryContent = LoadLocalContent(file, collection);
        }
        catch
        {
            file.BinaryContent = null;
        }
    }

    private static byte[] LoadLocalContent(GldfFileTyped file, IEnumerable<ContainerFile> files)
        => files.FirstOrDefault(f => f.FileName?.Equals(file.FileName, StringComparison.OrdinalIgnoreCase) == true)?.Bytes;
}