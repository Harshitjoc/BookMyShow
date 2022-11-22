using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookMyShow.Data;
using BookMyShow.Models;

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolePermissionMapsController : ControllerBase
    {
        private readonly BookMyShowContext _context;

        public RolePermissionMapsController(BookMyShowContext context)
        {
            _context = context;
        }

        // GET: api/RolePermissionMaps
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RolePermissionMap>>> GetRolePermissionMaps()
        {
            return await _context.RolePermissionMaps.ToListAsync();
        }

        // GET: api/RolePermissionMaps/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RolePermissionMap>> GetRolePermissionMap(int id)
        {
            var rolePermissionMap = await _context.RolePermissionMaps.FindAsync(id);

            if (rolePermissionMap == null)
            {
                return NotFound();
            }

            return rolePermissionMap;
        }

        // PUT: api/RolePermissionMaps/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolePermissionMap(int id, RolePermissionMap rolePermissionMap)
        {
            if (id != rolePermissionMap.Id)
            {
                return BadRequest();
            }

            _context.Entry(rolePermissionMap).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolePermissionMapExists(id))
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

        // POST: api/RolePermissionMaps
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RolePermissionMap>> PostRolePermissionMap(RolePermissionMap rolePermissionMap)
        {
            _context.RolePermissionMaps.Add(rolePermissionMap);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RolePermissionMapExists(rolePermissionMap.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRolePermissionMap", new { id = rolePermissionMap.Id }, rolePermissionMap);
        }

        // DELETE: api/RolePermissionMaps/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolePermissionMap(int id)
        {
            var rolePermissionMap = await _context.RolePermissionMaps.FindAsync(id);
            if (rolePermissionMap == null)
            {
                return NotFound();
            }

            _context.RolePermissionMaps.Remove(rolePermissionMap);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RolePermissionMapExists(int id)
        {
            return _context.RolePermissionMaps.Any(e => e.Id == id);
        }
    }
}
