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
    public class UnitsController : ControllerBase
    {
        private IData _data;

        public UnitsController(ShootingContext context)
        {
            _data = new UnitData(context);
        }

        // GET: api/Units
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> GetUnit()
        {
            var entities = await _data.Get();
            var returnEntities = new List<Unit>();
            entities.ForEach(delegate (IEntity entity) { returnEntities.Add((Unit)entity); });

            return returnEntities;
        }

        // GET: api/Units/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> GetUnit(int id)
        {
            var entity = await _data.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return (Brass)entity;
        }

        // PUT: api/Units/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnit(int id, Unit entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("Unit id does not match the unit to be updated.");
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

        // POST: api/Units
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEntity>> PostUnit(Unit entity)
        {
            var newEntity = await _data.Add(entity);

            return CreatedAtAction("GetUnit", new { id = newEntity.Id }, newEntity);
        }

        // DELETE: api/Units/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> DeleteUnit(int id)
        {
            return NotFound();

            // Deleting will be implemented later.
            var entity = await _data.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _data.Delete(entity.Id);

            return (Unit)entity;
        }
    }
}
