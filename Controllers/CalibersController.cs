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
    public class CalibersController : ControllerBase
    {
        private IData _data;

        public CalibersController(ShootingContext context)
        {
            _data = new CaliberData(context);
        }

        // GET: api/Calibers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> GetCaliber()
        {
            var entities = await _data.Get();
            var returnEntities = new List<Caliber>();
            entities.ForEach(delegate (IEntity entity) { returnEntities.Add((Caliber)entity); });

            return returnEntities;
        }

        // GET: api/Calibers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> GetCaliber(int id)
        {
            var entity = await _data.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return (Caliber)entity;
        }

        // PUT: api/Calibers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaliber(int id, Caliber entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("Caliber id does not match the caliber to be updated.");
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

        // POST: api/Calibers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEntity>> PostCaliber(Caliber entity)
        {
            var newEntity = await _data.Add(entity);

            return CreatedAtAction("GetCaliber", new { id = newEntity.Id }, newEntity);
        }

        // DELETE: api/Calibers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> DeleteCaliber(int id)
        {
            return NotFound();

            // Deleting will be implemented later.
            var entity = await _data.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _data.Delete(entity.Id);

            return (Caliber)entity;
        }
    }
}
