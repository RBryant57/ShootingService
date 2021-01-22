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
    public class PrimerTypesController : ControllerBase
    {
        private IData _data;

        public PrimerTypesController(ShootingContext context)
        {
            _data = new PrimerTypeData(context);
        }

        // GET: api/PrimerTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> GetPrimerType()
        {
            var entities = await _data.Get();
            var returnEntities = new List<PrimerType>();
            entities.ForEach(delegate (IEntity entity) { returnEntities.Add((PrimerType)entity); });

            return returnEntities;
        }

        // GET: api/PrimerTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> GetPrimerType(int id)
        {
            var entity = await _data.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return (PrimerType)entity;
        }

        // PUT: api/PrimerTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrimerType(int id, PrimerType entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("Primer type id does not match the primer type to be updated.");
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

        // POST: api/PrimerTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEntity>> PostPrimerType(PrimerType entity)
        {
            var newEntity = await _data.Add(entity);

            return CreatedAtAction("GetPrimerType", new { id = newEntity.Id }, newEntity);
        }

        // DELETE: api/PrimerTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> DeletePrimerType(int id)
        {
            return NotFound();

            // Deleting will be implemented later.
            var entity = await _data.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _data.Delete(entity.Id);

            return (PrimerType)entity;
        }
    }
}
