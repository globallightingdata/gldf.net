using Gldf.Net.Domain.Typed.Global;

namespace Gldf.Net.Domain.Typed.Head.Types;

public class AddressTyped
{
    public string FirstName { get; set; }

    public string Name { get; set; }

    public string Street { get; set; }

    public string Number { get; set; }

    public string ZipCode { get; set; }

    public string City { get; set; }

    public string Country { get; set; }

    public string Phone { get; set; }

    public EMailTyped[] EMailAddresses { get; set; }

    public HyperlinkTyped[] Websites { get; set; }

    public string AdditionalInfo { get; set; }
}