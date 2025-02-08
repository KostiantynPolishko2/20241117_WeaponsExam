using Microsoft.EntityFrameworkCore;
using ClientPageServer.PL.Entities;

namespace ClientPageServer.PL.EF
{
    public class WeaponsItemsContext : DbContext
    {
        public DbSet<WeaponsItem> weaponsItems { get; set; } = null!;
        public DbSet<WeaponsProperty> weaponsProperties { get; set; } = null!;
        public DbSet<WeaponsImage> weaponsImages { get; set; } = null!;

        public WeaponsItemsContext(DbContextOptions<WeaponsItemsContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WeaponsItemConfig());
            modelBuilder.ApplyConfiguration(new WeaponsPropertyConfig());
            modelBuilder.ApplyConfiguration(new WeaponsImageConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
