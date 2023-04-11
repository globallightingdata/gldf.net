using Gldf.Net.Domain.Xml.Head.Types;
using System;

// ReSharper disable InconsistentNaming

namespace Gldf.Net.Domain.Xml.Head;

public class Header
{
    public string Manufacturer { get; set; }

    public FormatVersion FormatVersion { get; set; }

    public string CreatedWithApplication { get; set; }

    public DateTime GldfCreationTimeCode { get; set; }

    public string UniqueGldfId { get; set; }

    public DateTime ProductDataTimeCode { get; set; }

    public string DefaultLanguage { get; set; }

    public ManufacturerLogo ManufacturerLogo { get; set; }
    
    public LicenseKey[] LicenseKeys { get; set; }

    public string ReluxMemberId { get; set; }

    public string DIALuxMemberId { get; set; }

    public string Author { get; set; }
    
    public Address[] Contact { get; set; }
}