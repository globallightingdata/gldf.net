using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Head.Types;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Parser.DataFlow;
using Gldf.Net.Parser.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser;

internal class HeaderTransform : TransformBase
{
    public static ParserDto Map(ParserDto parserDto)
    {
        return ExecuteSafe(() =>
        {
            MapHeader(parserDto.Header, parserDto.Container.Product.Header);
            return parserDto;
        }, parserDto);
    }

    private static void MapHeader(HeaderTyped headerTyped, Header header)
    {
        headerTyped.Manufacturer = header.Manufacturer;
        headerTyped.FormatVersion = MapFormatVersion(header.FormatVersion);
        headerTyped.CreatedWithApplication = header.CreatedWithApplication;
        headerTyped.GldfCreationTimeCode = header.GldfCreationTimeCode;
        headerTyped.UniqueGldfId = header.UniqueGldfId;
        headerTyped.ProductDataTimeCode = header.ProductDataTimeCodeSpecified ? header.ProductDataTimeCode : null;
        headerTyped.DefaultLanguage = header.DefaultLanguage;
        headerTyped.ManufacturerLogo = MapManufacturerLogo(header.ManufacturerLogo);
        headerTyped.LicenseKeys = MapLicenseKeys(header.LicenseKeys);
        headerTyped.ReluxMemberId = header.ReluxMemberId;
        headerTyped.DIALuxMemberId = header.DIALuxMemberId;
        headerTyped.Author = header.Author;
        headerTyped.Contact = MapContact(header.Contact);
    }

    private static FormatVersionTyped MapFormatVersion(FormatVersion formatVersion) => new()
    {
        Major = formatVersion.Major,
        Minor = formatVersion.Minor,
        PreRelease = formatVersion.PreReleaseSpecified ? formatVersion.PreRelease : null
    };

    private static LicenseKeyTyped[] MapLicenseKeys(IEnumerable<LicenseKey> licenseKeys) =>
        licenseKeys?.Select(key => new LicenseKeyTyped
        {
            Application = key.Application,
            Key = key.Key
        }).ToArray();

    private static ManufacturerLogoTyped MapManufacturerLogo(ManufacturerLogo manufacturerLogo) =>
        manufacturerLogo != null
            ? new ManufacturerLogoTyped
            {
                FileId = manufacturerLogo.FileId
            }
            : null;

    private static AddressTyped[] MapContact(IEnumerable<Address> addresses) =>
        addresses?.Select(address =>
            new AddressTyped
            {
                FirstName = address.FirstName,
                Name = address.Name,
                Street = address.Street,
                Number = address.Number,
                ZipCode = address.ZipCode,
                City = address.City,
                Country = address.Country,
                Phone = address.Phone,
                EMailAddresses = MapEmails(address.EMailAddresses),
                Websites = address.Websites?.ToTypedArray(),
                AdditionalInfo = address.AdditionalInfo
            }).ToArray();

    private static EMailTyped[] MapEmails(IEnumerable<EMail> eMails) =>
        eMails?.Select(eMail =>
            new EMailTyped
            {
                Mailto = eMail.Mailto,
                PlainText = eMail.PlainText
            }).ToArray();
}