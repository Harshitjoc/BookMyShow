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
    public class UserRoleMapsController : ControllerBase
    {
        private readonly BookMyShowContext _context;

        public UserRoleMapsController(BookMyShowContext context)
        {
            _context = context;
        }

        // GET: api/UserRoleMaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRoleMap>>> GetUserRoleMaps()
        {
            return await _context.UserRoleMaps.ToListAsync();
        }

        // GET: api/UserRoleMaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoleMap>> GetUserRoleMap(int id)
        {
            var userRoleMap = await _context.UserRoleMaps.FindAsync(id);

            if (userRoleMap == null)
            {
                return NotFound();
            }

            return userRoleMap;
        }

        // PUT: api/UserRoleMaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRoleMap(int id, UserRoleMap userRoleMap)
        {
            if (id != userRoleMap.Id)
            {
                return BadRequest();
            }

            _context.Entry(userRoleMap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRoleMapExists(id))
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

        // POST: api/UserRoleMaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRoleMap>> PostUserRoleMap(UserRoleMap userRoleMap)
        {
            _context.UserRoleMaps.Add(userRoleMap);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserRoleMapExists(userRoleMap.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserRoleMap", new { id = userRoleMap.Id }, userRoleMap);
        }

        // DELETE: api/UserRoleMaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRoleMap(int id)
        {
            var userRoleMap = await _context.UserRoleMaps.FindAsync(id);
            if (userRoleMap == null)
            {
                return NotFound();
            }

            _context.UserRoleMaps.Remove(userRoleMap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserRoleMapExists(int id)
        {
            return _context.UserRoleMaps.Any(e => e.Id == id);
        }
    }
}
