using System;
using System.Net.Http;

namespace Gldf.Net.Parser;

public class ParserSettings
{
    /// <summary>
    ///     If <see cref="OnlineFileLoadBehaviour" /> is OnlineFileLoadBehaviour.Load, this HttpClient is used.
    /// </summary>
    public HttpClient HttpClient { get; }

    /// <summary>
    ///     Defines the parser file loading behaviour for files stored in the GLDF container. Default ist Load.
    /// </summary>
    public LocalFileLoadBehaviour LocalFileLoadBehaviour { get; }

    /// <summary>
    ///     Defines the parser loading behaviour for files stored online. Default ist Skip.
    /// </summary>
    public OnlineFileLoadBehaviour OnlineFileLoadBehaviour { get; }

    public ParserSettings(LocalFileLoadBehaviour localFileLoadBehaviour = LocalFileLoadBehaviour.Load,
        OnlineFileLoadBehaviour onlineFileLoadBehaviour = OnlineFileLoadBehaviour.Skip, HttpClient httpClient = null)
    {
        if (onlineFileLoadBehaviour is OnlineFileLoadBehaviour.Load && httpClient is null)
            throw new ArgumentException("HttpClient must be set when OnlineFileLoadBehaviour is activated");
        LocalFileLoadBehaviour = localFileLoadBehaviour;
        OnlineFileLoadBehaviour = onlineFileLoadBehaviour;
        HttpClient = httpClient;
    }
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