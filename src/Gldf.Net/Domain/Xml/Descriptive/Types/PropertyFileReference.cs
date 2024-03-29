﻿using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive.Types;

public class PropertyFileReference : PropertyContentBase
{
    [XmlAttribute(DataType = "NCName", AttributeName = "fileId")]
    public string FileId { get; set; }
}