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
    public class CartridgeLoadsController : ControllerBase
    {
        private readonly ShootingContext _context;

        public CartridgeLoadsController(ShootingContext context)
        {
            _context = context;
        }

        // GET: api/CartridgeLoads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartridgeLoad>>> GetCartridgeLoad()
        {
            return await _context.CartridgeLoad.ToListAsync();
        }

        // GET: api/CartridgeLoads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartridgeLoad>> GetCartridgeLoad(int id)
        {
            var cartridgeLoad = await _context.CartridgeLoad.FindAsync(id);

            if (cartridgeLoad == null)
            {
                return NotFound();
            }

            return cartridgeLoad;
        }

        // PUT: api/CartridgeLoads/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartridgeLoad(int id, CartridgeLoad cartridgeLoad)
        {
            if (id != cartridgeLoad.Id)
            {
                return BadRequest();
            }

            _context.Entry(cartridgeLoad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartridgeLoadExists(id))
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

        // POST: api/CartridgeLoads
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CartridgeLoad>> PostCartridgeLoad(CartridgeLoad cartridgeLoad)
        {
            _context.CartridgeLoad.Add(cartridgeLoad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartridgeLoad", new { id = cartridgeLoad.Id }, cartridgeLoad);
        }

        // DELETE: api/CartridgeLoads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CartridgeLoad>> DeleteCartridgeLoad(int id)
        {
            var cartridgeLoad = await _context.CartridgeLoad.FindAsync(id);
            if (cartridgeLoad == null)
            {
                return NotFound();
            }

            _context.CartridgeLoad.Remove(cartridgeLoad);
            await _context.SaveChangesAsync();

            return cartridgeLoad;
        }

        private bool CartridgeLoadExists(int id)
        {
            return _context.CartridgeLoad.Any(e => e.Id == id);
        }
    }
}
