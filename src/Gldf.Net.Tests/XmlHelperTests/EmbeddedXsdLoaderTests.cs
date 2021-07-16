﻿using FluentAssertions;
using Gldf.Net.Domain;
using Gldf.Net.Domain.Head.Types;
using Gldf.Net.Exceptions;
using Gldf.Net.XmlHelper;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gldf.Net.Tests.XmlHelperTests
{
    [TestFixture]
    public class EmbeddedXsdLoaderTests
    {
        [Test]
        public async Task LoadXsd_Should_BeEquivalentTo_XsdStoredOnGldfIo()
        {
            var xsdUrl = new Root().SchemaLocation;

            var githubXsd = await new HttpClient().GetStringAsync(xsdUrl);
            var embeddedXsd = EmbeddedXsdLoader.LoadXsd(FormatVersion.V09);

            embeddedXsd.Should().BeEquivalentTo(githubXsd);
        }

        [Test]
        public void LoadXsd_Should_Throw_When_UnknownFormatVersion()
        {
            var invalidFormatVersion = (FormatVersion) int.MaxValue;

            Action act = () => EmbeddedXsdLoader.LoadXsd(invalidFormatVersion);

            act.Should().Throw<GldfException>().WithMessage("Failed to get embedded XSD*");
        }
    }
}