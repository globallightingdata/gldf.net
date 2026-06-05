using Gldf.Net.Domain.Xml.Definition;
using Gldf.Net.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Container;

public static class GldfFileExtensions
{
    public static byte[] GetBytesFromContainer(this GldfFile file, GldfContainer container)
    {
        ArgumentNullException.ThrowIfNull(file);
        ArgumentNullException.ThrowIfNull(container);
        var assetCollection = container.GetAssetCollection(file.ContentType);
        return GetBytes(assetCollection, file.File);
    }

    private static byte[] GetBytes(IEnumerable<ContainerFile> assetCollection, string fileName)
    {
        return assetCollection.FirstOrDefault(file =>
            string.Equals(file.FileName, fileName, StringComparison.OrdinalIgnoreCase))?.Bytes;
    }
}