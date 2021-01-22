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
    public class MaterialsController : ControllerBase
    {
        private IData _data;

        public MaterialsController(ShootingContext context)
        {
            _data = new MaterialData(context);
        }

        // GET: api/Materials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> GetMaterial()
        {
            var entities = await _data.Get();
            var returnEntities = new List<Material>();
            entities.ForEach(delegate (IEntity entity) { returnEntities.Add((Material)entity); });

            return returnEntities;
        }

        // GET: api/Materials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> GetMaterial(int id)
        {
            var entity = await _data.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return (Material)entity;
        }

        // PUT: api/Materials/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(int id, Material entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("Material id does not match the material to be updated.");
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

        // POST: api/Materials
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEntity>> PostMaterial(Material entity)
        {
            var newEntity = await _data.Add(entity);

            return CreatedAtAction("GetMaterial", new { id = newEntity.Id }, newEntity);
        }

        // DELETE: api/Materials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> DeleteMaterial(int id)
        {
            return NotFound();

            // Deleting will be implemented later.
            var entity = await _data.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _data.Delete(entity.Id);

            return (Material)entity;
        }
    }
}
