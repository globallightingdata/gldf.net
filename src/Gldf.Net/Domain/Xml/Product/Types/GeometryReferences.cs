namespace Gldf.Net.Domain.Xml.Product.Types
{
    public class GeometryReferences : GeometryReferenceBase
    {
        public SimpleGeometryReference SimpleGeometryReference { get; set; }

        public ModelGeometryReference ModelGeometryReference { get; set; }
    }
}