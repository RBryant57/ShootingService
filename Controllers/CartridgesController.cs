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
    public class CartridgesController : ControllerBase
    {
        private IData _data;

        public CartridgesController(ShootingContext context)
        {
            _data = new CartridgeData(context);
        }

        // GET: api/Cartridges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> GetCartridge()
        {
            var entities = await _data.Get();
            var returnEntities = new List<Cartridge>();
            entities.ForEach(delegate (IEntity entity) { returnEntities.Add((Cartridge)entity); });

            return returnEntities;
        }

        // GET: api/Cartridges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> GetCartridge(int id)
        {
            var entity = await _data.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return (Cartridge)entity;
        }

        // PUT: api/Cartridges/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartridge(int id, Cartridge entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("Cartridge id does not match the cartridge to be updated.");
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

        // POST: api/Cartridges
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEntity>> PostCartridge(Cartridge entity)
        {
            var newEntity = await _data.Add(entity);

            return CreatedAtAction("GetCartridge", new { id = newEntity.Id }, newEntity);
        }

        // DELETE: api/Cartridges/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> DeleteCartridge(int id)
        {
            return NotFound();

            // Deleting will be implemented later.
            var entity = await _data.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _data.Delete(entity.Id);

            return (Cartridge)entity;
        }
    }
}
