using System;
using System.Diagnostics.CodeAnalysis;

namespace Gldf.Net.Exceptions;

[ExcludeFromCodeCoverage]
public class RootNotFoundException : GldfContainerException
{
    public RootNotFoundException()
    {
    }

    public RootNotFoundException(string message) : base(message)
    {
    }

    public RootNotFoundException(string message, Exception inner) : base(message, inner)
    {
    }
}