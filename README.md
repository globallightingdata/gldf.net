# GLDF .NET library

![GLDF Logo](/img/logo.png)
## Intro

.NET Standard 2.0 library for the Global Lighting Data Format [GLDF](https://gldf.io)

Features

- Serialize and deserialize GLDF XML,100% format coverage
- Validate GLDF XML with the GLDF XmlSchema (XSD)
- Read and write .gldf container files, including all assets and signature file
- Validate .gldf container files
- No dependencies, small dll (<400kb)
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

#### Serialize GLDF domain POCOs to XML string

All models in the following examples are incomplete. For valid GLDF luminaires/sensors read the docs.

```CSharp
var serializer = new GldfXmlSerializer();
var root = new Root {Header = new Header {Author = "Github Example"}};
var xml = serializer.SerializeToXml(root);
```

#### Serialize GLDF domain POCOs to .xml file

```CSharp
var serializer = new GldfXmlSerializer();
var root = new Root {Header = new Header {Author = "Github Example"}};
serializer.SerializeToFile(root, @"c:\some\file\path\luminaire.xml");
```

#### Deserialize GLDF XML string to domain POCOs

```CSharp
var serializer = new GldfXmlSerializer();
var xml = @"<Root><Header><Author>Github Example</Author></Header></Root>";
Root root = serializer.DeserializeFromXml(xml);
```

#### Deserialize GLDF .xml file to domain POCOs

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
var gldfXmlValidator = new GldfXmlValidator();
var filePath = @"c:\some\file\path\luminaire.xml";
IEnumerable<ValidationHint> validationResult = gldfXmlValidator.ValidateXmlFile(filePath);

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
gldfXmlValidator.ValidateXmlFile(filePath);
```

---

### Container read/write

#### Write a .gldf container file

```CSharp
var gldfContainer = new GldfContainer();
var gldfArchive = new GldfArchive
{
    Product = new Root {Header = new Header {Author = "Github example"}},
    Assets = new GldfAssets(),
    Signature = "some checksum"
};
var filePath = @"c:\some\file\path\luminaire.gldf";
gldfContainer.WriteToFile(filePath, gldfArchive);
```

#### Read a .gldf container file

```CSharp
var gldfContainer = new GldfContainer();
var filePath = @"c:\some\file\path\luminaire.gldf";
GldfArchive container = gldfContainer.ReadFromFile(filePath);
Console.WriteLine($"Luminaire author: {container.Product.Header.Author}");
```

#### Extract a .gldf container content to a directory

```CSharp
var gldfContainer = new GldfContainer();
var sourceFilePath = @"c:\some\file\path\luminaire.gldf";
var targetFolder = @"c:\some\file\path\extractedContent\";
gldfContainer.ExtractToDirectory(sourceFilePath, targetFolder);
```

#### Create a .gldf container from content in a directory

```CSharp
var gldfContainer = new GldfContainer();
var sourceDirectory = @"c:\some\file\path\extractedContent\";
var targetFile = @"c:\some\file\path\luminaire.gldf";
gldfContainer.CreateFromDirectory(sourceDirectory, targetFile);
```

---

### Container Validation

#### Validate a GldfArchive domain POCO

```CSharp
var validator = new GldfContainerValidator();
var gldfArchive = new GldfArchive
{
    Product = new Root {Header = new Header {Author = "Github example"}},
    Assets = new GldfAssets(),
    Signature = "some checksum"
};
var validationResult = validator.Validate(gldfArchive);

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

---

## Questions, Issues & Contribution

Please use the discussion section for questions or create issues, when something seems to be wrong. PRs are welcome.
