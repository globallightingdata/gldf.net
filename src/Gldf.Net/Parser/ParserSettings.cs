using System.Net.Http;

namespace Gldf.Net.Parser;

public class ParserSettings
{
    /// <summary>
    ///     If <see cref="OnlineFileLoadBehaviour" /> is OnlineFileLoadBehaviour.Load, this HttpClient is used.
    /// </summary>
    public HttpClient HttpClient { get; init; } = new();

    /// <summary>
    ///     Defines the parser file loading behaviour for files stored in the GLDF container
    /// </summary>
    public LocalFileLoadBehaviour LocalFileLoadBehaviour { get; init; } = LocalFileLoadBehaviour.Load;

    /// <summary>
    ///     Defines the parser loading behaviour for files stored online
    /// </summary>
    public OnlineFileLoadBehaviour OnlineFileLoadBehaviour { get; init; } = OnlineFileLoadBehaviour.Load;
}

public enum LocalFileLoadBehaviour
{
    Load,
    Skip
}

public enum OnlineFileLoadBehaviour
{
    Load,
    Skip
}