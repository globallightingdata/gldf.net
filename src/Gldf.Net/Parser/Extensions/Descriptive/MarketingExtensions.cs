using Gldf.Net.Domain.Typed.Descriptive;
using Gldf.Net.Domain.Xml.Descriptive;

namespace Gldf.Net.Parser.Extensions.Descriptive;

public static class MarketingExtensions
{
    public static MarketingTyped ToTyped(this Marketing marketing)
    {
        if (marketing is null) return null;
        return new MarketingTyped
        {
            Applications = marketing.Applications
        };
    }
    
    public static void Update(this MarketingTyped marketing, MarketingTyped updateFrom)
    {
        marketing.Applications ??= updateFrom.Applications;
    }
}