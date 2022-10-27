using Gldf.Net.Domain.Xml.Product.Types;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Typed.Definition
{
    public class GeometryTyped
    {
        [XmlElement("EmitterReference", typeof(EmitterReference))]
        [XmlElement("SimpleGeometryReference", typeof(SimpleGeometryReference))]
        [XmlElement("ModelGeometryReference", typeof(ModelGeometryReference))]
        [XmlElement("GeometryReferences", typeof(GeometryReferences))]
        public GeometryReferenceBase Reference { get; set; }
        
        public EmitterReference GetReferenceAsEmitterReference() => Reference as EmitterReference;
        public SimpleGeometryReference GetReferenceAsSimpleGeometryReference() => Reference as SimpleGeometryReference;
        public ModelGeometryReference GetReferenceAsModelGeometryReference() => Reference as ModelGeometryReference;
        public GeometryReferences GetReferenceAsGeometryReferences() => Reference as GeometryReferences;
    }
}