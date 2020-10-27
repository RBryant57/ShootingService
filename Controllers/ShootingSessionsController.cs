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
    public class ShootingSessionsController : ControllerBase
    {
        private readonly ShootingContext _context;

        public ShootingSessionsController(ShootingContext context)
        {
            _context = context;
        }

        // GET: api/ShootingSessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShootingSession>>> GetShootingSession()
        {
            return await _context.ShootingSession.ToListAsync();
        }

        // GET: api/ShootingSessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShootingSession>> GetShootingSession(int id)
        {
            var shootingSession = await _context.ShootingSession.FindAsync(id);

            if (shootingSession == null)
            {
                return NotFound();
            }

            return shootingSession;
        }

        // PUT: api/ShootingSessions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShootingSession(int id, ShootingSession shootingSession)
        {
            if (id != shootingSession.Id)
            {
                return BadRequest();
            }

            _context.Entry(shootingSession).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShootingSessionExists(id))
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

        // POST: api/ShootingSessions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ShootingSession>> PostShootingSession(ShootingSession shootingSession)
        {
            _context.ShootingSession.Add(shootingSession);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShootingSession", new { id = shootingSession.Id }, shootingSession);
        }

        // DELETE: api/ShootingSessions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ShootingSession>> DeleteShootingSession(int id)
        {
            var shootingSession = await _context.ShootingSession.FindAsync(id);
            if (shootingSession == null)
            {
                return NotFound();
            }

            _context.ShootingSession.Remove(shootingSession);
            await _context.SaveChangesAsync();

            return shootingSession;
        }

        private bool ShootingSessionExists(int id)
        {
            return _context.ShootingSession.Any(e => e.Id == id);
        }
    }
}
