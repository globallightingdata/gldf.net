using Gldf.Net.Abstract;
using Gldf.Net.Container;
using System.Collections.Generic;

namespace Gldf.Net.Validation.Rules.Zip
{
    internal class IsValidZipContainerRule : IZipContaineraValidationRule
    {
        public int Priority => 10;

        private readonly ZipArchiveReader _zipArchiveReader;

        public IsValidZipContainerRule()
        {
            _zipArchiveReader = new ZipArchiveReader();
        }

        public IEnumerable<ValidationHint> Validate(string filePath)
        {
            return _zipArchiveReader.IsZipArchive(filePath)
                ? ValidationHint.Empty()
                : ValidationHint.Error($"The GLDF container '{filePath}' seems not to be a " +
                                       "valid ZIP file or can't be accessed", ErrorType.InvalidZipFile);
        }
    }
}