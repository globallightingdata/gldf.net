using Gldf.Net.Abstract;
using Gldf.Net.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Gldf.Net.Validation
{
    internal class ZipArchiveValidator
    {
        private readonly ZipArchiveReader _zipArchiveReader;
        private readonly List<IZipContaineraValidationRule> _zipValidationRules;
        private readonly List<IArchiveValidationRule> _archiveValidationRules;

        public ZipArchiveValidator()
        {
            _zipValidationRules = GetValidationRules<IZipContaineraValidationRule>()
                .OrderBy(rule => rule.Priority).ToList();
            _archiveValidationRules = GetValidationRules<IArchiveValidationRule>()
                .OrderBy(rule => rule.Priority).ToList();
            _zipArchiveReader = new ZipArchiveReader();
        }

        public IEnumerable<ValidationHint> Validate(GldfArchive archive)
        {
            try
            {
                return _archiveValidationRules.SelectMany(rule => rule.Validate(archive));
            }
            catch (Exception e)
            {
                return new[] {new ValidationHint(SeverityType.Error, e.Message, ErrorType.GenericError)};
            }
        }

        public IEnumerable<ValidationHint> Validate(string filePath)
        {
            try
            {
                var zipValidationHints = _zipValidationRules.SelectMany(rule => rule.Validate(filePath)).ToList();
                return zipValidationHints.Any(hint => hint.Severity == SeverityType.Error) 
                    ? zipValidationHints 
                    : zipValidationHints.Union(ValidateArchieve(filePath));
            }
            catch (Exception e)
            {
                return new[] {new ValidationHint(SeverityType.Error, e.Message, ErrorType.GenericError)};
            }
        }

        internal IEnumerable<T> GetValidationRules<T>()
        {
            static bool IsOfTypeClass(Type type)
                => typeof(T).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract;
            return Assembly.GetAssembly(typeof(ZipArchiveValidator))
                .GetTypes().Where(IsOfTypeClass)
                .Select(type => (T) Activator.CreateInstance(type));
        }

        private IEnumerable<ValidationHint> ValidateArchieve(string filePath)
        {
            const AssetLoadBehaviour assetLoadBehaviour = AssetLoadBehaviour.FileNamesOnly;
            var containerLoadSettings = new ContainerLoadSettings {AssetLoadBehaviour = assetLoadBehaviour};
            var gldfArchive = _zipArchiveReader.ReadArchive(filePath, containerLoadSettings);
            return _archiveValidationRules.SelectMany(rule => rule.Validate(gldfArchive));
        }
    }
}