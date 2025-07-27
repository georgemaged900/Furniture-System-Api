using Furniture_System_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Furniture_System_Api.Configuration.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                  : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<SubComponent> SubComponents { get; set; }

    }
}
