using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Exceptions;
using System;
using System.Collections.Generic;

namespace Gldf.Net.Validation.Rules.Zip
{
    internal class ContainsProductXmlRule : IZipContaineraValidationRule
    {
        public int Priority => 20;

        private readonly ZipArchiveReader _zipArchiveReader;

        public ContainsProductXmlRule()
        {
            _zipArchiveReader = new ZipArchiveReader();
        }

        public IEnumerable<ValidationHint> Validate(string filePath)
        {
            try
            {
                return _zipArchiveReader.ContainsRootXml(filePath)
                    ? ValidationHint.Empty()
                    : ValidationHint.Error($"The GLDF container '{filePath}' does not contain a " +
                                           "product.xml entry.", ErrorType.ProductXmlNotFound);
            }
            catch (Exception e)
            {
                return ValidationHint.Error($"The GLDF container '{filePath}' could not be validated " +
                                            "to contain a product.xml entry. " +
                                            $"Error: {e.FlattenMessage()}", ErrorType.ProductXmlNotFound);
            }
        }
    }
}