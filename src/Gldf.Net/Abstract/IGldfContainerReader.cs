using Gldf.Net.Container;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfContainerReader
{
    GldfContainer ReadFromFile(string filePath);

    GldfContainer ReadFromFile(string filePath, ContainerLoadSettings settings);

    public GldfContainer ReadFromStream(Stream zipStream, bool leaveOpen);
    
    public GldfContainer ReadFromStream(Stream zipStream, bool leaveOpen, ContainerLoadSettings settings);

    void ExtractToDirectory(string sourceContainerFilePath, string targetDirectory);
}