using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Xml.Global;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser.Extensions;

public static class HyperlinkExtensions
{
    public static HyperlinkTyped[] ToTypedArray(this IEnumerable<Hyperlink> hyperlinks) =>
        hyperlinks.Select(MapHyperlink).ToArray();

    private static HyperlinkTyped MapHyperlink(Hyperlink hyperlink) =>
        new()
        {
            Href = hyperlink.Href,
            Language = hyperlink.Language,
            Region = hyperlink.Region,
            CountryCode = hyperlink.CountryCode,
            PlainText = hyperlink.PlainText
        };
}