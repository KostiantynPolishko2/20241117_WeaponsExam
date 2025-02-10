using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AdminPageServer.PL.Entities;

namespace AdminPageServer.PL.EF
{
    public class WeaponsItemConfig : IEntityTypeConfiguration<WeaponsItem>
    {
        public void Configure(EntityTypeBuilder<WeaponsItem> builder)
        {
            builder.ToTable("weapons_items").HasKey(wi => wi.id);
            builder.HasOne(wi => wi.weaponsProperty).WithOne(wp => wp.weaponsItem).HasForeignKey<WeaponsProperty>(wp => wp.idWeaponsItem).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(wi => wi.weaponsImage).WithOne(wm => wm.weaponsItem).HasForeignKey<WeaponsImage>(wm => wm.idWeaponsItem).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
