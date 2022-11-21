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
    public class SeatPricesController : ControllerBase
    {
        private readonly BookMyShowContext _context;

        public SeatPricesController(BookMyShowContext context)
        {
            _context = context;
        }

        // GET: api/SeatPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeatPrice>>> GetSeatPrices()
        {
            return await _context.SeatPrices.ToListAsync();
        }

        // GET: api/SeatPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SeatPrice>> GetSeatPrice(int id)
        {
            var seatPrice = await _context.SeatPrices.FindAsync(id);

            if (seatPrice == null)
            {
                return NotFound();
            }

            return seatPrice;
        }

        // PUT: api/SeatPrices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSeatPrice(int id, SeatPrice seatPrice)
        {
            if (id != seatPrice.Id)
            {
                return BadRequest();
            }

            _context.Entry(seatPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SeatPriceExists(id))
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

        // POST: api/SeatPrices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SeatPrice>> PostSeatPrice(SeatPrice seatPrice)
        {
            _context.SeatPrices.Add(seatPrice);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SeatPriceExists(seatPrice.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSeatPrice", new { id = seatPrice.Id }, seatPrice);
        }

        // DELETE: api/SeatPrices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSeatPrice(int id)
        {
            var seatPrice = await _context.SeatPrices.FindAsync(id);
            if (seatPrice == null)
            {
                return NotFound();
            }

            _context.SeatPrices.Remove(seatPrice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SeatPriceExists(int id)
        {
            return _context.SeatPrices.Any(e => e.Id == id);
        }
    }
}
