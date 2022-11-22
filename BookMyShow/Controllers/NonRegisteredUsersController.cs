using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookMyShow.Data;
using BookMyShow.Models;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NonRegisteredUsersController : ControllerBase
    {
        private readonly BookMyShowContext _context;

        public NonRegisteredUsersController(BookMyShowContext context)
        {
            _context = context;
        }

        // GET: api/NonRegisteredUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NonRegisteredUser>>> GetNonRegisteredUsers()
        {
            return await _context.NonRegisteredUsers.ToListAsync();
        }

        // GET: api/NonRegisteredUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NonRegisteredUser>> GetNonRegisteredUser(int id)
        {
            var nonRegisteredUser = await _context.NonRegisteredUsers.FindAsync(id);

            if (nonRegisteredUser == null)
            {
                return NotFound();
            }

            return nonRegisteredUser;
        }

        // PUT: api/NonRegisteredUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNonRegisteredUser(int id, NonRegisteredUser nonRegisteredUser)
        {
            if (id != nonRegisteredUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(nonRegisteredUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NonRegisteredUserExists(id))
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

        // POST: api/NonRegisteredUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NonRegisteredUser>> PostNonRegisteredUser(NonRegisteredUser nonRegisteredUser)
        {
            _context.NonRegisteredUsers.Add(nonRegisteredUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NonRegisteredUserExists(nonRegisteredUser.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNonRegisteredUser", new { id = nonRegisteredUser.Id }, nonRegisteredUser);
        }

        // DELETE: api/NonRegisteredUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNonRegisteredUser(int id)
        {
            var nonRegisteredUser = await _context.NonRegisteredUsers.FindAsync(id);
            if (nonRegisteredUser == null)
            {
                return NotFound();
            }

            _context.NonRegisteredUsers.Remove(nonRegisteredUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NonRegisteredUserExists(int id)
        {
            return _context.NonRegisteredUsers.Any(e => e.Id == id);
        }
    }
}
