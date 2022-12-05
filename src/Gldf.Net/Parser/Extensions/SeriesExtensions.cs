using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Product.Types;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser.Extensions;

public static class SeriesExtensions
{
    public static ProductSerieTyped[] ToTypedArray(this IEnumerable<ProductSerie> series, ICollection<GldfFileTyped> files) =>
        series.Select(serie => MapSerie(serie, files)).ToArray();

    private static ProductSerieTyped MapSerie(ProductSerie serie, IEnumerable<GldfFileTyped> files) =>
        new()
        {
            Name = serie.Name?.ToTypedArray(),
            Description = serie.Description?.ToTypedArray(),
            Pictures = files.ToImageTypedArray(serie.Pictures),
            Hyperlinks = serie.Hyperlinks?.ToTypedArray()
        };
}