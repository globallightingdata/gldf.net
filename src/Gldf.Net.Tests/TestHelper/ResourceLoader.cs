using System.IO;
using System.Reflection;

namespace Gldf.Net.Tests.TestHelper
{
    public static class ResourceLoader
    {
        private const string AssemblyPath = "Gldf.Net.Tests";
        private static readonly Assembly ExecutingAssembly;

        static ResourceLoader()
        {
            ExecutingAssembly = Assembly.GetExecutingAssembly();
        }

        public static string LoadEmbeddedXml(string pathWithinAssembly)
        {
            using var stream = GetStream(pathWithinAssembly);
            using var streamReader = new StreamReader(stream!);
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
}