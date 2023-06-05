using System.Xml.Serialization;

namespace Gldf.Net.XmlHelper;

internal static class GldfNamespaceProvider
{
    public static XmlSerializerNamespaces GetNamespaces()
    {
        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
        return namespaces;
    }
}