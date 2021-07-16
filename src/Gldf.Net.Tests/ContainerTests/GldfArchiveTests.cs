using FluentAssertions;
using Gldf.Net.Container;
using Gldf.Net.Domain;
using Gldf.Net.Domain.Definition.Types;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Gldf.Net.Tests.ContainerTests
{
    [TestFixture]
    public class GldfArchiveTests
    {
        public delegate List<ContainerFile> ListSelector(GldfArchive archive);

        [Test]
        public void Ctor_ShouldInitialize_AllProperties()
        {
            var gldfArchive = new GldfArchive();

            gldfArchive.Product.Should().NotBeNull();
            gldfArchive.Assets.All.Should().HaveCount(0);
            gldfArchive.Signature.Should().BeEmpty();
        }

        [Test]
        public void Ctor_ShouldSet_Root()
        {
            var root = new Root();
            var gldfArchive = new GldfArchive(root);

            gldfArchive.Product.Should().BeSameAs(root);
            gldfArchive.Assets.All.Should().HaveCount(0);
            gldfArchive.Signature.Should().BeEmpty();
        }

        [Test]
        public void Ctor_ShouldSet_RootAndAssets()
        {
            var root = new Root();
            var assets = new GldfAssets();
            var gldfArchive = new GldfArchive(root, assets);

            gldfArchive.Product.Should().BeSameAs(root);
            gldfArchive.Assets.Should().BeSameAs(assets);
            gldfArchive.Signature.Should().BeEmpty();
        }

        [Test]
        public void Ctor_ShouldSet_RootAndSignature()
        {
            var root = new Root();
            const string signature = "signature";
            var gldfArchive = new GldfArchive(root, signature);

            gldfArchive.Product.Should().BeSameAs(root);
            gldfArchive.Assets.All.Should().HaveCount(0);
            gldfArchive.Signature.Should().BeSameAs(signature);
        }

        [Test]
        public void Ctor_ShouldSet_RootSignatureAndAssets()
        {
            var root = new Root();
            var assets = new GldfAssets();
            const string signature = "signature";
            var gldfArchive = new GldfArchive(root, assets, signature);

            gldfArchive.Product.Should().BeSameAs(root);
            gldfArchive.Assets.Should().BeSameAs(assets);
            gldfArchive.Signature.Should().BeSameAs(signature);
        }

        [TestCaseSource(nameof(TestData))]
        public void AddAssetFile_ShouldAdd_ToExpectedCollection(ListSelector listSelector, FileContentType type)
        {
            const string fileName = "file";
            var fileContent = new byte[1];
            var gldfArchive = new GldfArchive();

            gldfArchive.AddAssetFile(type, fileName, fileContent);

            listSelector(gldfArchive).Should().ContainEquivalentOf(new ContainerFile(fileName, fileContent));
        }

        [TestCaseSource(nameof(TestData))]
        public void AddAssetFile_ShouldThrow_When_FileName_IsNull(ListSelector _, FileContentType type)
        {
            var gldfArchive = new GldfArchive();
            Action act = () => gldfArchive.AddAssetFile(type, null, new byte[1]);

            act.Should().Throw<ArgumentNullException>();
        }

        [TestCaseSource(nameof(TestData))]
        public void AddAssetFile_ShouldThrow_When_FileContent_IsNull(ListSelector _, FileContentType type)
        {
            var gldfArchive = new GldfArchive();
            Action act = () => gldfArchive.AddAssetFile(type, "fileName", null);

            act.Should().Throw<ArgumentNullException>();
        }

        [Test]
        public void AddAssetFile_ShouldThrow_When_InvalidFileContentType()
        {
            var gldfArchive = new GldfArchive();
            Action act = () => gldfArchive.AddAssetFile((FileContentType) int.MaxValue, "fileName", null);

            act.Should()
                .Throw<ArgumentOutOfRangeException>()
                .WithMessage("Specified argument was out of the range*");
        }

        public static List<TestCaseData> TestData => new()
        {
            new TestCaseData(new ListSelector(archive => archive.Assets.Geometries), FileContentType.GeoL3d),
            new TestCaseData(new ListSelector(archive => archive.Assets.Geometries), FileContentType.GeoM3d),
            new TestCaseData(new ListSelector(archive => archive.Assets.Geometries), FileContentType.GeoR3d),
            new TestCaseData(new ListSelector(archive => archive.Assets.Images), FileContentType.ImageSvg),
            new TestCaseData(new ListSelector(archive => archive.Assets.Images), FileContentType.ImagePng),
            new TestCaseData(new ListSelector(archive => archive.Assets.Images), FileContentType.ImageJpg),
            new TestCaseData(new ListSelector(archive => archive.Assets.Documents), FileContentType.DocPdf),
            new TestCaseData(new ListSelector(archive => archive.Assets.Photometries), FileContentType.LdcIesXml),
            new TestCaseData(new ListSelector(archive => archive.Assets.Photometries), FileContentType.LdcEulumdat),
            new TestCaseData(new ListSelector(archive => archive.Assets.Photometries), FileContentType.LdcIes),
            new TestCaseData(new ListSelector(archive => archive.Assets.Other), FileContentType.Other),
            new TestCaseData(new ListSelector(archive => archive.Assets.Sensors), FileContentType.SensorSensXml),
            new TestCaseData(new ListSelector(archive => archive.Assets.Sensors), FileContentType.SensorSensLdt),
            new TestCaseData(new ListSelector(archive => archive.Assets.Symbols), FileContentType.SymbolSvg),
            new TestCaseData(new ListSelector(archive => archive.Assets.Symbols), FileContentType.SymbolDxf),
            new TestCaseData(new ListSelector(archive => archive.Assets.Spectrums), FileContentType.SpectrumText)
        };
    }
}