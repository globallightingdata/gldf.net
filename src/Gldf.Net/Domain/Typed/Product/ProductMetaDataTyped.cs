using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Typed.Product.Types;

namespace Gldf.Net.Domain.Typed.Product;

public class ProductMetaDataTyped
{
    public string UniqueProductId { get; set; }
    
    public LocaleTyped[] ProductNumber { get; set; }

    public LocaleTyped[] Name { get; set; }

    public LocaleTyped[] Description { get; set; }

    public LocaleTyped[] TenderText { get; set; }

    public ProductSerieTyped[] ProductSeries { get; set; }

    public ImageFileTyped[] Pictures { get; set; }

    public LuminaireMaintenanceTyped Maintenance { get; set; }

    public DescriptiveAttributesTyped DescriptiveAttributes { get; set; }
}