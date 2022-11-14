namespace WebAPI_REST.Models
{
    public class Asteroids
    {
        public int Id{ get; set; }

        public string? Name { get; set; }

        public bool? Near { get; set; }

        public DateTime NextTimeOnEarth { get; set; }
    }
}
