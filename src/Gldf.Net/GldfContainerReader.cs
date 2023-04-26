using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Exceptions;
using System;
using System.IO;
using System.Text;

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
    public GldfContainerReader() : this(Encoding.UTF8)
    {
    }
    
    public GldfContainerReader(Encoding encoding)
    {
        _zipArchiveReader = new ZipArchiveReader(encoding);
    }

    /// <summary>
    ///     Reads the GLDF container from file into an instance of <see cref="GldfContainer" />.
    /// </summary>
    /// <param name="gldfFilePath">The path on disk of the GLDF container file</param>
    /// <returns><see cref="GldfContainer" /> with deserialized product.xml, file assets and meta-information</returns>
    public GldfContainer ReadFromGldfFile(string gldfFilePath)
        => ReadFromGldfFile(gldfFilePath, ContainerLoadSettings.Default);

    /// <summary>
    ///     Reads the GLDF container from file into an instance of <see cref="GldfContainer" />.
    ///     With specified load behaviour settings for product.xml, file assets and meta-information.
    /// </summary>
    /// <param name="gldfFilePath">The path on disk of the GLDF container file</param>
    /// <param name="settings">Load behaviour for product.xml, asset files and meta-information</param>
    /// <returns><see cref="GldfContainer" /> with deserialized product.xml, file assets and meta-information</returns>
    public GldfContainer ReadFromGldfFile(string gldfFilePath, ContainerLoadSettings settings)
    {
        if (gldfFilePath == null) throw new ArgumentNullException(nameof(gldfFilePath));
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        try
        {
            return _zipArchiveReader.ReadContainer(gldfFilePath, settings);
        }
        catch (Exception e)
        {
            throw new GldfContainerException($"Failed to read {nameof(GldfContainer)} from " +
                                             $"'{gldfFilePath}'. See inner exception", e);
        }
    }

    /// <summary>
    ///     Reads the GLDF container from a stream into an instance of <see cref="GldfContainer" />.
    /// </summary>
    /// <param name="zipStream">Stream to read the <see cref="GldfContainer" /> from</param>
    /// <param name="leaveOpen">To leave the stream open after read, otherwise it will be disposed</param>
    /// <returns><see cref="GldfContainer" /> with deserialized product.xml, file assets and meta-information</returns>
    public GldfContainer ReadFromGldfStream(Stream zipStream, bool leaveOpen) =>
        ReadFromGldfStream(zipStream, leaveOpen, ContainerLoadSettings.Default);

    /// <summary>
    ///     Reads the GLDF container from a stream into an instance of <see cref="GldfContainer" />.
    /// </summary>
    /// <param name="zipStream">Stream of a ZIP archive to read the <see cref="GldfContainer" /> from</param>
    /// <param name="leaveOpen">To leave the stream open after read, otherwise it will be disposed</param>
    /// <param name="settings">Load behaviour for product.xml, asset files and meta-information</param>
    /// <returns><see cref="GldfContainer" /> with deserialized product.xml, file assets and meta-information</returns>
    public GldfContainer ReadFromGldfStream(Stream zipStream, bool leaveOpen, ContainerLoadSettings settings)
    {
        if (zipStream == null) throw new ArgumentNullException(nameof(zipStream));
        if (settings == null) throw new ArgumentNullException(nameof(settings));

        try
        {
            return _zipArchiveReader.ReadContainer(zipStream, leaveOpen, settings);
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
    /// <param name="sourceGldfFilePath">Filepath to the GLDF container file</param>
    /// <param name="targetDirectory">The target directory the content wil be extracted to</param>
    public void ExtractToDirectory(string sourceGldfFilePath, string targetDirectory)
    {
        if (sourceGldfFilePath == null) throw new ArgumentNullException(nameof(sourceGldfFilePath));
        if (targetDirectory == null) throw new ArgumentNullException(nameof(targetDirectory));

        try
        {
            ZipArchiveReader.ExtractToDirectory(sourceGldfFilePath, targetDirectory);
        }
        catch (Exception e)
        {
            throw new GldfContainerException($"Failed to extract '{sourceGldfFilePath}' to directory " +
                                             $"'{targetDirectory}'. See inner exception", e);
        }
    }
}