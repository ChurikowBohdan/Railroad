using Microsoft.EntityFrameworkCore;
using Railroad.DAL.Data;
using Railroad.DAL.Entities;
using Railroad.DAL.Interfaces;
using System.Collections.Generic;

namespace Railroad.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly RailroadDbContext _dBContext;

        public Repository(RailroadDbContext dbContext)
        {
            _dBContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity)
        {
            if (entity != null)
            {
                await _dbSet.AddAsync(entity);
            }
        }

        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            if (id > 0)
            {
                var entity = await GetByIdAsync(id);

                if (entity != null)
                {
                    Delete(entity);
                }
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Update(TEntity entity)
        {
            if (entity != null)
            {
                _dbSet.Update(entity);
            }
        }
    }
}
