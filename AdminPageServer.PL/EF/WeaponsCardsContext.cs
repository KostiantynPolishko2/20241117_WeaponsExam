using Microsoft.EntityFrameworkCore;
using AdminPageServer.PL.Entities;

namespace AdminPageServer.PL.EF
{
    public class WeaponsCardsContext : DbContext
    {
        public DbSet<WeaponsItem> weaponsItems { get; set; } = null!;
        public DbSet<WeaponsProperty> weaponsProperties { get; set; } = null!;
        public DbSet<WeaponsImage> weaponsImages { get; set; } = null!;

        public WeaponsCardsContext(DbContextOptions<WeaponsCardsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WeaponsItemConfig());
            modelBuilder.ApplyConfiguration(new WeaponsPropertyConfig());
            modelBuilder.ApplyConfiguration(new WeaponsImageConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
