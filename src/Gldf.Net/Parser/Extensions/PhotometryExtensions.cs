using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Parser.State;
using System;
using System.Linq;

namespace Gldf.Net.Parser.Extensions
{
    public static class PhotometryExtensions
    {
        public static PhotometryTyped GetTyped(this ParserDto<PhotometryTyped> dto, string id) =>
            dto.Items.Single(photometry => photometry.Id.Equals(id, StringComparison.Ordinal));
    }
}