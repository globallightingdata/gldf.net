using Gldf.Net.Domain.Typed.Global;

namespace Gldf.Net.Domain.Typed.Definition.Types
{
    public class ProductSerieTyped
    {
        public LocaleTyped[] Name { get; set; }

        public LocaleTyped[] Description { get; set; }

        public ImageFileTyped[] Pictures { get; set; }

        public HyperlinkTyped[] Hyperlinks { get; set; }
    }
}