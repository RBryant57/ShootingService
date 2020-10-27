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
    public class BulletTypesController : ControllerBase
    {
        private readonly ShootingContext _context;

        public BulletTypesController(ShootingContext context)
        {
            _context = context;
        }

        // GET: api/BulletTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BulletType>>> GetBulletType()
        {
            return await _context.BulletType.ToListAsync();
        }

        // GET: api/BulletTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BulletType>> GetBulletType(int id)
        {
            var bulletType = await _context.BulletType.FindAsync(id);

            if (bulletType == null)
            {
                return NotFound();
            }

            return bulletType;
        }

        // PUT: api/BulletTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBulletType(int id, BulletType bulletType)
        {
            if (id != bulletType.Id)
            {
                return BadRequest();
            }

            _context.Entry(bulletType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BulletTypeExists(id))
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

        // POST: api/BulletTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BulletType>> PostBulletType(BulletType bulletType)
        {
            _context.BulletType.Add(bulletType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBulletType", new { id = bulletType.Id }, bulletType);
        }

        // DELETE: api/BulletTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BulletType>> DeleteBulletType(int id)
        {
            var bulletType = await _context.BulletType.FindAsync(id);
            if (bulletType == null)
            {
                return NotFound();
            }

            _context.BulletType.Remove(bulletType);
            await _context.SaveChangesAsync();

            return bulletType;
        }

        private bool BulletTypeExists(int id)
        {
            return _context.BulletType.Any(e => e.Id == id);
        }
    }
}
