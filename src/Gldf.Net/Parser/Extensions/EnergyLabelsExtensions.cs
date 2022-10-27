using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Definition.Types;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser.Extensions
{
    public static class EnergyLabelsExtensions
    {
        public static EnergyLabelTyped[] ToTypedArray(this IEnumerable<EnergyLabel> labels) =>
            labels.Select(label => new EnergyLabelTyped
            {
                Region = label.Region,
                Label = label.Label
            }).ToArray();
    }
}