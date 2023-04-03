using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Head;

namespace Gldf.Net.Domain.Typed;

public class RootTyped
{
    public HeaderTyped Header { get; set; }

    public GeneralDefinitionsTyped GeneralDefinitions { get; set; }

    public ProductDefinitionsTyped ProductDefinitions { get; set; }
}