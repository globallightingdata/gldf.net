using Gldf.Net.Domain.Xml.Definition.Types;

namespace Gldf.Net.Domain.Typed.Definition.Types;

public class ActivePowerTableTyped
{
    public ActivePowerTableType Type { get; set; }

    public FluxFactorTyped[] FluxFactor { get; set; }
}