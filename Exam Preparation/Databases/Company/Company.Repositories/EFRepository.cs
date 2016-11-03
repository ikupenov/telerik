using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using Company.Repositories.Contracts;

namespace Company.Repositories
{
    public class CompanyRepository<T> : IRepository<T>
        where T : class
    {
        public CompanyRepository(DbContext context)
        {
            if (context == null)
            {
                string exMessage = "An instance of DbContext is required in order to use this repository";
                throw new ArgumentException(exMessage, nameof(context));
            }

            this.Context = context;
            this.DbSet = context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        protected DbContext Context { get; set; }

        public IEnumerable<T> Entities => this.DbSet;

        public IEnumerable<T> All()
        {
            return this.Entities;
        }

        public T GetById(object id)
        {
            return this.DbSet.Find(id);
        }

        public void Add(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Added;
        }

        public void AddMany(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                var entry = this.AttachIfDetached(entity);
                entry.State = EntityState.Added;
            }
        }

        public void Update(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            var entry = this.AttachIfDetached(entity);
            entry.State = EntityState.Deleted;
        }

        public void Detach(T entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Detached;
        }

        private DbEntityEntry AttachIfDetached(T entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            return entry;
        }
    }
}