using Gldf.Net.Container;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfContainerWriter
{
    void WriteToFile(string filePath, GldfContainer gldfContainer);

    void WriteToStream(Stream stream, bool leaveOpen, GldfContainer gldfContainer);

    void CreateFromDirectory(string sourceDirectory, string targetContainerFilePath);
}