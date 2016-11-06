using System.Collections.Generic;
using System.Data.Entity;

using System.Data.Entity.Infrastructure;
using Dealership.Repository.Contracts;

namespace Dealership.Repository
{
    public class EFDealershipRepository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> dbSet;

        public EFDealershipRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public IEnumerable<T> Entities => this.dbSet;

        public IEnumerable<T> All()
        {
            return this.Entities;
        }

        public T GetById(object id)
        {
            return this.dbSet.Find(id);
        }

        public void Add(T entity)
        {
            this.dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            DbEntityEntry<T> entry = this.dbContext.Entry(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            this.dbSet.Remove(entity);
        }
    }
}