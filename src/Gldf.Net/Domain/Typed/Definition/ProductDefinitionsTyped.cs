using System.Collections.Generic;

namespace Gldf.Net.Domain.Typed.Definition
{
    public class ProductDefinitionsTyped
    {
        public ProductMetaDataTyped ProductMetaData { get; set; } = new();

        public List<VariantTyped> Variants { get; set; } = new();
    }
}