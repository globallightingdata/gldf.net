using System;

namespace Gldf.Net.Container;

public class ContainerFile
{
    public string FileName { get; }

    public byte[] Bytes { get; }

    public ContainerFile(string fileName, byte[] bytes)
    {
        FileName = fileName ?? throw new ArgumentNullException(nameof(fileName));
        Bytes = bytes ?? throw new ArgumentNullException(nameof(bytes));
    }
}