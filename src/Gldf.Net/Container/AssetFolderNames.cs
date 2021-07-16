namespace Gldf.Net.Container
{
    /// <summary>
    ///     By definition the folder of Assets inside the ZIP archive must be the first part of
    ///     <see cref="Gldf.Net.Domain.Definition.Types.FileContentType" />
    /// </summary>
    public static class AssetFolderNames
    {
        public const string Spectrums = "spectrum";
        public const string Photometries = "ldc";
        public const string Sensors = "sensor";
        public const string Images = "image";
        public const string Symbols = "symbol";
        public const string Documents = "document";
        public const string Geometries = "geo";
        public const string Other = "other";
    }
}