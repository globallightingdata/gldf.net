﻿using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Descriptive.Types;

public class PropertyText : PropertyContentBase
{
    [XmlText]
    public string Value { get; set; }
}