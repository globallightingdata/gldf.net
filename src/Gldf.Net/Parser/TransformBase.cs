using Gldf.Net.Parser.DataFlow;
using System;
using System.Threading.Tasks;

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
    internal static async Task<ParserDto> ExecuteSafeAsync(Func<Task<ParserDto>> action, ParserDto fallback)
    {
        try
        {
            return await action().ConfigureAwait(false);
        }
        catch
        {
            return fallback;
        }
    }
}