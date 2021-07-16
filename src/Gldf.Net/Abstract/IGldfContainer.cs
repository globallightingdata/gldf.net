using Gldf.Net.Container;

namespace Gldf.Net.Abstract
{
    public interface IGldfContainer
    {
        GldfArchive ReadFromFile(string filePath);

        GldfArchive ReadFromFile(string filePath, ContainerLoadSettings settings);

        void WriteToFile(string filePath, GldfArchive gldfArchive);

        void CreateFromDirectory(string sourceDirectory, string targetContainerFilePath);

        void ExtractToDirectory(string sourceContainerFilePath, string targetDirectory);
    }
}