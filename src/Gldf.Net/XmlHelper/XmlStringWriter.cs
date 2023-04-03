using System.IO;
using System.Text;

namespace Gldf.Net.XmlHelper;

/// <summary>
///     Unlike the standard StringWriter, this XmlStringWriter allows Encoding specification.
///     The default Encoding is UTF8.
/// </summary>
internal class XmlStringWriter : StringWriter
{
    public override Encoding Encoding { get; }

    public XmlStringWriter() => Encoding = Encoding.UTF8;

    public XmlStringWriter(Encoding encoding) => Encoding = encoding;
}