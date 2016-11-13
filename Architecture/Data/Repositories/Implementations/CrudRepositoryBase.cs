using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Architecture.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Data.Repositories.Implementations
{
    public abstract class CrudRepositoryBase<TEntity> : ICrudRepositoryBase<TEntity> where TEntity : class
    {
        protected CrudRepositoryBase(
            AppDbContext dbContext,
            DbSet<TEntity> dbSet)
        {
            DbContext = dbContext;
            DbSet = dbSet;
        }

        public virtual async Task<IEnumerable<TEntity>> GetItemsAsync()
        {
            return await Queryable.ToArrayAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetItemsAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> convertQuery)
        {
            return await convertQuery(Queryable).ToArrayAsync();
        }

        public virtual async Task<TEntity> GetItemAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> convertQuery)
        {
            return await convertQuery(Queryable).SingleOrDefaultAsync();
        }

        public virtual async Task<TEntity> AddItemAsync(TEntity item)
        {
            DbSet.Add(item);
            await SaveChangesAsync();
            return item;
        }
        public virtual async Task<TEntity> UpdateItemAsync(TEntity item)
        {
            DbSet.Update(item);
            await SaveChangesAsync();
            return item;
        }

        public virtual async Task RemoveItemAsync(TEntity item)
        {
            DbSet.Remove(item);
            await SaveChangesAsync();
        }

        protected virtual AppDbContext DbContext { get; }

        protected virtual DbSet<TEntity> DbSet { get; }

        protected virtual IQueryable<TEntity> Queryable => DbSet;

        protected Task SaveChangesAsync() => DbContext.SaveChangesAsync();
    }

    public abstract class CrudRepositoryBase<TEntity, TKey> : CrudRepositoryBase<TEntity>, ICrudRepositoryBase<TEntity, TKey> where TEntity : class
    {
        protected CrudRepositoryBase(AppDbContext dbContext, DbSet<TEntity> dbSet)
            : base(dbContext, dbSet)
        {
        }

        public virtual Task<TEntity> GetItemAsync(TKey id)
        {
            return Queryable.SingleOrDefaultAsync(KeyPredicate(id));
        }

        public virtual Task<TEntity> GetItemAsync(TKey id, Func<IQueryable<TEntity>, IQueryable<TEntity>> convertQuery)
        {
            return convertQuery(Queryable).SingleOrDefaultAsync(KeyPredicate(id));
        }

        public virtual Task<bool> CheckIsItemExists(TKey id)
        {
            return Queryable.AnyAsync(KeyPredicate(id));
        }

        public async Task RemoveItemAsync(TKey id)
        {
            var item = await GetItemAsync(id);
            await RemoveItemAsync(item);
        }

        protected abstract Expression<Func<TEntity, bool>> KeyPredicate(TKey id);
    }
}