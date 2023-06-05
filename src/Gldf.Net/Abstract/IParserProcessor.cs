using Gldf.Net.Domain.Typed;
using Gldf.Net.Parser.DataFlow;
using System.Collections.Generic;

namespace Gldf.Net.Abstract;

internal interface IParserProcessor
{
    RootTyped Process(ParserDto parserDto, out IEnumerable<ParserError> errors);
}