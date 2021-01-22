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
    public class PowderShapesController : ControllerBase
    {
        private IData _data;

        public PowderShapesController(ShootingContext context)
        {
            _data = new PowderShapeData(context);
        }

        // GET: api/PowderShapes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> GetPowderShape()
        {
            var entities = await _data.Get();
            var returnEntities = new List<PowderShape>();
            entities.ForEach(delegate (IEntity entity) { returnEntities.Add((PowderShape)entity); });

            return returnEntities;
        }

        // GET: api/PowderShapes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> GetPowderShape(int id)
        {
            var entity = await _data.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return (PowderShape)entity;
        }

        // PUT: api/PowderShapes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPowderShape(int id, PowderShape entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("Powder shape id does not match the powder shape to be updated.");
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

        // POST: api/PowderShapes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEntity>> PostPowderShape(PowderShape entity)
        {
            var newEntity = await _data.Add(entity);

            return CreatedAtAction("GetPowderShape", new { id = newEntity.Id }, newEntity);
        }

        // DELETE: api/PowderShapes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> DeletePowderShape(int id)
        {
            return NotFound();

            // Deleting will be implemented later.
            var entity = await _data.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _data.Delete(entity.Id);

            return (PowderShape)entity;
        }
    }
}
