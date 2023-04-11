using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Parser.DataFlow;
using Gldf.Net.Parser.Extensions;
using System.Linq;

namespace Gldf.Net.Parser;

internal class VariantTransform : TransformBase
{
    public static ParserDto Map(ParserDto[] parserDtos)
    {
        return ExecuteSafe(() =>
        {
            var parserDto = parserDtos[0];
            var variants = parserDto.Container.Product.ProductDefinitions.Variants;
            if (variants?.Any() != true) return parserDto;
            parserDto.ProductDefinitions.Variants = variants.Select(x => Map(x, parserDto.GeneralDefinitions)).ToList();
            return parserDto;
        }, parserDtos[0]);
    }

    private static VariantTyped Map(Variant variant, GeneralDefinitionsTyped definitions)
    {
        return new VariantTyped
        {
            Id = variant.Id,
            SortOrder = variant.SortOrder,
            ProductNumber = variant.ProductNumber?.ToTypedArray(),
            Name = variant.Name?.ToTypedArray(),
            Description = variant.Description?.ToTypedArray(),
            TenderText = variant.TenderText?.ToTypedArray(),
            GTIN = variant.GTIN,
            Mountings = variant.Mountings?.ToTyped(),
            Geometry = variant.Geometry?.ToTyped(definitions),
            ProductSeries = variant.ProductSeries?.ToTypedArray(definitions.Files),
            Pictures = definitions.Files.ToImageTypedArray(variant.Pictures),
            Symbol = definitions.Files.ToFileTyped(variant.Symbol?.FileId),
            DescriptiveAttributes = variant.DescriptiveAttributes?.ToTyped() 
        };
    }
}