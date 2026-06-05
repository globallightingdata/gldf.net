using Gldf.Net.Container;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfContainerWriter
{
    public void WriteToGldfFile(string gldfFilePath, GldfContainer gldf);

    public void WriteToGldfStream(Stream zipStream, bool leaveOpen, GldfContainer gldf);

    public void CreateFromDirectory(string sourceDirectory, string targetContainerFilePath);
}