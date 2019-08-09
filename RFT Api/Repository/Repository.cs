using RFT.Api.Repository.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RFT.Api.Repository
{
    public class Repository
    {
        internal RFTContext Context { get; set; }

        public async Task CreateAsync<T>(T entity) where T : BaseEntity
        {
            var dbset = Context.Set<T>();
            dbset.Add(entity);
            await Context.SaveChangesAsync();
        }

        public IEnumerable<T> Query<T>(Expression<Func<T, bool>> filter) where T : BaseEntity
        {
            var query = (IQueryable<T>)Context.Set<T>();

            if (filter != null)
                query = query.Where(filter);

            return query.ToArray();
        }

        public async Task UpdateAsync<T>(T entity) where T : BaseEntity
        {

        }

        public async Task DeleteAsync<T>(int id) where T : BaseEntity
        {

        }
    }
}
