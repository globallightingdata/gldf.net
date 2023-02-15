using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Parser;
using Gldf.Net.Parser.DataFlow;

namespace Gldf.Net;

public class GldfParser : IGldfParser
{
    private readonly ParserSettings _settings;
    private readonly IParserProcessor _processor;

    public GldfParser(ParserSettings settings = null)
    {
        _settings = settings;
        _processor = new DataFlowProcessor();
    }

    public RootTyped ParseFromXml(string xml, IGldfXmlSerializer serializer = null)
    {
        var gldfXmlSerializer = serializer ?? new GldfXmlSerializer();
        var root = gldfXmlSerializer.DeserializeFromString(xml);
        var gldfContainer = new GldfContainer(root);
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }

    public RootTyped ParseFromXmlFile(string xmlFilePath, IGldfXmlSerializer serializer = null)
    {
        var gldfXmlSerializer = serializer ?? new GldfXmlSerializer();
        var root = gldfXmlSerializer.DeserializeFromFile(xmlFilePath);
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

    public RootTyped ParseFromContainer(GldfContainer gldfContainer)
    {
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }
    
    public RootTyped ParseFromContainerFile(string containerFilePath, IGldfContainerReader reader = null)
    {
        var containerReader = reader ?? new GldfContainerReader();
        var gldfContainer = containerReader.ReadFromFile(containerFilePath, new ContainerLoadSettings());
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }
}