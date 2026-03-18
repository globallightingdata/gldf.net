using Gldf.Net.Container;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfContainerReader
{
    public GldfContainer ReadFromGldfFile(string gldfFilePath);

    public GldfContainer ReadFromGldfFile(string gldfFilePath, ContainerLoadSettings settings);

    public GldfContainer ReadFromGldfStream(Stream zipStream, bool leaveOpen);

    public GldfContainer ReadFromGldfStream(Stream zipStream, bool leaveOpen, ContainerLoadSettings settings);

    public void ExtractToDirectory(string sourceGldfFilePath, string targetDirectory);
}