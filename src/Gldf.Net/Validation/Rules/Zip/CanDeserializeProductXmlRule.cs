using Gldf.Net.Abstract;
using Gldf.Net.Container;
using Gldf.Net.Exceptions;
using System;
using System.Collections.Generic;

namespace Gldf.Net.Validation.Rules.Zip
{
    internal class CanDeserializeProductXmlRule : IZipContaineraValidationRule
    {
        public int Priority => 40;

        private readonly GldfContainer _gldfContainer;

        public CanDeserializeProductXmlRule()
        {
            _gldfContainer = new GldfContainer();
        }

        public IEnumerable<ValidationHint> Validate(string filePath)
        {
            try
            {
                var loadRootOnlySettings = new ContainerLoadSettings
                {
                    ProductLoadBehaviour = ProductLoadBehaviour.Load,
                    AssetLoadBehaviour = AssetLoadBehaviour.Skip,
                    SignatureLoadBehaviour = SignatureLoadBehaviour.Skip
                };
                var archive = _gldfContainer.ReadFromFile(filePath, loadRootOnlySettings);
                return archive.Product != null
                    ? ValidationHint.Empty()
                    : ValidationHint.Error($"The product.xml in GLDF container '{filePath}' could not be " +
                                           "deserialised.", ErrorType.NonDeserialisableRoot);
            }
            catch (Exception e)
            {
                return ValidationHint.Error($"The product.xml in GLDF container '{filePath}' could " +
                                            "not be deserialised. Error: " +
                                            $"{e.FlattenMessage()}", ErrorType.NonDeserialisableRoot);
            }
        }
    }
}