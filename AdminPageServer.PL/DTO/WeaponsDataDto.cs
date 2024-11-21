using AdminPageServer.PL.Entities;

namespace AdminPageServer.PL.DTO
{
    public class WeaponsDataDto
    {
        public WeaponsItem weaponsItem { get; set; } = null!;
        public WeaponsProperty weaponsProperty { get; set; } = null!;
        public WeaponsImage weaponsImage { get; set; } = null!;

    }
}
