using Gldf.Net.Domain.Typed.Head;
using Gldf.Net.Domain.Typed.Head.Types;
using Gldf.Net.Domain.Xml.Head;
using Gldf.Net.Domain.Xml.Head.Types;
using Gldf.Net.Parser.DataFlow;
using Gldf.Net.Parser.Extensions;
using System;
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
        headerTyped.Author = header.Author;
        headerTyped.Manufacturer = header.Manufacturer;
        headerTyped.CreationTimeCode = header.CreationTimeCode;
        headerTyped.CreatedWithApplication = header.CreatedWithApplication;
        headerTyped.FormatVersion = MapFormatVersion(header.FormatVersion);
        headerTyped.DefaultLanguage = header.DefaultLanguage;
        headerTyped.LicenseKeys = MapLicenseKeys(header.LicenseKeys);
        headerTyped.ReluxMemberId = header.ReluxMemberId;
        headerTyped.DIALuxMemberId = header.DIALuxMemberId;
        headerTyped.Contact = MapContact(header.Contact);
    }

    private static FormatVersionTyped MapFormatVersion(FormatVersion formatVersion) =>
        formatVersion switch
        {
            FormatVersion.V100 => FormatVersionTyped.V100,
            _ => throw new ArgumentOutOfRangeException(nameof(formatVersion), formatVersion, null)
        };

    private static LicenseKeyTyped[] MapLicenseKeys(IEnumerable<LicenseKey> licenseKeys) =>
        licenseKeys?.Select(key => new LicenseKeyTyped
        {
            Application = key.Application,
            Key = key.Key
        }).ToArray();

    private static AddressTyped[] MapContact(IEnumerable<Address> adresses) =>
        adresses?.Select(adress =>
            new AddressTyped
            {
                FirstName = adress.FirstName,
                Name = adress.Name,
                Street = adress.Street,
                Number = adress.Number,
                ZipCode = adress.ZipCode,
                City = adress.City,
                Country = adress.Country,
                Phone = adress.Phone,
                EMailAddresses = MapEmails(adress.EMailAddresses),
                Websites = adress.Websites?.ToTypedArray(),
                AdditionalInfo = adress.AdditionalInfo
            }).ToArray();

    private static EMailTyped[] MapEmails(IEnumerable<EMail> eMails) =>
        eMails?.Select(eMail =>
            new EMailTyped
            {
                Mailto = eMail.Mailto,
                PlainText = eMail.PlainText
            }).ToArray();
}