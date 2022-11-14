using Microsoft.EntityFrameworkCore;


namespace WebAPI_REST.Models
{
    public class LlibreContext : DbContext
    {
        public LlibreContext(DbContextOptions<LlibreContext> options)
            : base(options)
        {

        }
        // DbSet tb és com un ArrayList
        public DbSet<Llibre> Llibres { get; set; } = null;
    }
}
