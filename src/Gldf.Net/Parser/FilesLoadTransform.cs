using Gldf.Net.Container;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Extensions;
using Gldf.Net.Parser.DataFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Gldf.Net.Parser;

internal class FilesLoadTransform : TransformBase
{
    public static Task<ParserDto> MapAsync(ParserDto parserDto) =>
        ExecuteSafeAsync(async () =>
        {
            bool LoadOnlineFiles(GldfFileTyped file) =>
                parserDto.Settings.OnlineFileLoadBehaviour == OnlineFileLoadBehaviour.Load && file.Type == FileType.Url;
            bool LoadLocalFiles(GldfFileTyped file) =>
                parserDto.Settings.LocalFileLoadBehaviour == LocalFileLoadBehaviour.Load && file.Type == FileType.LocalFileName;
            var localFilesToLoad = parserDto.GeneralDefinitions.Files.Where(LoadLocalFiles);
            var onlineFilesToLoad = parserDto.GeneralDefinitions.Files.Where(LoadOnlineFiles);
            var parallelOptions = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount };

            Parallel.ForEach(localFilesToLoad, parallelOptions, file => LoadLocalFile(file, parserDto));
            await Parallel.ForEachAsync(onlineFilesToLoad, parallelOptions, async (file, ct) => await LoadOnlineFileAsync(file, parserDto, ct).ConfigureAwait(false)).ConfigureAwait(false);
            return parserDto;
        }, parserDto);

    private static async Task LoadOnlineFileAsync(GldfFileTyped file, ParserDto parserDto, CancellationToken ct)
    {
        try
        {
            file.BinaryContent = await parserDto.Settings.HttpClient.GetByteArrayAsync(file.Uri, ct).ConfigureAwait(false);
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