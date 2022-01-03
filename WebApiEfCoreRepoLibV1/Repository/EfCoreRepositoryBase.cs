using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApiEfCoreRepoLibV1.Repository
{
    public class EfCoreRepositoryBase<TEntity, TKey, TContext> : IRepository<TEntity, TKey>
        where TContext : DbContext
        where TEntity : class
    {
        protected readonly TContext _context;

        public EfCoreRepositoryBase(TContext ctx)
        {
            _context = ctx;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var result = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task<TEntity> DeleteAsync(TKey id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity is not null)
            {
                var result = _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        /// <summary>
        /// Get all TEntities from the repository.
        /// </summary>
        /// <returns>IEnumerable of TEntity</returns>
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Find one TEntitiy from the repository by its ID.
        /// </summary>
        /// <returns>The instance of TEntity with the passed ID or null if not found.</returns>
        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity is not null) return entity;
            return null;
        }

        public virtual TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
