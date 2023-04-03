using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Gldf.Net.Exceptions;

[Serializable, ExcludeFromCodeCoverage]
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

    protected GldfException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}