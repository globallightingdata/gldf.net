namespace Gldf.Net.Domain.Product.Types
{
    public class GeometryReferences : GeometryReferenceBase
    {
        public SimpleGeometryReference SimpleGeometryReference { get; set; }

        public ModelGeometryReference ModelGeometryReference { get; set; }
    }
}