using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Parser;
using Gldf.Net.Parser.DataFlow;
using System.IO;

namespace Gldf.Net;

public class GldfParser : IGldfParser
{
    private readonly ParserSettings _settings;
    private readonly IParserProcessor _processor;
    private readonly GldfXmlSerializer _xmlSerializer;
    private readonly GldfContainerReader _containerReader;

    public GldfParser(ParserSettings settings = null)
    {
        _settings = settings ?? new ParserSettings();
        _xmlSerializer = new GldfXmlSerializer();
        _containerReader = new GldfContainerReader();
        _processor = new DataFlowProcessor();
    }

    public RootTyped ParseFromXml(string xml)
    {
        var root = _xmlSerializer.DeserializeFromXml(xml);
        var gldfContainer = new GldfContainer(root);
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }

    public RootTyped ParseFromXmlFile(string xmlFilePath)
    {
        var root = _xmlSerializer.DeserializeFromXmlFile(xmlFilePath);
        var gldfContainer = new GldfContainer(root);
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }

    public RootTyped ParseFromXmlStream(Stream xmlStream, bool leaveOpen)
    {
        var gldfXmlSerializer = new GldfXmlSerializer();
        var root = gldfXmlSerializer.DeserializeFromXmlStream(xmlStream, leaveOpen);
        var gldfContainer = new GldfContainer(root);
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }

    public RootTyped ParseFromRoot(Root root)
    {
        var gldfContainer = new GldfContainer(root);
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }

    public RootTyped ParseFromGldf(GldfContainer gldf)
    {
        var parserDto = new ParserDto(gldf, _settings);
        return _processor.Process(parserDto);
    }

    public RootTyped ParseFromGldfFile(string gldfFilePath)
    {
        var gldfContainer = _containerReader.ReadFromGldfFile(gldfFilePath, new ContainerLoadSettings());
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }

    public RootTyped ParseFromGldfStream(Stream zipStream, bool leaveOpen)
    {
        var gldfContainer = _containerReader.ReadFromGldfStream(zipStream, leaveOpen, new ContainerLoadSettings());
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }
}