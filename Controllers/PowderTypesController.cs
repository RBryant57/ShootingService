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
    public class PowderTypesController : ControllerBase
    {
        private IData _data;

        public PowderTypesController(ShootingContext context)
        {
            _data = new PowderTypeData(context);
        }

        // GET: api/PowderTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> GetPowderType()
        {
            var entities = await _data.Get();
            var returnEntities = new List<PowderType>();
            entities.ForEach(delegate (IEntity entity) { returnEntities.Add((PowderType)entity); });

            return returnEntities;
        }

        // GET: api/PowderTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> GetPowderType(int id)
        {
            var entity = await _data.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return (PowderType)entity;
        }

        // PUT: api/PowderTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPowderType(int id, PowderType entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("Powder types id does not match the powder type to be updated.");
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

        // POST: api/PowderTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEntity>> PostPowderType(PowderType entity)
        {
            var newEntity = await _data.Add(entity);

            return CreatedAtAction("GetPowderType", new { id = newEntity.Id }, newEntity);
        }

        // DELETE: api/PowderTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> DeletePowderType(int id)
        {
            return NotFound();

            // Deleting will be implemented later.
            var entity = await _data.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _data.Delete(entity.Id);

            return (PowderType)entity;
        }
    }
}
