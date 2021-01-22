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
    public class BrassesController : ControllerBase
    {
        private IData _data;

        public BrassesController(ShootingContext context)
        {
            _data = new BrassData(context);
        }

        // GET: api/Brasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> GetBrass()
        {
            var entities = await _data.Get();
            var returnEntities = new List<Brass>();
            entities.ForEach(delegate (IEntity entity) { returnEntities.Add((Brass)entity); });

            return returnEntities;
        }

        // GET: api/Brasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> GetBrass(int id)
        {
            var entity = await _data.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return (Brass)entity;
        }

        // PUT: api/Brasses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrass(int id, Brass entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("Brass id does not match the brass to be updated.");
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

        // POST: api/Brasses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEntity>> PostBrass(Brass entity)
        {
            var newEntity = await _data.Add(entity);

            return CreatedAtAction("GetBrass", new { id = newEntity.Id }, newEntity);
        }

        // DELETE: api/Brasses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> DeleteBrass(int id)
        {
            return NotFound();

            // Deleting will be implemented later.
            var entity = await _data.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _data.Delete(entity.Id);

            return (Brass)entity;
        }
    }
}
