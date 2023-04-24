using Gldf.Net.Container;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfContainerWriter
{
    void WriteToGldfFile(string gldfFilePath, GldfContainer gldf);

    void WriteToGldfStream(Stream zipStream, bool leaveOpen, GldfContainer gldf);

    void CreateFromDirectory(string sourceDirectory, string targetContainerFilePath);
}