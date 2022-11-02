using NUnit.Framework;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Gldf.Net.Tests.Parser;

[TestFixture]
public class ParserTests
{
    [Test, Explicit]
    public async Task Test()
    {
        var gldfParser = new GldfParser();
        var xml = await File.ReadAllTextAsync(@"C:\Users\Kurpanik\Desktop\GLDF.xml");

        Console.WriteLine("Parsing");
        var rootTyped1 = gldfParser.ParseFromXml(xml);
        Console.WriteLine($"rootTyped1 != null: {rootTyped1 != null}");
        var rootTyped2 = gldfParser.ParseFromXml(xml);
        Console.WriteLine($"rootTyped2 != null: {rootTyped2 != null}");

        // await Task.Delay(10000);
        // Console.WriteLine(rootTyped1.GeneralDefinitions.Sensors.Length);
    }
}