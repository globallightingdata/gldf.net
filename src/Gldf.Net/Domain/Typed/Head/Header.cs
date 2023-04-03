using Gldf.Net.Domain.Typed.Head.Types;
using System;

// ReSharper disable InconsistentNaming

namespace Gldf.Net.Domain.Typed.Head;

public class HeaderTyped
{
    public string Author { get; set; }

    public string Manufacturer { get; set; }

    public DateTime CreationTimeCode { get; set; }

    public string CreatedWithApplication { get; set; }

    public FormatVersionTyped FormatVersion { get; set; }

    public string DefaultLanguage { get; set; }

    public LicenseKeyTyped[] LicenseKeys { get; set; }

    public string ReluxMemberId { get; set; }

    public string DIALuxMemberId { get; set; }

    public AddressTyped[] Contact { get; set; }
}