using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ClientPageServer.PL.Entities;

namespace ClientPageServer.PL.EF
{
    public class WeaponsPropertyConfig : IEntityTypeConfiguration<WeaponsProperty>
    {
        public void Configure(EntityTypeBuilder<WeaponsProperty> builder)
        {
            builder.ToTable("weapons_properties").HasKey(wp => wp.id);
            builder.Property(wp => wp.idWeaponsItem).HasColumnName("FK_IdWeaponsItem");
            builder.HasIndex(wp => wp.idWeaponsItem).IsUnique().HasDatabaseName("IX_WeaponsProperty_idWeaponsItem");
        }
    }
}
