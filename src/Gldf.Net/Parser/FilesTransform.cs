using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Parser.DataFlow;
using System;
using System.IO;
using System.Linq;

namespace Gldf.Net.Parser;

internal class FilesTransform : TransformBase
{
    public static ParserDto Map(ParserDto parserDto)
    {
        return ExecuteSafe(() =>
        {
            var gldfFiles = parserDto.Container.Product.GeneralDefinitions.Files;
            if (gldfFiles?.Any() != true) return parserDto;
            foreach (var file in gldfFiles)
                parserDto.GeneralDefinitions.Files.Add(Map(file));
            return parserDto;
        }, parserDto);
    }

    private static GldfFileTyped Map(GldfFile file)
    {
        return new GldfFileTyped
        {
            Id = file.Id,
            ContentType = file.ContentType,
            Type = file.Type,
            Language = file.Language,
            Uri = file.Type == FileType.Url ? file.File : null,
            FileName = GetFileName(file)
        };
    }

    private static string GetFileName(GldfFile file)
    {
        try
        {
            return file.Type == FileType.Url
                ? Path.GetFileName(new Uri(file.File).LocalPath)
                : file.File;
        }
        catch
        {
            return file.File;
        }
    }
}