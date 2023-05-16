# GLDF .NET library

![GLDF Logo](/img/logo.png)

[![OnPublishedRelease](https://github.com/globallightingdata/gldf.net/actions/workflows/OnPublishedRelease.yml/badge.svg)](https://github.com/globallightingdata/gldf.net/actions/workflows/OnPublishedRelease.yml)  
[![OnPush develop](https://github.com/globallightingdata/gldf.net/actions/workflows/OnPushDevelop.yml/badge.svg)](https://github.com/globallightingdata/gldf.net/actions/workflows/OnPushDevelop.yml)  
[![NuGet Status](https://img.shields.io/nuget/v/GLDF.Net.svg)](https://www.nuget.org/packages/GLDF.Net/)

## Intro

.NET 6.0 library for the Global Lighting Data Format [GLDF](https://gldf.io)

Features

- Serialize and deserialize GLDF XML
- 100% format coverage of [version 1.0-rc2](https://github.com/globallightingdata/gldf/releases)
- Validate GLDF XML with the GLDF XmlSchema (XSD)
- Read and write .gldf container files, including all assets and meta-information.xml
- Validate .gldf container files
- Parse XML/container either into 1:1 .NET POCOs or alternatively with resolved references
- No dependencies, small footprint (~950kb)
- Windows & Unix compatible

If you would like to read the GLDF L3D format as well, have a look on [GLDF.L3d](https://github.com/globallightingdata/l3d.net)

## How to get started

### Requirements

- [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) compatible project

### Nuget package

Add the package within your IDE or using the CLI

```bash
dotnet add package GLDF.Net
```

---

### GLDF XML Serialization

#### Serialize GLDF domain DTOs to XML string

All models in the following examples are incomplete. For valid GLDF luminaires/sensors read the docs.

```CSharp
IGldfXmlSerializer serializer = new GldfXmlSerializer();
Root root = new Root {Header = new Header {Author = "Github Example"}};
string xml = serializer.SerializeToXml(root);
```

#### Serialize GLDF domain DTOs to .xml file

```CSharp
IGldfXmlSerializer serializer = new GldfXmlSerializer();
Root root = new Root {Header = new Header {Author = "Github Example"}};
serializer.SerializeToXmlFile(root, @"c:\some\file\path\product.xml");
```

#### Serialize GLDF domain DTOs to XML stream

```CSharp
IGldfXmlSerializer serializer = new GldfXmlSerializer();
Root root = new Root {Header = new Header {Author = "Github Example"}};
using Stream stream = new MemoryStream();
serializer.SerializeToXmlStream(root, stream);
```

#### Deserialize GLDF XML string to domain DTOs

```CSharp
IGldfXmlSerializer serializer = new GldfXmlSerializer();
string xml = @"<Root><Header><Author>Github Example</Author></Header></Root>";
Root root = serializer.DeserializeFromXml(xml);
```

#### Deserialize GLDF .xml file to domain DTOs

```CSharp
IGldfXmlSerializer serializer = new GldfXmlSerializer();
string filePath = @"c:\some\file\path\product.xml";
Root root = serializer.DeserializeFromXmlFile(filePath);
```

#### Deserialize GLDF stream to domain DTOs

```CSharp
IGldfXmlSerializer serializer = new GldfXmlSerializer();
string filePath = @"c:\some\file\path\product.xml";
using Stream stream = new FileStream(filePath, FileMode.Open);
Root root = serializer.DeserializeFromXmlStream(stream);
```

#### Set custom XML Serializer settings

```CSharp
XmlWriterSettings settings = new XmlWriterSettings();
settings.Encoding = Encoding.UTF32; // UTF-8 by default
settings.Indent = false; // true by default
// ...more settings
IGldfXmlSerializer serializer = new GldfXmlSerializer(settings);
```

---

### GLDF XML validation

#### Validate XML string with GLDF XmlSchema

```CSharp
IGldfXmlValidator gldfXmlValidator = new GldfXmlValidator();
string xml = @"<Root><Header><Author>Github Example</Author></Header></Root>";
IEnumerable<ValidationHint> validationResult = gldfXmlValidator.ValidateXml(xml);

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
IGldfXmlValidator gldfXmlValidator = new GldfXmlValidator();
string filePath = @"c:\some\file\path\product.xml";
IEnumerable<ValidationHint> validationResult = gldfXmlValidator.ValidateXmlFile(filePath);
```

#### Validate a .xml Stream with GLDF XmlSchema

```CSharp
IGldfXmlValidator gldfXmlValidator = new GldfXmlValidator();
string filePath = @"c:\some\file\path\product.xml";
using Stream stream = new FileStream(filePath, FileMode.Open);
IEnumerable<ValidationHint> validationResult = gldfXmlValidator.ValidateXmlStream(stream, leaveOpen:false);
```

#### Validate a .gldf container file with GLDF XmlSchema (the product.xml inside the zip)

```CSharp
IGldfXmlValidator gldfXmlValidator = new GldfXmlValidator();
string filePath = @"c:\some\file\path\luminaire.gldf";
IEnumerable<ValidationHint> validationResult = gldfXmlValidator.ValidateGldfFile(filePath);
```

#### Validate a .gldf container Stream with GLDF XmlSchema (the product.xml inside the zip)

```CSharp
IGldfXmlValidator gldfXmlValidator = new GldfXmlValidator();
string filePath = @"c:\some\file\path\luminaire.gldf";
using Stream stream = new FileStream(filePath, FileMode.Open);
IEnumerable<ValidationHint> validationResult = gldfXmlValidator.ValidateGldfStream(stream, leaveOpen:false);
```

#### Set Encoding for validation

```CSharp
var encoding = Encoding.UTF32;
var gldfXmlValidator = new GldfXmlValidator(encoding);
var filePath = @"c:\some\file\path\product.xml";
gldfXmlValidator.ValidateFile(filePath);
```

---

### GLDF container read/write

#### Create a .gldf container file

```CSharp
IGldfContainerWriter containerWriter = new GldfContainerWriter();
GldfContainer gldf = new GldfContainer
{
    Product = new Root {Header = new Header {Author = "Github example"}},
    Assets = new GldfAssets(),
    MetaInformation = new MetaInformation()
};
var filePath = @"c:\some\file\path\luminaire.gldf";
containerWriter.WriteToGldfFile(filePath, gldf);
```

#### Write to a .gldf container Stream

```CSharp
IGldfContainerWriter containerWriter = new GldfContainerWriter();
GldfContainer gldf = new GldfContainer
{
    Product = new Root {Header = new Header {Author = "Github example"}},
    Assets = new GldfAssets(),
    MetaInformation = new MetaInformation()
};
using Stream stream = new MemoryStream();
containerWriter.WriteToGldfStream(stream, leaveOpen:false, gldf);
```

#### Read a .gldf container file

```CSharp
IGldfContainerReader containerReader = new GldfContainerReader();
string filePath = @"c:\some\file\path\luminaire.gldf";
GldfContainer container = containerReader.ReadFromGldfFile(filePath);
Console.WriteLine($"GLDF author: {container.Product.Header.Author}");
```

#### Read a .gldf container file with `ContainerLoadSettings`

```CSharp
IGldfContainerReader containerReader = new GldfContainerReader();
string filePath = @"c:\some\file\path\luminaire.gldf";
var settings = new ContainerLoadSettings
{
    ProductLoadBehaviour = ProductLoadBehaviour.Load,
    AssetLoadBehaviour = AssetLoadBehaviour.FileNamesOnly,
    MetaInfoLoadBehaviour = MetaInfoLoadBehaviour.Skip
};
GldfContainer container = containerReader.ReadFromGldfFile(filePath, settings);
Console.WriteLine($"GLDF author: {container.Product.Header.Author}");
```

#### Read from a .gldf container Stream

```CSharp
IGldfContainerReader containerReader = new GldfContainerReader();
string filePath = @"c:\some\file\path\luminaire.gldf";
using Stream stream = new FileStream(filePath, FileMode.Open);
GldfContainer container = containerReader.ReadFromGldfStream(stream, leaveOpen:false);
Console.WriteLine($"GLDF author: {container.Product.Header.Author}");
```

#### Extract a .gldf container content to a directory

```CSharp
IGldfContainerReader containerReader = new GldfContainerReader();
string sourceFilePath = @"c:\some\file\path\luminaire.gldf";
string targetFolder = @"c:\some\file\path\extractedContent\";
containerReader.ExtractToDirectory(sourceFilePath, targetFolder);
```

#### Create a .gldf container from content in a directory

```CSharp
IGldfContainerWriter containerWriter = new GldfContainerWriter();
string sourceDirectory = @"c:\some\file\path\extractedContent\";
string targetFile = @"c:\some\file\path\luminaire.gldf";
containerWriter.CreateFromDirectory(sourceDirectory, targetFile);
```

---

### GLF container validation

#### Validate a GLDF container

```CSharp
IGldfValidator validator = new GldfValidator();
GldfContainer gldfContainer = new GldfContainer
{
    Product = new Root {Header = new Header {Author = "Github example"}},
    Assets = new GldfAssets(),
    MetaInformation = new MetaInformation()
};
IEnumerable<ValidationHint> validationResult = validator.ValidateGldf(gldfContainer);

foreach (var validationHint in validationResult)
{
    Console.Write(validationHint.Severity); // Enum: Error/Info/Warning
    Console.Write(validationHint.ErrorType); // Enum: E.g. InvalidZipFile
    Console.Write(validationHint.Message); // E.g. Not a valid ZIP file etc.
    Console.Write(Environment.NewLine);
}
```

#### Validate a GLDF container file

```CSharp
IGldfValidator validator = new GldfValidator();
var filePath = @"c:\some\file\path\luminaire.gldf";
var result = validator.ValidateGldfFile(filePath, ValidationFlags.All);
```

#### Validate GLDF partially with `ValidationFlags`

```CSharp
IGldfValidator validator = new GldfValidator();
var filePath = @"c:\some\file\path\luminaire.gldf";
var flags = ValidationFlags.Schema | ValidationFlags.Zip;
var result = validator.ValidateGldfFile(filePath, flags);
```

See [source](https://github.com/globallightingdata/gldf.net/tree/master/src/Gldf.Net/Validation/Rules) for individual Rules

#### Validate a GLDF container Stream

```CSharp
IGldfValidator validator = new GldfValidator();
string filePath = @"c:\some\file\path\luminaire.gldf";
using Stream stream = new FileStream(filePath, FileMode.Open); 
var result = validator.ValidateGldfStream(stream, leaveOpen:false, ValidationFlags.All);
```

---

### Deserialize GLDF with resolved references

The `GldfXmlSerializer` and `GldfContainerReader` classes produce an exact 1:1 representation of the GLDF XML in .NET (`Root`). Which implies that any references such as Variant ➜ Emitter ➜ Equipment ➜ LightSource ➜ Photometry ➜ File are mapped in the form of Ids, which have to be resolved manually in your application. With the `GldfParser` you have an option to let it resolve during deserialisation for you. And optionally load the GLDF `File` element content as well:

#### Parse into POCOs with resolved references

```CSharp
var parserSettings = new ParserSettings
{
    LocalFileLoadBehaviour = LocalFileLoadBehaviour.Skip,
    OnlineFileLoadBehaviour = OnlineFileLoadBehaviour.Load,
    HttpClient = new HttpClient()
};
IGldfParser gldfParser = new GldfParser(parserSettings);

var rootTyped = gldfParser.ParseFromXml(/* GLDF XML string */);
// Or
var rootTyped = gldfParser.ParseFromXmlFile(/* GLDF XML filepath */);
// Or
var rootTyped = gldfParser.ParseFromXmlStream(/* GLDF XML stream */);
// Or
var rootTyped = gldfParser.ParseFromRoot(/* Root POCO */);
// Or
var rootTyped = gldfParser.ParseFromGldf(/* GldfContainer POCO */);
// Or
var rootTyped = gldfParser.ParseFromGldfFile(/* GLDF container filepath */);
// Or
var rootTyped = gldfParser.ParseFromGldfStream(/* GLDF container stream */);
```

---

### Meta-Information XML Serialization

See [gldf.io](https://gldf.io/docs/container/meta-information) to learn more about meta-information.xml

#### Serialize Meta-Information DTO to XML string

```CSharp
IMetaInfoSerializer serializer = new MetaInfoSerializer();
var metaInformation = new MetaInformation();
string xml = serializer.SerializeToXml(metaInformation);
```

#### Serialize Meta-Information DTO to XML file

```CSharp
IMetaInfoSerializer serializer = new MetaInfoSerializer();
var metaInformation = new MetaInformation();
var filePath = @"c:\some\file\path\meta-information.xml";
serializer.SerializeToXmlFile(metaInformation, filePath);
```

#### Serialize Meta-Information DTO to XML Stream

```CSharp
IMetaInfoSerializer serializer = new MetaInfoSerializer();
var metaInformation = new MetaInformation();
using Stream stream = new MemoryStream();
serializer.SerializeToXmlStream(metaInformation, stream);
```

#### Deserialize Meta-Information from XML string

```CSharp
IMetaInfoSerializer serializer = new MetaInfoSerializer();
var xml = "<MetaInformation></MetaInformation>";
MetaInformation metaInformation = serializer.DeserializeFromXml(xml);
```

#### Deserialize Meta-Information from XML file

```CSharp
IMetaInfoSerializer serializer = new MetaInfoSerializer();
var filePath = @"c:\some\file\path\meta-information.xml";
MetaInformation metaInformation = serializer.DeserializeFromXmlFile(filePath);
```

#### Deserialize Meta-Information from XML stream

```CSharp
IMetaInfoSerializer serializer = new MetaInfoSerializer();
string xml = "<MetaInformation></MetaInformation>";
using Stream stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));
MetaInformation metaInformation = serializer.DeserializeFromXmlStream(stream);
```

### Other

#### Read [`FormatVersion`](https://gldf.io/docs/structure/header) from GLDF XML string or XML file. Or from GLDF container  

```CSharp
const string xml = "<Root><Header><FormatVersion major='1' minor='2'/></Header></Root>";
var formatVersion = GldfFormatVersionReader.GetFromXml(xml);
// or
const string filePath = @"c:\path\product.xml";
var formatVersion = GldfFormatVersionReader.GetFromXmlFile(filePath);
// or
const string filePath = @"c:\path\product.gldf";
var formatVersion = GldfFormatVersionReader.GetFromGldfFile(filePath);
// or
using var stream = File.OpenRead(@"c:\path\product.gldf");
var formatVersion = GldfFormatVersionReader.GetFromGldfStream(stream, leaveOpen: false);
```

---

### Interfaces

In summary, you can use the following interfaces

```CSharp
// 1) Serialize GLDF XML
IGldfXmlSerializer serializer = new GldfXmlSerializer();
// 2) Validate GLDF XML
IGldfXmlValidator gldfXmlValidator = new GldfXmlValidator();

// 3) Read GLDF container
IGldfContainerReader containerReader = new GldfContainerReader();
// 4) Write GLDF container
IGldfContainerWriter containerWriter = new GldfContainerWriter();
// 5) Validate GLDF Container
IGldfValidator validator = new GldfValidator();

// 6) Parse GLDF with resolved references
IGldfParser parser = new GldfParser();

// 7) Serialize Meta-Information XML
IMetaInfoSerializer serializer = new MetaInfoSerializer();
```

---

## Questions, Issues & Contribution

Please use the discussion section for questions or create issues, when something seems to be wrong. PRs are welcome.
