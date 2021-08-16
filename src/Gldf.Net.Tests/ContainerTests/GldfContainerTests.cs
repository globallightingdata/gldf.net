﻿using FluentAssertions;
using Gldf.Net.Container;
using Gldf.Net.Domain;
using Gldf.Net.Domain.Definition.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Gldf.Net.Tests.ContainerTests
{
    [TestFixture]
    public class GldfContainerTests
    {
        public delegate List<ContainerFile> ListSelector(GldfContainer container);

        [Test]
        public void Ctor_ShouldInitialize_AllProperties()
        {
            var gldfContainer = new GldfContainer();

            gldfContainer.Product.Should().NotBeNull();
            gldfContainer.Assets.All.Should().HaveCount(0);
            gldfContainer.Signature.Should().BeEmpty();
        }

        [Test]
        public void Ctor_ShouldSet_Root()
        {
            var root = new Root();
            var gldfContainer = new GldfContainer(root);

            gldfContainer.Product.Should().BeSameAs(root);
            gldfContainer.Assets.All.Should().HaveCount(0);
            gldfContainer.Signature.Should().BeEmpty();
        }

        [Test]
        public void Ctor_ShouldSet_RootAndAssets()
        {
            var root = new Root();
            var assets = new GldfAssets();
            var gldfContainer = new GldfContainer(root, assets);

            gldfContainer.Product.Should().BeSameAs(root);
            gldfContainer.Assets.Should().BeSameAs(assets);
            gldfContainer.Signature.Should().BeEmpty();
        }

        [Test]
        public void Ctor_ShouldSet_RootAndSignature()
        {
            var root = new Root();
            const string signature = "signature";
            var gldfContainer = new GldfContainer(root, signature);

            gldfContainer.Product.Should().BeSameAs(root);
            gldfContainer.Assets.All.Should().HaveCount(0);
            gldfContainer.Signature.Should().BeSameAs(signature);
        }

        [Test]
        public void Ctor_ShouldSet_RootSignatureAndAssets()
        {
            var root = new Root();
            var assets = new GldfAssets();
            const string signature = "signature";
            var gldfContainer = new GldfContainer(root, assets, signature);

            gldfContainer.Product.Should().BeSameAs(root);
            gldfContainer.Assets.Should().BeSameAs(assets);
            gldfContainer.Signature.Should().BeSameAs(signature);
        }

        [TestCaseSource(nameof(TestData))]
        public void AddAssetFile_ShouldAdd_ToExpectedCollection(ListSelector listSelector, FileContentType type)
        {
            const string fileName = "file";
            var fileContent = new byte[1];
            var gldfContainer = new GldfContainer();

            gldfContainer.AddAssetFile(type, fileName, fileContent);

            listSelector(gldfContainer).Should().ContainEquivalentOf(new ContainerFile(fileName, fileContent));
        }

        [TestCaseSource(nameof(TestData))]
        public void AddAssetFile_ShouldThrow_When_FileName_IsNull(ListSelector _, FileContentType type)
        {
            var gldfContainer = new GldfContainer();
            Action act = () => gldfContainer.AddAssetFile(type, null, new byte[1]);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestCaseSource(nameof(TestData))]
        public void AddAssetFile_ShouldThrow_When_FileContent_IsNull(ListSelector _, FileContentType type)
        {
            var gldfContainer = new GldfContainer();
            Action act = () => gldfContainer.AddAssetFile(type, "fileName", null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void AddAssetFile_ShouldThrow_When_InvalidFileContentType()
        {
            var gldfContainer = new GldfContainer();
            Action act = () => gldfContainer.AddAssetFile((FileContentType)int.MaxValue, "fileName", null);

            act.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage("Specified argument was out of the range*");
        }

        public static List<TestCaseData> TestData => new()
        {
            new TestCaseData(new ListSelector(container => container.Assets.Geometries), FileContentType.GeoL3d),
            new TestCaseData(new ListSelector(container => container.Assets.Geometries), FileContentType.GeoM3d),
            new TestCaseData(new ListSelector(container => container.Assets.Geometries), FileContentType.GeoR3d),
            new TestCaseData(new ListSelector(container => container.Assets.Images), FileContentType.ImageSvg),
            new TestCaseData(new ListSelector(container => container.Assets.Images), FileContentType.ImagePng),
            new TestCaseData(new ListSelector(container => container.Assets.Images), FileContentType.ImageJpg),
            new TestCaseData(new ListSelector(container => container.Assets.Documents), FileContentType.DocPdf),
            new TestCaseData(new ListSelector(container => container.Assets.Photometries), FileContentType.LdcIesXml),
            new TestCaseData(new ListSelector(container => container.Assets.Photometries), FileContentType.LdcEulumdat),
            new TestCaseData(new ListSelector(container => container.Assets.Photometries), FileContentType.LdcIes),
            new TestCaseData(new ListSelector(container => container.Assets.Other), FileContentType.Other),
            new TestCaseData(new ListSelector(container => container.Assets.Sensors), FileContentType.SensorSensXml),
            new TestCaseData(new ListSelector(container => container.Assets.Sensors), FileContentType.SensorSensLdt),
            new TestCaseData(new ListSelector(container => container.Assets.Symbols), FileContentType.SymbolSvg),
            new TestCaseData(new ListSelector(container => container.Assets.Symbols), FileContentType.SymbolDxf),
            new TestCaseData(new ListSelector(container => container.Assets.Spectrums), FileContentType.SpectrumText)
        };
    }
}