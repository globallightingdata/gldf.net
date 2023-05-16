using Gldf.Net.Domain.Typed.Definition;
using Gldf.Net.Domain.Typed.Definition.Types;
using Gldf.Net.Domain.Xml.Product;
using Gldf.Net.Domain.Xml.Product.Types;
using Gldf.Net.Parser.DataFlow;
using Gldf.Net.Parser.Extensions;
using Gldf.Net.Parser.Extensions.Descriptive;
using System.Collections.Generic;
using System.Linq;

namespace Gldf.Net.Parser;

internal class GlobalProductDataTransform : TransformBase
{
    public static ParserDto Map(ParserDto parserDto)
    {
        return ExecuteSafe(() =>
        {
            var product = parserDto.Container.Product.ProductDefinitions.ProductMetaData;
            var files = parserDto.GeneralDefinitions.Files;
            parserDto.ProductDefinitions.ProductMetaData = MapProduct(product, files);
            return parserDto;
        }, parserDto);
    }

    private static ProductMetaDataTyped MapProduct(ProductMetaData productMetaData, ICollection<GldfFileTyped> files) =>
        new()
        {
            UniqueProductId = productMetaData.UniqueProductId,
            ProductNumber = productMetaData.ProductNumber?.ToTypedArray(),
            Name = productMetaData.Name?.ToTypedArray(),
            Description = productMetaData.Description?.ToTypedArray(),
            TenderText = productMetaData.TenderText?.ToTypedArray(),
            ProductSeries = productMetaData.ProductSeries?.ToTypedArray(files),
            Pictures = files.ToImageTypedArray(productMetaData.Pictures),
            Maintenance = MapMaintenance(productMetaData.Maintenance),
            DescriptiveAttributes = productMetaData.DescriptiveAttributes?.ToTyped()
        };

    private static LuminaireMaintenanceTyped MapMaintenance(LuminaireMaintenance maintenance)
    {
        if (maintenance == null) return null;
        return new LuminaireMaintenanceTyped
        {
            Cie97LuminaireType = maintenance.Cie97LuminaireType,
            CieMaintenanceFactors = MapMaintenanceFactors(maintenance.CieMaintenanceFactors),
            IesLightLossFactors = MapLightLossFactors(maintenance.IesLightLossFactors),
            JiegMaintenanceFactors = MapJiegMaintenanceFactors(maintenance.JiegMaintenanceFactors)
        };
    }

    private static CieMaintenanceFactorTyped[] MapMaintenanceFactors(IEnumerable<CieMaintenanceFactor> factors) =>
        factors?.Select(factor => new CieMaintenanceFactorTyped
        {
            Years = factor.Years,
            RoomCondition = factor.RoomCondition,
            Factor = factor.Factor
        }).ToArray();

    private static IesDirtDepreciationTyped[] MapLightLossFactors(IEnumerable<IesDirtDepreciation> factors) =>
        factors?.Select(factor => new IesDirtDepreciationTyped
        {
            Years = factor.Years,
            RoomCondition = factor.RoomCondition,
            Factor = factor.Factor
        }).ToArray();

    private static JiegMaintenanceFactorTyped[] MapJiegMaintenanceFactors(IEnumerable<JiegMaintenanceFactor> factors) =>
        factors?.Select(factor => new JiegMaintenanceFactorTyped
        {
            Years = factor.Years,
            RoomCondition = factor.RoomCondition,
            Factor = factor.Factor
        }).ToArray();
}