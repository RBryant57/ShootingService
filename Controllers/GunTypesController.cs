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
    public class GunTypesController : ControllerBase
    {
        private IData _data;

        public GunTypesController(ShootingContext context)
        {
            _data = new GunTypeData(context);
        }

        // GET: api/GunTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> GetGunType()
        {
            var entities = await _data.Get();
            var returnEntities = new List<GunType>();
            entities.ForEach(delegate (IEntity entity) { returnEntities.Add((GunType)entity); });

            return returnEntities;
        }

        // GET: api/GunTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> GetGunType(int id)
        {
            var entity = await _data.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return (GunType)entity;
        }

        // PUT: api/GunTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGunType(int id, GunType entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("Gun type id does not match the gun type to be updated.");
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

        // POST: api/GunTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEntity>> PostGunType(GunType entity)
        {
            var newEntity = await _data.Add(entity);

            return CreatedAtAction("GetGunType", new { id = newEntity.Id }, newEntity);
        }

        // DELETE: api/GunTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> DeleteGunType(int id)
        {
            return NotFound();

            // Deleting will be implemented later.
            var entity = await _data.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _data.Delete(entity.Id);

            return (GunType)entity;
        }
    }
}
