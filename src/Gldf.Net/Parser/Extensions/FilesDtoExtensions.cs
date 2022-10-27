using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Parser.State;
using System;
using System.Linq;

namespace Gldf.Net.Parser.Extensions
{
    public static class FilesDtoExtensions
    {
        public static GldfFileTyped GetForId(this ParserDto<GldfFileTyped> files, string id) =>
            files.Items.FirstOrDefault(file => file.Id.Equals(id, StringComparison.Ordinal));
    }
}