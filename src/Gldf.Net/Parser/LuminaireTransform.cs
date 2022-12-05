using Gldf.Net.Domain.Typed;
using Gldf.Net.Parser.DataFlow;

namespace Gldf.Net.Parser;

internal class LuminaireTransform : TransformBase
{
    public static RootTyped Map(ParserDto[] parserDtos)
    {
        return new RootTyped
        {
            Header = parserDtos[0].Header,
            GeneralDefinitions = parserDtos[0].GeneralDefinitions,
            ProductDefinitions = parserDtos[0].ProductDefinitions
        };
    }
}