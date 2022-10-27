using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Xml.Product;

namespace Gldf.Net.Domain.Typed
{
    public class RootTyped
    {
        public HeaderTyped Header { get; set; }

        public GeneralDefinitionsTyped GeneralDefinitions { get; set; }

        public ProductDefinitions ProductDefinitions { get; set; }
    }
}