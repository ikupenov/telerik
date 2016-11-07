using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToyStore.Repository.Contracts;

namespace ToyStore.Repository
{
    public class EFRepository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext dbContext;
        private readonly DbSet<T> dbSet;

        public EFRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public IEnumerable<T> Entities => this.dbSet;

        public int Count => this.Entities.ToList().Count;

        public IEnumerable<T> All() => this.Entities;

        public T GetById(object id) => this.dbSet.Find(id);

        public void Add(T entity) => this.dbSet.Add(entity);

        public void Delete(T entity) => this.dbSet.Remove(entity);

        public void Update(T entity)
        {
            var entry = this.dbContext.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}