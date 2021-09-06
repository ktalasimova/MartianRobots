using MartianRobots.Domain.Entities;
using MartianRobots.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MartianRobots.Persistence.Repositories
{
    public class Repository<T, TKey> : IRepository<T, TKey>
        where T : Entity<TKey>
    {
        protected readonly MartianRobotsDbContext _dbContext;

        protected DbSet<T> DbSet => _dbContext.Set<T>();

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _dbContext;
            }
        }

        public Repository(MartianRobotsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            if (entity.Id.Equals(default(TKey)))
            {
                entity.CreatedDateTime = DateTimeOffset.Now;
                await DbSet.AddAsync(entity, cancellationToken);
            }
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate = null)
        {
            return GetAll().FirstOrDefaultAsync(predicate);
        }

        public Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate = null)
        {
            return GetAll().SingleOrDefaultAsync(predicate);
        }

        public Task<List<T>> ToListAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includedEntities)
        {
            return GetQueryWithIncludes(includedEntities).ToListAsync();
        }

        private IQueryable<T> GetQueryWithIncludes(Expression<Func<T, object>>[] includedEntities)
        {
            var query = GetAll();

            foreach (var includedEntity in includedEntities)
            {
                query = query.Include(includedEntity);
            }

            return query;
        }
    }
}
