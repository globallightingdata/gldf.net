using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;

namespace Gldf.Net.Domain.Typed.Definition;

public class ProductMetaDataTyped
{
    public LocaleTyped[] ProductNumber { get; set; }

    public LocaleTyped[] Name { get; set; }

    public LocaleTyped[] Description { get; set; }

    public LocaleTyped[] TenderText { get; set; }

    public ProductSerieTyped[] ProductSeries { get; set; }

    public ImageFileTyped[] Pictures { get; set; }

    public LuminaireMaintenanceTyped Maintenance { get; set; }

    public DescriptiveAttributesTyped DescriptiveAttributes { get; set; }
}