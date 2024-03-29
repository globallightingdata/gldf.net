﻿using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Definition.Types
{
    public class SensorReference
    {
        [XmlAttribute(DataType = "NCName", AttributeName = "sensorId")]
        public string SensorId { get; set; }
    }
}