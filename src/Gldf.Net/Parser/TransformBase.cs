using Gldf.Net.Parser.DataFlow;
using System;

namespace Gldf.Net.Parser;

internal abstract class TransformBase
{
    internal static ParserDto ExecuteSafe(Func<ParserDto> action, ParserDto fallback)
    {
        try
        {
            return action();
        }
        catch
        {
            return fallback;
        }
    }
}