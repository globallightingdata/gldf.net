using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Exceptions;
using System;

namespace Gldf.Net
{
    /// <summary>
    ///     Provides functionality to read and write GLDF container files into and from instances of type
    ///     <see cref="Gldf.Net.Container.GldfArchive" />. As well as to create and extract them them from/to
    ///     a directory path. This type is threadsafe.
    /// </summary>
    public class GldfContainer : IGldfContainer
    {
        private readonly ZipArchiveReader _zipArchiveReader;
        private readonly ZipArchiveWriter _zipArchiveWriter;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GldfContainer" /> class that can read and write
        ///     instances of type <see cref="Gldf.Net.Container.GldfArchive" />.
        /// </summary>
        public GldfContainer()
        {
            _zipArchiveReader = new ZipArchiveReader();
            _zipArchiveWriter = new ZipArchiveWriter();
        }

        /// <summary>
        ///     Reads the GLDF container from file into an instance of <see cref="Gldf.Net.Container.GldfArchive" />.
        /// </summary>
        /// <param name="filePath">The path on disk of the GLDF container file</param>
        /// <returns><see cref="GldfArchive" /> with deserialised product.xml, file assets and signature</returns>
        public GldfArchive ReadFromFile(string filePath) => ReadFromFile(filePath, ContainerLoadSettings.Default);

        /// <summary>
        ///     Reads the GLDF container from file into an instance of <see cref="Gldf.Net.Container.GldfArchive" />.
        ///     With specified load behaviour settings for product.xml, file assets and signature.
        /// </summary>
        /// <param name="filePath">The path on disk of the GLDF container file</param>
        /// <param name="settings">Load behaviour for product.xml, asset files and signature</param>
        /// <returns><see cref="GldfArchive" /> with deserialised product.xml, file assets and signature</returns>
        public GldfArchive ReadFromFile(string filePath, ContainerLoadSettings settings)
        {
            try
            {
                return _zipArchiveReader.ReadArchive(filePath, settings);
            }
            catch (Exception e)
            {
                throw new GldfContainerException($"Failed to read {nameof(GldfContainer)} from " +
                                                 $"'{filePath}'. See inner exception", e);
            }
        }

        /// <summary>
        ///     Writes the contents of a <see cref="Gldf.Net.Container.GldfArchive" /> to a file on disk.
        /// </summary>
        /// <param name="filePath">Path on disk to write the <see cref="GldfArchive" /> to</param>
        /// <param name="gldfArchive">The <see cref="GldfArchive" /> to wirte to disk</param>
        public void WriteToFile(string filePath, GldfArchive gldfArchive)
        {
            try
            {
                _zipArchiveWriter.Write(filePath, gldfArchive);
            }
            catch (Exception e)
            {
                throw new GldfContainerException($"Failed to create {nameof(GldfArchive)} in " +
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
            try
            {
                _zipArchiveWriter.CreateFromDirectory(sourceDirectory, targetContainerFilePath);
            }
            catch (Exception e)
            {
                throw new GldfContainerException($"Failed to create GLDF container from '{sourceDirectory}' in " +
                                                 $"'{targetContainerFilePath}'. See inner exception", e);
            }
        }

        /// <summary>
        ///     Extracts the content of a GLDF container file to disk
        /// </summary>
        /// <param name="sourceContainerFilePath">Filepath to the GLDF container file</param>
        /// <param name="targetDirectory">The target directory the content wil be extracted to</param>
        public void ExtractToDirectory(string sourceContainerFilePath, string targetDirectory)
        {
            try
            {
                _zipArchiveWriter.ExtractToDirectory(sourceContainerFilePath, targetDirectory);
            }
            catch (Exception e)
            {
                throw new GldfContainerException($"Failed to extract '{sourceContainerFilePath}' to directory " +
                                                 $"'{targetDirectory}'. See inner exception", e);
            }
        }
    }
}