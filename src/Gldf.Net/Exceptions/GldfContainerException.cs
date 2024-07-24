using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Gldf.Net.Exceptions;

[ExcludeFromCodeCoverage]
public class GldfContainerException : GldfException
{
    public GldfContainerException()
    {
    }

    public GldfContainerException(string message) : base(message)
    {
    }

    public GldfContainerException(string message, Exception inner) : base(message, inner)
    {
    }

    protected GldfContainerException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}