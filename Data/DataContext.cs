using Al_Delal.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Al_Delal.Api.Data
{
    public class DataContext :DbContext
    {
          public DataContext(DbContextOptions<DataContext>  options) : base (options) {}

        public DbSet<User> Users { get; set; }
    }
}