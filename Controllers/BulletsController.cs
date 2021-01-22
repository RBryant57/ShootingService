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
    public class BulletsController : ControllerBase
    {
        private IData _data;

        public BulletsController(ShootingContext context)
        {
            _data = new BulletData(context);
        }

        // GET: api/Bullets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> GetBullet()
        {
            var entities = await _data.Get();
            var returnEntities = new List<Bullet>();
            entities.ForEach(delegate (IEntity entity) { returnEntities.Add((Bullet)entity); });

            return returnEntities;
        }

        // GET: api/Bullets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> GetBullet(int id)
        {
            var entity = await _data.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return (Bullet)entity;
        }

        // PUT: api/Bullets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBullet(int id, Bullet entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("Bullet id does not match the bullet to be updated.");
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

        // POST: api/Bullets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEntity>> PostBullet(Bullet entity)
        {
            var newEntity = await _data.Add(entity);

            return CreatedAtAction("GetBullet", new { id = newEntity.Id }, newEntity);
        }

        // DELETE: api/Bullets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> DeleteBullet(int id)
        {
            return NotFound();

            // Deleting will be implemented later.
            var entity = await _data.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _data.Delete(entity.Id);

            return (Bullet)entity;
        }
    }
}
