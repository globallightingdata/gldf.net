using Gldf.Net.Container;

namespace Gldf.Net.Abstract;

public interface IGldfContainerReader
{
    GldfContainer ReadFromFile(string filePath);

    GldfContainer ReadFromFile(string filePath, ContainerLoadSettings settings);

    void ExtractToDirectory(string sourceContainerFilePath, string targetDirectory);
}