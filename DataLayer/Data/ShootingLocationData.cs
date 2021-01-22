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
    public class ShootingLocationData : IData
    {
        
        private readonly ShootingContext _context;
        private const string ENTITY_MISSING = "Shooting location does not exist.";

        public ShootingLocationData(ShootingContext context)
        {
            _context = context;
        }

        public async Task<List<IEntity>> Get()
        {
            return await _context.ShootingLocation.ToListAsync<IEntity>();
        }

        public async Task<IEntity> Get(int id)
        {
            return await _context.ShootingLocation.Where(i => i.Id == id).FirstOrDefaultAsync<IEntity>();
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
                if (!_context.ShootingLocation.Any(e => e.Id == id))
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
            _context.ShootingLocation.Add((ShootingLocation)entity);
            await _context.SaveChangesAsync();

            return (ShootingLocation)entity;
        }

        public async Task<IEntity> Delete(int id)
        {
            var entity = await _context.ShootingLocation.FindAsync(id);
            if (entity == null)
            {
                throw new ArgumentException(ENTITY_MISSING);
            }

            _context.ShootingLocation.Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}