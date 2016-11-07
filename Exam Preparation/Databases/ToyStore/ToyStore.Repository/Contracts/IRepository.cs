using System.Collections.Generic;

namespace ToyStore.Repository.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> Entities { get; }

        int Count { get; }

        IEnumerable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}