using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShootingService.Models;

namespace ShootingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GunsController : ControllerBase
    {
        private readonly ShootingContext _context;

        public GunsController(ShootingContext context)
        {
            _context = context;
        }

        // GET: api/Guns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gun>>> GetGun()
        {
            return await _context.Gun.ToListAsync();
        }

        // GET: api/Guns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gun>> GetGun(int id)
        {
            var gun = await _context.Gun.FindAsync(id);

            if (gun == null)
            {
                return NotFound();
            }

            return gun;
        }

        // PUT: api/Guns/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGun(int id, Gun gun)
        {
            if (id != gun.Id)
            {
                return BadRequest();
            }

            _context.Entry(gun).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GunExists(id))
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

        // POST: api/Guns
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Gun>> PostGun(Gun gun)
        {
            _context.Gun.Add(gun);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGun", new { id = gun.Id }, gun);
        }

        // DELETE: api/Guns/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Gun>> DeleteGun(int id)
        {
            var gun = await _context.Gun.FindAsync(id);
            if (gun == null)
            {
                return NotFound();
            }

            _context.Gun.Remove(gun);
            await _context.SaveChangesAsync();

            return gun;
        }

        private bool GunExists(int id)
        {
            return _context.Gun.Any(e => e.Id == id);
        }
    }
}
