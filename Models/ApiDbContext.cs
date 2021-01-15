using Equals_Api.Models.EntityModel.CardLayouts;
using Equals_Api.Models.EntityModel.DeliveryPeriodicitys;
using Microsoft.EntityFrameworkCore;

namespace Equals_Api.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<CardLayout> CardLayouts { get; set; }
        public DbSet<DeliveryPeriodicity> DeliveryPeriodicitys { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardLayout>().Map();
            modelBuilder.Entity<DeliveryPeriodicity>().Map();
        }
    }
}
