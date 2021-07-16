using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Gldf.Net.Exceptions
{
    [Serializable, ExcludeFromCodeCoverage]
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

        protected GldfValidationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}