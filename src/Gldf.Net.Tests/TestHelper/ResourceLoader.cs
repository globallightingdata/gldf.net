using System.IO;
using System.Reflection;
using System.Text;

namespace Gldf.Net.Tests.TestHelper;

public static class ResourceLoader
{
    private const string AssemblyPath = "Gldf.Net.Tests";
    private static readonly Assembly ExecutingAssembly = Assembly.GetExecutingAssembly();

    public static string LoadEmbeddedXml(string pathWithinAssembly, Encoding encoding = null)
    {
        using var stream = GetStream(pathWithinAssembly);
        using var streamReader = encoding is null ? new StreamReader(stream!) : new StreamReader(stream!, encoding);
        return streamReader.ReadToEnd();
    }

    public static byte[] LoadEmbeddedBytes(string pathWithinAssembly)
    {
        using var stream = GetStream(pathWithinAssembly);
        using var memoryStream = new MemoryStream();
        stream.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }

    private static Stream GetStream(string pathWithinAssembly)
    {
        return ExecutingAssembly.GetManifestResourceStream($"{AssemblyPath}.{pathWithinAssembly}");
    }
}