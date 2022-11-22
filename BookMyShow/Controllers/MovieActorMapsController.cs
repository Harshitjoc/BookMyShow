using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookMyShow.Data;
using BookMyShow.Models;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieActorMapsController : ControllerBase
    {
        private readonly BookMyShowContext _context;

        public MovieActorMapsController(BookMyShowContext context)
        {
            _context = context;
        }

        // GET: api/MovieActorMaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieActorMap>>> GetMovieActorMaps()
        {
            return await _context.MovieActorMaps.ToListAsync();
        }

        // GET: api/MovieActorMaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieActorMap>> GetMovieActorMap(int id)
        {
            var movieActorMap = await _context.MovieActorMaps.FindAsync(id);

            if (movieActorMap == null)
            {
                return NotFound();
            }

            return movieActorMap;
        }

        // PUT: api/MovieActorMaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieActorMap(int id, MovieActorMap movieActorMap)
        {
            if (id != movieActorMap.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieActorMap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieActorMapExists(id))
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

        // POST: api/MovieActorMaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieActorMap>> PostMovieActorMap(MovieActorMap movieActorMap)
        {
            _context.MovieActorMaps.Add(movieActorMap);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovieActorMapExists(movieActorMap.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMovieActorMap", new { id = movieActorMap.Id }, movieActorMap);
        }

        // DELETE: api/MovieActorMaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieActorMap(int id)
        {
            var movieActorMap = await _context.MovieActorMaps.FindAsync(id);
            if (movieActorMap == null)
            {
                return NotFound();
            }

            _context.MovieActorMaps.Remove(movieActorMap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieActorMapExists(int id)
        {
            return _context.MovieActorMaps.Any(e => e.Id == id);
        }
    }
}
