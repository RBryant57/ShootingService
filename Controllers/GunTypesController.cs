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
    public class GunTypesController : ControllerBase
    {
        private readonly ShootingContext _context;

        public GunTypesController(ShootingContext context)
        {
            _context = context;
        }

        // GET: api/GunTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GunType>>> GetGunType()
        {
            return await _context.GunType.ToListAsync();
        }

        // GET: api/GunTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GunType>> GetGunType(int id)
        {
            var gunType = await _context.GunType.FindAsync(id);

            if (gunType == null)
            {
                return NotFound();
            }

            return gunType;
        }

        // PUT: api/GunTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGunType(int id, GunType gunType)
        {
            if (id != gunType.Id)
            {
                return BadRequest();
            }

            _context.Entry(gunType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GunTypeExists(id))
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

        // POST: api/GunTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GunType>> PostGunType(GunType gunType)
        {
            _context.GunType.Add(gunType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGunType", new { id = gunType.Id }, gunType);
        }

        // DELETE: api/GunTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GunType>> DeleteGunType(int id)
        {
            var gunType = await _context.GunType.FindAsync(id);
            if (gunType == null)
            {
                return NotFound();
            }

            _context.GunType.Remove(gunType);
            await _context.SaveChangesAsync();

            return gunType;
        }

        private bool GunTypeExists(int id)
        {
            return _context.GunType.Any(e => e.Id == id);
        }
    }
}
