using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiTemplateV1.Data;
using WebApiTemplateV1.Models;

namespace WebApiTemplateV1.Managers
{
    /// <summary>
    /// Manager class/Repository.
    /// </summary>
    public class ItemsManager
    {
        private readonly ApplicationDbContext _context;

        public ItemsManager(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        /// <summary>
        /// Get all entities from the repository.
        /// </summary>
        /// <returns>IEnumerable of Item</returns>
        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Find one entity from the repository by its Id.
        /// </summary>
        /// <returns>The instance of Item with the passed ID or null if not found.</returns>
        public async Task<Item> GetByIdAsync(int id)
        {
            return await _context.Items.AsNoTracking().FirstOrDefaultAsync(e=>e.Id==id);
        }

        public async Task<Item> AddAsync(Item entity)
        {
            var result = await _context.Items.AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        /// <summary>
        /// Delete an entity from the database.
        /// </summary>
        /// <returns>True if an entity was deleted, false if not.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Items.FindAsync(id);
            if (entity is not null)
            {
                _context.Items.Remove(entity);
                var result = await _context.SaveChangesAsync();
                return result > 0;
            }
            return false;
        }

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <returns>Entity with new state or null if not found.</returns>
        public async Task<Item> UpdateAsync(int id, Item updatedEntity)
        {
            var entity = await _context.Items.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            if (entity is not null)
            {
                var result = _context.Items.Update(updatedEntity);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }
    }
}
