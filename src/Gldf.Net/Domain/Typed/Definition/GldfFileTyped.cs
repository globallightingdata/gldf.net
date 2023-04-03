using Gldf.Net.Domain.Xml.Definition.Types;
using System.Linq;
using System.Text;

namespace Gldf.Net.Domain.Typed.Definition;

public class GldfFileTyped : TypedBase
{
    public string FileName { get; set; }

    public string Uri { get; set; }

    public FileContentType ContentType { get; set; }

    public FileType Type { get; set; }

    public string Language { get; set; }

    public byte[] BinaryContent { get; set; }

    public string AsStringContentUtf8 => BinaryContent?.Any() == true ? Encoding.UTF8.GetString(BinaryContent) : null;
}