using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookMyShow.Data;
using BookMyShow.Models;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieLangMapsController : ControllerBase
    {
        private readonly BookMyShowContext _context;

        public MovieLangMapsController(BookMyShowContext context)
        {
            _context = context;
        }

        // GET: api/MovieLangMaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieLangMap>>> GetMovieLangMaps()
        {
            return await _context.MovieLangMaps.ToListAsync();
        }

        // GET: api/MovieLangMaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieLangMap>> GetMovieLangMap(int id)
        {
            var movieLangMap = await _context.MovieLangMaps.FindAsync(id);

            if (movieLangMap == null)
            {
                return NotFound();
            }

            return movieLangMap;
        }

        // PUT: api/MovieLangMaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieLangMap(int id, MovieLangMap movieLangMap)
        {
            if (id != movieLangMap.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieLangMap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieLangMapExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MovieLangMaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieLangMap>> PostMovieLangMap(MovieLangMap movieLangMap)
        {
            _context.MovieLangMaps.Add(movieLangMap);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovieLangMapExists(movieLangMap.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMovieLangMap", new { id = movieLangMap.Id }, movieLangMap);
        }

        // DELETE: api/MovieLangMaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieLangMap(int id)
        {
            var movieLangMap = await _context.MovieLangMaps.FindAsync(id);
            if (movieLangMap == null)
            {
                return NotFound();
            }

            _context.MovieLangMaps.Remove(movieLangMap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieLangMapExists(int id)
        {
            return _context.MovieLangMaps.Any(e => e.Id == id);
        }
    }
}
