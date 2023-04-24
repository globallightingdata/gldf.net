using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Exceptions;
using System;
using System.IO;

namespace Gldf.Net;

/// <summary>
///     Provides functionality to write GLDF container files from instances of type
///     <see cref="GldfContainer" />. As well as to create them from a directory path.
///     This type is threadsafe.
/// </summary>
public class GldfContainerWriter : IGldfContainerWriter
{
    private readonly ZipArchiveWriter _zipArchiveWriter;

    /// <summary>
    ///     Initializes a new instance of the <see cref="GldfContainerWriter" /> class that can write
    ///     instances of type <see cref="GldfContainer" />.
    /// </summary>
    public GldfContainerWriter()
    {
        _zipArchiveWriter = new ZipArchiveWriter();
    }

    /// <summary>
    ///     Writes the contents of a <see cref="GldfContainer" /> to a file on disk.
    /// </summary>
    /// <param name="gldfFilePath">Path on disk to write the <see cref="GldfContainer" /> to</param>
    /// <param name="gldf">The <see cref="GldfContainer" /> to wirte to disk</param>
    public void WriteToGldfFile(string gldfFilePath, GldfContainer gldf)
    {
        if (gldfFilePath == null) throw new ArgumentNullException(nameof(gldfFilePath));
        if (gldf == null) throw new ArgumentNullException(nameof(gldf));

        try
        {
            _zipArchiveWriter.Write(gldfFilePath, gldf);
        }
        catch (Exception e)
        {
            throw new GldfContainerException($"Failed to create {nameof(GldfContainer)} in " +
                                             $"'{gldfFilePath}'. See inner exception", e);
        }
    }

    /// <summary>
    ///     Writes the contents of a <see cref="GldfContainer" /> to a stream.
    /// </summary>
    /// <param name="zipStream">Stream to write the <see cref="GldfContainer" /> to</param>
    /// <param name="leaveOpen">To leave the stream open after write, otherwise it will be disposed</param>
    /// <param name="gldf">The <see cref="GldfContainer" /> to wirte to the stream</param>
    public void WriteToGldfStream(Stream zipStream, bool leaveOpen, GldfContainer gldf)
    {
        if (zipStream == null) throw new ArgumentNullException(nameof(zipStream));
        if (gldf == null) throw new ArgumentNullException(nameof(gldf));

        try
        {
            _zipArchiveWriter.Write(zipStream, leaveOpen, gldf);
        }
        catch (Exception e)
        {
            throw new GldfContainerException($"Failed to create {nameof(GldfContainer)} stream. " +
                                             "See inner exception", e);
        }
    }

    /// <summary>
    ///     Creates a GLDF container from a directory path and writes it to disk.
    /// </summary>
    /// <param name="sourceDirectory">
    ///     The source directory with GLDF content (product.xml, assets and meta-information)
    /// </param>
    /// <param name="targetContainerFilePath">
    ///     The target file path the container will be written to. It should
    ///     end with .gldf
    /// </param>
    public void CreateFromDirectory(string sourceDirectory, string targetContainerFilePath)
    {
        if (sourceDirectory == null) throw new ArgumentNullException(nameof(sourceDirectory));
        if (targetContainerFilePath == null) throw new ArgumentNullException(nameof(targetContainerFilePath));

        try
        {
            ZipArchiveWriter.CreateFromDirectory(sourceDirectory, targetContainerFilePath);
        }
        catch (Exception e)
        {
            throw new GldfContainerException($"Failed to create {nameof(GldfContainer)} from '{sourceDirectory}' in " +
                                             $"'{targetContainerFilePath}'. See inner exception", e);
        }
    }
}