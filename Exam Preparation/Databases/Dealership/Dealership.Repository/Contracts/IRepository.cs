using System.Collections.Generic;

namespace Dealership.Repository.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> Entities { get; }

        IEnumerable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}