using Microsoft.EntityFrameworkCore;
using Podium.Data.Primitives.Entities;

namespace Podium.Data
{
    public class PodiumDbContext : DbContext
    {
        public PodiumDbContext(DbContextOptions options) : base(options)

        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<PropertyDetails> PropertyDetails { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<LoanCalculation> LoanCalculations { get; set; }
    }
}