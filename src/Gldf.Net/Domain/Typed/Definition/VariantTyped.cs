using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Definition.Types.Mounting;
using Gldf.Net.Domain.Typed.Global;

// ReSharper disable InconsistentNaming

namespace Gldf.Net.Domain.Typed.Definition;

public class VariantTyped
{
    public string Id { get; set; }

    public int SortOrder { get; set; }

    public LocaleTyped[] ProductNumber { get; set; }

    public LocaleTyped[] Name { get; set; }

    public LocaleTyped[] Description { get; set; }

    public LocaleTyped[] TenderText { get; set; }

    public string GTIN { get; set; }

    public MountingsTyped Mountings { get; set; }

    public GeometryTyped Geometry { get; set; }

    public ProductSerieTyped[] ProductSeries { get; set; }

    public ImageFileTyped[] Pictures { get; set; }

    public GldfFileTyped Symbol { get; set; }

    public DescriptiveAttributesTyped DescriptiveAttributes { get; set; }
}