using Gldf.Net.Parser.DataFlow;
using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Gldf.Net.Parser;

internal abstract class TransformBase
{
    internal static ParserDto ExecuteSafe(Func<ParserDto> action, ParserDto fallback, [CallerFilePath] string callerFilePath = "")
    {
        try
        {
            return action();
        }
        catch (Exception ex)
        {
            var callerTypeName = Path.GetFileNameWithoutExtension(callerFilePath);
            fallback.Errors.Add(new ParserError(callerTypeName, ex));
            return fallback;
        }
    }
}