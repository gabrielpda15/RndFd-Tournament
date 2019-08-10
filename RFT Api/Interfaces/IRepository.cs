using RFT.Api.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace RFT.Api.Repository
{
    public interface IRepository<TEntity> where TEntity : Models.Base.BaseEntity
    {
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, CancellationToken ct = default);
        Task<TEntity> GetSingle(Expression<Func<TEntity, bool>> filter = null, CancellationToken ct = default);
        Task<TEntity> GetById(int id, CancellationToken ct = default);
        Task<TEntity> Post(TEntity entity, User user, CancellationToken ct = default);
        Task<bool> Delete(int id, CancellationToken ct = default);
        Task<bool> Update(TEntity entity, User user, CancellationToken ct = default);
    }
}
