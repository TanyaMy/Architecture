using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture.Data.Repositories.Interfaces
{

    public interface ICrudRepositoryBase<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetItemsAsync();
        Task<IEnumerable<TEntity>> GetItemsAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> convertQuery);

        Task<TEntity> GetItemAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> convertQuery);

        Task<TEntity> AddItemAsync(TEntity item);
        Task<TEntity> UpdateItemAsync(TEntity item);
        Task RemoveItemAsync(TEntity item);
    }

    public interface ICrudRepositoryBase<TEntity, TKey> : ICrudRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> GetItemAsync(TKey id);
        Task<TEntity> GetItemAsync(TKey id, Func<IQueryable<TEntity>, IQueryable<TEntity>> convertQuery);

        Task<bool> CheckIsItemExists(TKey id);

        Task RemoveItemAsync(TKey id);
    }
}
