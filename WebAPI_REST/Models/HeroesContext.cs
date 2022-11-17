using Microsoft.EntityFrameworkCore;

namespace WebAPI_REST.Models
{
    public class HeroesContext : DbContext
    {
        public HeroesContext(DbContextOptions<HeroesContext> options)
            : base(options)
        {

        }

        public DbSet<Heroes> Heroes { get; set; } = null;
    }
}
