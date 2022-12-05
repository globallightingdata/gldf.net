using Gldf.Net.Domain.Xml.Product.Types;

namespace Gldf.Net.Domain.Typed.Definition.Types
{
    public class LuminaireMaintenanceTyped
    {
        public Cie97LuminaireType? Cie97LuminaireType { get; set; }

        public CieMaintenanceFactorTyped[] CieMaintenanceFactors { get; set; }

        public IesDirtDepreciationTyped[] IesLightLossFactors { get; set; }

        public JiegMaintenanceFactorTyped[] JiegMaintenanceFactors { get; set; }
    }
}