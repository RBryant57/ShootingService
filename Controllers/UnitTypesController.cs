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
    public class UnitTypesController : ControllerBase
    {
        private IData _data;

        public UnitTypesController(ShootingContext context)
        {
            _data = new BrassData(context);
        }

        // GET: api/UnitTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> GetUnitType()
        {
            var entities = await _data.Get();
            var returnEntities = new List<UnitType>();
            entities.ForEach(delegate (IEntity entity) { returnEntities.Add((UnitType)entity); });

            return returnEntities;
        }

        // GET: api/UnitTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> GetUnitType(int id)
        {
            var entity = await _data.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return (UnitType)entity;
        }

        // PUT: api/UnitTypes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitType(int id, UnitType entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("Unit type id does not match the unit type to be updated.");
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

        // POST: api/UnitTypes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEntity>> PostUnitType(UnitType entity)
        {
            var newEntity = await _data.Add(entity);

            return CreatedAtAction("GetUnitType", new { id = newEntity.Id }, newEntity);
        }

        // DELETE: api/UnitTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> DeleteUnitType(int id)
        {
            return NotFound();

            // Deleting will be implemented later.
            var entity = await _data.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _data.Delete(entity.Id);

            return (UnitType)entity;
        }
    }
}
