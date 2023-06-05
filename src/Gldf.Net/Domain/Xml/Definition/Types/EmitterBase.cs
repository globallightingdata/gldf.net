using Gldf.Net.Domain.Xml.Global;

namespace Gldf.Net.Domain.Xml.Definition.Types;

public abstract class EmitterBase
{
    public Locale[] Name { get; set; }

    public Rotation Rotation { get; set; }
}