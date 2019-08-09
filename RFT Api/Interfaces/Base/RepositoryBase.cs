using Microsoft.EntityFrameworkCore;
using RFT.Api.Repository;
using RFT.Api.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace RFT.Api.Interfaces.Base
{
    public abstract class RepositoryBase<TEntity, TContext> : IRepository<TEntity> 
        where TEntity : Repository.Models.Base.BaseEntity
        where TContext : DbContext
    {
        public DbSet<TEntity> Entities { get; }

        public RepositoryBase(TContext context)
        {
            Entities = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, CancellationToken ct = default)
        {
            return await Task.Run(() =>
            {
                var query = (IQueryable<TEntity>)Entities;

                if (filter != null)
                    query = query.Where(filter);

                return query.ToArray();
            }, ct);
        }

        public async Task<TEntity> GetById(int id, CancellationToken ct = default)
        {
            return await Entities.SingleAsync(x => x.Id == id, ct);
        }

        public async Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter, CancellationToken ct = default)
        {
            return await Entities.SingleOrDefaultAsync(filter, ct);
        }

        public async Task<TEntity> Post(TEntity entity, User user, CancellationToken ct = default)
        {
            entity.EditionDate = DateTime.Now;
            entity.EditionUser = user.Username;
            return (await Task.FromResult(Entities.Add(entity))).Entity;
        }

        public async Task<bool> Delete(int id, CancellationToken ct = default)
        {
            try
            {
                var toRemove = await Entities.SingleAsync(x => x.Id == id, ct);
                Entities.Remove(toRemove);
                return true;
            }
            catch { return false; }
        }
    }
}
