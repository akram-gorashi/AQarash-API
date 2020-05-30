using Al_Delal.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Al_Delal.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().Property(t => t.Id).ValueGeneratedOnAdd(); // Auto-increment
            modelBuilder.Entity<Vehicle>().Property(t => t.Id).ValueGeneratedOnAdd(); // Auto-increment


        }
    }
}