using System;
using System.Diagnostics.CodeAnalysis;

namespace Gldf.Net.Exceptions;

[ExcludeFromCodeCoverage]
public class UnreadableZipException : GldfContainerException
{
    public UnreadableZipException()
    {
    }

    public UnreadableZipException(string message) : base(message)
    {
    }

    public UnreadableZipException(string message, Exception inner) : base(message, inner)
    {
    }
}