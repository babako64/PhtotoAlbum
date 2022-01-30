using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhotoAlbum.Application.Common.Interfaces.Infrastructure;
using PhotoAlbum.Domain.Common;
using PhotoAlbum.Infrastructure.Data;

namespace PhotoAlbum.Infrastructure.Repository
{
    public class RepositoryBase<TEntity> : IAsyncRepository<TEntity> where TEntity : EntityBase
    {
        private readonly PhotoAlbumDbContext _dbContext;

        private DbSet<TEntity> _dbSet;

        public RepositoryBase(PhotoAlbumDbContext dbContext)
        {
            _dbContext = dbContext;

            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync(int pageSize=10, int pageNumber=1)
        {
            var result = await _dbSet.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return result;
        }

        public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeString = null,
            bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, List<Expression<Func<TEntity, object>>> includes = null, bool disableTracking = true)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
           return await _dbSet.FirstOrDefaultAsync(predicate);
        }
    }
}
