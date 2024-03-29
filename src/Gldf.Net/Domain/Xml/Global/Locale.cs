﻿using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Global;

public class Locale
{
    [XmlAttribute(DataType = "language", AttributeName = "language")]
    public string Language { get; set; }

    [XmlText]
    public string Text { get; set; }
}