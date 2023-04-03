using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Exceptions;
using System;
using System.IO;

namespace Gldf.Net;

/// <summary>
///     Provides functionality to read GLDF container files into instances of type
///     <see cref="GldfContainer" />. As well as to extract them to a directory path.
///     This type is threadsafe.
/// </summary>
public class GldfContainerReader : IGldfContainerReader
{
    private readonly ZipArchiveReader _zipArchiveReader;

    /// <summary>
    ///     Initializes a new instance of the <see cref="GldfContainerReader" /> class that can read
    ///     instances of type <see cref="GldfContainer" />.
    /// </summary>
    public GldfContainerReader()
    {
        _zipArchiveReader = new ZipArchiveReader();
    }

    /// <summary>
    ///     Reads the GLDF container from file into an instance of <see cref="GldfContainer" />.
    /// </summary>
    /// <param name="filePath">The path on disk of the GLDF container file</param>
    /// <returns><see cref="GldfContainer" /> with deserialised product.xml, file assets and signature</returns>
    public GldfContainer ReadFromFile(string filePath) => ReadFromFile(filePath, ContainerLoadSettings.Default);

    /// <summary>
    ///     Reads the GLDF container from file into an instance of <see cref="GldfContainer" />.
    ///     With specified load behaviour settings for product.xml, file assets and signature.
    /// </summary>
    /// <param name="filePath">The path on disk of the GLDF container file</param>
    /// <param name="settings">Load behaviour for product.xml, asset files and signature</param>
    /// <returns><see cref="GldfContainer" /> with deserialised product.xml, file assets and signature</returns>
    public GldfContainer ReadFromFile(string filePath, ContainerLoadSettings settings)
    {
        if (filePath == null) throw new ArgumentNullException(nameof(filePath));
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        try
        {
            return _zipArchiveReader.ReadContainer(filePath, settings);
        }
        catch (Exception e)
        {
            throw new GldfContainerException($"Failed to read {nameof(GldfContainer)} from " +
                                             $"'{filePath}'. See inner exception", e);
        }
    }
    
    public GldfContainer ReadFromStream(Stream stream, ContainerLoadSettings settings)
    {
        if (stream == null) throw new ArgumentNullException(nameof(stream));
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        try
        {
            return _zipArchiveReader.ReadContainer(stream, settings);
        }
        catch (Exception e)
        {
            throw new GldfContainerException($"Failed to read {nameof(GldfContainer)} from stream. " +
                                             "See inner exception", e);
        }
    }

    /// <summary>
    ///     Extracts the content of a GLDF container file to disk
    /// </summary>
    /// <param name="sourceContainerFilePath">Filepath to the GLDF container file</param>
    /// <param name="targetDirectory">The target directory the content wil be extracted to</param>
    public void ExtractToDirectory(string sourceContainerFilePath, string targetDirectory)
    {
        if (sourceContainerFilePath == null) throw new ArgumentNullException(nameof(sourceContainerFilePath));
        if (targetDirectory == null) throw new ArgumentNullException(nameof(targetDirectory));

        try
        {
            _zipArchiveReader.ExtractToDirectory(sourceContainerFilePath, targetDirectory);
        }
        catch (Exception e)
        {
            throw new GldfContainerException($"Failed to extract '{sourceContainerFilePath}' to directory " +
                                             $"'{targetDirectory}'. See inner exception", e);
        }
    }
}