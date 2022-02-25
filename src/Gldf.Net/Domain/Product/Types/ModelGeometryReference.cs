﻿using System.Xml.Serialization;

namespace Gldf.Net.Domain.Product.Types
{
    public class ModelGeometryReference : EmitterReferenceBase
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "geometryId")]
        public string GeometryId { get; set; }

        [XmlElement("EmitterReference")]
        public GeometryEmitterReference[] EmitterReferences { get; set; }
    }
}