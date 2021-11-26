using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Exceptions;
using System;

namespace Gldf.Net
{
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
        /// <param name="filePath">Path on disk to write the <see cref="GldfContainer" /> to</param>
        /// <param name="gldfContainer">The <see cref="GldfContainer" /> to wirte to disk</param>
        public void WriteToFile(string filePath, GldfContainer gldfContainer)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));
            if (gldfContainer == null) throw new ArgumentNullException(nameof(gldfContainer));

            try
            {
                _zipArchiveWriter.Write(filePath, gldfContainer);
            }
            catch (Exception e)
            {
                throw new GldfContainerException($"Failed to create {nameof(GldfContainer)} in " +
                                                 $"'{filePath}'. See inner exception", e);
            }
        }

        /// <summary>
        ///     Creates a GLDF container from a directory path and writes it to disk.
        /// </summary>
        /// <param name="sourceDirectory">
        ///     The source directory with GLDF content (product.xml, assets and signature)
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
                _zipArchiveWriter.CreateFromDirectory(sourceDirectory, targetContainerFilePath);
            }
            catch (Exception e)
            {
                throw new GldfContainerException($"Failed to create {nameof(GldfContainer)} from '{sourceDirectory}' in " +
                                                 $"'{targetContainerFilePath}'. See inner exception", e);
            }
        }
    }
}