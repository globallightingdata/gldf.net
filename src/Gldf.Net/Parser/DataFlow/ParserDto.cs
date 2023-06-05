using Gldf.Net.Container;
using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Product;
using System.Collections.Generic;

namespace Gldf.Net.Parser.DataFlow;

internal class ParserDto
{
    public ParserSettings Settings { get; }

    public GldfContainer Container { get; }

    public HeaderTyped Header { get; }

    public GeneralDefinitionsTyped GeneralDefinitions { get; }

    public ProductDefinitionsTyped ProductDefinitions { get; }

    public List<ParserError> Errors { get; }

    public bool HasParsingErrors => Errors.Count > 0;

    public ParserDto(GldfContainer container, ParserSettings settings)
    {
        Container = container;
        Settings = settings;
        Header = new HeaderTyped();
        GeneralDefinitions = new GeneralDefinitionsTyped();
        ProductDefinitions = new ProductDefinitionsTyped();
        Errors = new List<ParserError>();
    }
}