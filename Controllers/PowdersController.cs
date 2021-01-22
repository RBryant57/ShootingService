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
    public class PowdersController : ControllerBase
    {
        private IData _data;

        public PowdersController(ShootingContext context)
        {
            _data = new PowderData(context);
        }

        // GET: api/Powders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> GetPowder()
        {
            var entities = await _data.Get();
            var returnEntities = new List<Powder>();
            entities.ForEach(delegate (IEntity entity) { returnEntities.Add((Powder)entity); });

            return returnEntities;
        }

        // GET: api/Powders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> GetPowder(int id)
        {
            var entity = await _data.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return (Powder)entity;
        }

        // PUT: api/Powders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPowder(int id, Powder entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("Powder id does not match the powder to be updated.");
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

        // POST: api/Powders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEntity>> PostPowder(Powder entity)
        {
            var newEntity = await _data.Add(entity);

            return CreatedAtAction("GetPowder", new { id = newEntity.Id }, newEntity);
        }

        // DELETE: api/Powders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> DeletePowder(int id)
        {
            return NotFound();

            // Deleting will be implemented later.
            var entity = await _data.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _data.Delete(entity.Id);

            return (Powder)entity;
        }
    }
}
