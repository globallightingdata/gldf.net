using System.IO;
using System.Text;

namespace Gldf.Net.Tests.TestHelper;

public static class StreamHelper
{
    // ReSharper disable once InconsistentNaming
    public static string ToUTF8String(this Stream stream)
    {
        stream.Seek(0, SeekOrigin.Begin);
        using var streamReader = new StreamReader(stream, Encoding.UTF8);
        return streamReader.ReadToEnd();
    }
}