using MartianRobots.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MartianRobots.Domain.Repositories
{
    public interface IRepository<TEntity, TKey>
        where TEntity : Entity<TKey>
    {
        IUnitOfWork UnitOfWork { get; }

        IQueryable<TEntity> GetAll();

        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        void Delete(TEntity entity);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<List<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> predicate = null, params Expression<Func<TEntity, object>>[] includedEntities);
    }
}
