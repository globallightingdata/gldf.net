namespace Gldf.Net.Validation
{
    public enum ErrorType
    {
        None,
        GenericError,
        InvalidZipFile,
        ProductXmlNotFound,
        XmlSchema,
        NonDeserialisableRoot,
        ToLargeFiles,
        MissingContainerAssets,
        OrphanedContainerAssets
    }
}