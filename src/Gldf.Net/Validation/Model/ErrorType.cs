namespace Gldf.Net.Validation.Model;

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