using System;

namespace Gldf.Net.Exceptions
{
    public static class ExceptionExtensions
    {
        public static string FlattenMessage(this Exception exception)
        {
            return exception.InnerException == null
                ? exception.Message
                : $"{exception.Message}: {exception.InnerException.FlattenMessage()}";
        }
    }
}