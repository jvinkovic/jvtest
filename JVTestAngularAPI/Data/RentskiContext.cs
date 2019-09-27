using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class RentskiContext : DbContext
    {
        public RentskiContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<RentModel> Rents { get; set; }

        public DbSet<SkiModel> Skis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
