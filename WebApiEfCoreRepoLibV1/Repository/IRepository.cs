using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApiEfCoreRepoLibV1.Repository
{
    public interface IRepository<TEntity, TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TKey id);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TKey id);
        TEntity Update(TEntity entity);
    }
}
