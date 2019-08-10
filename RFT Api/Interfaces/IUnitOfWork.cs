using RFT.Api.Interfaces.Base;
using RFT.Api.Repository;
using RFT.Api.Repository.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RFT.Api.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken ct = default);
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    }
}
