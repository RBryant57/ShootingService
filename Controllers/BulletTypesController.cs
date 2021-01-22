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
    public class BulletTypesController : ControllerBase
    {
        private IData _data;

        public BulletTypesController(ShootingContext context)
        {
            _data = new BulletTypeData(context);
        }

        // GET: api/BulletTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> GetBulletType()
        {
            var entities = await _data.Get();
            var returnEntities = new List<BulletType>();
            entities.ForEach(delegate (IEntity entity) { returnEntities.Add((BulletType)entity); });

            return returnEntities;
        }

        // GET: api/BulletTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> GetBulletType(int id)
        {
            var entity = await _data.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return (BulletType)entity;
        }

        // PUT: api/BulletTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBulletType(int id, BulletType entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("Bullet type id does not match the bullet type to be updated.");
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

        // POST: api/BulletTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEntity>> PostBulletType(BulletType entity)
        {
            var newEntity = await _data.Add(entity);

            return CreatedAtAction("GetBulletType", new { id = newEntity.Id }, newEntity);
        }

        // DELETE: api/BulletTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> DeleteBulletType(int id)
        {
            return NotFound();

            // Deleting will be implemented later.
            var entity = await _data.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _data.Delete(entity.Id);

            return (BulletType)entity;
        }
    }
}
