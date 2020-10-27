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
    public class PrimerTypesController : ControllerBase
    {
        private readonly ShootingContext _context;

        public PrimerTypesController(ShootingContext context)
        {
            _context = context;
        }

        // GET: api/PrimerTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrimerType>>> GetPrimerType()
        {
            return await _context.PrimerType.ToListAsync();
        }

        // GET: api/PrimerTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrimerType>> GetPrimerType(int id)
        {
            var primerType = await _context.PrimerType.FindAsync(id);

            if (primerType == null)
            {
                return NotFound();
            }

            return primerType;
        }

        // PUT: api/PrimerTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrimerType(int id, PrimerType primerType)
        {
            if (id != primerType.Id)
            {
                return BadRequest();
            }

            _context.Entry(primerType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrimerTypeExists(id))
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

        // POST: api/PrimerTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PrimerType>> PostPrimerType(PrimerType primerType)
        {
            _context.PrimerType.Add(primerType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrimerType", new { id = primerType.Id }, primerType);
        }

        // DELETE: api/PrimerTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PrimerType>> DeletePrimerType(int id)
        {
            var primerType = await _context.PrimerType.FindAsync(id);
            if (primerType == null)
            {
                return NotFound();
            }

            _context.PrimerType.Remove(primerType);
            await _context.SaveChangesAsync();

            return primerType;
        }

        private bool PrimerTypeExists(int id)
        {
            return _context.PrimerType.Any(e => e.Id == id);
        }
    }
}
