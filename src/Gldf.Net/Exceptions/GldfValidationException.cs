using System;
using System.Diagnostics.CodeAnalysis;

namespace Gldf.Net.Exceptions;

[ExcludeFromCodeCoverage]
public class GldfValidationException : Exception
{
    public GldfValidationException()
    {
    }

    public GldfValidationException(string message) : base(message)
    {
    }

    public GldfValidationException(string message, Exception inner) : base(message, inner)
    {
    }
}