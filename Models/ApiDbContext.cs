using Equals_Api.Models.EntityModel.CardLayouts;
using Microsoft.EntityFrameworkCore;

namespace pagcerto.prepaidCard.api.Models
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<CardLayout> CardLayouts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardLayout>().Map();
        }
    }
}
