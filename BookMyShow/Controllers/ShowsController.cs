using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookMyShow.Data;
using BookMyShow.Models;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private readonly BookMyShowContext _context;

        public ShowsController(BookMyShowContext context)
        {
            _context = context;
        }

        // GET: api/Shows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Show>>> GetShows()
        {
            return await _context.Shows.ToListAsync();
        }

        // GET: api/Shows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Show>> GetShow(int id)
        {
            var show = await _context.Shows.FindAsync(id);

            if (show == null)
            {
                return NotFound();
            }

            return show;
        }

        // PUT: api/Shows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShow(int id, Show show)
        {
            if (id != show.Id)
            {
                return BadRequest();
            }

            _context.Entry(show).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShowExists(id))
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

        // POST: api/Shows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Show>> PostShow(Show show)
        {
            _context.Shows.Add(show);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ShowExists(show.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetShow", new { id = show.Id }, show);
        }

        // DELETE: api/Shows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShow(int id)
        {
            var show = await _context.Shows.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }

            _context.Shows.Remove(show);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShowExists(int id)
        {
            return _context.Shows.Any(e => e.Id == id);
        }
    }
}
