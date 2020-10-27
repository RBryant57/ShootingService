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
    public class ShootingLocationsController : ControllerBase
    {
        private readonly ShootingContext _context;

        public ShootingLocationsController(ShootingContext context)
        {
            _context = context;
        }

        // GET: api/ShootingLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShootingLocation>>> GetShootingLocation()
        {
            return await _context.ShootingLocation.ToListAsync();
        }

        // GET: api/ShootingLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShootingLocation>> GetShootingLocation(int id)
        {
            var shootingLocation = await _context.ShootingLocation.FindAsync(id);

            if (shootingLocation == null)
            {
                return NotFound();
            }

            return shootingLocation;
        }

        // PUT: api/ShootingLocations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShootingLocation(int id, ShootingLocation shootingLocation)
        {
            if (id != shootingLocation.Id)
            {
                return BadRequest();
            }

            _context.Entry(shootingLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShootingLocationExists(id))
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

        // POST: api/ShootingLocations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShootingLocation>> PostShootingLocation(ShootingLocation shootingLocation)
        {
            _context.ShootingLocation.Add(shootingLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShootingLocation", new { id = shootingLocation.Id }, shootingLocation);
        }

        // DELETE: api/ShootingLocations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShootingLocation>> DeleteShootingLocation(int id)
        {
            var shootingLocation = await _context.ShootingLocation.FindAsync(id);
            if (shootingLocation == null)
            {
                return NotFound();
            }

            _context.ShootingLocation.Remove(shootingLocation);
            await _context.SaveChangesAsync();

            return shootingLocation;
        }

        private bool ShootingLocationExists(int id)
        {
            return _context.ShootingLocation.Any(e => e.Id == id);
        }
    }
}
