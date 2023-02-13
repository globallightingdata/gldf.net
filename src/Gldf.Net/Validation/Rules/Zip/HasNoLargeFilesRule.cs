using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Validation.Rules.Zip
{
    internal class HasNoLargeFilesRule : IZipArchiveValidationRule
    {
        public int Priority => 50;
        public const int LimitInBytes = 5 * 1024 * 1024;

        private readonly ZipArchiveReader _zipArchiveReader;

        public HasNoLargeFilesRule()
        {
            _zipArchiveReader = new ZipArchiveReader();
        }

        public IEnumerable<ValidationHint> Validate(string filePath)
        {
            try
            {
                var toLargeFiles = _zipArchiveReader.GetLargeFileNames(filePath, LimitInBytes).ToList();
                return toLargeFiles.Any()
                    ? ValidationHint.Warning("Large files found. It is recommended to limit the " +
                                             "maximum file size to 5MB each: " +
                                             $"{FlattenFileNames(toLargeFiles)}", ErrorType.TooLargeFiles)
                    : ValidationHint.Empty();
            }
            catch (Exception e)
            {
                return ValidationHint.Warning($"The GLDF container '{filePath}' could not be validated " +
                                              "to have no large Files. " +
                                              $"Error: {e.FlattenMessage()}", ErrorType.TooLargeFiles);
            }
        }

        private static string FlattenFileNames(IEnumerable<string> filesWithoutAssets)
        {
            return filesWithoutAssets.Aggregate(string.Empty, (result, fileName)
                => result == string.Empty ? $"{fileName}" : $"{result}, {fileName}");
        }
    }
}