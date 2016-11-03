using System.Collections.Generic;

namespace Company.Repositories.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> Entities { get; }

        IEnumerable<T> All();

        T GetById(object id);

        void Add(T entity);

        void AddMany(IEnumerable<T> entities);

        void Update(T entity);

        void Delete(T entity);

        void Detach(T entity);
    }
}