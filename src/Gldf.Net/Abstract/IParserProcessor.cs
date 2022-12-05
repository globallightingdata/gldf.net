using Gldf.Net.Domain.Typed;
using Gldf.Net.Parser.DataFlow;

namespace Gldf.Net.Abstract;

internal interface IParserProcessor
{
    RootTyped Process(ParserDto parserDto);
}