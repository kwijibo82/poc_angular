using Microsoft.EntityFrameworkCore;

namespace WebAPI_REST.Models
{
    // : és el extends en JAVA (herència)
    public class AsteroidsContext : DbContext
    {
        // ctor + TAB
        // ArrayList<tipus_objecte> nom_variable = DbContextOptions<tipus_objecte> nom_variable
        public AsteroidsContext(DbContextOptions<AsteroidsContext> options)
            : base(options) // Simil a super()
        {

        }
        // DbSet tb és com un ArrayList
        public DbSet<Asteroids> Asteroids { get; set; } = null;
    }
}
