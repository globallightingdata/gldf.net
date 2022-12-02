using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using Gldf.Net.Parser.State;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser.Extensions
{
    public static class FilesDtoExtensions
    {
        public static GldfFileTyped GetFileTyped(this ParserDto<GldfFileTyped> files, string id) =>
            files.Items.FirstOrDefault(file => file.Id.Equals(id, StringComparison.Ordinal));

        public static ImageFileTyped[] GetImagesTyped(this ParserDto<GldfFileTyped> files, IEnumerable<Image> images)
        {
            return images
                .Select(image =>
                {
                    var fileTyped = files.Items.Single(file => file.Id.Equals(image.FileId, StringComparison.Ordinal));
                    return new ImageFileTyped
                    {
                        Id = fileTyped.Id,
                        FileName = fileTyped.FileName,
                        Uri = fileTyped.Uri,
                        ContentType = fileTyped.ContentType,
                        Type = fileTyped.Type,
                        Language = fileTyped.Language,
                        BinaryContent = fileTyped.BinaryContent,
                        ImageType = image.ImageType
                    };
                })
                .ToArray();
        }

        // todo entfernen
        // public static GldfFileTyped GetFileTyped(this ParserDto<SpectrumTyped> spectrum, string spectrumId)
        // {
        //     return spectrum.Items
        //         .Single(spectrumTyped => spectrumTyped.Id.Equals(spectrumId, StringComparison.Ordinal))
        //         .SpectrumFile;
        // }
    }
}