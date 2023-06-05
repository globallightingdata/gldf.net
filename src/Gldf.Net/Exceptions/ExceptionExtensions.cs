using System;

namespace Gldf.Net.Exceptions;

internal static class ExceptionExtensions
{
    public static string FlattenMessage(this Exception exception)
    {
        return exception.InnerException == null
            ? exception.Message
            : $"{exception.Message}: {exception.InnerException.FlattenMessage()}";
    }
}