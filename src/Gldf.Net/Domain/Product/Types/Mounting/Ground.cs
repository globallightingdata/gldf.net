namespace Gldf.Net.Domain.Product.Types.Mounting
{
    public class Ground
    {
        public PoleTop PoleTop { get; set; }

        public PoleIntegrated PoleIntegrated { get; set; }

        public FreeStanding FreeStanding { get; set; }

        public SurfaceMounted SurfaceMounted { get; set; }

        public Recessed Recessed { get; set; }
    }
}