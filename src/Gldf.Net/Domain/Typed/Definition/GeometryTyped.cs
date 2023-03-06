using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Product.Types;

namespace Gldf.Net.Domain.Typed.Definition;

public class GeometryTyped
{
    public EmitterTyped EmitterOnly { get; set; }

    public SimpleGeometryEmitterTyped Simple { get; set; }

    public ModelGeometryEmitterTyped Model { get; set; }
}

public class SimpleGeometryEmitterTyped
{
    public EmitterTyped Emitter { get; set; }

    public SimpleGeometryTyped Geometry { get; set; }
}

public class ModelGeometryEmitterTyped
{
    public ModelEmitterTyped[] Emitter { get; set; }

    public ModelGeometryTyped Geometry { get; set; }
}

public class ModelEmitterTyped
{
    public string EmitterObjectExtrernalName { get; set; }

    public TargetModelType? TargetModelType { get; set; }

    public EmitterTyped Emitter { get; set; }
}