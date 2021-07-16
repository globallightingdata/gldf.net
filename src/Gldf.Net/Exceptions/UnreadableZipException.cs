using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Gldf.Net.Exceptions
{
    [Serializable, ExcludeFromCodeCoverage]
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

        protected UnreadableZipException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}