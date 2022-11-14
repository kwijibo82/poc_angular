using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_REST.Models;

namespace WebAPI_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsteroidsController : ControllerBase
    {
        private readonly AsteroidsContext _context;
        public AsteroidsController(AsteroidsContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetAsteroids")]
        public ActionResult<IEnumerable<Asteroids>> Get()
        {
            return _context.Asteroids.ToList();
        }

        [HttpGet("{id}", Name = "GetAsteroid")]
        public ActionResult<Asteroids> Get(int id)
        {
            var asteroid = _context.Asteroids.Find(id);
            if (asteroid == null)
            {
                return NotFound();
            }
            return asteroid;
        }

        [HttpPost(Name = "PostAsteroid")]
        public ActionResult<Asteroids> Post(Asteroids asteroid)
        {
            _context.Asteroids.Add(asteroid);
            _context.SaveChanges();
            return CreatedAtRoute("GetAsteroid", new { id = asteroid.Id }, asteroid);
        }

        [HttpPut("{id}", Name = "PutAsteroid")]
        public ActionResult<Asteroids> Put(int id, Asteroids asteroid)
        {
            if (id != asteroid.Id)
            {
                return BadRequest();
            }
            _context.Entry(asteroid).State = EntityState.Modified;
            _context.SaveChanges();
            return CreatedAtRoute("PostAsteroid", new { id = asteroid.Id }, asteroid);
        }

        [HttpDelete("{id}", Name = "DeleteAsteroid")]
        public ActionResult<Asteroids> Delete(int id)
        {
            var asteroid = _context.Asteroids.Find(id);
            if (asteroid == null)
            {
                return NotFound();
            }
            _context.Asteroids.Remove(asteroid);
            _context.SaveChanges();
            return asteroid;
        }
    }
}
