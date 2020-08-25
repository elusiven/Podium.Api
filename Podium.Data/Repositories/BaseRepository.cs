using System;
using Microsoft.EntityFrameworkCore;
using Podium.Data.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Podium.Data.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly PodiumDbContext _databaseContext;
        private DbSet<T> _dbSet;

        public BaseRepository(
            PodiumDbContext databaseContext)
        {
            _databaseContext = databaseContext;
            _dbSet = _databaseContext.Set<T>();
        }

        public virtual async Task<T> GetAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _dbSet.Where(predicate);
            return query;
        }

        public virtual async Task<T> CreateAsync(T entity)
        {
            var result = await _dbSet.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            var result = _dbSet.Update(entity);
            await _databaseContext.SaveChangesAsync();
            return result.Entity;
        }

        public virtual async Task<bool> DeleteAsync(object id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            return await _databaseContext.SaveChangesAsync() > 0;
        }
    }
}