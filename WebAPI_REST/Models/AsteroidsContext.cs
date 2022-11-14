using Microsoft.EntityFrameworkCore;

namespace WebAPI_REST.Models
{
    public class AsteroidsContext : DbContext
    {
        public AsteroidsContext(DbContextOptions<AsteroidsContext> options)
            : base(options)
        {
            
        }

        public DbSet<Asteroids> Asteroids { get; set; } = null;
    }
}
