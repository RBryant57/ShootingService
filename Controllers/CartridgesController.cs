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
    public class CartridgesController : ControllerBase
    {
        private readonly ShootingContext _context;

        public CartridgesController(ShootingContext context)
        {
            _context = context;
        }

        // GET: api/Cartridges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cartridge>>> GetCartridge()
        {
            return await _context.Cartridge.ToListAsync();
        }

        // GET: api/Cartridges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cartridge>> GetCartridge(int id)
        {
            var cartridge = await _context.Cartridge.FindAsync(id);

            if (cartridge == null)
            {
                return NotFound();
            }

            return cartridge;
        }

        // PUT: api/Cartridges/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartridge(int id, Cartridge cartridge)
        {
            if (id != cartridge.Id)
            {
                return BadRequest();
            }

            _context.Entry(cartridge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartridgeExists(id))
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

        // POST: api/Cartridges
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cartridge>> PostCartridge(Cartridge cartridge)
        {
            _context.Cartridge.Add(cartridge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartridge", new { id = cartridge.Id }, cartridge);
        }

        // DELETE: api/Cartridges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cartridge>> DeleteCartridge(int id)
        {
            var cartridge = await _context.Cartridge.FindAsync(id);
            if (cartridge == null)
            {
                return NotFound();
            }

            _context.Cartridge.Remove(cartridge);
            await _context.SaveChangesAsync();

            return cartridge;
        }

        private bool CartridgeExists(int id)
        {
            return _context.Cartridge.Any(e => e.Id == id);
        }
    }
}
