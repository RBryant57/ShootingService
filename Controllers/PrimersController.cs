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
    public class PrimersController : ControllerBase
    {
        private IData _data;

        public PrimersController(ShootingContext context)
        {
            _data = new PrimerData(context);
        }

        // GET: api/Primers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> GetPrimer()
        {
            var entities = await _data.Get();
            var returnEntities = new List<Primer>();
            entities.ForEach(delegate (IEntity entity) { returnEntities.Add((Primer)entity); });

            return returnEntities;
        }

        // GET: api/Primers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> GetPrimer(int id)
        {
            var entity = await _data.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return (Primer)entity;
        }

        // PUT: api/Primers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrimer(int id, Primer entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("Primer id does not match the primer to be updated.");
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

        // POST: api/Primers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEntity>> PostPrimer(Primer entity)
        {
            var newEntity = await _data.Add(entity);

            return CreatedAtAction("GetPrimer", new { id = newEntity.Id }, newEntity);
        }

        // DELETE: api/Primers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> DeletePrimer(int id)
        {
            return NotFound();

            // Deleting will be implemented later.
            var entity = await _data.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _data.Delete(entity.Id);

            return (Primer)entity;
        }
    }
}
