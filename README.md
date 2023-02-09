# GLDF .NET library

![GLDF Logo](/img/logo.png)

[![OnPublishedRelease](https://github.com/globallightingdata/gldf.net/actions/workflows/OnPublishedRelease.yml/badge.svg)](https://github.com/globallightingdata/gldf.net/actions/workflows/OnPublishedRelease.yml)  
[![OnPush develop](https://github.com/globallightingdata/gldf.net/actions/workflows/OnPushDevelop.yml/badge.svg)](https://github.com/globallightingdata/gldf.net/actions/workflows/OnPushDevelop.yml)  
[![NuGet Status](https://img.shields.io/nuget/v/GLDF.Net.svg)](https://www.nuget.org/packages/GLDF.Net/)

## Intro

.NET 6.0 library for the Global Lighting Data Format [GLDF](https://gldf.io)

Features

- Serialize and deserialize GLDF XML
- 100% format coverage of [version 1.0.0](https://github.com/globallightingdata/gldf/releases)
- Validate GLDF XML with the GLDF XmlSchema (XSD)
- Read and write .gldf container files, including all assets and signature file
- Validate .gldf container files
- Parse XML/container either into 1:1 .NET POCOs or alternatively with resolved references
- No dependencies, small footprint (~450kb)
- Windows & Unix compatible

If you would like to read the GLDF L3D format as well, have a look on [GLDF.L3d](https://github.com/globallightingdata/l3d.net)

## How to get started

### Requirements

- [.NET Standard 2.0](https://docs.microsoft.com/de-de/dotnet/standard/net-standard) compatible project

### Nuget package

Add the package within your IDE or using the CLI

```bash
dotnet add package GLDF.Net
```

---

### XML Serialization

#### Serialize GLDF domain DTOs to XML string

All models in the following examples are incomplete. For valid GLDF luminaires/sensors read the docs.

```CSharp
var serializer = new GldfXmlSerializer();
var root = new Root {Header = new Header {Author = "Github Example"}};
var xml = serializer.SerializeToString(root);
```

#### Serialize GLDF domain DTOs to .xml file

```CSharp
var serializer = new GldfXmlSerializer();
var root = new Root {Header = new Header {Author = "Github Example"}};
serializer.SerializeToFile(root, @"c:\some\file\path\luminaire.xml");
```

#### Deserialize GLDF XML string to domain DTOs

```CSharp
var serializer = new GldfXmlSerializer();
var xml = @"<Root><Header><Author>Github Example</Author></Header></Root>";
Root root = serializer.DeserializeFromString(xml);
```

#### Deserialize GLDF .xml file to domain DTOs

```CSharp
var serializer = new GldfXmlSerializer();
var filePath = @"c:\some\file\path\luminaire.xml";
Root root = serializer.DeserializeFromFile(filePath);
```

#### Set custom XML Serializer settings

```CSharp
XmlWriterSettings settings = new XmlWriterSettings();
settings.Encoding = Encoding.UTF32; // UTF-8 by default
settings.Indent = false; // true by default
// ...more settings
var serializer = new GldfXmlSerializer(settings);
```

---

### XML validation

#### Validate XML string with GLDF XmlSchema

```CSharp
var gldfXmlValidator = new GldfXmlValidator();
var xml = @"<Root><Header><Author>Github Example</Author></Header></Root>";
IEnumerable<ValidationHint> validationResult = gldfXmlValidator.ValidateString(xml);

foreach (var validationHint in validationResult)
{
    Console.Write(validationHint.Severity); // Error/Info/Warning
    Console.Write(validationHint.ErrorType); // For XML validation its always XmlSchema
    Console.Write(validationHint.Message); // E.g. missing XML Elements etc.
    Console.Write(Environment.NewLine);
}
```

#### Validate a .xml file with GLDF XmlSchema

```CSharp
var gldfXmlValidator = new GldfXmlValidator();
var filePath = @"c:\some\file\path\luminaire.xml";
IEnumerable<ValidationHint> validationResult = gldfXmlValidator.ValidateFile(filePath);

foreach (var validationHint in validationResult)
{
    Console.Write(validationHint.Severity); // Error/Info/Warning
    Console.Write(validationHint.ErrorType); // For XML validation its always XmlSchema
    Console.Write(validationHint.Message); // E.g. missing XML Elements etc.
    Console.Write(Environment.NewLine);
}
```

#### Set Encoding (only required when validating .xml files)

```CSharp
var encoding = Encoding.UTF32;
var gldfXmlValidator = new GldfXmlValidator(encoding);
var filePath = @"c:\some\file\path\luminaire.xml";
gldfXmlValidator.ValidateFile(filePath);
```

---

### Container read/write

#### Write a .gldf container file

```CSharp
var containerWriter = new GldfContainerWriter();
var gldfArchive = new GldfContainer
{
    Product = new Root {Header = new Header {Author = "Github example"}},
    Assets = new GldfAssets(),
    Signature = "some checksum"
};
var filePath = @"c:\some\file\path\luminaire.gldf";
containerWriter.WriteToFile(filePath, gldfArchive);
```

#### Read a .gldf container file

```CSharp
var containerReader = new GldfContainerReader();
var filePath = @"c:\some\file\path\luminaire.gldf";
GldfContainer container = containerReader.ReadFromFile(filePath);
Console.WriteLine($"Luminaire author: {container.Product.Header.Author}");
```

#### Extract a .gldf container content to a directory

```CSharp
var containerReader = new GldfContainerReader();
var sourceFilePath = @"c:\some\file\path\luminaire.gldf";
var targetFolder = @"c:\some\file\path\extractedContent\";
containerReader.ExtractToDirectory(sourceFilePath, targetFolder);
```

#### Create a .gldf container from content in a directory

```CSharp
var containerWriter = new GldfContainerWriter();
var sourceDirectory = @"c:\some\file\path\extractedContent\";
var targetFile = @"c:\some\file\path\luminaire.gldf";
containerWriter.CreateFromDirectory(sourceDirectory, targetFile);
```

---

### Container Validation

#### Validate a GldfArchive domain DTO

```CSharp
var validator = new GldfContainerValidator();
var gldfContainer = new GldfContainer
{
    Product = new Root {Header = new Header {Author = "Github example"}},
    Assets = new GldfAssets(),
    Signature = "some checksum"
};
var validationResult = validator.Validate(gldfContainer);

foreach (var validationHint in validationResult)
{
    Console.Write(validationHint.Severity); // Enum: Error/Info/Warning
    Console.Write(validationHint.ErrorType); // Enum: E.g. InvalidZipFile
    Console.Write(validationHint.Message); // E.g. Not a valid ZIP file etc.
    Console.Write(Environment.NewLine);
}
```

#### Validate a .gldf container file

```CSharp
var validator = new GldfContainerValidator();
var filePath = @"c:\some\file\path\luminaire.gldf";
var validationResult = validator.Validate(filePath);

foreach (var validationHint in validationResult)
{
    Console.Write(validationHint.Severity); // Enum: Error/Info/Warning
    Console.Write(validationHint.ErrorType); // Enum: E.g. InvalidZipFile
    Console.Write(validationHint.Message); // E.g. Not a valid ZIP file etc.
    Console.Write(Environment.NewLine);
}
```

### Deserialize with resolved references

The `GldfXmlSerializer` and `GldfContainerReader` classes produce an exact 1:1 representation of the GLDF XML in .NET (`Root`). Which implies that any references such as Variant ➜ Emitter ➜ Equipment ➜ LightSource ➜ Photometry ➜ File are mapped in the form of Ids, which have to be resolved manually in your application. With the `GldfParser` you have an option to let it resolve during deserialisation for you. And optionally load the GLDF `File` element content as well:

#### Parse into POCOs with resolved references

```CSharp
var gldfParser = new GldfParser(new ParserSettings
{
    LocalFileLoadBehaviour = LocalFileLoadBehaviour.Load,
    OnlineFileLoadBehaviour = OnlineFileLoadBehaviour.Skip
});

var rootTyped = gldfParser.ParseFromContainerFile(/* GLDF container filepath */);
// Or
var rootTyped = gldfParser.ParseFromXmlFile(/* GLDF XML filepath */)
// Or
var rootTyped = gldfParser.ParseFromRoot(/* Root result from i.e. GldfXmlSerializer/GldfContainerReader */)
// Or
var rootTyped = gldfParser.ParseFromXml(/* GLDF XML content */)
```

---

### Interfaces

There are also Interfaces you can use:

```CSharp
// 1) Serialize XML
IGldfXmlSerializer serializer = new GldfXmlSerializer();
// 2) Validate XML
IGldfXmlValidator xmlValidator = new GldfXmlValidator();

// 3) Read GLDF container
IGldfContainerReader containerReader = new GldfContainerReader();
// 4) Write GLDF container
IGldfContainerWriter containerWriter = new GldfContainerWriter();
// 5) Validate GLDF Container
IGldfContainerValidator containerValidator = new GldfContainerValidator();

// 6) Parse GLDF with resolved references
IGldfParser gldfParser = new GldfParser();
```

---

## Questions, Issues & Contribution

Please use the discussion section for questions or create issues, when something seems to be wrong. PRs are welcome.
