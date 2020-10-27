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
    public class BrassesController : ControllerBase
    {
        private readonly ShootingContext _context;

        public BrassesController(ShootingContext context)
        {
            _context = context;
        }

        // GET: api/Brasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brass>>> GetBrass()
        {
            return await _context.Brass.ToListAsync();
        }

        // GET: api/Brasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Brass>> GetBrass(int id)
        {
            var brass = await _context.Brass.FindAsync(id);

            if (brass == null)
            {
                return NotFound();
            }

            return brass;
        }

        // PUT: api/Brasses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrass(int id, Brass brass)
        {
            if (id != brass.Id)
            {
                return BadRequest();
            }

            _context.Entry(brass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrassExists(id))
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

        // POST: api/Brasses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Brass>> PostBrass(Brass brass)
        {
            _context.Brass.Add(brass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBrass", new { id = brass.Id }, brass);
        }

        // DELETE: api/Brasses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Brass>> DeleteBrass(int id)
        {
            var brass = await _context.Brass.FindAsync(id);
            if (brass == null)
            {
                return NotFound();
            }

            _context.Brass.Remove(brass);
            await _context.SaveChangesAsync();

            return brass;
        }

        private bool BrassExists(int id)
        {
            return _context.Brass.Any(e => e.Id == id);
        }
    }
}
