using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace api
{
    public interface IGenericRepository <TEntity, TId> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(TId id);
        Task<TEntity> CreateAsync (TEntity entity);
        Task<TEntity?> DeleteAsync(TId id);
        Task<bool> ExistsAsync(TId id);
    }
}
