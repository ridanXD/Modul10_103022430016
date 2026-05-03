using Microsoft.AspNetCore.Mvc;
using Modul10_103022430016.Models;

namespace Modul10_103022430016.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilmController : ControllerBase    
    {
        private static List<Film> films = new List<Film>
        {
            new Film { Judul = "Inception", Sutradara = "Christopher Nolan", Tahun = "2010", Genre = "Sci-Fi", Rating = "9.0" },
            new Film { Judul = "Interstellar", Sutradara = "Christopher Nolan", Tahun = "2014", Genre = "Sci-Fi", Rating = "8.7" },
            new Film { Judul = "Parasite", Sutradara = "Bong Joon-ho", Tahun = "2019", Genre = "Thriller", Rating = "8.6" }
        };

        [HttpGet]
        public ActionResult<List<Film>> GetAll()
        {
            return films;
        }

        [HttpGet("{index}")]
        public ActionResult<Film> GetByIndex(int index)
        {
            if (index < 0 || index >= films.Count)
                return NotFound();

            return films[index];
        }

        [HttpPost]
        public ActionResult Post([FromBody] Film newFilm)
        {
            films.Add(newFilm);
            return Ok(newFilm);
        }

        [HttpDelete("{index}")]
        public ActionResult Delete(int index)
        {
            if (index < 0 || index >= films.Count)
                return NotFound();

            films.RemoveAt(index);
            return Ok();
        }
    }
}