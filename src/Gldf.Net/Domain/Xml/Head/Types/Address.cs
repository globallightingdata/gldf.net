using Gldf.Net.Domain.Xml.Global;
using System.Xml.Serialization;

namespace Gldf.Net.Domain.Xml.Head.Types
{
    public class Address
    {
        public string FirstName { get; set; }

        public string Name { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        [XmlElement(ElementName = "ZIPCode")]
        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public EMail[] EMailAddresses { get; set; }

        public Hyperlink[] Websites { get; set; }

        public string AdditionalInfo { get; set; }
    }
}