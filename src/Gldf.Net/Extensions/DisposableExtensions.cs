using System;

namespace Gldf.Net.Extensions;

internal static class DisposableExtensions
{
    public static void DisposeSafe(this IDisposable disposable)
    {
        try
        {
            disposable.Dispose();
        }
        catch
        {
            // ignore
        }
    }
}