using Microsoft.EntityFrameworkCore;

namespace Prodesp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Fabricantes> Fabricantes { get; set; }
    }
}
