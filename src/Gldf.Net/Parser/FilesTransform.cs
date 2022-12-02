using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Domain.Xml.Definition.Types;
using Gldf.Net.Parser.State;
using System;
using System.IO;
using System.Linq;

namespace Gldf.Net.Parser
{
    internal class FilesTransform
    {
        public static FilesTransform Instance { get; } = new();

        public ParserDto<GldfFileTyped> Map(ContainerDto containerDto)
        {
            var parserDto = new ParserDto<GldfFileTyped>(containerDto);
            if (containerDto.Container.Product.GeneralDefinitions.Files?.Any() != true) return parserDto;
            foreach (var file in containerDto.Container.Product.GeneralDefinitions.Files)
                parserDto.Items.Add(Map(containerDto, file));
            return parserDto;
        }

        private GldfFileTyped Map(ContainerDto containerDto, GldfFile file)
        {
            return new GldfFileTyped
            {
                Id = file.Id,
                ContentType = file.ContentType,
                Type = file.Type,
                Language = file.Language,
                Uri = file.File,
                FileName = file.Type == FileType.Url ? Path.GetFileName(new Uri(file.File).LocalPath) : file.File,
                BinaryContent = containerDto.LoadFileContent ? GetContent(containerDto, file) : null
            };
        }

        private byte[] GetContent(ContainerDto parserCache, GldfFile file)
        {
            // todo Laden der Daten implementieren 
            return Array.Empty<byte>();
        }
    }
}