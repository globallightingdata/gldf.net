using System.IO;
using System.IO.Compression;

namespace Gldf.Net.Container
{
    internal static class ZipEntryExtensions
    {
        public static byte[] GetBytes(this ZipArchiveEntry entry)
        {
            using var zipStream = entry.Open();
            using var memoryStream = new MemoryStream();
            zipStream.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }
}