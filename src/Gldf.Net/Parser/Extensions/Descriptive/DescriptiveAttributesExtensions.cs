using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Xml.Descriptive;

namespace Gldf.Net.Parser.Extensions.Descriptive;

internal static class DescriptiveAttributesExtensions
{
    public static DescriptiveAttributesTyped ToTyped(this DescriptiveAttributes attributes)
    {
        // todo Map DescriptiveAttributes
        return new DescriptiveAttributesTyped
        {
            Marketing = attributes.Marketing.ToTyped()
        };
    }
}