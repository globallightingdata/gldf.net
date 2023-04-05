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