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
    public class PowderShapesController : ControllerBase
    {
        private readonly ShootingContext _context;

        public PowderShapesController(ShootingContext context)
        {
            _context = context;
        }

        // GET: api/PowderShapes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PowderShape>>> GetPowderShape()
        {
            return await _context.PowderShape.ToListAsync();
        }

        // GET: api/PowderShapes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PowderShape>> GetPowderShape(int id)
        {
            var powderShape = await _context.PowderShape.FindAsync(id);

            if (powderShape == null)
            {
                return NotFound();
            }

            return powderShape;
        }

        // PUT: api/PowderShapes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPowderShape(int id, PowderShape powderShape)
        {
            if (id != powderShape.Id)
            {
                return BadRequest();
            }

            _context.Entry(powderShape).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PowderShapeExists(id))
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

        // POST: api/PowderShapes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PowderShape>> PostPowderShape(PowderShape powderShape)
        {
            _context.PowderShape.Add(powderShape);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPowderShape", new { id = powderShape.Id }, powderShape);
        }

        // DELETE: api/PowderShapes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PowderShape>> DeletePowderShape(int id)
        {
            var powderShape = await _context.PowderShape.FindAsync(id);
            if (powderShape == null)
            {
                return NotFound();
            }

            _context.PowderShape.Remove(powderShape);
            await _context.SaveChangesAsync();

            return powderShape;
        }

        private bool PowderShapeExists(int id)
        {
            return _context.PowderShape.Any(e => e.Id == id);
        }
    }
}
