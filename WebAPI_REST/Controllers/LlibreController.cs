using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_REST.Models;
namespace WebAPI_REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LlibreController : Controller
    {
        private readonly LlibreContext _context;
        public LlibreController(LlibreContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetLlibres")]
        public ActionResult<IEnumerable<Llibre>> Get()
        {
            return _context.Llibres.ToList();
        }

        [HttpGet("{id}", Name = "GetLlibre")]
        public ActionResult<Llibre> Get(int id)
        {
            var llibre = _context.Llibres.Find(id);
            if (llibre == null)
            {
                return NotFound();
            }
            return llibre;
        }

        [HttpPost(Name = "PostLlibre")]
        public ActionResult<Llibre> Post(Llibre llibre)
        {
            _context.Llibres.Add(llibre);
            _context.SaveChanges();
            return CreatedAtRoute("PostLlibre", new { id = llibre.Id }, llibre);
        }

        [HttpPut("{id}", Name = "PutLlibre")]
        public ActionResult<Llibre> Put(int id, Llibre llibre)
        {
            if (id != llibre.Id)
            {
                return BadRequest();
            }
            _context.Entry(llibre).State = EntityState.Modified;
            _context.SaveChanges();
            return CreatedAtRoute("PostLlibre", new { id = llibre.Id }, llibre);
        }

        [HttpDelete("{id}", Name = "DeleteLlibre")]
        public ActionResult<Llibre> Delete(int id)
        {
            var llibre = _context.Llibres.Find(id);
            if (llibre == null)
            {
                return NotFound();
            }
            _context.Llibres.Remove(llibre);
            _context.SaveChanges();
            return llibre;
        }
    }
}
