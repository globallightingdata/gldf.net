using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Parser;
using Gldf.Net.Parser.DataFlow;
using System.IO;
using System.Xml;

namespace Gldf.Net;

public class GldfParser : IGldfParser
{
    private readonly ParserSettings _settings;
    private readonly IParserProcessor _processor;

    public GldfParser(ParserSettings settings = null)
    {
        _settings = settings ?? new ParserSettings();
        _processor = new DataFlowProcessor();
    }

    public RootTyped ParseFromXml(string xml, IGldfXmlSerializer serializer = null)
    {
        var gldfXmlSerializer = serializer ?? new GldfXmlSerializer();
        var root = gldfXmlSerializer.DeserializeFromXml(xml);
        var gldfContainer = new GldfContainer(root);
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }

    public RootTyped ParseFromXmlFile(string xmlFilePath, IGldfXmlSerializer serializer = null)
    {
        var gldfXmlSerializer = serializer ?? new GldfXmlSerializer();
        var root = gldfXmlSerializer.DeserializeFromXmlFile(xmlFilePath);
        var gldfContainer = new GldfContainer(root);
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }
    
    public RootTyped ParseFromXmlStream(Stream xmlStream, bool leaveOpen, IGldfXmlSerializer serializer = null)
    {
        var gldfXmlSerializer = serializer ?? new GldfXmlSerializer(new XmlWriterSettings { CloseOutput = !leaveOpen });
        var root = gldfXmlSerializer.DeserializeFromXmlStream(xmlStream);
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
    
    public RootTyped ParseFromGldfFile(string gldfFilePath, IGldfContainerReader reader = null)
    {
        var containerReader = reader ?? new GldfContainerReader();
        var gldfContainer = containerReader.ReadFromGldfFile(gldfFilePath, new ContainerLoadSettings());
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }
    
    public RootTyped ParseFromGldfStream(Stream zipStream, bool leaveOpen, IGldfContainerReader reader = null)
    {
        var containerReader = reader ?? new GldfContainerReader();
        var gldfContainer = containerReader.ReadFromGldfStream(zipStream, leaveOpen, new ContainerLoadSettings());
        var parserDto = new ParserDto(gldfContainer, _settings);
        return _processor.Process(parserDto);
    }
}