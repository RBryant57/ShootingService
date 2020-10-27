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
    public class CalibersController : ControllerBase
    {
        private readonly ShootingContext _context;

        public CalibersController(ShootingContext context)
        {
            _context = context;
        }

        // GET: api/Calibers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Caliber>>> GetCaliber()
        {
            return await _context.Caliber.ToListAsync();
        }

        // GET: api/Calibers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Caliber>> GetCaliber(int id)
        {
            var caliber = await _context.Caliber.FindAsync(id);

            if (caliber == null)
            {
                return NotFound();
            }

            return caliber;
        }

        // PUT: api/Calibers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaliber(int id, Caliber caliber)
        {
            if (id != caliber.Id)
            {
                return BadRequest();
            }

            _context.Entry(caliber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaliberExists(id))
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

        // POST: api/Calibers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Caliber>> PostCaliber(Caliber caliber)
        {
            Caliber cal = new Caliber();
            await caliber.AddCaliber(cal, _context);

            return CreatedAtAction("GetCaliber", new { id = caliber.Id }, caliber);
        }

        // DELETE: api/Calibers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Caliber>> DeleteCaliber(int id)
        {
            var caliber = await _context.Caliber.FindAsync(id);
            if (caliber == null)
            {
                return NotFound();
            }

            _context.Caliber.Remove(caliber);
            await _context.SaveChangesAsync();

            return caliber;
        }

        private bool CaliberExists(int id)
        {
            return _context.Caliber.Any(e => e.Id == id);
        }
    }
}
