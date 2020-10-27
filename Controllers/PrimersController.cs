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
    public class PrimersController : ControllerBase
    {
        private readonly ShootingContext _context;

        public PrimersController(ShootingContext context)
        {
            _context = context;
        }

        // GET: api/Primers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Primer>>> GetPrimer()
        {
            return await _context.Primer.ToListAsync();
        }

        // GET: api/Primers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Primer>> GetPrimer(int id)
        {
            var primer = await _context.Primer.FindAsync(id);

            if (primer == null)
            {
                return NotFound();
            }

            return primer;
        }

        // PUT: api/Primers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrimer(int id, Primer primer)
        {
            if (id != primer.Id)
            {
                return BadRequest();
            }

            _context.Entry(primer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrimerExists(id))
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

        // POST: api/Primers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Primer>> PostPrimer(Primer primer)
        {
            _context.Primer.Add(primer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrimer", new { id = primer.Id }, primer);
        }

        // DELETE: api/Primers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Primer>> DeletePrimer(int id)
        {
            var primer = await _context.Primer.FindAsync(id);
            if (primer == null)
            {
                return NotFound();
            }

            _context.Primer.Remove(primer);
            await _context.SaveChangesAsync();

            return primer;
        }

        private bool PrimerExists(int id)
        {
            return _context.Primer.Any(e => e.Id == id);
        }
    }
}
