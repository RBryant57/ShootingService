using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using DataLayer.Data;
using DataLayer.Interfaces;
using EntityLayer.Contexts;
using EntityLayer.Interfaces;
using EntityLayer.Models;

namespace ShootingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShootingSessionsController : ControllerBase
    {
        private IData _data;

        public ShootingSessionsController(ShootingContext context)
        {
            _data = new ShootingSessionData(context);
        }

        // GET: api/ShootingSessions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> GetShootingSession()
        {
            var entities = await _data.Get();
            var returnEntities = new List<ShootingSession>();
            entities.ForEach(delegate (IEntity entity) { returnEntities.Add((ShootingSession)entity); });

            return returnEntities;
        }

        // GET: api/ShootingSessions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> GetShootingSession(int id)
        {
            var entity = await _data.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return (ShootingSession)entity;
        }

        // PUT: api/ShootingSessions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShootingSession(int id, ShootingSession entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("Shooting session id does not match the shooting session to be updated.");
            }

            try
            {
                await _data.Update(id, entity);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/ShootingSessions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEntity>> PostShootingSession(ShootingSession entity)
        {
            var newEntity = await _data.Add(entity);

            return CreatedAtAction("GetShootingSession", new { id = newEntity.Id }, newEntity);
        }

        // DELETE: api/ShootingSessions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> DeleteShootingSession(int id)
        {
            return NotFound();

            // Deleting will be implemented later.
            var entity = await _data.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _data.Delete(entity.Id);

            return (ShootingSession)entity;
        }
    }
}
