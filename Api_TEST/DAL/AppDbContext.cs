using Api_TEST.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api_TEST.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Color> colors { get; set; }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Car> cars { get; set; }
    }
}
