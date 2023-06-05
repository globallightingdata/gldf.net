using System.Collections.Generic;

namespace Gldf.Net.Domain.Typed.Product;

public class ProductDefinitionsTyped
{
    public ProductMetaDataTyped ProductMetaData { get; set; } = new();

    public List<VariantTyped> Variants { get; set; } = new();
}