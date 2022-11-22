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
    public class SeatRowsController : ControllerBase
    {
        private readonly BookMyShowContext _context;

        public SeatRowsController(BookMyShowContext context)
        {
            _context = context;
        }

        // GET: api/SeatRows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeatRow>>> GetSeatRows()
        {
            return await _context.SeatRows.ToListAsync();
        }

        // GET: api/SeatRows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeatRow>> GetSeatRow(int id)
        {
            var seatRow = await _context.SeatRows.FindAsync(id);

            if (seatRow == null)
            {
                return NotFound();
            }

            return seatRow;
        }

        // PUT: api/SeatRows/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeatRow(int id, SeatRow seatRow)
        {
            if (id != seatRow.Id)
            {
                return BadRequest();
            }

            _context.Entry(seatRow).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatRowExists(id))
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

        // POST: api/SeatRows
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SeatRow>> PostSeatRow(SeatRow seatRow)
        {
            _context.SeatRows.Add(seatRow);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SeatRowExists(seatRow.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSeatRow", new { id = seatRow.Id }, seatRow);
        }

        // DELETE: api/SeatRows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeatRow(int id)
        {
            var seatRow = await _context.SeatRows.FindAsync(id);
            if (seatRow == null)
            {
                return NotFound();
            }

            _context.SeatRows.Remove(seatRow);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeatRowExists(int id)
        {
            return _context.SeatRows.Any(e => e.Id == id);
        }
    }
}
