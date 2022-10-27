using Gldf.Net.Domain.Typed.Global;
using Gldf.Net.Domain.Xml.Global;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser.Extensions
{
    public static class LocaleExtensions
    {
        public static LocaleTyped[] ToTypedArray(this IEnumerable<Locale> locales) =>
            locales.Select(MapLocale).ToArray();

        private static LocaleTyped MapLocale(Locale locale) =>
            new()
            {
                Language = locale.Language,
                Text = locale.Text
            };
    }
}