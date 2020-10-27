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
    public class PowderTypesController : ControllerBase
    {
        private readonly ShootingContext _context;

        public PowderTypesController(ShootingContext context)
        {
            _context = context;
        }

        // GET: api/PowderTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PowderType>>> GetPowderType()
        {
            return await _context.PowderType.ToListAsync();
        }

        // GET: api/PowderTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PowderType>> GetPowderType(int id)
        {
            var powderType = await _context.PowderType.FindAsync(id);

            if (powderType == null)
            {
                return NotFound();
            }

            return powderType;
        }

        // PUT: api/PowderTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPowderType(int id, PowderType powderType)
        {
            if (id != powderType.Id)
            {
                return BadRequest();
            }

            _context.Entry(powderType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PowderTypeExists(id))
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

        // POST: api/PowderTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PowderType>> PostPowderType(PowderType powderType)
        {
            _context.PowderType.Add(powderType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPowderType", new { id = powderType.Id }, powderType);
        }

        // DELETE: api/PowderTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PowderType>> DeletePowderType(int id)
        {
            var powderType = await _context.PowderType.FindAsync(id);
            if (powderType == null)
            {
                return NotFound();
            }

            _context.PowderType.Remove(powderType);
            await _context.SaveChangesAsync();

            return powderType;
        }

        private bool PowderTypeExists(int id)
        {
            return _context.PowderType.Any(e => e.Id == id);
        }
    }
}
