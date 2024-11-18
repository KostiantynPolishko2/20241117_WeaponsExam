using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using AdminPageServer.PL.Entities;

namespace AdminPageServer.PL.EF
{
    public class WeaponsImageConfig : IEntityTypeConfiguration<WeaponsImage>
    {
        public void Configure(EntityTypeBuilder<WeaponsImage> builder)
        {
            builder.ToTable("weapons_images").HasKey(wm => wm.id);
            builder.Property(wm => wm.idWeaponsItem).HasColumnName("FK_IdWeaponsItem");
            builder.HasIndex(wm => wm.idWeaponsItem).IsUnique().HasDatabaseName("IX_WeaponsImage_idWeaponsItem");
        }
    }
}
