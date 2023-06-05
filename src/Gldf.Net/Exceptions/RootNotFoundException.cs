using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Gldf.Net.Exceptions;

[Serializable, ExcludeFromCodeCoverage]
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

    protected RootNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}