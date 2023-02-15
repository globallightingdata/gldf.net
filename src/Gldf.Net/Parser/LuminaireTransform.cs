using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Parser.DataFlow;

namespace Gldf.Net.Parser;

internal class LuminaireTransform : TransformBase
{
    public static RootTyped Map(ParserDto[] parserDtos)
    {
        var result = ExecuteSafe(() => UpdateVariantOverwrites(parserDtos[0]), parserDtos[0]);
        return new RootTyped
        {
            Header = result.Header,
            GeneralDefinitions = result.GeneralDefinitions,
            ProductDefinitions = result.ProductDefinitions
        };
    }

    private static ParserDto UpdateVariantOverwrites(ParserDto parserDto)
    {
        foreach (var variant in parserDto.ProductDefinitions.Variants)
        {
            UpdateVariant(variant, parserDto.ProductDefinitions.ProductMetaData);
            UpdateDescriptiveAttributes(variant.DescriptiveAttributes, parserDto.ProductDefinitions.ProductMetaData.DescriptiveAttributes);
        }
        return parserDto;
    }

    private static void UpdateVariant(VariantTyped variant, ProductMetaDataTyped product)
    {
        variant.ProductNumber ??= product.ProductNumber;
        variant.Name ??= product.Name;
        variant.Description ??= product.Description;
        variant.TenderText ??= product.TenderText;
        variant.ProductSeries ??= product.ProductSeries;
        variant.Pictures ??= product.Pictures;
    }

    private static void UpdateDescriptiveAttributes(DescriptiveAttributesTyped variant, DescriptiveAttributesTyped product)
    {
        // todo Update DescriptiveAttributes
    }
}