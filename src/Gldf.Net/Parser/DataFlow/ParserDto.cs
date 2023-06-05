using Gldf.Net.Container;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Product;

namespace Gldf.Net.Parser.DataFlow;

internal class ParserDto
{
    public ParserSettings Settings { get; }

    public GldfContainer Container { get; }

    public HeaderTyped Header { get; }

    public GeneralDefinitionsTyped GeneralDefinitions { get; }

    public ProductDefinitionsTyped ProductDefinitions { get; }

    public ParserDto(GldfContainer container, ParserSettings settings)
    {
        Container = container;
        Settings = settings;
        Header = new HeaderTyped();
        GeneralDefinitions = new GeneralDefinitionsTyped();
        ProductDefinitions = new ProductDefinitionsTyped();
    }
}