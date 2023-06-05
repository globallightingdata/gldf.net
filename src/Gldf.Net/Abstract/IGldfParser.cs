using Gldf.Net.Container;
using Gldf.Net.Domain.Typed;
using Gldf.Net.Domain.Xml;
using Gldf.Net.Parser.DataFlow;
using System.Collections.Generic;
using System.IO;

namespace Gldf.Net.Abstract;

public interface IGldfParser
{
    RootTyped ParseFromXml(string xml, out IEnumerable<ParserError> errors);

    RootTyped ParseFromXmlFile(string xmlFilePath, out IEnumerable<ParserError> errors);

    RootTyped ParseFromXmlStream(Stream xmlStream, bool leaveOpen, out IEnumerable<ParserError> errors);

    RootTyped ParseFromRoot(Root root, out IEnumerable<ParserError> errors);

    RootTyped ParseFromGldf(GldfContainer gldf, out IEnumerable<ParserError> errors);

    RootTyped ParseFromGldfFile(string gldfFilePath, out IEnumerable<ParserError> errors);

    RootTyped ParseFromGldfStream(Stream zipStream, bool leaveOpen, out IEnumerable<ParserError> errors);
}