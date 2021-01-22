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
    public class CartridgeLoadsController : ControllerBase
    {
        private IData _data;

        public CartridgeLoadsController(ShootingContext context)
        {
            _data = new CartridgeLoadData(context);
        }

        // GET: api/CartridgeLoads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IEntity>>> GetCartridgeLoad()
        {
            var entities = await _data.Get();
            var returnEntities = new List<CartridgeLoad>();
            entities.ForEach(delegate (IEntity entity) { returnEntities.Add((CartridgeLoad)entity); });

            return returnEntities;
        }

        // GET: api/CartridgeLoads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEntity>> GetCartridgeLoad(int id)
        {
            var entity = await _data.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return (CartridgeLoad)entity;
        }

        // PUT: api/CartridgeLoads/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartridgeLoad(int id, CartridgeLoad entity)
        {
            if (id != entity.Id)
            {
                return BadRequest("Cartridge load id does not match the cartridge load to be updated.");
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

        // POST: api/CartridgeLoads
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<IEntity>> PostCartridgeLoad(CartridgeLoad entity)
        {
            var newEntity = await _data.Add(entity);

            return CreatedAtAction("GetCartridgeLoad", new { id = newEntity.Id }, newEntity);
        }

        // DELETE: api/CartridgeLoads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEntity>> DeleteCartridgeLoad(int id)
        {
            return NotFound();

            // Deleting will be implemented later.
            var entity = await _data.Get(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _data.Delete(entity.Id);

            return (CartridgeLoad)entity;
        }
    }
}
