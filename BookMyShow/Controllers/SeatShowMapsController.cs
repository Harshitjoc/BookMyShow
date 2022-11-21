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
    public class SeatShowMapsController : ControllerBase
    {
        private readonly BookMyShowContext _context;

        public SeatShowMapsController(BookMyShowContext context)
        {
            _context = context;
        }

        // GET: api/SeatShowMaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeatShowMap>>> GetSeatShowMaps()
        {
            return await _context.SeatShowMaps.ToListAsync();
        }

        // GET: api/SeatShowMaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeatShowMap>> GetSeatShowMap(int id)
        {
            var seatShowMap = await _context.SeatShowMaps.FindAsync(id);

            if (seatShowMap == null)
            {
                return NotFound();
            }

            return seatShowMap;
        }

        // PUT: api/SeatShowMaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeatShowMap(int id, SeatShowMap seatShowMap)
        {
            if (id != seatShowMap.Id)
            {
                return BadRequest();
            }

            _context.Entry(seatShowMap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatShowMapExists(id))
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

        // POST: api/SeatShowMaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SeatShowMap>> PostSeatShowMap(SeatShowMap seatShowMap)
        {
            _context.SeatShowMaps.Add(seatShowMap);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SeatShowMapExists(seatShowMap.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSeatShowMap", new { id = seatShowMap.Id }, seatShowMap);
        }

        // DELETE: api/SeatShowMaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeatShowMap(int id)
        {
            var seatShowMap = await _context.SeatShowMaps.FindAsync(id);
            if (seatShowMap == null)
            {
                return NotFound();
            }

            _context.SeatShowMaps.Remove(seatShowMap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeatShowMapExists(int id)
        {
            return _context.SeatShowMaps.Any(e => e.Id == id);
        }
    }
}
