using Gldf.Net.Container;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfContainerReader
{
    GldfContainer ReadFromGldfFile(string gldfFilePath);

    GldfContainer ReadFromGldfFile(string gldfFilePath, ContainerLoadSettings settings);

    public GldfContainer ReadFromGldfStream(Stream zipStream, bool leaveOpen);
    
    public GldfContainer ReadFromGldfStream(Stream zipStream, bool leaveOpen, ContainerLoadSettings settings);

    void ExtractToDirectory(string sourceGldfFilePath, string targetDirectory);
}