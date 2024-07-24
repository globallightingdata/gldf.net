using System;
using System.Diagnostics.CodeAnalysis;

namespace Gldf.Net.Exceptions;

[ExcludeFromCodeCoverage]
public class GldfException : Exception
{
    public GldfException()
    {
    }

    public GldfException(string message) : base(message)
    {
    }

    public GldfException(string message, Exception inner) : base(message, inner)
    {
    }
}