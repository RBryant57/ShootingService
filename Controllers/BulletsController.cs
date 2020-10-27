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
    public class BulletsController : ControllerBase
    {
        private readonly ShootingContext _context;

        public BulletsController(ShootingContext context)
        {
            _context = context;
        }

        // GET: api/Bullets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bullet>>> GetBullet()
        {
            return await _context.Bullet.ToListAsync();
        }

        // GET: api/Bullets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bullet>> GetBullet(int id)
        {
            var bullet = await _context.Bullet.FindAsync(id);

            if (bullet == null)
            {
                return NotFound();
            }

            return bullet;
        }

        // PUT: api/Bullets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBullet(int id, Bullet bullet)
        {
            if (id != bullet.Id)
            {
                return BadRequest();
            }

            _context.Entry(bullet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BulletExists(id))
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

        // POST: api/Bullets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Bullet>> PostBullet(Bullet bullet)
        {
            _context.Bullet.Add(bullet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBullet", new { id = bullet.Id }, bullet);
        }

        // DELETE: api/Bullets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bullet>> DeleteBullet(int id)
        {
            var bullet = await _context.Bullet.FindAsync(id);
            if (bullet == null)
            {
                return NotFound();
            }

            _context.Bullet.Remove(bullet);
            await _context.SaveChangesAsync();

            return bullet;
        }

        private bool BulletExists(int id)
        {
            return _context.Bullet.Any(e => e.Id == id);
        }
    }
}
