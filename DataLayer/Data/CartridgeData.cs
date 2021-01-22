using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using DataLayer.Interfaces;
using EntityLayer.Contexts;
using EntityLayer.Interfaces;
using EntityLayer.Models;


namespace DataLayer.Data
{
    public class CartridgeData : IData
    {
        
        private readonly ShootingContext _context;
        private const string ENTITY_MISSING = "Cartridge does not exist.";

        public CartridgeData(ShootingContext context)
        {
            _context = context;
        }

        public async Task<List<IEntity>> Get()
        {
            return await _context.Cartridge.ToListAsync<IEntity>();
        }

        public async Task<IEntity> Get(int id)
        {
            return await _context.Cartridge.Where(i => i.Id == id).FirstOrDefaultAsync<IEntity>();
        }

        public async Task<bool> Update(int id, IEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Cartridge.Any(e => e.Id == id))
                {
                    throw new ArgumentException(ENTITY_MISSING);
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public async Task<IEntity> Add(IEntity entity)
        {
            _context.Cartridge.Add((Cartridge)entity);
            await _context.SaveChangesAsync();

            return (Cartridge)entity;
        }

        public async Task<IEntity> Delete(int id)
        {
            var entity = await _context.Cartridge.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException(ENTITY_MISSING);
            }

            _context.Cartridge.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}