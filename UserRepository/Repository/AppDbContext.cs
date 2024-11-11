using Microsoft.EntityFrameworkCore;
using Promomash.UserRepository.Entities;

namespace Promomash.UserRepository.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasData(InitialData.GetPreconfiguredCountries());
            modelBuilder.Entity<Province>().HasData(InitialData.GetPreconfiguredProvinces());
        }
    }
}