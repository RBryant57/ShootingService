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
    public class PowdersController : ControllerBase
    {
        private readonly ShootingContext _context;

        public PowdersController(ShootingContext context)
        {
            _context = context;
        }

        // GET: api/Powders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Powder>>> GetPowder()
        {
            return await _context.Powder.ToListAsync();
        }

        // GET: api/Powders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Powder>> GetPowder(int id)
        {
            var powder = await _context.Powder.FindAsync(id);

            if (powder == null)
            {
                return NotFound();
            }

            return powder;
        }

        // PUT: api/Powders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPowder(int id, Powder powder)
        {
            if (id != powder.Id)
            {
                return BadRequest();
            }

            _context.Entry(powder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PowderExists(id))
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

        // POST: api/Powders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Powder>> PostPowder(Powder powder)
        {
            _context.Powder.Add(powder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPowder", new { id = powder.Id }, powder);
        }

        // DELETE: api/Powders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Powder>> DeletePowder(int id)
        {
            var powder = await _context.Powder.FindAsync(id);
            if (powder == null)
            {
                return NotFound();
            }

            _context.Powder.Remove(powder);
            await _context.SaveChangesAsync();

            return powder;
        }

        private bool PowderExists(int id)
        {
            return _context.Powder.Any(e => e.Id == id);
        }
    }
}
