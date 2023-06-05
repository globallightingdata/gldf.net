using System;

namespace Gldf.Net.Parser.DataFlow;

public record ParserError(string Location, Exception Ex);