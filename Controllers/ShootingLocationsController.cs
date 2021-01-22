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
    public class ShootingLocationsController : ControllerBase
    {
        private IData _data;

        public ShootingLocationsController(ShootingContext context)
        {
            _data = new ShootingLocationData(context);
        }

        // GET: api/ShootingLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> GetShootingLocation()
        {
            var entities = await _data.Get();
            var returnEntities = new List<ShootingLocation>();
            entities.ForEach(delegate (IEntity entity) { returnEntities.Add((ShootingLocation)entity); });

            return returnEntities;
        }

        // GET: api/ShootingLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> GetShootingLocation(int id)
        {
            var entity = await _data.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return (ShootingLocation)entity;
        }

        // PUT: api/ShootingLocations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShootingLocation(int id, ShootingLocation entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("Shooting location id does not match the shooting location to be updated.");
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

        // POST: api/ShootingLocations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEntity>> PostShootingLocation(ShootingLocation entity)
        {
            var newEntity = await _data.Add(entity);

            return CreatedAtAction("GetShooting", new { id = newEntity.Id }, newEntity);
        }

        // DELETE: api/ShootingLocations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> DeleteShootingLocation(int id)
        {
            return NotFound();

            // Deleting will be implemented later.
            var entity = await _data.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _data.Delete(entity.Id);

            return (ShootingLocation)entity;
        }
    }
}
