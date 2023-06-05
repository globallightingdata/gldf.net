using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Global;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser.Extensions;

public static class FilesDtoExtensions
{
    public static GldfFileTyped ToFileTyped(this IEnumerable<GldfFileTyped> files, string fileId) =>
        files.FirstOrDefault(file => file.Id.Equals(fileId, StringComparison.Ordinal));

    public static ImageFileTyped[] ToImageTypedArray(this IEnumerable<GldfFileTyped> files, IEnumerable<Image> images)
    {
        if (images == null) return null;
        return (from image in images
                let fileTyped = files.FirstOrDefault(file => file.Id.Equals(image.FileId, StringComparison.Ordinal))
                where fileTyped != null
                select new ImageFileTyped(fileTyped, image.ImageType))
            .ToArray();
    }
}