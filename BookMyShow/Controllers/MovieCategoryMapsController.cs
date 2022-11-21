using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookMyShow.Data;
using BookMyShow.Models;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCategoryMapsController : ControllerBase
    {
        private readonly BookMyShowContext _context;

        public MovieCategoryMapsController(BookMyShowContext context)
        {
            _context = context;
        }

        // GET: api/MovieCategoryMaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieCategoryMap>>> GetMovieCategoryMaps()
        {
            return await _context.MovieCategoryMaps.ToListAsync();
        }

        // GET: api/MovieCategoryMaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieCategoryMap>> GetMovieCategoryMap(int id)
        {
            var movieCategoryMap = await _context.MovieCategoryMaps.FindAsync(id);

            if (movieCategoryMap == null)
            {
                return NotFound();
            }

            return movieCategoryMap;
        }

        // PUT: api/MovieCategoryMaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieCategoryMap(int id, MovieCategoryMap movieCategoryMap)
        {
            if (id != movieCategoryMap.Id)
            {
                return BadRequest();
            }

            _context.Entry(movieCategoryMap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieCategoryMapExists(id))
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

        // POST: api/MovieCategoryMaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MovieCategoryMap>> PostMovieCategoryMap(MovieCategoryMap movieCategoryMap)
        {
            _context.MovieCategoryMaps.Add(movieCategoryMap);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MovieCategoryMapExists(movieCategoryMap.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMovieCategoryMap", new { id = movieCategoryMap.Id }, movieCategoryMap);
        }

        // DELETE: api/MovieCategoryMaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieCategoryMap(int id)
        {
            var movieCategoryMap = await _context.MovieCategoryMaps.FindAsync(id);
            if (movieCategoryMap == null)
            {
                return NotFound();
            }

            _context.MovieCategoryMaps.Remove(movieCategoryMap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MovieCategoryMapExists(int id)
        {
            return _context.MovieCategoryMaps.Any(e => e.Id == id);
        }
    }
}
