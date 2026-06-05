using Gldf.Net.Domain.Typed;
using Gldf.Net.Parser.DataFlow;

namespace Gldf.Net.Abstract;

internal interface IParserProcessor
{
    public RootTyped Process(ParserDto parserDto);
}