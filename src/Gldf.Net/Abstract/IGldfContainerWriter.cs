using Gldf.Net.Container;

namespace Gldf.Net.Abstract
{
    public interface IGldfContainerWriter
    {
        void WriteToFile(string filePath, GldfContainer gldfContainer);

        void CreateFromDirectory(string sourceDirectory, string targetContainerFilePath);
    }
}