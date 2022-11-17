using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_REST.Models;

namespace WebAPI_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroesController : ControllerBase
    {
        private readonly HeroesContext _context;

        public HeroesController(HeroesContext context)
        {
            _context = context;
        }
        [HttpGet(Name = "GetHeros")]
        public ActionResult<IEnumerable<Heroes>> Get()
        {
            return _context.Heroes.ToList();
        }

        [HttpGet("{id}", Name = "GetHero")]
        public ActionResult<Heroes> Get(int id)
        {
            var hero = _context.Heroes.Find(id);
            if (hero == null)
            {
                return NotFound();
            }
            return hero;
        }

        [HttpPost(Name = "PostHeros")]
        public ActionResult<Heroes> Post(Heroes hero)
        {
            _context.Heroes.Add(hero);
            _context.SaveChanges();
            return CreatedAtRoute("GetHeros", new { id = hero.Id }, hero);
        }

        [HttpPut("{id}", Name = "PutHeros")]
        public ActionResult<Heroes> Put(int id, Heroes hero)
        {
            if (id != hero.Id)
            {
                return BadRequest();
            }
            _context.Entry(hero).State = EntityState.Modified;
            _context.SaveChanges();
            return CreatedAtRoute("PostHeros", new { id = hero.Id }, hero);
        }

        [HttpDelete("{id}", Name = "DeleteHeros")]
        public ActionResult<Heroes> Delete(int id)
        {
            var hero = _context.Heroes.Find(id);
            if (hero == null)
            {
                return NotFound();
            }
            _context.Heroes.Remove(hero);
            _context.SaveChanges();
            return hero;
        }
    }
}
