namespace Gldf.Net.Validation;

public enum ErrorType
{
    None,
    GenericError,
    InvalidZip,
    ProductXmlNotFound,
    XmlSchema,
    NonDeserialisableRoot,
    TooLargeFiles,
    MissingContainerAssets,
    OrphanedContainerAssets
}