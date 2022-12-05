using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Product.Types;
using System.Collections.Generic;

namespace Gldf.Net.Domain.Typed.Definition;

public class GeometryTyped
{
    public EmitterOnlyGeometryTyped EmitterOnlyGeometry { get; set; }

    public SingleSimpleGeometryTyped SimpleGeometry { get; set; }

    public SingleModelGeometryTyped ModelGeometry { get; set; }
}

public class EmitterOnlyGeometryTyped
{
    public ChangeableLightEmitterTyped ChangeableLightEmitter { get; set; }

    public FixedLightEmitterTyped FixedLightEmitter { get; set; }
}

public class SingleSimpleGeometryTyped
{
    public ChangeableLightEmitterTyped ChangeableLightEmitter { get; set; }

    public FixedLightEmitterTyped FixedLightEmitter { get; set; }

    public SimpleGeometryTyped SimpleGeometry { get; set; }
}

public class SingleModelGeometryTyped
{
    public List<EmitterTyped> Emitter { get; set; }

    public ModelGeometryTyped ModelGeometry { get; set; }
}

public class EmitterTyped
{
    public ChangeableLightEmitterTyped ChangeableLightEmitter { get; set; }

    public FixedLightEmitterTyped FixedLightEmitter { get; set; }

    public string EmitterObjectExtrernalName { get; set; }

    public TargetModelType? TargetModelType { get; set; }
}