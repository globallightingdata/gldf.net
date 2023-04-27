using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Parser;
using Gldf.Net.Parser.DataFlow;
using System.IO;

namespace Gldf.Net;

/// <summary>
///     Provides functionality to Parses GLDF XML and container files into an instance of type
///     <see cref="RootTyped" />
///     with resolved object references.
/// </summary>
public class GldfParser : IGldfParser
{
    private readonly ParserSettings _settings;
    private readonly IParserProcessor _processor;
    private readonly GldfXmlSerializer _xmlSerializer;
    private readonly GldfContainerReader _containerReader;

    /// <summary>
    ///     Initializes a new instance of the <see cref="GldfParser" /> class that can Parses GLDF XML and container files
    ///     into an instance of type <see cref="RootTyped" /> with resolved object references.
    /// </summary>
    public GldfParser(ParserSettings settings = null)
    {
        _settings = settings ?? new ParserSettings();
        _xmlSerializer = new GldfXmlSerializer();
        _containerReader = new GldfContainerReader();
        _processor = new DataFlowProcessor();
    }

    /// <summary>
    ///     Parses GLDF XML string into an instance of type <see cref="RootTyped" /> with resolved object references.
    /// </summary>
    /// <param name="xml">The XML to deserialize</param>
    /// <returns>Parsed GLDF with resolved object references</returns>
    public RootTyped ParseFromXml(string xml)
    {
        var root = _xmlSerializer.DeserializeFromXml(xml);
        var gldfContainer = new GldfContainer(root);
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }

    /// <summary>
    ///     Parses GLDF XML file into an instance of type <see cref="RootTyped" /> with resolved object references.
    /// </summary>
    /// <param name="xmlFilePath">The XML to deserialize</param>
    /// <returns>Parsed GLDF with resolved object references</returns>
    public RootTyped ParseFromXmlFile(string xmlFilePath)
    {
        var root = _xmlSerializer.DeserializeFromXmlFile(xmlFilePath);
        var gldfContainer = new GldfContainer(root);
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }

    /// <summary>
    ///     Parses GLDF XML stream into an instance of type <see cref="RootTyped" /> with resolved object references.
    /// </summary>
    /// <param name="xmlStream">The stream with GLDF XML</param>
    /// <param name="leaveOpen">Whether to close the stream after serialization.</param>
    /// <returns>Parsed GLDF with resolved object references</returns>
    public RootTyped ParseFromXmlStream(Stream xmlStream, bool leaveOpen)
    {
        var gldfXmlSerializer = new GldfXmlSerializer();
        var root = gldfXmlSerializer.DeserializeFromXmlStream(xmlStream, leaveOpen);
        var gldfContainer = new GldfContainer(root);
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }

    /// <summary>
    ///     Parses an instance of <see cref="Root" /> with unresolved references to an object of type <see cref="RootTyped" />
    ///     with resolved references
    /// </summary>
    /// <param name="root">The instance of <see cref="Root" /> from which to map</param>
    /// <returns>Mapped <see cref="RootTyped" /> with resolved object references</returns>
    public RootTyped ParseFromRoot(Root root)
    {
        var gldfContainer = new GldfContainer(root);
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }

    /// <summary>
    ///     Parses a <see cref="GldfContainer" /> instance to <see cref="RootTyped" /> with resolved object references.
    /// </summary>
    /// <param name="gldf">The GLDF container to map from</param>
    /// <returns>Mapped instance with resolved object references</returns>
    public RootTyped ParseFromGldf(GldfContainer gldf)
    {
        var parserDto = new ParserDto(gldf, _settings);
        return _processor.Process(parserDto);
    }

    /// <summary>
    ///     Parses GLDF XML container file into an instance of type <see cref="RootTyped" /> with resolved object
    ///     references.
    /// </summary>
    /// <param name="gldfFilePath">The file containing the GLDF container</param>
    /// <returns>Parsed GLDF with resolved object references</returns>
    public RootTyped ParseFromGldfFile(string gldfFilePath)
    {
        var gldfContainer = _containerReader.ReadFromGldfFile(gldfFilePath, new ContainerLoadSettings());
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }

    /// <summary>
    ///     Parses GLDF XML stream into an instance of type <see cref="RootTyped" /> with resolved object references.
    /// </summary>
    /// <param name="zipStream">The stream containing the GLDF container</param>
    /// <param name="leaveOpen">Whether to close the stream after serialization.</param>
    /// <returns>Parsed GLDF with resolved object references</returns>
    public RootTyped ParseFromGldfStream(Stream zipStream, bool leaveOpen)
    {
        var gldfContainer = _containerReader.ReadFromGldfStream(zipStream, leaveOpen, new ContainerLoadSettings());
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }
}