using Gldf.Net.Domain.Xml.Head.Types;
using System;

// ReSharper disable InconsistentNaming

namespace Gldf.Net.Domain.Xml.Head
{
    public class Header
    {
        public string Author { get; set; }

        public string Manufacturer { get; set; }

        public DateTime CreationTimeCode { get; set; }

        public string CreatedWithApplication { get; set; }

        public FormatVersion FormatVersion { get; set; }

        public string DefaultLanguage { get; set; }

        public LicenseKey[] LicenseKeys { get; set; }

        public string ReluxMemberId { get; set; }

        public string DIALuxMemberId { get; set; }

        public Address[] Contact { get; set; }
    }
}